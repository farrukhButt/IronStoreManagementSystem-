using IronStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronStore.Helpers
{

    class ItemDropDownList
    {

        public string ItemComplete { get; set; }
        public int ItemId { get; set; }



        public static List<ItemDropDownList> GetItemsList()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var items = db.Items.Where(aa => aa.IsExtra == false).ToList();
            List<ItemDropDownList> ItemsDropDownList = new List<ItemDropDownList>();

            ItemDropDownList itemA = new ItemDropDownList();
            itemA.ItemComplete = "Select Item";
            itemA.ItemId = 0;

            ItemsDropDownList.Add(itemA);

            foreach (var item in items)
            {
                ItemDropDownList item1 = new ItemDropDownList();

                if (item.Sotar == null && item.thickness == null)
                {
                    item1.ItemComplete = item.ItemName.Trim() + "  " + "  " + " " + item.City.Trim();
                }

                else if (item.thickness == null)
                {
                    item1.ItemComplete = item.ItemName.Trim() + "  " + item.Sotar.Trim() + "  " + " " + item.City.Trim();
                }

                else if (item.Sotar == null)
                {
                    item1.ItemComplete = item.ItemName.Trim() + "  " + "  " + item.thickness.Trim() + " " + item.City.Trim();
                }

                else
                {
                    item1.ItemComplete = item.ItemName.Trim() + "  " + item.Sotar.Trim() + "  " + item.thickness.Trim() + " " + item.City.Trim();
                }
                
                item1.ItemId = item.ItemId;
                ItemsDropDownList.Add(item1);
            }
            return ItemsDropDownList;
        }



        public static List<ItemDropDownList> GetExtrasList()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var extras = db.Items.Where(aa => aa.IsExtra == true).ToList();
            List<ItemDropDownList> ExtrasDropDownList = new List<ItemDropDownList>();

            ItemDropDownList itemA = new ItemDropDownList();
            itemA.ItemComplete = "Select Extras";
            itemA.ItemId = 0;

            ExtrasDropDownList.Add(itemA);

            foreach (var extra in extras)
            {
                ItemDropDownList extra1 = new ItemDropDownList();

                extra1.ItemComplete = extra.ItemName.Trim();
                extra1.ItemId = extra.ItemId;
                ExtrasDropDownList.Add(extra1);
            }
            return ExtrasDropDownList;

        }

        public static List<ItemDropDownList> GetOrderItems(Order order)
        {
            List<ItemDropDownList> itemDropDownList = new List<ItemDropDownList>();
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var items = db.OrderLines.Where(aa => aa.OrderId == order.OrderId).Select(aa => aa.Item).ToList();

            foreach (var item in items)
            {
                if (item.IsExtra==false)
                {
                    ItemDropDownList item1 = new ItemDropDownList();
                    item1.ItemComplete = item.ItemName.Trim() + "  " + item.Sotar.Trim() + "  " + item.thickness.Trim() + " " + item.City.Trim();
                    item1.ItemId = item.ItemId;
                    itemDropDownList.Add(item1);
                }
            }

            return itemDropDownList;
        }


        public static ItemDropDownList ConverItemToItemComplete(Item item)
        {
            ItemDropDownList item1 = new ItemDropDownList();

            if (item.Sotar == null && item.thickness == null)
            {
                item1.ItemComplete = item.ItemName.Trim() + "  " + "  " + " " + item.City.Trim();
            }

            else if (item.thickness == null)
            {
                item1.ItemComplete = item.ItemName.Trim() + "  " + item.Sotar.Trim() + "  " + " " + item.City.Trim();
            }

            else if (item.Sotar == null)
            {
                item1.ItemComplete = item.ItemName.Trim() + "  " + "  " + item.thickness.Trim() + " " + item.City.Trim();
            }

            else
            {
                item1.ItemComplete = item.ItemName.Trim() + "  " + item.Sotar.Trim() + "  " + item.thickness.Trim() + " " + item.City.Trim();
            }

            
            item1.ItemId = item.ItemId;
            return item1;
        }

    }
}
