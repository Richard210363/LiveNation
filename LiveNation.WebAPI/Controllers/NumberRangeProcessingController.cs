using Microsoft.AspNetCore.Mvc;
using LiveNation.WebAPI.DataProcessing;
using LiveNation.WebAPI.Models;

namespace LiveNation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberRangeProcessingController : ControllerBase
    {

        private readonly INumberRangeProcessor _numberRangeProcessor;
        
        public NumberRangeProcessingController(INumberRangeProcessor numberRangeProcessor)
        {
            this._numberRangeProcessor = numberRangeProcessor;
        }

        [HttpGet]
        public NumberRangeProcessingResult Get(int startRange, int endRange)
        {
            return _numberRangeProcessor.ProcessNumberRange(startRange, endRange);
        }
    }
}
