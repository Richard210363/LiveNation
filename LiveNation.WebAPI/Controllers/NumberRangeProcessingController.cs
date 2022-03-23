using Microsoft.AspNetCore.Mvc;
using LiveNation.WebAPI.DataProcessing;
using LiveNation.WebAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace LiveNation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberRangeProcessingController : ControllerBase
    {

        private readonly INumberRangeProcessor _numberRangeProcessor;
        private readonly IMemoryCache _memoryCache;


        public NumberRangeProcessingController(INumberRangeProcessor numberRangeProcessor)
        //public NumberRangeProcessingController(INumberRangeProcessor numberRangeProcessor, IMemoryCache memoryCache)
        {


            this._numberRangeProcessor = numberRangeProcessor;
            //this._memoryCache = memoryCache;
        }

        [HttpGet]
        public NumberRangeProcessingResult Get(int startRange, int endRange)
        {
            if(endRange < startRange)
            {
                return new NumberRangeProcessingResult
                {
                    Result = "Please make endRange larger than or equal to startRange."
                };

            }

            return _numberRangeProcessor.ProcessNumberRange(startRange, endRange);
        }
    }
}
