using AutoMapper;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;

namespace SushiRest.Api.Tools;

public class AutomapperProfile : Profile
{
	public AutomapperProfile()
	{
		#region Product in top (recommendations)

		CreateMap<Product, ProductTopDto>(MemberList.Destination)
			.ForMember(
				dest => dest.Rating,
				opt => opt
					.MapFrom(src => src.Rates!
						.Select(r => r.Value)
						.DefaultIfEmpty(0)
						.Average())
			)
			.ForMember(
				dest => dest.Cover,
				opt => opt
					.MapFrom(src => src.TopPosThumbnail)
			);

		#endregion
		
		#region Product in menu

		CreateMap<Product, ProductMenuDto>(MemberList.Destination)
			.ForMember(
				dest => dest.Rating,
				opt => opt
					.MapFrom(src => src.Rates!
						.Select(r => r.Value)
						.DefaultIfEmpty(0)
						.Average())
			)
			.ForMember(
				dest => dest.Cover,
				opt => opt
					.MapFrom(src => src.DefaultThumbnail)
			);
		#endregion

		#region Category in menu

		CreateMap<Category, CategoryDto>(MemberList.Destination)
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

		#region Feedback (Review)

		CreateMap<Review, FeedbackDto>(MemberList.Destination)
			.ForMember(
				dest => dest.FullName,
				opt => opt
					.MapFrom(src => $"{src.ReviewedBy!.FirstName} {src.ReviewedBy!.LastName}")
			)/*
			.ForMember(
				dest => dest.Rating,
				opt => opt
					.MapFrom(src => src.Rate)
			)
			.ForMember(
				dest => dest.Description,
				opt => opt
					.MapFrom(src => src.Description)
			)*/;

		#endregion
	}
}