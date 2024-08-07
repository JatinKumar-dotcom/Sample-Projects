using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareB_BGUI
{
    public class AccommodationManager
    {
        private List<Accommodation> accommodations = new List<Accommodation>();
        private List<Booking> bookedAccommodations;

        public AccommodationManager()
        {
            // Initialize accommodations (similar to your console app)
            accommodations = new List<Accommodation>
            {
               new House(1, 3, true, 2, 70, new List<string> { "Wi-Fi", "Parking" }),
            new House(2, 4, false, 3, 100, new List<string> { "Garden", "Pool" }),
            new House(3, 2, true, 1, 90, new List<string> { "Wi-Fi", "Fireplace" }),

            // Flats
            new Flat(4, 2, 2, true, false, 60, new List<string> { "Wi-Fi", "Elevator" }),
            new Flat(5, 1, 1, false, true, 80, new List<string> { "Balcony", "Laundry" }),
            new Flat(6, 3, 2, true, false, 100, new List<string> { "Wi-Fi", "Fitness Center" }),

            // Hotel Rooms
            new HotelRoom(7, 2, 80, new List<string> { "Breakfast", "Gym", "Wi-Fi" }),
            new HotelRoom(8, 1, 70, new List<string> { "Wi-Fi", "Pool" }),
            new HotelRoom(9, 3, 100, new List<string> { "Breakfast", "Spa", "Wi-Fi" })
            };
            bookedAccommodations = new List<Booking>();
        }
        public void MakeBooking(Accommodation accommodation, User user)
        {
            if (!bookedAccommodations.Any(booking => booking.Accommodation == accommodation))
            {
                bookedAccommodations.Add(new Booking(1,accommodation, user));
            }
        }
        public List<Accommodation> GetAvailableAccommodations()
        {
            return accommodations.Where(acc => !bookedAccommodations.Any(booking => booking.Accommodation == acc)).ToList();
        }
        public string GetAvailableAccommodationsAsString()
        {
            List<Accommodation> availableAccommodations = accommodations
                .Where(acc => !bookedAccommodations.Any(booking => booking.Accommodation == acc))
                .ToList();

            List<string> accommodationStrings = availableAccommodations.Select(acc => acc.ToString()).ToList();

            return string.Join(Environment.NewLine, accommodationStrings);
        }
        public List<Booking> GetBookedAccommodations()
        {
            return bookedAccommodations.ToList();
        }
        public string GetBookedAccommodationsAsString()
        {
            List<string> bookedAccommodationStrings = bookedAccommodations.Select(booking => booking.ToString()).ToList();
            return string.Join(Environment.NewLine, bookedAccommodationStrings);
        }
    }
}
