using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusyPet.Tests
{
    [TestClass]
    public class PetTests
    { 
        [TestMethod]
        public void PetCreationTest()
        {
            /* Alivia Houdek */
            /* March 22, 2019 */
            
            BusyPet.Classes.Utilities ut = new Classes.Utilities();

            // create user
            BusyPet.Classes.User user1 = new Classes.User("test1", "test1", ut.ConvertStringToBytes("test1"));

            // create pet
            BusyPet.Classes.Pet pet1 = new Classes.Pet(user1, "test1", "cat", "male", ut.ConvertStringToDateTime("01/01/2019").ToShortDateString());

            Assert.IsNotNull(user1);
            Assert.IsNotNull(pet1);
        }
    }
}
