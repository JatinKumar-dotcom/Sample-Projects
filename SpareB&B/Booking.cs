using System;

public class Booking
{
    public int BookingID { get; private set; } // ID of the booking
    public Accommodation Accommodation { get; private set; } // Accommodation object associated with the booking
    public User BookedBy { get; private set; } // User who made the booking
    public DateTime BookingDate { get; private set; } // Date and time when the booking was made
    public bool IsBooked { get; private set; } // Indicates if the booking is currently active or not

    // Constructor for creating a booking object
    public Booking(int bookingID, Accommodation accommodation, User bookedBy)
    {
        BookingID = bookingID;
        Accommodation = accommodation;
        BookedBy = bookedBy;
        BookingDate = DateTime.Now;
        IsBooked = false; // Initially set the booking status to not booked
    }

    // Method to make a booking
    public void MakeBooking()
    {
        if (!IsBooked) // Check if the accommodation is not already booked
        {
            IsBooked = true; // Set the booking status to booked
            Console.WriteLine($"Booking {BookingID}: Accommodation ID {Accommodation.ID} booked by {BookedBy.Name} on {BookingDate}.");
        }
        else
        {
            Console.WriteLine($"Booking {BookingID}: Accommodation ID {Accommodation.ID} is already booked.");
        }
    }

    // Method to release a booking
    public void ReleaseBooking()
    {
        if (IsBooked) // Check if the accommodation is currently booked
        {
            IsBooked = false; // Set the booking status to not booked
            Console.WriteLine($"Booking {BookingID}: Accommodation ID {Accommodation.ID} released by {BookedBy.Name} on {DateTime.Now}.");
        }
        else
        {
            Console.WriteLine($"Booking {BookingID}: Accommodation ID {Accommodation.ID} is not currently booked.");
        }
    }

    // Method to print the details of a booking
    public void PrintBookingDetails()
    {
        Console.WriteLine($"Booking ID: {BookingID}");
        Console.WriteLine($"Accommodation ID: {Accommodation.ID}");
        Console.WriteLine($"Booked by: {BookedBy.Name}");
        Console.WriteLine($"Booking Date: {BookingDate}");
        Console.WriteLine($"Booking Status: {(IsBooked ? "Booked" : "Not Booked")}");
    }
}