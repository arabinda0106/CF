using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class InstaBot
    {
        /*
        Instacart customers are able to set the delivery window during which they want to receive their groceries. There are always plenty of shoppers in the area 
        ready to take a customer's order, but unfortunately they can't always do it right away. Before taking an order a shopper wants to ensure they will make it in time. 
        They also don't want to stay idle, so arriving early isn't an option either.

        Our task is to implement an algorithm that determines whether shoppers should take the given order or not.

        For each shopper you know their travel speed, distance to the store and the estimated amount of time they will spend there. Figure out which of them can take the order, 
        assuming it is known when the customer wants to receive the groceries and the distance between their house and the store.

        Example

        For order = [200, 20, 15] and shoppers = [[300, 40, 5], [600, 40, 10]], the output should be

        delivery(order, shoppers) = [false, true].

        The store is located 200 m away from the customer's house.

        The customer will be ready to receive the groceries in 20 minutes, but they shouldn't be delivered more than 15 minutes late.

        The first shopper is 300 m away from the store, his speed is 40 m/min, and he will spend 5 minutes in the store, 
        which means that he will need (300 + 200) / 40 + 5 = 17.5 minutes to fulfill the order. This will leave him with 20 - 17.5 = 2.5 idle minutes, so he shouldn't take the order.

        The second shopper is 600 m away from the store, his speed is 40 m/min, and he will spend 10 minutes in the store, 
        which means it will take him (600 + 200) / 40 + 10 = 30 minutes to fulfill the order. The customer can wait for 20 + 15 = 35 minutes, 
        which means that the shopper will make it in time.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer order

        The order is given as an array of 3 positive integers. order[0] is the distance from the customer's home to the store in meters, order[1] is the time by which the customer will be ready to receive the delivery in minutes, and order[2] is the number of minutes they are willing to wait.

        Constraints:

        1 ≤ order[i] ≤ 1000.

        [input] array.array.integer shoppers

        Each element of this array represents a shopper. For each shopper three positive integers are stored in the exact given order: their distance from the shop in meters, their speed in meters per minute and the estimated time they will spend in the store in minutes.

        Constraints:

        1 ≤ shoppers.length ≤ 5,

        1 ≤ shoppers[i][j] ≤ 1000.

        [output] array.boolean

        For each shopper return if they should take the order or not.
        */

        public bool[] delivery(int[] order, int[][] shoppers)
        {
            bool[] output = new bool[shoppers.Length];

            for(int i = 0; i < shoppers.Length; i++)
            {
                double timeNeededToFulfill = (double) (shoppers[i][0] + order[0]) / shoppers[i][1] + shoppers[i][2];
                if (timeNeededToFulfill < order[1] || timeNeededToFulfill > (order[1] + order[2]))
                    output[i] = false;
                else
                    output[i] = true;
            }

            return output;
        }

        /*
        After recently joining Instacart's beta testing developer group, you decide to experiment with their new API. You know that the API returns item-specific 
        display-ready strings like 10.0% higher than in-store or 5.0% lower than in-store that inform users when the price of an item is different from the one in-store. 
        But you want to extend this functionality by giving people a better sense of how much more they will be paying for their entire shopping cart.

        Your app lets a user decide the total amount x they are willing to pay via Instacart over in-store prices. This you call their price sensitivity.

        Your job is to determine whether a given customer will be willing to pay for the given items in their cart based on their stated price sensitivity x.

        Example

        For
        prices = [110, 95, 70],

        notes = ["10.0% higher than in-store", 
                 "5.0% lower than in-store", 
                 "Same as in-store"]
        and x = 5, the output should be
        isAdmissibleOverpayment(prices, notes, x) = true.

        In-store prices of the first and the second items are 100, and the price of the third item is 70, which means the customer is overpaying 10 - 5 + 0 = 5, which they are willing to do based on their price sensitivity.

        For
        prices = [48, 165],

        notes = ["20.00% lower than in-store", 
                 "10.00% higher than in-store"]
        and x = 2, the output should be
        isAdmissibleOverpayment(prices, notes, x) = false.

        The in-store price of the first item is 60, and the second item is 150. The overpayment equals 15 - 12 = 3, which is too much for the customer to be willing to pay.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.float prices

        Positive numbers, representing prices of the items in the shopping cart.

        Constraints:
        1 ≤ prices.length ≤ 10,
        20.0 ≤ prices[i] ≤ 35.0 · 103.

        [input] array.string notes

        Array of the same length as prices. For each valid i notes[i] has one of the following forms:

        "x% higher than in-store", which means that Instacart price of the ith item is x% higher than the local one;
        "x% lower than in-store", which means that Instacart price of the ith item is x% lower than the local one;
        "Same as in-store", which means that the ith item costs the same in Instacart and in the local store,
        where x is a positive float number with the decimal point and at least one digit after it.

        Constraints:
        notes.length = prices.length,
        16 ≤ notes[i].length ≤ 30.

        [input] float x

        A non-negative integer, the maximum amount of money the customer is willing to overpay.

        Constraints:
        0 ≤ x ≤ 150.0.

        [output] boolean

        true if the overpayment is admissible, false otherwise.
        */

        public bool isAdmissibleOverpayment(double[] prices, string[] notes, double x)
        {
            double actualPrice = 0, instaCartPrice = 0;

            for(int i = 0; i < prices.Length; i++)
            {
                instaCartPrice += prices[i];
                string[] tempNotes = notes[i].Split(' ');

                if (tempNotes[0].ToLower() == "same")
                    actualPrice += prices[i];
                else
                {
                    double percentage = Convert.ToDouble(tempNotes[0].Replace("%", ""));

                    if (tempNotes[1].ToLower() == "higher")
                        actualPrice += (prices[i] / (1 + percentage));
                    else
                        actualPrice += (prices[i] / (1 - percentage));
                }
            }

            return instaCartPrice <= actualPrice + x;
        }

        /*
        To celebrate Cyber Monday, Instacart has decided to give its shoppers (employees that shop at grocery stores and deliver orders to customers) a break. 
        For a 24h period, every shopper only has to make 1 delivery, after which his/her workday is over. However, since providing customers with a reliable shopping experience is 
        Instacart's #1 priority, it is important to ensure that each order is fulfilled and delivered as promised.

        You are given a list of orders with the time periods when they should be completed, and the time leadTime it takes to fulfill each order. Knowing the time period each shopper 
        is available (shoppers), find out whether the current number of shoppers is enough to fulfill all orders.

        A shopper can fulfill an order if he/she can both start and finish it in the time period specified for this order.

        Example

        For

        shoppers = [["15:10", "16:00"], 
                    ["17:40", "22:30"]]
        orders = [["17:30", "18:00"], 
                  ["15:00", "15:45"]]
        and leadTime = [15, 30], the output should be
        busyHolidays(shoppers, orders, leadTime) = true.

        The first shopper can take the second order, and the second shopper can take the first one.

        For

        shoppers = [["15:10", "16:00"], 
                    ["17:50", "22:30"], 
                    ["13:00", "14:40"]]
        orders = [["14:30", "15:00"]]
        and leadTime = [15], the output should be
        busyHolidays(shoppers, orders, leadTime) = false.

        None of the shoppers can fulfill the given order. The first two will be unavailable at the time of the order and the last one won't be able to finish it in time, since the earliest time the order can be completed is 14:30 + 15 minutes = 14:45.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.string shoppers

        Available time for each shopper is given as an array of two strings [from, to], where each string represents time in "hh:mm" format. The shopper is available in the interval from from to to inclusive.
        It is guaranteed that both from and to refer to the same day, and thus from < to in terms of time.

        Constraints:
        2 ≤ shoppers.length ≤ 40.

        [input] array.array.string orders

        For each order the period in which it should be fulfilled is given in the same format as the availability of each shopper.

        Constraints:
        1 ≤ orders.length ≤ 40,

        [input] array.integer leadTime

        Array of positive integers of the same length as orders. leadTime[i] is the number of minutes required to fulfill the ith order.

        Constraints:
        1 ≤ leadTime.length ≤ 40,
        1 ≤ leadTime[i] ≤ 1000.

        [output] boolean

        true if the shoppers can fulfill each order, false otherwise.
        */

        public bool busyHolidaysOld(string[][] shoppers, string[][] orders, int[] leadTime)
        {
            bool matchingShopperFound = true;

            var sortedLeadTime = leadTime.Select((k, v) => new KeyValuePair<int, int>(v, k)).OrderByDescending(i => i.Value).ToList();

            var shoppersList = shoppers.ToList();

            if (shoppers.Length < orders.Length)
                return false;
            
            for(int i = 0; i < sortedLeadTime.Count; i++)
            {
                bool matchFound = false;

                for(int j = 0; j < shoppersList.Count; j++)
                {
                    DateTime shopperStartTime = DateTime.Now;
                    DateTime shopperEndTime = shopperStartTime;

                    DateTime orderStartTime = shopperStartTime;
                    DateTime orderEndTime = shopperStartTime;

                    shopperStartTime = shopperStartTime.AddHours(Convert.ToDouble(shoppersList[j][0].Split(':')[0]));
                    shopperStartTime = shopperStartTime.AddMinutes(Convert.ToDouble(shoppersList[j][0].Split(':')[1]));

                    shopperEndTime = shopperEndTime.AddHours(Convert.ToDouble(shoppersList[j][1].Split(':')[0]));
                    shopperEndTime = shopperEndTime.AddMinutes(Convert.ToDouble(shoppersList[j][1].Split(':')[1]));

                    orderStartTime = orderStartTime.AddHours(Convert.ToDouble(orders[sortedLeadTime[i].Key][0].Split(':')[0]));
                    orderStartTime = orderStartTime.AddMinutes(Convert.ToDouble(orders[sortedLeadTime[i].Key][0].Split(':')[1]));

                    orderEndTime = orderEndTime.AddHours(Convert.ToDouble(orders[sortedLeadTime[i].Key][1].Split(':')[0]));
                    orderEndTime = orderEndTime.AddMinutes(Convert.ToDouble(orders[sortedLeadTime[i].Key][1].Split(':')[1]));

                    DateTime compareStartTime = (shopperStartTime > orderStartTime ? shopperStartTime : orderStartTime);
                    DateTime compareEndTime = (shopperEndTime < orderEndTime ? shopperEndTime : orderEndTime);

                    var diff = compareEndTime - compareStartTime;

                    if (diff.Minutes >= 0 && diff.Minutes >= sortedLeadTime[i].Value)
                    {
                        matchFound = true;
                        shoppersList.RemoveAt(j);
                        break;
                    }

                }

                if (!matchFound)
                {
                    matchingShopperFound = false;
                    break;
                }
            }

            return matchingShopperFound;
        }

        public bool busyHolidays(string[][] shoppers, string[][] orders, int[] leadTime)
        {
            if (shoppers.Length < orders.Length || orders.Length != leadTime.Length)
                return false;

            Dictionary<int, List<int>> matchingDetails = new Dictionary<int, List<int>>();

            for(int i = 0; i < shoppers.Length; i++)
            {
                List<int> canFulFillTheseOrders = new List<int>();

                for(int j = 0; j < orders.Length; j++)
                {
                    if (CanFulfill(shoppers[i], orders[j], leadTime[j]))
                        canFulFillTheseOrders.Add(j);
                }

                matchingDetails.Add(i, canFulFillTheseOrders);
            }

            var matchingDetailsSorted = matchingDetails.OrderBy(x => x.Value.Count).ToList();

            HashSet<int> ordersMatched = new HashSet<int>();

            for (int i = 0; i < matchingDetailsSorted.Count(); i++)
            {
                int ordersMatchedAlready = ordersMatched.Count;
                for (int j = 0; j < matchingDetailsSorted[i].Value.Count; j ++)
                {
                    if (ordersMatched.Count - ordersMatchedAlready < 1)
                        ordersMatched.Add(matchingDetailsSorted[i].Value[j]);
                }
            }

            return (ordersMatched.Count == orders.Count());
        }

        private bool CanFulfill(string[] shopper, string[] order, int leadTime)
        {
            DateTime shopperStartTime = DateTime.Now;

            shopperStartTime = shopperStartTime.AddHours((-1) * shopperStartTime.Hour);
            shopperStartTime = shopperStartTime.AddMinutes((-1) * shopperStartTime.Minute);
            shopperStartTime = shopperStartTime.AddSeconds((-1) * shopperStartTime.Second);

            DateTime shopperEndTime = shopperStartTime;

            DateTime orderStartTime = shopperStartTime;
            DateTime orderEndTime = shopperStartTime;

            shopperStartTime = shopperStartTime.AddHours(Convert.ToDouble(shopper[0].Split(':')[0]));
            shopperStartTime = shopperStartTime.AddMinutes(Convert.ToDouble(shopper[0].Split(':')[1]));

            shopperEndTime = shopperEndTime.AddHours(Convert.ToDouble(shopper[1].Split(':')[0]));
            shopperEndTime = shopperEndTime.AddMinutes(Convert.ToDouble(shopper[1].Split(':')[1]));

            orderStartTime = orderStartTime.AddHours(Convert.ToDouble(order[0].Split(':')[0]));
            orderStartTime = orderStartTime.AddMinutes(Convert.ToDouble(order[0].Split(':')[1]));

            orderEndTime = orderEndTime.AddHours(Convert.ToDouble(order[1].Split(':')[0]));
            orderEndTime = orderEndTime.AddMinutes(Convert.ToDouble(order[1].Split(':')[1]));

            DateTime commonStartTime = (shopperStartTime > orderStartTime ? shopperStartTime : orderStartTime);
            DateTime commonEndTime = (shopperEndTime < orderEndTime ? shopperEndTime : orderEndTime);

            var maxTimeAvailable = commonEndTime - commonStartTime;

            int maxTimeAvailableMinutes = (maxTimeAvailable.Hours * 60 + maxTimeAvailable.Minutes);

            return (maxTimeAvailableMinutes >= leadTime);
        }

    }
}
