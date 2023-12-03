using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using yadVashemBL;

namespace yadVashemServer
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]

    public class availablePlaceController : ControllerBase
    {
       private IAvailablePlaceBL _availablePlaceBL;
        public availablePlaceController(IAvailablePlaceBL availablePlaceBL)
        {
            _availablePlaceBL = availablePlaceBL;
        }

     
        [HttpGet("GetSumPlaceInThisDay")]
        public async Task<int> GetSumPlaceInThisDay()
        {
            return await _availablePlaceBL.GetSumPlaceInThisDay();
        }

        [HttpGet("GetHourByPart/{partOfDay}")]
        public async Task<List<AvailablePlacesHour>> GetHourByPart(string partOfDay)
        {
            try
            {
                int ipartOfDay = int.Parse(partOfDay);
                return await _availablePlaceBL.GetAvailablePlaceHoursByPartOfDay(ipartOfDay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
