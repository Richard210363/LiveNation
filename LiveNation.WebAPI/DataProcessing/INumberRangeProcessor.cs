using LiveNation.WebAPI.Models;

namespace LiveNation.WebAPI.DataProcessing
{
    public interface INumberRangeProcessor
    {
        NumberRangeProcessingResult ProcessNumberRange(int startRange, int endRange);
    }
}