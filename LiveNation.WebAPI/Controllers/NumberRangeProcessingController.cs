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
        public IActionResult Get(int startRange, int endRange)
        {
            if (endRange < startRange)
            {
                return BadRequest(new { message = "Please make endRange larger than or equal to startRange." });

            }

            //return _numberRangeProcessor.ProcessNumberRange(startRange, endRange);
            return Ok(_numberRangeProcessor.ProcessNumberRange(startRange, endRange));
        }
    }
}
