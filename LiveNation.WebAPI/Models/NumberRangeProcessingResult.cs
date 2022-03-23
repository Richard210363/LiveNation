namespace LiveNation.WebAPI.Models
{
    public struct NumberRangeProcessingResult
    {
        public string Result { get; set; }

        public NumberRangeProcessingResultSummery Summary { get; set; }
    }

    public struct NumberRangeProcessingResultSummery
    {
        public string Live { get; set; }

        public string Nation { get; set; }

        public string LiveNation { get; set; }

        public string Integer { get; set; }
    }
}
