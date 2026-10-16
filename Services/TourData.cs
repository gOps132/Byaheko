using Midterm.Models;

namespace Midterm.Services;

public static class TourData
{
    private const string U = "https://images.unsplash.com/{0}?auto=format&fit=crop&w=1200&q=80";

    public static List<TourPackage> GetPackages() => new()
    {
        new TourPackage
        {
            Slug = "el-nido-island-escape",
            Title = "El Nido Island Escape",
            Destination = "El Nido, Palawan",
            Category = "Island",
            DurationDays = 4,
            PricePerPerson = 18500m,
            Rating = 4.9,
            ImageUrl = string.Format(U, "photo-1559494007-9f5847c49d94"),
            GalleryUrls = new()
            {
                string.Format(U, "photo-1559494007-9f5847c49d94"),
                string.Format(U, "photo-1518509562904-e7ef99cdcc86"),
                string.Format(U, "photo-1544551763-46a013bb70d5"),
            },
            Summary = "Karst lagoons, hidden beaches, and water so clear the boats look airborne.",
            DreamLine = "Paddle the Big Lagoon at first light.",
            Highlights = new() { "Big & Small Lagoon tour", "Nacpan Beach sunset", "Snorkel with sea turtles" },
            Inclusions = new() { "3 nights beachfront stay", "Daily breakfast", "Licensed island guides", "All lagoon entrance fees" },
            Exclusions = new() { "Flights to El Nido", "Lunch on tour days", "Travel insurance" },
            Itinerary = new()
            {
                "Day 1: Arrival, sunset welcome dinner on the beach.",
                "Day 2: Tour A — Big Lagoon, Small Lagoon, Secret Lagoon.",
                "Day 3: Nacpan Beach + inland sunset viewpoint.",
                "Day 4: Slow morning, souvenir market, departure.",
            },
        },
        new TourPackage
        {
            Slug = "boracay-luxury-retreat",
            Title = "Boracay Luxury Retreat",
            Destination = "Boracay Island, Aklan",
            Category = "Beach",
            DurationDays = 3,
            PricePerPerson = 15000m,
            Rating = 4.8,
            ImageUrl = string.Format(U, "photo-1507525428034-b723cf961d3e"),
            GalleryUrls = new()
            {
                string.Format(U, "photo-1507525428034-b723cf961d3e"),
                string.Format(U, "photo-1510414842594-a61c69b5ae57"),
                string.Format(U, "photo-1540541338287-41700207dee6"),
            },
            Summary = "Powder-white sand, sunset sails, and a resort that handles everything.",
            DreamLine = "White Beach, barefoot, no schedule.",
            Highlights = new() { "Sunset paraw sailing", "White Beach Station 1 stay", "Spa afternoon" },
            Inclusions = new() { "2 nights resort stay", "Daily breakfast", "Sunset sail tickets", "Island terminal transfers" },
            Exclusions = new() { "Flights to Caticlan", "Water activities (helmet dive, etc.)", "Dinner" },
            Itinerary = new()
            {
                "Day 1: Arrival via Caticlan, beachfront check-in, sunset walk.",
                "Day 2: Free morning, sunset paraw sail, dinner on the sand.",
                "Day 3: Spa session, souvenir run, departure.",
            },
        },
        new TourPackage
        {
            Slug = "cebu-heritage-falls",
            Title = "Cebu Heritage & Falls",
            Destination = "Cebu City & South Cebu",
            Category = "Culture",
            DurationDays = 3,
            PricePerPerson = 12800m,
            Rating = 4.7,
            ImageUrl = string.Format(U, "photo-1433086966358-54859d0ed716"),
            GalleryUrls = new()
            {
                string.Format(U, "photo-1433086966358-54859d0ed716"),
                string.Format(U, "photo-1520250497591-112f2f40a3f4"),
                string.Format(U, "photo-1559827260-dc66d52bef19"),
            },
            Summary = "Three centuries of history in the morning, turquoise falls by afternoon.",
            DreamLine = "Canyoneer down to Kawasan's blue water.",
            Highlights = new() { "Magellan's Cross & Basilica walk", "Kawasan Falls canyoneering", "Moalboal sardine-run snorkel" },
            Inclusions = new() { "2 nights city hotel", "Daily breakfast", "Heritage walking guide", "Canyoneering gear + guides" },
            Exclusions = new() { "Flights to Cebu", "Lunch on canyoneering day", "Tips for guides" },
            Itinerary = new()
            {
                "Day 1: Arrival, heritage walk — Cross, Basilica, Fort San Pedro.",
                "Day 2: Kawasan canyoneering + Moalboal snorkel.",
                "Day 3: Pasalubong market, departure.",
            },
        },
        new TourPackage
        {
            Slug = "bohol-nature-adventure",
            Title = "Bohol Nature Adventure",
            Destination = "Bohol Island",
            Category = "Adventure",
            DurationDays = 3,
            PricePerPerson = 11500m,
            Rating = 4.8,
            ImageUrl = string.Format(U, "photo-1506905925346-21bda4d32df4"),
            GalleryUrls = new()
            {
                string.Format(U, "photo-1506905925346-21bda4d32df4"),
                string.Format(U, "photo-1476514525535-07fb3b4ae5f1"),
                string.Format(U, "photo-1537996194471-e657df975ab4"),
            },
            Summary = "Chocolate Hills, wide-eyed tarsiers, and a slow river cruise.",
            DreamLine = "Stand above a thousand chocolate mounds.",
            Highlights = new() { "Chocolate Hills viewpoint", "Tarsier sanctuary visit", "Loboc River lunch cruise" },
            Inclusions = new() { "2 nights countryside stay", "Daily breakfast", "Countryside tour van + guide", "River cruise lunch" },
            Exclusions = new() { "Flights to Tagbilaran", "ATV rental at the hills", "Dinner" },
            Itinerary = new()
            {
                "Day 1: Arrival, Loboc River lunch cruise, firefly watch.",
                "Day 2: Chocolate Hills, tarsiers, butterfly garden.",
                "Day 3: Panglao beach morning, departure.",
            },
        },
    };

    public static TourPackage? GetBySlug(string slug) =>
        GetPackages().FirstOrDefault(p =>
            p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
}
