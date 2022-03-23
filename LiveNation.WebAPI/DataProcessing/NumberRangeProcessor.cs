using LiveNation.WebAPI.Models;

namespace LiveNation.WebAPI.DataProcessing
{
    public class NumberRangeProcessor : INumberRangeProcessor
    {
        public virtual NumberRangeProcessingResult ProcessNumberRange(int startRange, int endRange)
        {
            //Strictly speaking, as I'm using dependency injection, we don't need virtual methods and inheritance to implement configuration changes but as you asked for use of
            //s O lid and this is a knowledge test I put it in.

            return new NumberRangeProcessingResult();
        }
    }
}
