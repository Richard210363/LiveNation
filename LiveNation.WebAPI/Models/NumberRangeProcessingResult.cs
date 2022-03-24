namespace LiveNation.WebAPI.Models
{
    public class NumberRangeProcessingResult
    {
        public string Result { get; set; }

        public NumberRangeProcessingResultSummery Summary { get; set; }
    }

    public class NumberRangeProcessingResultSummery
    {
        public string Live { get; set; }

        public string Nation { get; set; }

        public string LiveNation { get; set; }

        public string Integer { get; set; }
    }
}
