using AutoMapper;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;

namespace SushiRest.Api.Tools;

public class AutomapperProfile : Profile
{
	public AutomapperProfile()
	{
		#region Product in menu

		CreateMap<Product, ProductMenuDto>()
			.ForMember(
				dest => dest.Id,
				opt => opt
					.MapFrom(src => src.Id)
			)
			.ForMember(
				dest => dest.Title,
				opt => opt
					.MapFrom(src => src.Title)
			)
			.ForMember(
				dest => dest.Description,
				opt => opt
					.MapFrom(src => src.Description)
			)
			.ForMember(
				dest => dest.Cover,
				opt => opt
					.MapFrom(src => src.DefaultThumbnail)
			)
			.ForMember(
				dest => dest.Rating,
				opt => opt
					.MapFrom(src => src.Rates!
						.Select(r => r.Value)
						.DefaultIfEmpty(0)
						.Average())
			)
			.ForMember(
				dest => dest.Pieces,
				opt => opt
					.MapFrom(src => src.Pieces)
			)
			.ForMember(
				dest => dest.Weight,
				opt => opt
					.MapFrom(src => src.Weight)
			)
			.ForMember(
				dest => dest.Price,
				opt => opt
					.MapFrom(src => src.Price)
			);

		#endregion

		#region Category in menu

		CreateMap<Category, CategoryDto>()
			.ForMember(
				dest => dest.Id,
				opt => opt
					.MapFrom(src => src.Id)
			)
			.ForMember(
				dest => dest.Name,
				opt => opt
					.MapFrom(src => src.Name)
			);

		#endregion
	}
}