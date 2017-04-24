using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayItForward.Classes;
using System.Linq;

namespace PayItForward.Tests
{
    [TestClass]
    public class DonationHistoryTest
    {
        [TestMethod]
        public void CreateDonatedItem()
        {
            using (var db = new DatabaseContext())
            {
                Item item = new Item();
                item.itemId = 0;
                DonationCenter center = new DonationCenter();
                center.CenterId = 0;
                int quantity = 2;
                DonatedItem expected = new DonatedItem(item, center, quantity);

                DonatedItem donItem = new DonatedItem(0, 0, quantity);

                Assert.AreEqual(expected, donItem, "Donated items are not equal");
            }
        }

        [TestMethod]
        public void ItemsEqualTest()
        {
            Item item1 = new Item("item", 0, 1, 10);
            Item item2 = new Item("item", 0, 1, 10);

            Assert.AreEqual(item1, item2, "Equal items are not being evaluated as equal");
        }

        [TestMethod]
        public void CreateDonation()
        {
            
        }

        [TestMethod]
        public void AddDonationToUser()
        {

        }
    }
}
