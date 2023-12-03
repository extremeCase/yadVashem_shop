using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yadVashemDal;

namespace yadVashemBL
{
    public class AvailablePlaceBL : IAvailablePlaceBL
    {
        IAvailablePlaceDal _availablePlaceDal;
        public AvailablePlaceBL(IAvailablePlaceDal availablePlaceDal)
        {
            _availablePlaceDal = availablePlaceDal;
        }
        public async Task<List<AvailablePlacesHour>> GetAvailablePlaceHoursByPartOfDay(int partOfDay)
        {
            return await _availablePlaceDal.GetAvailablePlaceHoursByPartOfDay(partOfDay);
        }

        public async Task<int> GetSumPlaceInThisDay()
        {
            return await _availablePlaceDal.GetSumPlaceInThisDay();
        }
    }
}
