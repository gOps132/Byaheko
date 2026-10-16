namespace Midterm.Models;

public class TourPackage
{
    public string Slug { get; set; } = "";
    public string Title { get; set; } = "";
    public string Destination { get; set; } = "";
    public string Category { get; set; } = "";
    public int DurationDays { get; set; }
    public int DurationNights => DurationDays - 1;
    public decimal PricePerPerson { get; set; }
    public double Rating { get; set; }
    public string ImageUrl { get; set; } = "";
    public List<string> GalleryUrls { get; set; } = new();
    public string Summary { get; set; } = "";
    public string DreamLine { get; set; } = "";
    public List<string> Highlights { get; set; } = new();
    public List<string> Inclusions { get; set; } = new();
    public List<string> Exclusions { get; set; } = new();
    public List<string> Itinerary { get; set; } = new();

    public string DurationLabel => $"{DurationDays}D{DurationNights}N";
}
