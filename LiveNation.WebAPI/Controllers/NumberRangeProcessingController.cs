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
        private IMemoryCache _memoryCache;


        public NumberRangeProcessingController(INumberRangeProcessor numberRangeProcessor, IMemoryCache memoryCache)
        {


            this._numberRangeProcessor = numberRangeProcessor;
            this._memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Get(int startRange, int endRange)
        {
            if (endRange < startRange)
            {
                return BadRequest(new {message = "Please make endRange larger than or equal to startRange."});
            }

            string cacheKey = startRange.ToString() + "__" + endRange.ToString();

            if (_memoryCache.TryGetValue(cacheKey, out NumberRangeProcessingResult numberRangeProcessingResult))
            {
                return Ok(numberRangeProcessingResult);
            }

            numberRangeProcessingResult = _numberRangeProcessor.ProcessNumberRange(startRange, endRange);

            _memoryCache.Set(cacheKey, numberRangeProcessingResult);

            return Ok(numberRangeProcessingResult);
        }
    }
}
