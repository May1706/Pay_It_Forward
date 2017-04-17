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

        #region Methods

        public override bool Equals(object o)
        {
            var other = o as DonatedItem;

            if (o == null) return false;

            // Check if ItemTypes are equal
            if (this.ItemType == null)
            {
                if (other.ItemType != null)
                {
                    return false;
                }
            }
            else
            {
                if (!this.ItemType.Equals(other.ItemType)) return false;
            }

            // Check if DonationCenters are equal
            if (this.Center == null)
            {
                if (other.Center != null)
                {
                    return false;
                }
            }
            else
            {
                if (!this.Center.Equals(other.Center)) return false;
            }

            // Check if quantity is equal
            return this.Quantity == other.Quantity;
        }

        #endregion

        #region Properties

        public Item ItemType { get; set; }
        public DonationCenter Center {get; set; }
        public int Quantity { get; set; }

        #endregion
}
}