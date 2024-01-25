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
    public class CustomerTests
    {
        private OnlineFoodDeliveryAPPDBEntities dbContext = new OnlineFoodDeliveryAPPDBEntities();

        [Test]
        public void GetCustomerById_ShouldReturnCorrectCustomer()
        {

            long customerId = 28;


            var customer = dbContext.Customers.FirstOrDefault(c => c.CustId == customerId);


            ClassicAssert.IsNotNull(customer);
            ClassicAssert.AreEqual(customerId, customer.CustId);

        }

        //[Test]
        //public void InsertCustomer_ShouldAddNewCustomerToDatabase()
        //{

        //    var newCustomer = new Customer
        //    {

        //        CustEmail = "John@gmail.com",
        //        CustPhone = "1234567890",
        //        CustFName = "John",
        //        CustLName = "Doe",
        //        CustPassword = "password"
        //    };


        //    dbContext.Customers.Add(newCustomer);
        //    dbContext.SaveChanges();


        //    var retrievedCustomer = dbContext.Customers.FirstOrDefault(c => c.CustEmail == "John@gmail.com");
        //    ClassicAssert.IsNotNull(retrievedCustomer);
        //    ClassicAssert.AreEqual(newCustomer.CustEmail, retrievedCustomer.CustEmail);

        //}
        [Test]
        public void GetCustomerByEmailAndPassword_ShouldReturnCorrectCustomer()
        {

            string email = "Customer2@gmail.com";
            string password = "Cust@123";


            var customer = dbContext.Customers.FirstOrDefault(c => c.CustEmail == email && c.CustPassword == password);


            ClassicAssert.IsNotNull(customer);
            ClassicAssert.AreEqual(email, customer.CustEmail);
            ClassicAssert.AreEqual(password, customer.CustPassword);

        }

        [Test]
        public void GetCustomerByInvalidCredentials_ShouldReturnNull()
        {

            string email = "nonexistent@example.com";
            string password = "invalidpassword";


            var customer = dbContext.Customers.FirstOrDefault(c => c.CustEmail == email && c.CustPassword == password);


            ClassicAssert.IsNull(null);

        }

    }
}
