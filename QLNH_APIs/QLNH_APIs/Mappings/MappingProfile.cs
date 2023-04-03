using AutoMapper;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;

namespace QLNH_APIs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                      .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<Role, RoleDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser));

            CreateMap<Guest, GuestDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
              .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
              .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
              .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser));

            CreateMap<Status, StatusDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
             .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
             .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
             .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
            .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Unit, UnitDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
             .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
             .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
             .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser));

            CreateMap<Size, SizeDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
            .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
            .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
            .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Location, LocationDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
            .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
            .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<GuestTable, GuestTableDTO>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
         .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
         .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
         .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
         .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
         .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Category, CategoryDTO>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
          .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
          .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
          .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
          .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
          .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Food, FoodDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
        .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
        .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
        .ForMember(dest => dest.ItemImage, opt => opt.MapFrom(src => src.ItemImage))
        .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
        .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));


            CreateMap<ItemImage, ItemImageDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
        .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
        .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser))
        .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
        .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Item, ItemDTO>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
       .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
       .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
         .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.Food))
          .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size));


        CreateMap<OrderItem, OrderItemDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
        .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalePrice))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
        .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created));




        }
    }
}