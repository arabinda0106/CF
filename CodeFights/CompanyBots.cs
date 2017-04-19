using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class MyComparer : IComparer<string>
    {
        public int Compare(string inputA, string inputB)
        {
            if (inputA == inputB)
                return 0;

            if (LexicographicallySmaller(inputA, inputB) == inputA)
                return -1;
            else
                return 1;

        }
        private string LexicographicallySmaller(string inputA, string inputB)
        {
            if (inputA != inputB)
            {
                if (inputA.Length > inputB.Length && inputA.Substring(0, inputB.Length) == inputB)
                    return inputB;
                else if (inputB.Length > inputA.Length && inputB.Substring(0, inputA.Length) == inputA)
                    return inputA;
            }
            else
                return inputA;

            bool inputALexicographicallySmaller = false;

            for (int i = 0; i < Min(inputA.Length, inputB.Length); i++)
            {
                if (inputA[i] < inputB[i])
                {
                    inputALexicographicallySmaller = true;
                    break;
                }
                else if (inputA[i] > inputB[i])
                    break;

                for (int j = 0; j < i; j++)
                {
                    if (inputA[j] == inputB[j] && j == i - 1)
                    {
                        inputALexicographicallySmaller = true;
                        break;
                    }
                }

                if (inputALexicographicallySmaller == true && i == Min(inputA.Length, inputB.Length) - 1)
                    break;
                else
                    inputALexicographicallySmaller = false;
            }

            if (inputALexicographicallySmaller)
                return inputA;
            else
                return inputB;
        }

        private int Min(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
    }

    public class CompanyBots
    {

        /*
                This time you are an Uber driver and you are trying your best to park your car in a parking lot.

                Your car has length carDimensions[0] and width carDimensions[1]. You have already picked your lucky spot (rectangle of the same size as the car with upper left corner at (luckySpot[0], luckySpot[1])) and bottom right corner at (luckySpot[2], luckySpot[3]) and you need to find out if it's possible to park there or not.

                It is possible to park your car at a given spot if and only if you can drive through the parking lot without any turns to your lucky spot (for safety reasons, the car can only move in two directions inside the parking lot - forwards or backwards along the long side of the car) starting from some side of the lot (all four sides are valid options).

                Naturally, you can't park your car if the lucky sport is already occupied. The car can't drive through or park at any of the occupied spots.

                Example

                For carDimensions = [3, 2],

                parkingLot = [[1, 0, 1, 0, 1, 0],
                              [0, 0, 0, 0, 1, 0],
                              [0, 0, 0, 0, 0, 1],
                              [1, 0, 1, 1, 1, 1]]
                and
                luckySpot = [1, 1, 2, 3], the output should be
                parkingSpot(carDimensions, parkingLot, luckySpot) = true.



                For carDimensions = [3, 2],

                parkingLot = [[1, 0, 1, 0, 1, 0],
                              [1, 0, 0, 0, 1, 0],
                              [0, 0, 0, 0, 0, 1],
                              [1, 0, 0, 0, 1, 1]]
                and
                luckySpot = [1, 1, 2, 3], the output should be
                parkingSpot(carDimensions, parkingLot, luckySpot) = false;

                For carDimensions = [4, 1],
                the same parkingLot as in the previous example and
                luckySpot = [0, 3, 3, 3], the output should be
                parkingSpot(carDimensions, parkingLot, luckySpot) = true.

                Input/Output

                [time limit] 3000ms (cs)
                [input] array.integer carDimensions

                Array of two positive integers. It is guaranteed that carDimensions[0] > carDimensions[1].

                Constraints:
                1 ≤ carDimensions[i] ≤ 10.

                [input] array.array.integer parkingLot

                2-dimensional array, where parkingLot[x][y] is 1 if cell (x, y) is occupied and is 0 otherwise.

                Constraints:
                3 ≤ parkingLot.length ≤ 10,
                3 ≤ parkingLot[0].length ≤ 10.

                [input] array.integer luckySpot

                Array of four integers - coordinates of your lucky spot at the parking lot.
                It is guaranteed that one of the following statements is true:

                luckySpot[2] - luckySpot[0] + 1 = carDimensions[0] and
                luckySpot[3] - luckySpot[1] + 1 = carDimensions[1];
                luckySpot[2] - luckySpot[0] + 1 = carDimensions[1] and
                luckySpot[3] - luckySpot[1] + 1 = carDimensions[0].
                Constraints:
                0 ≤ luckySpot[0] ≤ luckySpot[2] < parkingLot.length,
                0 ≤ luckySpot[1] ≤ luckySpot[3] < parkingLot[i].length.

                [output] boolean

                true if it is possible to park your car, false otherwise. 
                */
        public bool parkingSpot(int[] carDimensions, int[][] parkingLot, int[] luckySpot)
        {
            carDimensions = new int[] { 3, 2 };

            carDimensions = new int[] { 3, 1 };

            parkingLot = new int[][] { new int[] { 1, 0, 1, 0, 1, 0 },
                                       new int[] { 1, 0, 0, 0, 1, 0 },
                                       new int[] { 0, 0, 0, 0, 0, 1 },
                                       new int[] { 1, 0, 0, 0, 1, 1 }
                                     };

            parkingLot = new int[][] { new int[] { 1, 0, 1, 1, 1, 0 },
                                       new int[] { 1, 0, 0, 0, 1, 0 },
                                       new int[] { 0, 0, 0, 0, 0, 1 },
                                       new int[] { 1, 0, 0, 0, 1, 1 }
                                     };

            parkingLot = new int[][] { new int[] { 1, 2, 3, 4, 5, 6 },
                                       new int[] { 7, 8, 9, 10, 11, 12 },
                                       new int[] { 13, 14, 15, 16, 17, 18 },
                                       new int[] { 19, 20, 21, 22, 23, 24 }
                                     };

            luckySpot = new int[] { 1, 1, 2, 3 };

            luckySpot = new int[] { 1, 3, 3, 3 };


            bool parkingAvailable = false;

            int parkingLotWidth = 0;
            int parkingLotLength = 0;

            if (parkingLot[0].Length < parkingLot.Length)
            {
                parkingLotWidth = parkingLot[0].Length;
                parkingLotLength = parkingLot.Length;
            }
            else
            {
                parkingLotWidth = parkingLot.Length;
                parkingLotLength = parkingLot[0].Length;
            }

            int carLength = carDimensions[0];
            int carwidth = carDimensions[1];

            if (carLength > parkingLotLength || carwidth > parkingLotWidth)
                return false;

            //check if the parking lot is free
            for (int count = luckySpot[0]; count <= luckySpot[2]; count++)
            {
                for (int count1 = luckySpot[1]; count1 <= luckySpot[3]; count1++)
                {
                    if (parkingLot[count][count1] == 1)
                    {
                        //Console.WriteLine(parkingLot[count][count1]);
                        return false;
                    }
                }
            }

            bool parkingInXAxis = false;

            if (Math.Abs(luckySpot[0] - luckySpot[2]) > Math.Abs(luckySpot[1] - luckySpot[3]))
                parkingInXAxis = false;
            else
                parkingInXAxis = true;

            if (parkingInXAxis == true)
            {
                //check if the entry to the parking lot is free
                //First check if the entry from the shorter side of the parking is free
                parkingAvailable = FindIfEntranceIsFree(parkingLot, luckySpot[0], luckySpot[2], 0, luckySpot[1] - 1);

                //Now check if the entry from the other side of the shorter side of parking is free
                if (!parkingAvailable)
                    parkingAvailable = FindIfEntranceIsFree(parkingLot, luckySpot[0], luckySpot[2], luckySpot[3] + 1, parkingLotLength - 1);
            }
            else
            {
                //check if the entry to the parking lot is free
                //First check if the entry from the shorter side of the parking is free
                if ((luckySpot[0] - 1) < 0)
                    parkingAvailable = true;
                else
                    parkingAvailable = FindIfEntranceIsFree(parkingLot, 0, luckySpot[0] - 1, luckySpot[1], luckySpot[3]);

                //Now check if the entry from the other side of the shorter side of parking is free
                if (!parkingAvailable)
                {
                    if (luckySpot[2] + 1 >= parkingLotWidth)
                        parkingAvailable = true;
                    else
                        parkingAvailable = FindIfEntranceIsFree(parkingLot, luckySpot[2], parkingLotWidth - 1, luckySpot[1], luckySpot[3]);
                }
            }

            return parkingAvailable;
        }

        bool FindIfEntranceIsFree(int[][] parkingLot, int yAxisStart, int yAxisEnd, int xAxisStart, int xAxisEnd)
        {
            bool parkingAvailable = true;

            for (int count = yAxisStart; count <= yAxisEnd; count++)
            {
                for (int count1 = xAxisStart; count1 <= xAxisEnd; count1++)
                {
                    if (parkingLot[count][count1] == 1)
                    {
                        parkingAvailable = false;
                        break;
                    }
                }
                if (parkingAvailable == false)
                    break;
            }

            return parkingAvailable;
        }


        /*
        Before delivery, all orders at Jet are packed into boxes to protect them from damage.

        Consider a package pkg of a given size that needs to be packed into a box chosen from a list of available boxes. The package should fit inside the box, keeping in mind that the size of the package should not exceed the size of the box in any dimension (note that the package can be rotated to fit and it can be positioned upside down). For the sake of efficiency, among the available boxes that fit, the one with smallest volume should be chosen.

        Given a package pkg and available boxes, find the 0-based index of the smallest-by-volume box such that the package fits inside it, or return -1 if there is no such box.

        Example

        For pkg = [4, 2, 5] and boxes = [[4, 3, 5], [5, 2, 5]], the output should be
        packageBoxing(pkg, boxes) = 1.
        The package fits into both boxes, but the volume of the first one (4 * 3 * 5 = 60) is greater than the volume of the second (5 * 5 * 2 = 50).

        For pkg = [4, 4, 2] and boxes = [[2, 4, 4], [4, 4, 3]], the output should be
        packageBoxing(pkg, boxes) = 0.
        The package can fit into the first box if it is rotated, and into the second box as-is, but the first box is chosen because it has less volume overall.

        For pkg = [4, 5, 3] and boxes = [[3, 10, 2], [2, 6, 7], [1, 1, 1]], the output should be
        packageBoxing(pkg, boxes) = -1.
        The package doesn't fit into any of the available boxes.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer pkg

        Array of three positive integers denoting the size of the package as its width, height and length.

        Constraints:
        1 ≤ pkg[i] ≤ 500.

        [input] array.array.integer boxes

        Every box is given as an array of three positive integers denoting its width, height and length.
        It is guaranteed that each box has a unique volume.

        Constraints:
        0 ≤ boxes.length ≤ 15,
        1 ≤ boxes[i][j] ≤ 500.

        [output] integer

        The 0-based index of the smallest-by-volume box such that the package fits inside it, or -1 if there is no such box.
        */

        public int packageBoxing(int[] pkg, int[][] boxes)
        {
            //pkg = new int[] { 4, 2, 5 };
            pkg = new int[] { 4, 4, 2 };

            //boxes = new int[][] { new int[] { 4, 3, 5 }, 
            //                      new int[] { 5, 2, 5 }
            //                    };

            boxes = new int[][] { new int[] { 2, 4, 4 },
                                  new int[] { 4, 4, 3 }
                                };

            int lastAcceptableIndex = -1;
            int lastAcceptableBoxVolume = 0;

            for (int count = 0; count < boxes.Length; count++)
            {
                Array.Sort(pkg);
                Array.Sort(boxes[count]);

                if ((pkg[0] <= boxes[count][0]) && (pkg[1] <= boxes[count][1]) && (pkg[2] <= boxes[count][2]))
                {
                    int currentBoxVolume = boxes[count][0] * boxes[count][1] * boxes[count][2];

                    if ((lastAcceptableIndex == -1) || (currentBoxVolume < lastAcceptableBoxVolume))
                    {
                        lastAcceptableIndex = count;
                        lastAcceptableBoxVolume = currentBoxVolume;
                    }
                }
            }

            return lastAcceptableIndex;
        }

        /*
        Jet.com customers can easily find the item they are looking for by browsing by category. Categories are stored in a catalog that is updated on a regular basis as inventory changes. Your goal is to implement an algorithm that updates the catalog with new items.

        The catalog is given as a two-dimensional array. For each i, catalog[i][0] represents the name of the corresponding category, and catalog[i][j] for j > 0 is the name of some item within this category, which can also be the category of some other items. For each i all elements of catalog[i] except the first are sorted lexicographically, and catalog arrays are sorted lexicographically by their first elements. The name of the topmost directory is "root".

        Given a list of updates, update the catalog with the new items and return the result.

        Example

        For

        catalog = [["Books", "Classics", "Fiction"],
                   ["Electronics", "Cell Phones", "Computers", "Ultimate item"],
                   ["Grocery", "Beverages", "Snacks"],
                   ["Snacks", "Chocolate", "Sweets"],
                   ["root", "Books", "Electronics", "Grocery"]]
        and

        updates = [["Snacks", "Marmalade"],
                   ["Fiction", "Harry Potter"],
                   ["root", "T-shirts"],
                   ["T-shirts", "CodeFights"]]
        the output should be

        catalogUpdate(catalog, updates) = [["Books", "Classics", "Fiction"],
                                           ["Electronics", "Cell Phones", "Computers", "Ultimate item"],
                                           ["Fiction", "Harry Potter"],
                                           ["Grocery", "Beverages", "Snacks"],
                                           ["Snacks", "Chocolate", "Marmalade", "Sweets"],
                                           ["T-shirts", "CodeFights"],
                                           ["root", "Books", "Electronics", "Grocery", "T-shirts"]]
        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.string catalog

        The initial catalog in the format described above. It is guaranteed that the catalog is correct, i.e. there are no duplicate elements, category[i][0] = "root" for some i, and for each t ≠ i category[t][0] is equal to exactly one category[j][k], where j ≠ t and k > 0.

        Constraints:
        1 ≤ catalog.length ≤ 10,
        2 ≤ catalog[i].length ≤ 5,
        1 ≤ catalog[i][j].length ≤ 45.

        [input] array.array.string updates

        Array of updates. Each update is a two-element array in the format [<parent_category>, <item_name>], where <parent_category> is the name of the category the item belongs to, and <item_name> is the item name.
        The elements of update should be considered in the order they are given.
        It is guaranteed that <parent_category> is always present in the catalog at the time the corresponding update is made.

        Constraints:
        0 ≤ updates.length ≤ 15,
        2 ≤ updates[i].length ≤ 2,
        3 ≤ updates[i][j].length ≤ 24.

        [output] array.array.string

        The updated catalog, formatted as it is initially given. The elements should be sorted as described above, and all elements of the resulting array should contain at least two elements each.
         */
        public string[][] catalogUpdate(string[][] catalog, string[][] updates)
        {
            CommonSubroutines cs = new CommonSubroutines();

            //catalog = new string[][] { new string [] { "Books", "Classics", "Fiction" },
            //                           new string [] { "Electronics", "Cell Phones", "Computers", "Ultimate item" },
            //                           new string [] { "Grocery", "Beverages", "Snacks" },
            //                           new string [] { "Snacks", "Chocolate", "Sweets" },
            //                           new string [] { "root", "Books", "Electronics", "Grocery" }
            //                         };

            //updates = new string[][] { new string [] {"Snacks", "Marmalade" },
            //                           new string [] {"Fiction", "Harry Potter" },
            //                           new string [] {"root", "T-shirts" },
            //                           new string [] {"T-shirts", "CodeFights" }
            //                         };

            //catalog = new string[][] { new string[] { "root", "All", "Fiction", "here", "topics" } };

            //updates = new string[][] { new string [] { "root", "and" },
            //                           new string [] { "root","Fiction stories" },
            //                           new string [] { "Fiction stories","The Chronicles of Narnia" },
            //                           new string [] { "root","T-shirts-men" },
            //                           new string [] { "root","words" },
            //                           new string [] { "T-shirts-men","My little pony t-shirt" },
            //                           new string [] { "T-shirts-men","T-shirts" },
            //                           new string [] { "Fiction","Harry Potter" },
            //                           new string [] { "root","and good T-shirts" },
            //                           new string [] { "T-shirts","CodeFights" }
            //                         };

            //catalog = new string[][] { new string [] { "Books", "Classics", "Fiction " },
            //                           new string [] { "Electronics","Cell Phones","Computers","Ultimate item" },
            //                           new string [] { "Grocery","Beverages","Snacks" },
            //                           new string [] { "Snacks","Chocolate","Sweets" },
            //                           new string [] { "root","Books","Electronics","Grocery" }
            //                         };

            //updates = new string[][] { new string [] { "Snacks", "Marmalade" },
            //                           new string [] { "Fiction ","The Chronicles of Narnia" },
            //                           new string [] { "Fiction ","Fiction stories" },
            //                           new string [] { "Books","Abc" },
            //                           new string [] { "Snacks","Tuc" },
            //                           new string [] { "root","T-shirts-men" },
            //                           new string [] { "T-shirts-men","My little pony t-shirt" },
            //                           new string [] { "Fiction ","Harry Potter" },
            //                           new string [] { "root","T-shirts" },
            //                           new string [] { "T-shirts","CodeFights" },
            //                           new string [] { "Fiction stories","Frozen heart" },
            //                           new string [] { "Fiction stories","Marvel films" },
            //                           new string [] { "Marvel films","Ant-man" },
            //                           new string [] { "Marvel films","Avengers" }
            //                        };


            //catalog = new string[][] { new string[] { "root", "All", "Fiction", "here", "topics" } };

            //updates = new string[][] { new string[] { "root", "and", "sand" },
            //                           new string [] { "root","Fiction stories" },
            //                           new string [] { "Fiction stories","The Chronicles of Narnia" },
            //                           new string [] { "root","T-shirts-men" },
            //                           new string [] { "root","words" },
            //                           new string [] { "sand","test" },
            //                           new string [] { "and","test1" },
            //                           new string [] { "T-shirts-men","My little pony t-shirt" },
            //                           new string [] { "T-shirts-men","T-shirts" },
            //                           new string [] { "Fiction","Harry Potter" },
            //                           new string [] { "root","and good T-shirts" },
            //                           new string [] { "T-shirts","CodeFights" }
            //                        };

            string[] rootCatalog = Array.Find(catalog, element => element[0].Equals("root"));

            int rootCatalogIndex = -1;

            if (rootCatalog != null)
                rootCatalogIndex = Array.IndexOf(catalog, rootCatalog);

            string[][] updateRootCatalog = Array.FindAll(updates, element => element[0].Equals("root"));

            List<string> rootCtlgList = new List<string>();

            if (rootCatalogIndex > -1)
                rootCtlgList = catalog[rootCatalogIndex].ToList();
            else
                rootCtlgList.Add("root");

            if (updateRootCatalog != null)
            {
                foreach (string[] category in updateRootCatalog)
                {
                    for (int i = 1; i < category.Length; i++)
                    {
                        rootCtlgList.Add(category[i]);
                    }
                }
            }

            List<List<string>> updatedCatalog = new List<List<string>>();

            if (rootCtlgList.Count > 0)
                updatedCatalog.Add(rootCtlgList);

            foreach (string[] ctlg in updates)
            {
                if (ctlg[0] != "root")
                {
                    string[][] category = Array.FindAll(catalog, element => element[0].Equals(ctlg[0]));

                    List<string> categoryList = new List<string>();

                    categoryList.Add(ctlg[0]);

                    if (category != null)
                    {
                        foreach (string[] ctgry in category)
                        {
                            List<string> ctgryList = ctgry.ToList();

                            for (int i = 1; i < ctgryList.Count; i++)
                            {
                                if (categoryList.FindIndex(element => element.Equals(ctgryList[i])) == -1)
                                    categoryList.Add(ctgryList[i]);
                            }
                        }
                    }

                    for (int i = 1; i < ctlg.Length; i++)
                    {
                        if (categoryList.FindIndex(element => element.Equals(ctlg[i])) == -1)
                            categoryList.Add(ctlg[i]);
                    }

                    //Now if the same category has already been added to updatedCatalog, we need to update that.

                    int index = updatedCatalog.FindIndex(element => element[0].Equals(categoryList[0]));

                    if (index > -1)
                    {
                        List<string> ctgryList = updatedCatalog.Find(element => element[0].Equals(categoryList[0]));
                        updatedCatalog.RemoveAt(index);

                        for (int i = 1; i < ctgryList.Count; i++)
                        {
                            if (categoryList.FindIndex(element => element.Equals(ctgryList[i])) == -1)
                                categoryList.Add(ctgryList[i]);
                        }
                    }

                    updatedCatalog.Add(categoryList);
                }
            }

            //convert the catalog to List of lists

            List<List<string>> originalCatalogList = new List<List<string>>();

            foreach (string[] category in catalog)
            {
                originalCatalogList.Add(category.ToList());
            }

            //update the original catalog with the updated List
            foreach (List<string> category in updatedCatalog)
            {
                int index = originalCatalogList.FindIndex(element => element[0].Equals(category[0]));
                if (index > -1)
                    originalCatalogList.RemoveAt(index);

                originalCatalogList.Add(category);
            }

            //originalCatalogList
            List<List<string>> SortedCategoriesList = originalCatalogList.OrderBy(o => o[0]).ToList();

            List<string> categories = new List<string>();

            foreach (List<string> category in originalCatalogList)
            {
                categories.Add(category[0]);
            }

            categories = cs.LexicographicallyMergeSortedList(categories);
            //categories = cs.LexicographicallyBubbleSortedList(categories);

            List<List<string>> updatedCatalogListWithSortedItems = new List<List<string>>();

            for (int i = 0; i < originalCatalogList.Count; i++)
            {
                List<string> SortedList = originalCatalogList.Find(element => element[0].Equals(categories[i]));

                string firstElement = SortedList[0];

                SortedList = cs.LexicographicallyMergeSortedList(SortedList);
                //SortedList = cs.LexicographicallyBubbleSortedList(SortedList);

                SortedList.RemoveAt(SortedList.FindIndex(element => element.Equals(firstElement)));
                SortedList.Insert(0, firstElement);

                updatedCatalogListWithSortedItems.Add(SortedList);
            }

            return updatedCatalogListWithSortedItems.Select(a => a.ToArray()).ToArray();

        }

        /*
        Jet is building a new feature designed to significantly reduce order delivery times. However, faster delivery sometimes means higher shipping fees, and for cost-conscious customers this might be a problem. Your task is to implement a function that finds the fastest delivery time for a given order, taking into account that the customer doesn't want to pay more than maxPrice.

        Consider a customer's basket of items. You are given a list of available vendors from which you can order these items. For each vendor you know the products they provide with their price (vendorProducts) and the time it will take to deliver them (vendorsDelivery). Find the vendors that should be chosen so that the total price of items in the basket is not greater than the maxPrice, while keeping delivery time to a minimum. The delivery time is the maximum delivery time of all chosen vendors.

        You should only choose vendors you're going to buy something from. It is guaranteed that there is always exactly one solution.

        Example

        For maxPrice = 7, vendorsDelivery = [5, 4, 2, 3] and

        vendorsProducts = [[1, 1, 1],
                           [3, -1, 3],
                           [-1, 2, 2],
                           [5, -1, -1]]
        the output should be
        minimalBasketPrice(maxPrice, vendorsDelivery, vendorsProducts) = [1, 2].

        There are three items in the basket, so here is the list of options:

        although vendor 0 can provide all items for the lowest price, it will take 5 days to deliver them;
        vendors 1 and 2 can deliver all items in 4 and 2 days respectively, so in 4 days all of the items will have been delivered. It would cost 3 + 2 + 2 = 7 (note that the 2nd 0-based item is provided by both vendors, but since the price at vendor number 2 is lower, that's where we would purchase it);
        vendors 2 and 3 will deliver everything in just 3 days, but it would cost 2 + 2 + 5 = 9, which is too much.
        Thus, vendors 1 and 2 should be chosen to fulfill the order.

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer maxPrice

        The maximum amount of money the customer is willing to pay.

        Constraints:
        1 ≤ maxPrice ≤ 106

        [input] array.integer vendorsDelivery

        For each valid i, vendorsDelivery[i] is the number of days it will take the ith vendor to deliver the goods.

        Constraints:
        1 ≤ vendorsDelivery.length ≤ 100
        1 ≤ vendorsDelivery[i] ≤ 106 + 1

        [input] array.array.integer vendorsProducts

        Rectangular matrix with vendorsDelivery.length rows. The number of its columns equals the number of items in the basket.
        If vendors[i][j] > 0, then the ith vendor provides the jth item, and it costs vendors[i][j].
        vendors[i][j] = -1 otherwise, which means that the ith vendor doesn't provide the jth item.

        Constraints:
        vendorsProducts.length = vendorsDelivery.length,
        1 ≤ vendorsProducts[0].length ≤ 100,
        -1 ≤ vendorsProducts[i][j] ≤ 106.

        [output] array.integer

        A sorted array of 0-based indices of the vendors that should be chosen to fulfill the order.

        The order is fulfilled if for each item j (0 ≤ j < vendors[0].length) there is a vendor which provides it.         
        */
        public int[] minimalBasketPrice(int maxPrice, int[] vendorsDelivery, int[][] vendorsProducts)
        {
            maxPrice = 7;
            vendorsDelivery = new int[] { 5, 4, 2, 3 };
            vendorsProducts = new int[][] { new int[] { 1, 1, 1 },
                                            new int[] { 3, -1, 3 },
                                            new int[] { -1, 2, 2 },
                                            new int[] { 5, -1, -1 }
                                          };

            int numOfProducts = vendorsProducts[0].Length;
            int numOfvendors = vendorsProducts.Length;

            //List<>

            List<int> vendorsDeliveryList = vendorsDelivery.ToList();
            var sortedVendorsDeliveryList = vendorsDeliveryList.Select((x, i) => new KeyValuePair<int, int>(x, i)).OrderBy(x => x.Key).ToList();

            for (int i = 0; i < vendorsProducts.Length; i++)
            {
                int totalShippingPrice = 0;

                for (int j = 0; j < sortedVendorsDeliveryList.Count; j++)
                {
                    int vendorIndex = sortedVendorsDeliveryList[j].Value;

                    if (vendorsProducts[vendorIndex][i] == -1)
                    {

                    }
                    else
                        totalShippingPrice = vendorsProducts[vendorIndex][i];


                    //totalShippingPrice = vendorsProducts[vendorIndex].AsEnumerable().Sum(o => 0);

                }
            }



            return new int[] { };
        }

        /*
        Your first assignment as a Jet employee is to build an internal dashboard of various order statistics and how they change over time. The 3 most important values that should be calculated are the maximum price, average price and standard deviation.

        To observe the evolution of these values in the given list of prices, for the given number n you should consider the following running sets of orders:

        the nth order at the end;
        the nth and (n - 1)th orders at the end;
        the nth, (n - 1)th and (n - 2)th orders at the end;
        ...
        n last orders, from the nth at the end to the most recent one.
        For each of the running sets, calculate the required statistics and return them in arrays comprised of three elements.
        When it's impossible to calculate the standard deviation, return -1 instead.

        Example

        For orders = [4, 2, 5, 9, 2] and n = 5, the output should be

        jetDashboard(orders, n) = [[4, 4.0,     -1], 
                                   [4, 3.0,     1.41421], 
                                   [5, 3.66667, 1.52752], 
                                   [9, 5.0,     2.94392],
                                   [9, 4.4,     2.88097]]
        The values are calculated for the following running sets: [4], [4, 2], [4, 2, 5], [4, 2, 5, 9] and [4, 2, 5, 9, 2].

        For orders = [4, 2, 5, 9, 2] and n = 3, the output should be

        jetDashboard(orders, n) = [[5, 5.0,     -1], 
                                   [9, 7.0,     2.82843],
                                   [9, 5.33333, 3.51188]]
        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer orders

        Array of orders, where orders[i] is a positive integer denoting the price of the ith order.

        Constraints:
        1 ≤ orders.length ≤ 100,
        0 ≤ orders[i] ≤ 1000.

        [input] integer n

        The length of the time period.

        Constraints:
        1 ≤ n ≤ orders.length.

        [output] array.array.float

        A two-dimensional array of n elements. For each 0 ≤ i < n the ith element should contain statistics of the ith running set in the following format: [max_price, average_price, standard_deviation].

        Your answer will be considered correct if the absolute error of each output element does not exceed 10-5.

         */
        public double[][] jetDashboard(int[] orders, int n)
        {
            CommonSubroutines cs = new CommonSubroutines();

            orders = new int[] { 4, 2, 5, 9, 2 };
            n = 5;

            n = 3;

            List<List<double>> orderdashboard = new List<List<double>>();

            int subsetStartingIndex = orders.Length - n;

            int subsetLength = 1;

            for (int i = orders.Length - n; i < orders.Length; i++)
            {
                List<double> orderDetails = new List<double>();

                int[] orderSubset = new int[subsetLength];

                Array.Copy(orders, subsetStartingIndex, orderSubset, 0, subsetLength);

                orderDetails.Add(orderSubset.Max());
                orderDetails.Add(orderSubset.Average(val => val));
                if (subsetLength == 1)
                    orderDetails.Add(-1);
                else
                    orderDetails.Add(cs.StandardDeviation(orderSubset.ToList().Select(v => (double)v)));

                orderdashboard.Add(orderDetails);

                subsetLength++;
            }

            return orderdashboard.Select(a => a.ToArray()).ToArray();
        }

        /*
        With Jet Smart Cart the more items you buy, the more you save. The algorithm behind how this works is a bit complicated, and since it's your first day at Jet you decide to ask one of your co-workers for more information. In return, you offer to implement a new cart update algorithm for them. The update algorithm works like this:

        Whenever a new customer visits jet.com, their shopping cart is initially empty. Once the customer starts shopping, the cart can receive any of the following requests:

        add : <item_name>: the <item_name> item was added to the cart;
        remove : <item_name>: the <item_name> item was removed from the cart;
        quantity_upd : <item_name> : <value>: the <item_name> quantity in the cart was changed by <value>, which is an integer in the format +a or -a;
        checkout: the customer has paid and the cart is now empty.
        Given a list of requests in the formats described above, return the state of the cart after they have been processed.

        Example

        For

        requests = ["add : milk",
                    "add : pickles",
                    "remove : milk",
                    "add : milk",
                    "quantity_upd : pickles : +4"]
        the output should be
        shoppingCart(requests) = ["pickles : 5", "milk : 1"];

        For

        requests = ["add : rock",
                    "add : paper",
                    "add : scissors",
                    "checkout",
                    "add : golden medal"]
        the output should be
        shoppingCart(requests) = ["golden medal : 1"].

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string requests

        Array of strings, where each string is a request in one of the formats described above. The following holds true:

        the add request item is guaranteed not to be present in the cart;
        the remove request item is guaranteed to be present in the cart;
        the quantity_upd request item is guaranteed to be present in the cart, and the quantity of the item is guaranteed to remain more than 0 after the update.
        [output] array.string

        Array of elements in the cart once all requests have been processed in the order they are received. Each string should be formatted as <item_name> : <item_quantity>, where <item_name> is the name of the item, and <item_quantity> is its quantity.
        */

        public string[] shoppingCart(string[] requests)
        {
            List<string[]> cartDetails = new List<string[]>();

            for (int i = 0; i <requests.Length; i++)
            {
                cartDetails = Process(requests[i], cartDetails);
            }

            string[] output = new string[cartDetails.Count()];

            for (int i = 0; i < cartDetails.Count(); i++)
            {
                output[i] = cartDetails[i][0].ToString() + " : " + cartDetails[i][1].ToString();
            }

            return output;
        }

        private List<string[]> Process(string requestDetails, List<string[]> input)
        {
            List<string[]> output = input;

            string[] itemDetails = requestDetails.Split(':');

            switch(itemDetails[0].Trim())
            {
                case "checkout":
                    output = new List<string[]>();
                    break;

                case "add":
                    output.Add(new string[] { itemDetails[1].Trim(), "1" });
                    break;

                case "remove":
                    output.RemoveAt(output.FindIndex(element => element[0] == itemDetails[1].Trim()));
                    break;

                case "quantity_upd":
                    int itemIndex = output.FindIndex(element => element[0] == itemDetails[1].Trim());

                    string[] item = output.Find(element => element[0] == itemDetails[1].Trim());

                    if (itemDetails[2].Trim().Substring(0,1)=="+")
                        output[itemIndex][1] = (Convert.ToInt32(item[1]) + Convert.ToInt32(itemDetails[2].Trim().Replace("+",""))).ToString();
                    else
                        output[itemIndex][1] = (Convert.ToInt32(item[1]) - Convert.ToInt32(itemDetails[2].Trim().Replace("-", ""))).ToString();
                    break;
            }

            return output;
        }

        /*
        At Jet.com, each customer is guaranteed quick service since there are always enough merchants available to fulfill a given order. To keep the number of available merchants high, Jet tries to minimize the number of merchants required to fulfill a given order.

        Consider a list of items the customer has ordered, and a list of available merchants. For each merchant it is known which items they have in their inventory. Calculate which merchants should fulfill the order so that all items are accounted for and the number of merchants is kept as small as possible. Return the answer as a 0-based array of merchant indices.

        If there are several possible answers, return the lexicographically smallest one. If there is no answer, return [-1] instead.

        Example

        For items = ["apples", "bananas", "kiwis"] and

        merchants = [["apples", "pineapples"],
                     ["apples", "kiwis"],
                     ["kiwis", "papayas", "bananas"],
                     ["bananas", "apples"]]
        the output should be
        merchantMinimization(items, merchants) = [0, 2].

        In this case it's impossible to use a single available merchant to fulfill the entire order. However, there are several sets of 2 merchants that could work:

        merchants 1 and 2;
        merchants 1 and 3;
        merchants 2 and 3;
        merchants 0 and 2.
        The last option forms the lexicographically smallest array, thus it is the correct answer.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string items

        Array of items in the order. It is guaranteed that each item name is unique.

        Constraints:
        1 ≤ items.length ≤ 12,
        1 ≤ items[i].length ≤ 15.

        [input] array.array.string merchants

        The list of available merchants. For each valid i, merchants[i] is an array of different strings representing items which the ith merchant can fulfill.

        Constraints:
        3 ≤ merchants.length ≤ 10,
        1 ≤ merchants[i].length ≤ 7,
        1 ≤ merchants[i][j].length ≤ 15.

        [output] array.integer

        The indices of the group of merchants that should fulfill the order or [-1] if there is no answer.
        */
        public int[] merchantMinimization(string[] items, string[][] merchants)
        {
            //Try to find single merchants first that can satisfy the entire item set, 
            //if not then try to find combinations of two merchants, if not then a combination of three merchants and so on.

            CommonSubroutines cs = new CommonSubroutines();

            List<List<string>> possibleCombinations = cs.PossibleCombinationsOfIndexes(merchants.Length, -1, new List<List<string>>());

            bool bestCombinationFound = false;
            int combinationIndexRow = -1;
            int combinationIndexColumn = -1;

            for (int i = 0; i < possibleCombinations.Count(); i++)
            {
                for (int j = 0; j < possibleCombinations[i].Count(); j++ )
                {
                    string[] vendorIndex = possibleCombinations[i][j].Split('|');

                    List <string> commonItems = new List<string>();

                    for (int k = 0; k < vendorIndex.Length; k++ )
                    {
                        for (int l = 0; l < merchants[Convert.ToInt32(vendorIndex[k]) - 1].Length; l++ )
                        {
                            commonItems.Add(merchants[Convert.ToInt32(vendorIndex[k]) - 1][l]);
                        }
                    }
                    if (CheckIfAllItemsCovered(commonItems, items))
                    {
                        bestCombinationFound = true;
                        combinationIndexRow = i;
                        combinationIndexColumn = j;
                        break;
                    }
                }

                if (bestCombinationFound)
                    break;
            }

            if (bestCombinationFound == false)
                return new int[] { -1 };

            string[] bestCombinationsString = possibleCombinations[combinationIndexRow][combinationIndexColumn].Split('|');

            int[] bestCombinations = new int[bestCombinationsString.Length];

            for (int i = 0; i < bestCombinationsString.Length; i ++)
            {
                bestCombinations[i] = Convert.ToInt32(bestCombinationsString[i]) - 1;
            }

            return bestCombinations;
        }

        private bool CheckIfAllItemsCovered(List<string> commonItems, string[] items)
        {
            if (commonItems.Intersect(items).ToArray().Length == items.Length)
                return true;
            else
                return false;
        }

        /*
        Two Sigma engineers process large amounts of data every day, much more than any single server could possibly handle. Their solution is to use collections of servers, or server farms, to handle the massive computational load. Maintaining the server farms can get quite expensive, and because each server farm is simultaneously used by a number of different engineers, making sure that the servers handle their backlogs efficiently is critical.
        Your goal is to optimally distribute a list of jobs between servers within the same farm. Since this problem cannot be solved in polynomial time, you want to implement an approximate solution using the Longest Processing Time (LPT) algorithm. This approach sorts the jobs by their associated processing times in descending order and then assigns them to the server that's going to become available next. If two operations have the same processing time the one with the smaller index is listed first. If there are several servers with the same availability time, then the algorithm assigns the job to the server with the smallest index.
        Given a list of job processing times, determine how the LPT algorithm will distribute the jobs between the servers within the farm.
        Example
        For jobs = [15, 30, 15, 5, 10] and servers = 3, the output should be
        serverFarm(jobs, servers) = [[1],
                                     [0, 4],
                                     [2, 3]]
        •	job with index 1 goes to the server with index 0;
        •	job with index 0 goes to server 1;
        •	job with index 2 goes to server 2;
        •	server 1 is going to be available next, since it got the job with the shortest processing time (15). Thus job 4 goes to server 1;
        •	finally, job 3 goes to server 2.
        Check out the image below for better understanding:

        Input/Output
        •	[time limit] 3000ms (cs)
        •	[input] array.integer jobs
        Unsorted array of positive integers representing the processing times of the given jobs.
        Constraints:
        0 ≤ jobs.length ≤ 100,
        1 ≤ jobs[i] ≤ 1000.
        •	[input] integer servers
        Constraints:
        1 ≤ servers ≤ 20.
        •	[output] array.array.integer
        Array consisting of job indices grouped by which server they were run on. The ith row should contain 0-based indices of the jobs that were run on the ith server in the order of processing. 

        */

        //var sortedVendorsDeliveryList = vendorsDeliveryList.Select((x, i) => new KeyValuePair<int, int>(x, i)).OrderBy(x => x.Key).ToList();
        public int[][] serverFarm(int[] jobs, int servers)
        {
            var sortedJobsList = jobs.Select((x, i) => new KeyValuePair<int, int>(x, i)).OrderByDescending(x => x.Key).ToList();

            List<List<int>> jobServerCombinations = new List<List<int>>();

            int jobsAssigned = 0;

            for (int i = 0; jobsAssigned < Math.Max(jobs.Length, servers); i ++)
            {
                if (jobServerCombinations.Count() == servers && jobsAssigned == jobs.Length)
                    break;

                if (i == servers && Math.Max(jobs.Length, servers) == jobs.Length)
                    i = 0;

                List<int> jobServer = new List<int>();

                if (i >= jobsAssigned && jobsAssigned == jobs.Length)
                {
                    jobServerCombinations.Add(new List<int>());
                    continue;
                }

                if (jobServerCombinations.Count() < servers)
                {
                    jobServer.Add(sortedJobsList[jobsAssigned].Value);
                    jobServerCombinations.Add(jobServer);
                }
                else
                {
                    List<int> processingTimeTotalList = new List<int>();

                    for (int j = 0; j < jobServerCombinations.Count(); j++)
                    {
                        int totalProcessingTime = 0;

                        for (int k = 0; k < jobServerCombinations[j].Count(); k++)
                        {
                            totalProcessingTime = totalProcessingTime + jobs[jobServerCombinations[j][k]];
                        }

                        processingTimeTotalList.Add(totalProcessingTime);
                    }

                    var sortedProcessingTimeTotalList = processingTimeTotalList.Select((x, l) => new KeyValuePair<int, int>(x, l)).OrderBy(x => x.Key).ToList();

                    int indexOfNextAvailableServer = sortedProcessingTimeTotalList[0].Value;

                    jobServer = jobServerCombinations[indexOfNextAvailableServer];

                    jobServer.Add(sortedJobsList[jobsAssigned].Value);
                    jobServerCombinations[indexOfNextAvailableServer] = jobServer;
                }

                jobsAssigned = jobsAssigned + 1;
            }

            return jobServerCombinations.Select(a => a.ToArray()).ToArray();
        }

        /*
        When visualizing market data over a long period of time, it is often helpful to build an Open-high-low-close (OHLC) chart. However, to build an OHLC chart you first need to prepare some data. For each financial instrument consider each day when it was traded, and find the following prices the instrument had that day:

        open price: the price of the first trade of the day;
        high price: the highest trade of the day;
        low price: the lowest trade of the day;
        close price: the price of the last trade of the day.
        Given a stream of trade data ordered by time, write a program to compute the OHLC by day and instrument (see output section for the format details). If two trades happen to have equal timestamps, then their order is determined by the order of their timestamps in the timestamp array.

        Example

        For

        timestamp = [1450625399, 1450625400, 1450625500, 
                     1450625550, 1451644200, 1451690100, 1451691000]
        instrument = ["HPQ", "HPQ", "HPQ", "HPQ", "AAPL", "HPQ", "GOOG"],
        side = ["sell", "buy", "buy", "sell", "buy", "buy", "buy"],
        price = [10, 20.3, 35.5, 8.65, 20, 10, 100.35] and
        size = [10, 1, 2, 3, 5, 1, 10], the output should be

        dailyOHLC(timestamp, instrument, side, price, size) = 
        [["2015-12-20", "HPQ", "10.00", "35.50", "8.65", "8.65"],
         ["2016-01-01", "AAPL", "20.00", "20.00", "20.00", "20.00"],
         ["2016-01-01", "GOOG", "100.35", "100.35", "100.35", "100.35"],
         ["2016-01-01", "HPQ", "10.00", "10.00", "10.00", "10.00"]]
        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer timestamp

        A nondecreasing sequence of positive integers. timestamp[i] stands for the Unix time when the ith trade was made.

        Constraints:
        1 ≤ timestamp.length ≤ 50,
        666 ≤ timestamp[i] < 2 · 109.

        [input] array.string instrument

        Array of the same length as timestamp. instrument[i] is the ticker symbol (identifier) for the financial instrument taking part in the ith trade.

        Constraints:
        instrument.length = timestamp.length,
        1 ≤ instrument[i].length ≤ 4.

        [input] array.string side

        Array of the same length as timestamp. side[i] equals either "buy" or "sell" depending on whether instrument[i] was bought or sold during the ith trade.

        Constraints:
        side.length = timestamp.length.

        [input] array.float price

        Array of the same length as timestamp. price[i] is the price of the instrument[i] during the ith trade. It is guaranteed that price[i] has no more than two digits after the decimal point.

        Constraints:
        price.length = timestamp.length,
        0.5 ≤ price[i] ≤ 100.5.

        [input] array.integer size

        Array of the same length as timestamp. size[i] equals the number of shares of the instrument[i] traded during the ith trade.

        Constraints:
        size.length = timestamp.length,
        1 ≤ size[i] ≤ 5 · 105.

        [output] array.array.string

        The ith row of the output should contain the following elements:

        output[i][0] - local sever date in the YYYY-MM-DD format;
        output[i][1] - a ticker symbol for some instrument;
        output[i][2] - a string corresponding to the open price;
        output[i][3] - a string corresponding to the high price;
        output[i][4] - a string corresponding to the low price;
        output[i][5] - a string corresponding to the close price.
        Each string corresponding to the price should contain exactly two digits after the decimal point and at least one digit before.

        For each unique pair of a date and an instrument present in the inputs, such that there was a trade of that instrument on that day, there should be exactly one row in the output.

        Output rows should be ordered by dates. Rows corresponding to the same date should be ordered in lexicographical order for ticker symbols.
        */

        public string[][] dailyOHLC(int[] timestamp, string[] instrument, string[] side, double[] price, int[] size)
        {
            List<List<string>> timestampInstrumentDetailsList = new List<List<string>>();

            for (int i = 0; i < timestamp.Count(); i++)
            {
                List<string> temp = new List<string>();

                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(timestamp[i]).ToLocalTime();
                temp.Add(dtDateTime.ToString("yyyy-MM-dd"));
                temp.Add(instrument[i]);
                temp.Add(price[i].ToString("0.00"));

                temp.Add(i.ToString());

                timestampInstrumentDetailsList.Add(temp);
            }

            var sortedList = timestampInstrumentDetailsList.OrderBy(x => x[0]).ThenBy(x => x[1], new MyComparer()).ThenBy(x => Convert.ToInt32(x[3])).ToList();

            List<List<string>> output = new List<List<string>>();

            for (int i = 0; i < sortedList.Count(); i++)
            {
                List<string> temp = new List<string>();

                if (i == 0)
                {
                    temp.Add(sortedList[i][0]);
                    temp.Add(sortedList[i][1]);
                    temp.Add(sortedList[i][2]);
                    temp.Add(sortedList[i][2]);
                    temp.Add(sortedList[i][2]);
                    temp.Add(sortedList[i][2]);

                    output.Add(temp);
                }
                else
                {
                    List<string> tempPrev = output[output.Count() - 1];

                    if (tempPrev[0] != sortedList[i][0] || tempPrev[1] != sortedList[i][1])
                    {
                        temp.Add(sortedList[i][0]);
                        temp.Add(sortedList[i][1]);
                        temp.Add(sortedList[i][2]);
                        temp.Add(sortedList[i][2]);
                        temp.Add(sortedList[i][2]);
                        temp.Add(sortedList[i][2]);

                        output.Add(temp);
                    }
                    else
                    {
                        if (Convert.ToDouble(tempPrev[3]) < Convert.ToDouble(sortedList[i][2]))
                            tempPrev[3] = sortedList[i][2];

                        if (Convert.ToDouble(tempPrev[4]) > Convert.ToDouble(sortedList[i][2]))
                            tempPrev[4] = sortedList[i][2];

                        tempPrev[5] = sortedList[i][2];

                        output[output.Count() - 1] = tempPrev;
                    }
                }
            }

            return output.Select(a => a.ToArray()).ToArray();
        }

        /*
        Each CodeFights Company Bot is trained by engineers from that specific company. The way it works is that a representative group of engineers from each company is identified as trainers before the bot goes live, and they CodeFight against the bot during a training phase. The current training algorithm is definitely more complex, but let's assume it works this way:

        For each trainer we collect two pieces of information per task [answerTime, correctness], where correctness is 1 if the answer was correct, -1 if the answer was wrong, and 0 if no answer was given. In this case, the bot's correct answer time for a given task would be the average of the answer times from the trainers who answered correctly. Given all of the training information for a specific task, calculate the bot's answer time.

        Example

        For

        trainingData = [[3, 1],
                        [6, 1],
                        [4, 1],
                        [5, 1]]
        the output should be companyBotStrategy(trainingData) = 4.5.

        All four trainers have solved the task correctly, so the answer is (3 + 6 + 4 + 5) / 4 = 4.5.

        For

        trainingData = [[4, 1],
                        [4, -1],
                        [0, 0],
                        [6, 1]]
        the output should be companyBotStrategy(trainingData) = 5.0.

        Only the 1st and the 4th trainers (1-based) submitted correct solutions, so the answer is (4 + 6) / 2 = 5.0.

        For

        trainingData = [[4, -1],
                        [0, 0],
                        [5, -1]]
        the output should be companyBotStrategy(trainingData) = 0.0.

        No correct answers were given for the task.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.integer trainingData

        The ith element of trainingData contains exactly 2 elements: trainingData[i][0] is the answer time for the ith person and trainingData[i][1] is correctness.

        If a trainer answered correctly, then correctness equals 1;
        If a trainer answered incorrectly, then correctness equals -1;
        If a trainer didn't give any answer, answerTime and correctness both equal to 0.
        Constraints:
        1 ≤ trainingData.length ≤ 20.

        [output] float

        The time the bot will take to solve a specific task. Return 0 if none of the trainers answered correctly. Your output will be considered correct if its absolute error does not exceed 10-5 compared to our tests.
        */
        public double companyBotStrategy(int[][] trainingData)
        {
            int count = 0;
            double output = 0;

            for(int i = 0; i < trainingData.Length; i++)
            {
                if (trainingData[i][1] == 1)
                {
                    output = output + trainingData[i][0];
                    count = count + 1;
                }
            }

            if (count > 0 && output > 0)
                return output / count;
            else
                return 0;
        }

        public string[] taskMakerSimple(string[] source, int challengeId)
        {
            List<int> filterIndexes = new List<int>();

            int challengeLineIndex = -1;

            string debuggingLine = Array.Find(source, s => s.Contains("//DB " + challengeId.ToString()));

            if (debuggingLine != "" && debuggingLine != null)
            {
                challengeLineIndex = Array.IndexOf(source, debuggingLine);

                //string newText = debuggingLine.Replace("//DB " + challengeId.ToString() + "//", "");
                string newText = debuggingLine.TrimStart().Split(new string[] { "//DB " + challengeId.ToString() + "//" }, StringSplitOptions.None)[1];

                for (int i = challengeLineIndex; i > 1; i--)
                {
                    if (!source[i].Contains("//DB "))
                    {
                        int emptySpaceCount = source[i].TakeWhile(Char.IsWhiteSpace).Count();
                        source[i] = source[i].Substring(0, emptySpaceCount) + newText;

                        break;
                    }
                }
            }

            return source.Where(s => s.Contains("//DB ") == false).ToArray();
        }

        public string[] taskMaker(string[] source, int challengeId)
        {
            List<string> sourceList = source.OfType<string>().ToList();

            List<int> filterIndexes = new List<int>();

            int challengeLineIndex = -1;

            string debuggingLine = Array.Find(source, s => s.Contains("//DB " + challengeId.ToString()));

            if (debuggingLine != "" && debuggingLine != null)
            {
                challengeLineIndex = Array.IndexOf(source, debuggingLine);

                //string newText = debuggingLine.Replace("//DB " + challengeId.ToString() + "//", "");
                string newText = debuggingLine.TrimStart().Split(new string[] { "//DB " + challengeId.ToString() + "//" }, StringSplitOptions.None)[1];

                for (int i = challengeLineIndex; i > 1; i -- )
                {
                    if (!sourceList[i].Contains("//DB "))
                    {
                        //sourceList[i] = newText;
                        int emptySpaceCount = sourceList[i].TakeWhile(Char.IsWhiteSpace).Count();
                        sourceList[i] = sourceList[i].Substring(0, emptySpaceCount) + newText;

                        break;
                    }
                }

            }

            for (int i = 0; i < sourceList.Count(); i++)
            {
                if (sourceList[i].Contains("//DB "))
                {
                    string afterDBSpace = sourceList[i].Split(new string[] { "//DB " }, StringSplitOptions.None)[1];
                    if (afterDBSpace != "")
                    {
                        if (afterDBSpace.Contains("//"))
                        {
                            string numValue = afterDBSpace.Split(new string[] { "//" }, StringSplitOptions.None)[0];
                            if (numValue.Trim().Length > 0 && Int32.Parse(numValue.Trim()) > 0 && Convert.ToInt32(numValue.Trim()) >= 1 && Convert.ToInt32(numValue.Trim()) < 1000)
                            {
                                sourceList.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                    }
                }
            }

            //return source.Where(s => s.Contains("//DB ") == false).ToArray();
            return sourceList.ToArray();
        }

        public bool plagiarismCheck(string[] code1, string[] code2)
        {
            if (code1.Length != code2.Length)
                return false;

            string functionLine = code1[0];

            if (functionLine.Contains('(') == false)
                return code1.SequenceEqual(code2);

            string[] code1parameters = functionLine.Split('(')[1].Split(')')[0].Split(',');

            functionLine = code2[0];

            string[] code2parameters = functionLine.Split('(')[1].Split(')')[0].Split(',');

            if (code1parameters.Length == 1 && code1parameters[0].Trim() == "")
                return Array.Equals(code1, code2);
            else
            {
                //find unused variables. Any variable that is used only on the left side of assigment and is not used in any return statement is an unused variable.

                List<string> code1UnusedVariables = new List<string>();

                for (int i = 0; i < code1.Length; i++)
                {
                    if (code1[i].Contains(" = "))
                    {
                        string[] assignmentSplit = code1[i].Split(new string[] { "=" }, StringSplitOptions.None);

                        if (assignmentSplit.Length == 2 && assignmentSplit[0].Trim() == assignmentSplit[1].Trim())
                        {
                            code1[i] = code1[i].Replace(assignmentSplit[0].Trim() + " = ", "abcd" + i.ToString() + " = ");
                            assignmentSplit = code1[i].Split(new string[] { "=" }, StringSplitOptions.None);
                        }

                        string variable = assignmentSplit[0].Trim();

                        if (variable != "")
                        {
                            if (!code1UnusedVariables.Contains(variable))
                                code1UnusedVariables.Add(variable.ToLower());
                        }
                    }
                    else if (code1[i].ToLower().Trim().Length >= 3 && (code1[i].ToLower().Trim().Substring(0, 3) == "ret" || code1[i].ToLower().Trim().Substring(0, 6) == "return"))
                    {
                        string returnStmt = code1[i].ToLower().Trim().Replace("return", "").Replace("ret", "").Replace("(", "").Replace(")", "").Trim();
                        string[] variables = returnStmt.Split(' ');

                        if (code1UnusedVariables.Count() > 0)
                        {
                            foreach(string variable in code1UnusedVariables)
                            {
                                if (variables.Contains(variable))
                                {
                                    code1UnusedVariables.Remove(variable);
                                    if (code1UnusedVariables.Count() == 0)
                                        break;
                                }
                            }
                        }                        
                    }
                }

                List<string> code2UnusedVariables = new List<string>();

                for (int i = 0; i < code2.Length; i++)
                {
                    if (code2[i].Contains(" = "))
                    {
                        string[] assignmentSplit = code2[i].Split(new string[] { "=" }, StringSplitOptions.None);

                        if (assignmentSplit.Length == 2 && assignmentSplit[0].Trim() == assignmentSplit[1].Trim())
                        {
                            code2[i] = code2[i].Replace(assignmentSplit[0].Trim() + " = ", "abcd" + i.ToString() + " = ");
                            assignmentSplit = code2[i].Split(new string[] { "=" }, StringSplitOptions.None);
                        }

                        string variable = assignmentSplit[0].Trim();

                        if (variable != "")
                        {
                            if (!code2UnusedVariables.Contains(variable))
                                code2UnusedVariables.Add(variable.ToLower());
                        }
                    }
                    else if (code2[i].ToLower().Trim().Length >= 3 && (code2[i].ToLower().Trim().Substring(0, 3) == "ret" || code2[i].ToLower().Trim().Substring(0, 6) == "return"))
                    {
                        string returnStmt = code2[i].ToLower().Trim().Replace("return", "").Replace("ret", "").Replace("(", "").Replace(")", "").Trim();
                        string[] variables = returnStmt.Split(' ');

                        if (code2UnusedVariables.Count() > 0)
                        {
                            foreach (string variable in code2UnusedVariables)
                            {
                                if (variables.Contains(variable))
                                {
                                    code2UnusedVariables.Remove(variable);
                                    if (code1UnusedVariables.Count() == 0)
                                        break;
                                }
                            }
                        }
                    }
                }


                for (int i = 0; i < code2.Length; i++)
                {
                    for (int j = 0; j < code2parameters.Length; j++)
                    {
                        code2[i] = code2[i].Replace(code2parameters[j].Trim(), "xyz" + j.ToString());
                    }

                    for (int j = 0; j < code2UnusedVariables.Count; j++)
                    {
                        if (code2[i].Contains(" = "))
                            code2[i] = code2[i].Replace(code2UnusedVariables[j].Trim(), "efg" + j.ToString());
                    }
                }

                for (int i = 0; i < code1.Length; i++)
                {
                    for (int j = 0; j < code1parameters.Length; j++)
                    {
                        code1[i] = code1[i].Replace(code1parameters[j].Trim(), "xyz" + j.ToString());
                    }

                    for (int j = 0; j < code1UnusedVariables.Count; j++)
                    {
                        if (code2[i].Contains(" = "))
                            code1[i] = code1[i].Replace(code1UnusedVariables[j].Trim(), "efg" + j.ToString());
                    }
                }
            }

            return code1.SequenceEqual(code2);
        }

        /*
        In CodeFights marathons, each task score is calculated independently. For a specific task, you get some amount of points if you solve it correctly, or you get a 0. Here is how the exact number of points is calculated:

        If you solve a task on your first attempt within the first minute, you get maxScore points.
        Each additional minute you spend on the task adds a penalty of (maxScore / 2) * (1 / marathonLength) to your final score.
        Each unsuccessful attempt adds a penalty of 10 to your final score.
        After all the penalties are deducted, if the score is less than maxScore / 2, you still get maxScore / 2 points.
        Implement an algorithm that calculates this score given some initial parameters.

        Example

        For
        marathonLength = 100,
        maxScore = 400,
        submissions = 4 and
        successfulSubmissionTime = 30, the output should be

        marathonTaskScore(marathonLength, maxScore, 
                          submissions, successfulSubmissionTime) = 310
        Three unsuccessful attempts cost 10 * 3 = 30 points. 30 minutes adds 30 * (400 / 2) * (1 / 100) = 60 more points to the total penalty. So the final score is 400 - 30 - 60 = 310.

        Keeping the same input parameters as above but changing the number of attempts to 95 we get:
        marathonTaskScore(marathonLength, maxScore, submissions, successfulSubmissionTime) = 200;

        400 - 10 * 94 - 30 * (400 / 2) * (1 / 100) = -600. But the score for this task cannot be less than 400 / 2 = 200, so the final score is 200 points.

        For marathonLength = 100, maxScore = 400, submissions = 4 and successfulSubmissionTime = -1, the output should be
        marathonTaskScore(marathonLength, maxScore, submissions, successfulSubmissionTime) = 0.

        The task wasn't solved, so it doesn't give any points.

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer marathonLength

        A positive integer representing the length of the marathon in minutes.

        Constraints:
        100 ≤ marathonLength ≤ 1000.

        [input] integer maxScore

        A positive integer. It is guaranteed that maxScore is divisible by 2 * marathonLength.

        Constraints:
        400 ≤ maxScore ≤ 2000.

        [input] integer submissions

        A positive integer equal to the number of submissions made by the user for the specific task.

        Constraints:
        1 ≤ submissions ≤ 100.

        [input] integer successfulSubmissionTime

        An integer equal to the time of successful submission in minutes since the beginning of the marathon (for example, if a successful submission was made on the first minute then successfulSubmissionTime = 0). If all submissions were unsuccessful then successfulSubmissionTime = -1.

        Constraints:
        -1 ≤ successfulSubmissionTime < marathonLength.

        [output] integer

        The final score for the task.
         */
        public int marathonTaskScore(int marathonLength, int maxScore, int submissions, int successfulSubmissionTime)
        {
            if (successfulSubmissionTime == -1)
                return 0;

            int taskScore = maxScore - ((successfulSubmissionTime) * (maxScore / 2 / marathonLength)) - ((submissions - 1) * 10);
            if (taskScore < maxScore / 2)
                return maxScore / 2;
            else
                return taskScore;
        }

        public int[][] opponentMatching(int[] XP)
        {
            var sortedXP = XP.Select((x, i) => new KeyValuePair<int, int>(i, x)).OrderBy(i => i.Value).ToList();

            List<List<int>> output = new List<List<int>>();

            while (sortedXP.Count > 1)
            {
                for (int i = 0; i < sortedXP.Count(); i++)
                {
                    if (sortedXP.Count() - i > 2)
                    {
                        if ((sortedXP[i + 1].Value - sortedXP[i].Value) < (sortedXP[i + 2].Value - sortedXP[i + 1].Value))
                        {
                            List<int> combination = GetCombinationList(sortedXP, i);

                            sortedXP.RemoveAt(i + 1);
                            sortedXP.RemoveAt(i);

                            output.Add(combination);
                            break;
                        }
                        else
                            continue;
                    }
                    else
                    {
                        List<int> combination = GetCombinationList(sortedXP, i);

                        sortedXP.RemoveAt(i + 1);
                        sortedXP.RemoveAt(i);

                        output.Add(combination);
                    }
                    break;
                }
            }

            var sorted = output.OrderBy(x => x[2]).Select(y => new List<int>() { y[0], y[1] });

            return sorted.Select(a => a.ToArray()).ToArray();
        }

        private List<int> GetCombinationList(List<KeyValuePair<int, int>> sortedXP, int i)
        {
            List<int> combination = new List<int>();

            if (sortedXP[i].Key < sortedXP[i + 1].Key)
            {
                combination.Add(sortedXP[i].Key);
                combination.Add(sortedXP[i + 1].Key);
            }
            else
            {
                combination.Add(sortedXP[i + 1].Key);
                combination.Add(sortedXP[i].Key);
            }

            combination.Add(Math.Abs(sortedXP[i].Value - sortedXP[i + 1].Value));

            return combination;
        }


    }
}
