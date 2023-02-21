namespace Domain.SupportModels
{
    public class NBPConvertModel
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public List<Rate> rates { get; set; }
    }

    public class Rate
    {
        public string no { get; set; }
        public DateOnly effectiveDate { get; set; }
        public double mid { get; set; }
    }
}
