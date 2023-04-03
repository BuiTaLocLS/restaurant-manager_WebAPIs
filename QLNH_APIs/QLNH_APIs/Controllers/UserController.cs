using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(MyDBContext context, IMapper mapper, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = optionsMonitor.CurrentValue;

        }


        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IOrderedEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var data = await _context.UserDBSet
                      .Where(r => !r.Deleted)
                    .Select(d => new User
                {
                    Id = d.Id,
                    DisplayName = d.DisplayName,
                    UserName = d.UserName,
                    Description = d.Description,
                    Created = d.Created,
                    Email = d.Email,
                    Updated = d.Updated,
                    OffDuty = d.OffDuty,
                    Role = d.Role,
                    CreatedUser = _context.UserDBSet
                                            .Where(c => c.Id == d.CreatedUserId)
                                           
                                            .Select(d => new User {
                                                Id = d.Id,
                                                UserName = d.UserName,
                                                Description = d.Description,
                                                Created = d.Created,
                                                Updated = d.Updated,
                                                OffDuty = d.OffDuty,
                                                Role = d.Role,
                                            }).ToList(),
                    UpdatedUser = _context.UserDBSet
                                            .Where(c => c.Id == d.UpdatedUserId)
                                            .Select(d => new User
                                            {
                                                Id = d.Id,
                                                UserName = d.UserName,
                                                Description = d.Description,
                                                Created = d.Created,
                                                Updated = d.Updated,
                                                OffDuty = d.OffDuty,
                                                Role = d.Role,
                                            }).ToList(),

                })

                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<UserDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Not good");
            }
        }
        [Authorize(Policy = "ManageOnlyPolicy")]
        [HttpPost("Create")]
        public IActionResult Create(CreateUserModel createUserModel)
        {
            try
            {
                var role = _context.RoleDBSet.Find(createUserModel.RoleId);

                var User = new User();

                User.UserName = createUserModel.UserName;
                User.DisplayName = createUserModel.DisplayName;        
                User.Password= createUserModel.Password;
                User.Email= createUserModel.Email;
                User.Role = role;

                User.CreatedUserId = createUserModel.CreatedUserId;
                User.UpdatedUserId = createUserModel.UpdatedUserId; ;

                User.Updated = DateTime.Now;
                User.Created = DateTime.Now;

                _context.UserDBSet.Add(User);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = User
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(User user)
        {
            try
            {
                var role = _context.RoleDBSet.Find(user.RoleId);

                var User = _context.UserDBSet.Find(user.Id);

                User.UserName = user.UserName;
                User.DisplayName = user.DisplayName;
                User.Email = user.Email;
                User.Role = role;
                User.Description = user.Description;

                User.Deleted = user.Deleted;
                User.OffDuty = user.OffDuty;


                User.UpdatedUserId = user.UpdatedUserId;
                User.CreatedUserId = user.CreatedUserId;

                User.Updated = DateTime.Now;
                User.Created = DateTime.Now;

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = User
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Validate(LoginModel model)
        {
            var user = _context.UserDBSet.SingleOrDefault(p => p.UserName == model.UserName && p.Password == model.Password);
            if (user == null) //Khong dung
            {
                return Ok(new ApiRespone
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            //cap token
            var token = await GenerateToken(user);

            return Ok(new ApiRespone
            {
                Success = true,
                Message = "Authenticate success",
                Data = token
            });
        }

        private async Task<TokenModel> GenerateToken(User nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var role = _context.RoleDBSet.Find(nguoiDung.RoleId);
           
            var roleName = role.Name;

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoiDung.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, nguoiDung.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, nguoiDung.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", nguoiDung.DisplayName),
                    new Claim("Id", nguoiDung.Id.ToString()),

                    //roles
                     new Claim("TokenId", Guid.NewGuid().ToString()),
                     new Claim(ClaimTypes.Role, roleName.ToString()),

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenrateRefreshToken();


            //Luu database
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                UserId = nguoiDung.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddHours(1)
            };


            await _context.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return new Models.TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenrateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        [HttpPost("RenewToken")]
        public async Task<IActionResult> RenewToken(TokenModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tu cap token
                ValidateIssuer = false,
                ValidateAudience = false,

                //Ky vao token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false, //Ko kiem tra token het han
            };
            try
            {
                //checked 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);

                //check 2: check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return Ok(new ApiRespone
                        {
                            Success = false,
                            Message = "Invalid token"
                        });
                    }
                }

                //check 3: Check accessToken exprie?
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new ApiRespone
                    {
                        Success = false,
                        Message = "Access token has not yet expired"
                    });
                }

                //check 4: Check refreshtoken exist in DB
                var storedToken = _context.RefreshTokenDBSet.FirstOrDefault(x => x.Token == model.RefreshToken);
                
                if (storedToken == null)
                {
                    return Ok(new ApiRespone
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    });
                }

                //check 5: check refreshtoken is used/revoked?
                if (storedToken.IsUsed)
                {
                    return Ok(new ApiRespone
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    });
                }

                if (storedToken.IsRevoked)
                {
                    return Ok(new ApiRespone
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    });
                }

                //check 6: AccessToken id == JwtId in RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return Ok(new ApiRespone
                    {
                        Success = false,
                        Message = "Token does not match"
                    });
                }

                //Update token is used
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                _context.Update(storedToken);
                await _context.SaveChangesAsync();

                //create new token
                var user = await _context.UserDBSet.SingleOrDefaultAsync(nd => nd.Id == storedToken.UserId);
                var token = await GenerateToken(user);

                return Ok(new ApiRespone
                {
                    Success = true,
                    Message = "Renew token success",
                    Data = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiRespone
                {
                    Success = false,
                    Message = "Something went wrong"
                });
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}
