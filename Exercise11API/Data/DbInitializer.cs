using Exercise11API.Models;

namespace Exercise11API.Data;

public static class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        PropertyDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<PropertyDbContext>();

        //if (!context.Categories.Any())
        //{
        //    context.Categories.AddRange(PropertyCategories.Select(c => c.Value));
        //}

        if (!context.Properties.Any())
        {
            context.AddRange
            (
                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-1-apartment.jpg",
                    Title = "Modern Single-Family Home in the Heart of California",
                    SummaryDescription = "Stylish 2-bedroom house with breathtaking city views",
                    DetailDescription = "This modern house features an open floor plan, high-end finishes, and a spacious balcony. Conveniently located near shopping centers and business districts.",
                    PropertyCategory = "House and Lot",
                    Price = 5_000_000,
                    CarSpace = 1,
                    NumberOfBedroom = 2,
                    NumberOfBathroom = 1,
                    FloorArea = 1910,
                    LandSize = 6451,
                    Location = "23649 Long Valley Rd, Hidden Hills, CA 91302",
                    BrokerName = "Alexandra Swift",
                    BrokerEmail = "alexandraswift@gmail.com",
                    BrokerPhone = "+1234567890",
                    IsPropertyOfTheWeek = false
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-2-villa.jpg",
                    Title = "Spacious Family Home in Quezon City",
                    SummaryDescription = "Large 4-bedroom house with a generous backyard.",
                    DetailDescription = "This family-friendly house offers ample living space, a modern kitchen, and a landscaped garden. Ideal for those seeking a peaceful residential area.",
                    PropertyCategory = "House and Lot",
                    Price = 1_414_000,
                    CarSpace = 3,
                    NumberOfBedroom = 2,
                    NumberOfBathroom = 2,
                    FloorArea = 2300,
                    LandSize = 5130,
                    Location = "5037 Van Fleet /B St Unit A, Quezon City 77033",
                    BrokerName = "Jane Smith",
                    BrokerEmail = "jane.smith@example.com",
                    BrokerPhone = "+9876543210",
                    IsPropertyOfTheWeek = true
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-22-single.jpg",
                    Title = "Cozy Home in Manila",
                    SummaryDescription = "Budget-friendly 1-bedroom home for rent.",
                    DetailDescription = "This apartment is perfect for singles or couples, offering a comfortable living space, a compact kitchen, and easy access to public transportation.",
                    PropertyCategory = "House and Lot",
                    Price = 3_500_000,
                    CarSpace = 1,
                    NumberOfBedroom = 2,
                    NumberOfBathroom = 2,
                    FloorArea = 1415,
                    LandSize = 4126,
                    Location = "Pasig, Manila",
                    BrokerName = "Maria Rodriguez",
                    BrokerEmail = "maria.rodriguez@example.com",
                    BrokerPhone = "+9876543210",
                    IsPropertyOfTheWeek = true
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-22-single.jpg",
                    Title = "Prime Commercial Space in BGC",
                    SummaryDescription = "High-visibility commercial space for lease in Bonifacio Global City.",
                    DetailDescription = "An excellent opportunity for businesses looking for a strategic location. This commercial space offers modern amenities and a dynamic business environment.",
                    PropertyCategory = "Commercial",
                    Price = 4_300_000,
                    CarSpace = 1,
                    NumberOfBedroom = 3,
                    NumberOfBathroom = 3,
                    FloorArea = 3910,
                    LandSize = 5451,
                    Location = "564 Eclipse Dr, Taguig City 78737",
                    BrokerName = "Robert Lee",
                    BrokerEmail = "robert.lee@example.com",
                    BrokerPhone = "+3334445556",
                    IsPropertyOfTheWeek = false
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-5-home.jpg",
                    Title = "Exclusive Beachfront Villa in Boracay",
                    SummaryDescription = "Luxury 5-bedroom villa with a private beach access.",
                    DetailDescription = "This stunning villa boasts panoramic ocean views, a private pool, and direct access to the beach. A perfect retreat for those seeking a premium tropical experience.",
                    PropertyCategory = "House and Lot",
                    Price = 25_000_000,
                    CarSpace = 3,
                    NumberOfBedroom = 5,
                    NumberOfBathroom = 6,
                    FloorArea = 8102,
                    LandSize = 10859,
                    Location = "708 W Johanna St, Aklan, Boracay",
                    BrokerName = "Michael Chang",
                    BrokerEmail = "rmichael.chang@example.com",
                    BrokerPhone = "+9998887776",
                    IsPropertyOfTheWeek = true
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-6-home.jpg",
                    Title = "Studio Apartment in the Heart of Cebu",
                    SummaryDescription = "Compact studio apartment for urban living.",
                    DetailDescription = "This centrally located apartment offers a modern design, fully equipped kitchen, and proximity to shopping and entertainment. Ideal for young professionals or students.",
                    PropertyCategory = "Apartment",
                    Price = 5250000,
                    CarSpace = 1,
                    NumberOfBedroom = 2,
                    NumberOfBathroom = 1,
                    FloorArea = 34523,
                    LandSize = 6456,
                    Location = "3525 Sage Rd Apt 403, Cebu City 77056",
                    BrokerName = "Angela Gomez",
                    BrokerEmail = "angela.gomez@example.com",
                    BrokerPhone = "+7776665554",
                    IsPropertyOfTheWeek = true
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-20-condo.jpg",
                    Title = "Luxurious Penthouse with Skyline Views",
                    SummaryDescription = "Elegant 3-bedroom penthouse with a private terrace.",
                    DetailDescription = "This executive penthouse features high-end finishes, a spacious living area, and a rooftop terrace with stunning city views. A perfect blend of sophistication and comfort.",
                    PropertyCategory = "Condo",
                    Price = 15000000,
                    CarSpace = 2,
                    NumberOfBedroom = 3,
                    NumberOfBathroom = 4,
                    FloorArea = 3694,
                    LandSize = 9235,
                    Location = "Mandaluyong, Metro Manila",
                    BrokerName = "Carlos Hernandez",
                    BrokerEmail = "carlos.hernandez@example.com",
                    BrokerPhone = "+2223334447",
                    IsPropertyOfTheWeek = true
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-8-apartment.jpg",
                    Title = "Charming Family Home in Antipolo Hills",
                    SummaryDescription = "Serene 4-bedroom home with a scenic view.",
                    DetailDescription = "This charming house offers a peaceful escape, spacious bedrooms, a well-maintained garden, and a view of the Antipolo hills. Perfect for families seeking tranquility.",
                    PropertyCategory = "House and Lot",
                    Price = 3269000,
                    CarSpace = 2,
                    NumberOfBedroom = 4,
                    NumberOfBathroom = 3,
                    FloorArea = 1552,
                    LandSize = 18730,
                    Location = "333 Westminster Ave Apt 304, Antipolo City 90020",
                    BrokerName = "Sofia Rodriguez",
                    BrokerEmail = "sofia.rodriguez@example.com",
                    BrokerPhone = "+8889990001",
                    IsPropertyOfTheWeek = false
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-9-apartment.jpg",
                    Title = "Modern Loft Living in Quezon City",
                    SummaryDescription = "Trendy 2-bedroom loft apartment with industrial design.",
                    DetailDescription = "This contemporary loft features an open layout, exposed brick walls, and large windows. Ideal for those who appreciate a modern and urban lifestyle.",
                    PropertyCategory = "Apartment",
                    Price = 6542000,
                    CarSpace = 1,
                    NumberOfBedroom = 6,
                    NumberOfBathroom = 4,
                    FloorArea = 2971,
                    LandSize = 41382,
                    Location = "9119 Wakefield Ave Unit 4, Quezon City 91402",
                    BrokerName = "Mark Johnson",
                    BrokerEmail = "mark.johnson@example.com",
                    BrokerPhone = "+1239874562",
                    IsPropertyOfTheWeek = false
                },

                new PropertyModel()
                {
                    ImageUrl = "https://jabezstorageaccount.blob.core.windows.net/exercise8container/property-10-multi.jpg",
                    Title = "High-End Commercial Space in Makati CBD",
                    SummaryDescription = "Fully furnished 2-bedroom apartment for rent.",
                    DetailDescription = "This top-tier commercial space offers modern amenities, panoramic city views, and a prestigious business address. Perfect for corporate headquarters and upscale businesses.",
                    PropertyCategory = "Apartment",
                    Price = 10000000,
                    CarSpace = 1,
                    NumberOfBedroom = 2,
                    NumberOfBathroom = 2,
                    FloorArea = 3452,
                    LandSize = 6451,
                    Location = "4525 Balkin St Apt 12, Pasig City, Manila 77021",
                    BrokerName = "Michelle Tan",
                    BrokerEmail = "michelle.tan@example.com",
                    IsPropertyOfTheWeek = false
                }
            );
        }

        context.SaveChanges();
    }
}
