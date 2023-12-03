using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace yadVashemDal
{
    public class AvailablePlaceDal : IAvailablePlaceDal
    {
        private HourInPartOfDay[] _hourInPartOfDay;


        public AvailablePlaceDal()
        {
            _hourInPartOfDay = new[]
               {
                    new HourInPartOfDay {  StartHour = "8:30", EndHour = "12:00" },
                    new HourInPartOfDay {  StartHour = "12:00", EndHour = "15:00" },
                    new HourInPartOfDay { StartHour = "15:00", EndHour = "15:50" },
                };
        }
        public async Task<List<AvailablePlacesHour>> GetAvailablePlaceHoursByPartOfDay(int partOfDay)
        {
            try
            {
                List<AvailablePlacesHour> availablePlacesHour = await ReadFromPlaceFile();
                List<AvailablePlacesHour> subArray = GetHourByPartDay(partOfDay, availablePlacesHour);
                return subArray;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetSumPlaceInThisDay()
        {

            try
            {
                List<AvailablePlacesHour> availablePlacesHour = await ReadFromPlaceFile();
                int sumPlace = availablePlacesHour.Sum(x => x.availablePlaces);
                return sumPlace;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<AvailablePlacesHour>> ReadFromPlaceFile()
        {

            try
            {
                using (StreamReader reader = new StreamReader("../availablePlacesList.json"))
                {
                    string _availablePlacesHour;
                    List<AvailablePlacesHour> availablePlacesHour;


                    _availablePlacesHour = await reader.ReadToEndAsync();
                    if (_availablePlacesHour != null)
                    {
                        availablePlacesHour = JsonConvert.DeserializeObject<List<AvailablePlacesHour>>(_availablePlacesHour);
                        return availablePlacesHour;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<AvailablePlacesHour> GetHourByPartDay(int partOfDay, List<AvailablePlacesHour> availablePlacesHour)
        {
            try
            {
                HourInPartOfDay hourInPartOfDay = _hourInPartOfDay[partOfDay - 1];
                int indexSt = availablePlacesHour.FindIndex(hour => hour.StartTime == hourInPartOfDay.StartHour);
                int indexEn = availablePlacesHour.FindIndex(hour => hour.StartTime == hourInPartOfDay.EndHour);


                List<AvailablePlacesHour> subArray = availablePlacesHour.GetRange(indexSt, indexEn - indexSt);
                return subArray;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
