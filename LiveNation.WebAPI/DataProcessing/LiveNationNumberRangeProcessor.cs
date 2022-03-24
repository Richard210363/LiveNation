using System.Collections.Generic;
using LiveNation.WebAPI.Models;

namespace LiveNation.WebAPI.DataProcessing
{
    public class LiveNationNumberRangeProcessor : NumberRangeProcessor
    {
        public override NumberRangeProcessingResult ProcessNumberRange(int startRange, int endRange)
        {
            NumberRangeProcessingResult numberRangeProcessingResult = new NumberRangeProcessingResult();
            NumberRangeProcessingResultSummery numberRangeProcessingResultSummery = new NumberRangeProcessingResultSummery();

            List<string> result = new List<string>();

            int live=0;
            int nation = 0;
            int liveNation = 0;
            int integerNumber = 0;

            for (int currentValue = startRange; currentValue <= endRange; currentValue++)
            {
                if (currentValue%3==0 & currentValue % 5 == 0)
                {
                    result.Add("LiveNation");
                    liveNation++;
                    continue;
                }

                if (currentValue % 3 == 0)
                {
                    result.Add("Live");
                    live++;
                    continue;
                }

                if (currentValue % 5 == 0)
                {
                    result.Add("Nation");
                    nation++;
                    continue;
                }

                result.Add(currentValue.ToString());
                integerNumber++;

            }

            numberRangeProcessingResult.Result = string.Join(" ", result);

            numberRangeProcessingResultSummery.Live = live.ToString();
            numberRangeProcessingResultSummery.Nation = nation.ToString();
            numberRangeProcessingResultSummery.LiveNation = liveNation.ToString();
            numberRangeProcessingResultSummery.Integer = integerNumber.ToString();

            numberRangeProcessingResult.Summary = numberRangeProcessingResultSummery;

            return numberRangeProcessingResult;
        }
    }
}
