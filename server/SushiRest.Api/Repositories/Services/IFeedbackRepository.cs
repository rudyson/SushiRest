using SushiRest.Api.Dto;

namespace SushiRest.Api.Repositories.Services;

public interface IFeedbackRepository
{
	/// <summary>
	/// Returns shuffled feedbacks about service leaved by users
	/// </summary>
	/// <param name="items">Amount of feedbacks to display</param>
	/// <returns></returns>
	public Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(int? items);
}