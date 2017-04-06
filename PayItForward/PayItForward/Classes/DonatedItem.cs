using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class DonatedItem
    {
        public DonatedItem(Item item, DonationCenter center, int quantity)
        {
            ItemType = item;
            Center = center;
            Quantity = quantity;
        }

        public DonatedItem(int itemID, int centerID, int quantity)
        {
            using (var db = new DatabaseContext())
            {
                ItemType = db.Items.Where(i => i.itemId == itemID).First();
                Center = db.DonationCenters.Where(c => c.CenterId == centerID).First();
                Quantity = quantity;
            }
        }

        #region Properties

        public Item ItemType { get; set; }
        public DonationCenter Center {get; set; }
        public int Quantity { get; set; }

        #endregion
}
}