namespace AutotraderFeed.Models
{
    public class Listing
    {
        public int id { get; set; }
        public Image images { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string ownerName { get; set; }
        public string[] packages { get; set; }
        public PricingDetail pricingDetail { get; set; }
        public Specifications specifications { get; set; }
        public string[] style { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string trim { get; set; }
        public string vin { get; set; }
        public string year { get; set; }
        public string zip { get; set; }
    }

    public class Specifications
    {
        public string interiorColor { get; set; }
        public string transmission { get; set; }
        public string color { get; set; }
        public string mpg { get; set; }
        public string engine { get; set; }
        public string driveType { get; set; }
        public string mileage { get; set; }

    }

    public class LabelValueTuple
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class PricingDetail 
    {
        public string derived { get; set; }
        public string first { get; set; }
        public string primary { get; set; }
        public string  salePrice { get; set; }
    }

    public class Image 
    {
        public ImageSource[] sources { get; set; }
    }

    public class ImageSource 
    {
        public string alt { get; set; }
        public string source { get; set; }
        public string title { get; set; }
    }
}