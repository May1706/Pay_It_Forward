using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace PayItForward.Classes
{
    public class Donation
    {
        #region fields
        // Items in the donation 
        private List<DonatedItem> _items;
        
        #endregion

        public Donation()
        {

        }

        #region Methods

        public void addItem(DonatedItem item)
        {
            if (_items == null)
            {
                _items = new List<DonatedItem>();
            }

            _items.Add(item);
        }

        public void addItem(Item item, DonationCenter center, int quantity)
        {
            addItem(new DonatedItem(item, center, quantity));
        }

        public void addItem(int itemId, int centerId, int quantity)
        {
            addItem(new DonatedItem(itemId, centerId, quantity));
        }

        private string donatedItemToString(DonatedItem item)
        {
            StringBuilder itemString = new StringBuilder("");

            // Null check on ItemType, '_' represents null
            if (item.ItemType == null)
                itemString.Append("_,");
            else
                itemString.Append(item.ItemType.itemId + ",");

            // Add quantity
            itemString.Append(item.Quantity + ",");

            // Null check on Center, '_' represents null
            if (item.Center == null)
                itemString.Append("_");
            else
                itemString.Append(item.Center.CenterId);

            return itemString.ToString();
        }

        #endregion

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /**
         * Formatted string to store important details about items in the
         * donation. Each item is formatted as:
         *      [itemId],[quantity donated],[centerId]
         * different items are separated by a ';'
         */
        public string ItemsAsString
        {
            // Creates and returns the formatted string
            get
            {
                // Make sure _items isn't null or empty
                if (_items != null && _items.Count > 0)
                {
                    StringBuilder itemString = new StringBuilder("");

                    // Make a formatted string
                    itemString.Append(donatedItemToString(_items[0]));

                    for (int i=1; i<_items.Count; i++)
                    {
                        itemString.Append(";");
                        itemString.Append(donatedItemToString(_items[i]));
                    }
                    
                    return itemString.ToString();
                }

                // If _items is empty, return an empty string
                return "";
            }

            /* Parses the string and performs queries */
            set
            {
                _items = new List<DonatedItem>();

                // Split to each items info
                List<string> splitVals = value.Split(';').ToList();
                foreach (string val in splitVals)
                {
                    // Split to each info int
                    List<string> idsAsStrings = val.Split(',').ToList();

                    // If not formatted correctly, log and move on
                    try
                    {
                        if (idsAsStrings.Count != 3)
                            throw new ArgumentException(idsAsStrings.Count + "");

                        int itemId = int.Parse(idsAsStrings[0]);
                        int quantity = int.Parse(idsAsStrings[1]);
                        if (idsAsStrings[2].Equals("_"))
                        {
                            using (var db = new DatabaseContext())
                            {
                                Item item = db.Items.Where(i => i.itemId == itemId).FirstOrDefault();
                                _items.Add(new DonatedItem(item, null, quantity));
                            }
                        }
                        else
                        {
                            int centerId = int.Parse(idsAsStrings[2]);
                            _items.Add(new DonatedItem(itemId, centerId, quantity));
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("DB entry formatted incorrectly: "
                            + "Expected int");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("DB entry formatted incorrectly: "
                            + "Expected 3 arguments found " + e.Message);
                    }
                }
            }
        }

        public DateTime DonationDateTime { get; set; }

        [NotMapped]
        public List<DonatedItem> Items
        {
            get
            {
                DonatedItem[] array = new DonatedItem[_items.Count];
                _items.CopyTo(array);
                return array.ToList();
            }

            set
            {
                DonatedItem[] array = new DonatedItem[value.Count];
                value.CopyTo(array);
                _items = value.ToList();
            }
        }

        #endregion
    }
}