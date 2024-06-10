using System.Text.Json.Serialization;

namespace WineLib

{
    public class Wine
    {
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        //undgå at wine ka oprettes med forkerte værdier, da vi kalder "Validate" i Konstrukteren"  

        //Json deserializer  bruges til at fortælle Json, at vi vil bruge denne konstruktor
        //når du serialiserer 
        //prøv at fjerne JsonConstructor og se hvad der sker
        [JsonConstructor]
        public Wine(string? manufacturer, int year, double price, double rating)
        {
            Manufacturer = manufacturer;
            Year = year;
            Price = price;
            Rating = rating;
            Validate();
        }
       
        public Wine(int id, string? manufacturer, int year, double price, double rating)
        {
            Id = id;
            Manufacturer = manufacturer;
            Year = year;
            Price = price;
            Rating = rating;
            Validate();
        }
        
        public override string ToString() // her laver vi en override af ToString metoden, så vi kan se hvad der er i Wine objektet
        {
            return $"Wine: {Id}, Manufacturer: {Manufacturer}, year: {Year},price: {Price}, rating: {Rating}";
        }
        
        public void ValidateManufacturer()
        {
            if (Manufacturer is null)
            {
                throw new ArgumentNullException("Manufacturer must not be null");
            }
            if (Manufacturer.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Manufacturer must be at least 2 characters long");
            }
           
        }
        
        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentException("Price must be positive");
            }
        }
     
        public void ValidateRating()
        {
            if (Rating < 0 || (Rating < 2 && Rating != 0) || Rating > 5) // her siger vi at rating skal være mellem 0 og 2-5
            {
                throw new ArgumentOutOfRangeException("Rating must be between 0 or 2 - 5"); // her siger vi at rating skal være mellem 0 og 2-5
            }
        }

        //bruges til at 
        public void Validate()
        {
            ValidateManufacturer();
            ValidatePrice();
            ValidateRating();
        }

    }
}