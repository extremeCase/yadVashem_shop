using Entities;

namespace yadVashemBL
{
    public interface IAvailablePlaceBL
    {
        Task<List<AvailablePlacesHour>> GetAvailablePlaceHoursByPartOfDay(int partOfDay);
        Task<int> GetSumPlaceInThisDay();
    }
}