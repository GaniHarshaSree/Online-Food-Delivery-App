using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOFDAPP
{
    [TestFixture]
    internal class RestaurentTests
    {
        private OnlineFoodDeliveryAPPDBEntities dbContext = new OnlineFoodDeliveryAPPDBEntities();


        [Test]
        public void AddNewRestaurant_ShouldIncreaseRestaurantCount()
        {
            // Arrange
            var initialRestaurantCount = dbContext.Restaurants.Count();

            // Act
            var newRestaurant = new Restaurant
            {
                RestaurentName = "New Restaurant",
                RestaurentAvailable = true,
                RestaurentLogoUrl = "logo.jpg",
                RestaurentAdminId = 1 
            };

            dbContext.Restaurants.Add(newRestaurant);
            dbContext.SaveChanges();

            // Assert
            var updatedRestaurantCount = dbContext.Restaurants.Count();
            ClassicAssert.AreEqual(initialRestaurantCount + 1, updatedRestaurantCount, "Restaurant count should be increased after adding a new restaurant.");
        }







        private bool RestaurantNameChecking(string restaurantName)
        {
            // Implement logic to check if the restaurant name exists
            var existingRestaurant = dbContext.Restaurants.FirstOrDefault(r => r.RestaurentName == restaurantName);
            return existingRestaurant != null;
        }

        
        private bool RestaurantAvailabilityChecking(int restaurantId)
        {
            
            var existingRestaurant = dbContext.Restaurants.FirstOrDefault(r => r.RestaurentId == restaurantId && r.RestaurentAvailable);
            return existingRestaurant != null;
        }




        [Test]
        public void CheckRestaurantName_ShouldReturnTrue()
        {
            // Arrange
            var restaurantNameToCheck = "New Restaurant"; // Replace with a name that exists in your test data

            // Act
            var isRestaurantNameExist = RestaurantNameChecking(restaurantNameToCheck);

            // Assert
            ClassicAssert.IsTrue(isRestaurantNameExist, $"Restaurant name '{restaurantNameToCheck}' should exist.");
        }




        [Test]
        public void CheckRestaurantAvailability_ShouldReturnTrue()
        {
            // Arrange
            var restaurantIdToCheck = 12;

            // Act
            var isRestaurantAvailable = RestaurantAvailabilityChecking(restaurantIdToCheck);

            // Assert
            ClassicAssert.IsTrue(isRestaurantAvailable, $"Restaurant with ID '{restaurantIdToCheck}' should be available.");
        }





    }
}
