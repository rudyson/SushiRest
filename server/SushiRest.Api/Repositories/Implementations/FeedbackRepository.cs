using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Repositories.Implementations;

public class FeedbackRepository : IFeedbackRepository
{
	private readonly SushiRestDbContext _context;
	private readonly IMapper _mapper;

	public FeedbackRepository(SushiRestDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(int? items)
	{
		// Fetching
		var feedbacksFetched = await _context.Reviews!
			.ToListAsync();
		
		// Shuffling
		var feedbacksShuffled = feedbacksFetched.OrderBy(f => f.Id = Guid.NewGuid());
		
		// Mapping
		var feedbacksMapped = _mapper.Map<List<Review>,List<FeedbackDto>>(feedbacksShuffled.ToList());
		
		// Taking
		var result = items.HasValue ? feedbacksMapped.Take(items.Value) : feedbacksMapped;
		
		return result;
	}
}