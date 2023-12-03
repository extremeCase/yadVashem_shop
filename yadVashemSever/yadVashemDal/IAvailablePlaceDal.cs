using Entities;

namespace yadVashemDal
{
    public interface IAvailablePlaceDal
    {
        Task<List<AvailablePlacesHour>> GetAvailablePlaceHoursByPartOfDay(int partOfDay);
        Task<int> GetSumPlaceInThisDay();
    }
}