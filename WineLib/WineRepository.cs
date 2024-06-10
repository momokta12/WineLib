using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WineLib
{
    public class WineRepository
    {
        public int nextId = 6;
        private List<Wine> wines = new()
        { new  (id: 1, manufacturer: "Chateau Margaux", year: 534, price: 123, rating: 2.5),
          new  (id: 2, manufacturer: "Chateau Margaux", year: 2345, price: 123, rating: 2.5),
          new  (id: 3, manufacturer: "Chateau Margaux", year: 4525, price: 123, rating: 2.5),
          new  (id: 4, manufacturer: "Chateau Margaux", year: 3435, price: 123, rating: 2.5),
          new  (id: 5, manufacturer: "Chateau Margaux", year: 6455, price: 123, rating: 2.5),
        };

        public Wine Add(Wine wine)
        {
            wine.Id = nextId++;
            wines.Add(wine);
            return wine;
        }

        public Wine? GetById(int id)
        {
            return wines.Find(w => w.Id == id);
        }

        public List<Wine> GetAll()
        {
            //returner en kopi af listen, så vi ikke kan ændre på den originale liste
            return new List<Wine>(wines);
        }

        public Wine Delete(int id)
        {
            Wine? wine = GetById(id);
            //hvis den er null, så kastes en exception
            if (wine is null)
            {
                throw new ArgumentException("Wine not found");
            }
            else
            {
                wines.Remove(wine);
            }
            return wine;
        }

        public Wine Update(Wine wine)
        {
            Wine? existingWine = GetById(wine.Id);
            if (existingWine is null)
            {
                throw new ArgumentException("Wine not found");
            }
            else
            {
                existingWine.Manufacturer = wine.Manufacturer;
                existingWine.Price = wine.Price;
                existingWine.Year = wine.Year;
            }
            return existingWine;
        }
    }
}