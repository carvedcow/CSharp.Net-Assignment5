using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Net_Assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {

            /* --------------------------------
              Question 1
             Write a program in C# Sharp to display the number and frequency of number from given array.
            Expected Output : 
            -The number and the Frequency are : 
            -Number 5 appears 3 times 
            -Number 9 appears 2 times 
            -Number 1 appears 1 times 
            */

            IList<int> intList1 = new List<int>() { 5, 9, 1, 5, 5, 9};

            var groupedIntList = intList1.GroupBy(i => i);
            Console.WriteLine("----- Question 1 -----\n");
            Console.WriteLine("-The numbers and frequencies are : ");
            foreach (var intGroup in groupedIntList)
            {
                Console.WriteLine("Number {0} appears {1} time(s)", intGroup.Key, intGroup.Count());
            }

            /* --------------------------------
            Question 2

            Write a program with LINQ Sharp to display the top nth records. 
            Test Data : 
            The members of the list are : 5 7 13 24 6 9 8 7 
            How many records you want to display ? : 3 
            Expected Output : 
            The top 3 records from the list are : 24 13 9 
            */
            IList<int> intList2 = new List<int>() { 5, 7, 13, 24, 6, 9, 8, 7 };
            Console.WriteLine("----- Question 2 -----\n");
            Console.WriteLine("Your current int array is: [5, 7, 13, 24, 6, 9, 8, 7]");
            Console.WriteLine("How many record(s) do you want to display ? : ");
            int count = Convert.ToInt32(Console.ReadLine());
            var sortedIntList2 = (from i in intList2 orderby i descending select i).Take(count);
            Console.Write("The top {0} record(s) from the list is/are : ", count);
            foreach (var i in sortedIntList2)
            {
                Console.Write("{0} ", i);
            }

            /* --------------------------------
            Question 3

            Write a program with LINQ to generate an Inner Join between two data sets. 
            public class Item_mast
            {
                public int ItemId { get; set; }
                public string ItemDes { get; set; }
            }

            public class Purchase
            {
                public int InvNo { get; set; }
                public int ItemId { get; set; }
                public int PurQty { get; set; }
            }
             */
            IList<Item_mast> itemList = new List<Item_mast>()
            {
                new Item_mast(){ ItemId = 0, ItemDes = "A red fruit."},
                new Item_mast(){ ItemId = 1, ItemDes = "An orange fruit."},
                new Item_mast(){ ItemId = 2, ItemDes = "A yellow fruit."}
            };

            IList<Purchase> purchaseList = new List<Purchase>()
            {
                new Purchase(){ InvNo = 1111111, ItemId = 0, PurQty = 3},
                new Purchase(){ InvNo = 1111112, ItemId = 1, PurQty = 5}
            };

            var itemPurchaseJoin = from i in itemList join p in purchaseList
                                   on i.ItemId equals p.ItemId
                                   select new { itemID = i.ItemId, purchaseQty = p.PurQty };

            Console.WriteLine("\n----- Question 3 -----\n");
            foreach (var item in itemPurchaseJoin)
            {
                Console.WriteLine("ItemID {0} has been purchased {1} time(s).", item.itemID, item.purchaseQty);
            }
            
        }
        public class Item_mast
        {
            public int ItemId { get; set; }
            public string ItemDes { get; set; }
        }

        public class Purchase
        {
            public int InvNo { get; set; }
            public int ItemId { get; set; }
            public int PurQty { get; set; }
        }
    }
}
