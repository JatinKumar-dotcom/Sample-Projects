using System;
using System.Collections.Generic;
using System.Globalization;

public class Accommodation
{
    public int ID { get; protected set; }
    public string Type { get; protected set; }
    public decimal PricePerNight { get; protected set; }
    public List<string> Facilities { get; protected set; }

    // Constructor for creating an accommodation object
    public Accommodation(int id, string type, decimal pricePerNight, List<string> facilities)
    {
        ID = id;
        Type = type;
        PricePerNight = pricePerNight;
        Facilities = facilities;
    }

    // Method to print the details of the accommodation
    public virtual void Print()
    {
        Console.WriteLine($"Accommodation ID: {ID}"); // Print the ID of the accommodation
        Console.WriteLine($"Type: {Type}"); // Print the type of the accommodation
        Console.WriteLine($"Price per Night: {PricePerNight.ToString("C2", CultureInfo.CreateSpecificCulture("en-GB"))}"); // Format the price per night as pounds and print
        Console.WriteLine($"Facilities: {string.Join(", ", Facilities)}"); // Print the list of facilities
    }
    public virtual string DisplayInfo
    {
        get { return $"Accommodation ID: {ID}, Type: {Type}, Price per Night: {PricePerNight:C2}, Facilities: {string.Join(", ", Facilities)}"; }
    }
}