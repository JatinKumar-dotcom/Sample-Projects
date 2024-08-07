// Aras Taha
// TAH22520691
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a list to hold available accommodations
        List<Accommodation> accommodations = new List<Accommodation>
        {
            // List with different accommodation types
            // Houses
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

        // Create a dictionary to hold booked accommodations and the users who booked them
        Dictionary<Accommodation, List<User>> bookedAccommodations = new Dictionary<Accommodation, List<User>>();

        while (true)
        {
            Console.Write("\nEnter your username (press 'q' to quit): ");
            string username = Console.ReadLine(); // Get user input to create a new user

            if (username.ToLower() == "q") // Check if the user wants to quit
            {
                Console.WriteLine("Thank you for visiting!");
                break;
            }

            if (accommodations.Count == 0)
            {
                Console.WriteLine("Sorry, there are no accommodations available at the moment.");
                break;
            }
            User currentUser = new User(username); // Create a new user object with the provided username

            var groupedAccommodations = accommodations.GroupBy(acc => acc.GetType().Name); // Group accommodations by type

            Console.WriteLine("\nAvailable Accommodations:"); // Display available accommodations

            foreach (var group in groupedAccommodations)
            {
                Console.WriteLine(); // Add an empty line before each accommodation type
                Console.WriteLine($"--- {group.Key}s ---"); // Print the type of accommodation
                Console.WriteLine(); // Add an empty line after each accommodation type

                foreach (var accommodation in group)
                {
                    if (bookedAccommodations.ContainsKey(accommodation))
                    {
                        Console.WriteLine($"{accommodation.GetType().Name} ID {accommodation.ID} booked by:");

                        foreach (var user in bookedAccommodations[accommodation])
                        {
                            Console.WriteLine($"- {user.GetUserName()}");
                        }
                        Console.WriteLine(new string('-', 40)); // Separation line for better visual representation
                    }
                    else
                    {
                        accommodation.Print(); // Print the details of the accommodation
                        Console.WriteLine();
                    }
                }
            }

            int chosenAccommodationId; // Get user input to choose an accommodation
            bool isValidInput;
            do
            {
                Console.Write("Enter the ID of the accommodation you want to book: ");
                isValidInput = int.TryParse(Console.ReadLine(), out chosenAccommodationId);
                if (!isValidInput)
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number for the accommodation ID.");
                }
                else
                {
                    Accommodation chosenAccommodation = accommodations.Find(acc => acc.ID == chosenAccommodationId); // Find the chosen accommodation from the list of accommodations

                    if (chosenAccommodation != null)
                    {
                        if (!bookedAccommodations.ContainsKey(chosenAccommodation))
                        {
                            bookedAccommodations[chosenAccommodation] = new List<User>();
                        }

                        if (!bookedAccommodations[chosenAccommodation].Contains(currentUser))
                        {
                            Booking userBooking = new Booking(1, chosenAccommodation, currentUser); // Create a booking for the chosen accommodation
                            userBooking.MakeBooking(); // Make the booking for the user

                            bookedAccommodations[chosenAccommodation].Add(currentUser); // Add booked accommodation to the dictionary

                            Console.WriteLine("\nBooking Details:"); // Print booking details
                            userBooking.PrintBookingDetails();
                        }
                        else
                        {
                            Console.WriteLine($"You have already booked {chosenAccommodation.GetType().Name} ID {chosenAccommodation.ID}.");
                            isValidInput = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid accommodation ID. Please enter a valid ID.");
                        isValidInput = false;
                    }
                }
            } while (!isValidInput);

            accommodations.RemoveAll(acc => bookedAccommodations.ContainsKey(acc)); // Update the list of available accommodations after each booking
        }
    }
}