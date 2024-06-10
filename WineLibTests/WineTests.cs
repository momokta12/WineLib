
namespace WineLib.Tests


{
    [TestClass()]
    public class WineTests
    {
        [TestMethod]
        public void ValidateManufacturerTest()
        {
            Wine wineValid = new(manufacturer: "Chateau Margaux", year: 2134, price: 123, rating: 5);
           

            // Test at en undtagelse kastes for null eller tom værdi
            Assert.ThrowsException<ArgumentNullException>(() => new Wine(manufacturer: null, year: 2134, price: 123, rating: 5));

            // Test at en undtagelse kastes for kort værdi
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Wine(manufacturer: "A", year: 2134, price: 123, rating: 5));

            // Test at ingen undtagelse kastes for gyldig værdi
            Assert.AreEqual ("Chateau Margaux", wineValid.Manufacturer);
          

        }
        [TestMethod]
        public void ValidateRatingTest()
        {
            // Opret test-objekter med forskellige værdier for Rating
            Wine wineValid = new(manufacturer: "Chateau Margaux", year: 1234, price: 123, rating: 3);

            Wine wineZero = new(manufacturer: "Chateau Margaux", year: 1234, price: 123, rating: 0);

            // Test at en undtagelse kastes for ugyldig lav værdi
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Wine(manufacturer: "Chateau Margaux", year: 1234, price: 123, rating: 1));

            // Test at en undtagelse kastes for ugyldig høj værdi
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Wine(manufacturer: "Chateau Margaux", year: 1234, price: 123, rating: 6));

            // Test at 0 er en gyldig værdi
           Assert.AreEqual(0, wineZero.Rating);

            // Test at ingen undtagelse kastes for gyldige værdier (2-5)
           Assert.AreEqual(3, wineValid.Rating);
        }
    }
}