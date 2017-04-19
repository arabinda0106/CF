using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    class UberBot
    {
        /*
        Uber BOT:
        
        Uber is building a Fare Estimator that can tell you how much your ride will cost before you request it. It works by passing approximated ride distance and ride time through this formula:

        (Cost per minute) * (ride time) + (Cost per mile) * (ride distance)

        where Cost per minute and Cost per mile depend on the car type.

        You are one of the engineers building the Fare Estimator, so knowing cost per minute and cost per mile for each car type, as well as ride distance and ride time, return the fare estimates for all car types.

        Example

        For
        ride_time = 30,
        ride_distance = 7,
        cost_per_minute = [0.2, 0.35, 0.4, 0.45] and
        cost_per_mile = [1.1, 1.8, 2.3, 3.5], the output should be
        fareEstimator(ride_time, ride_distance, cost_per_minute, cost_per_mile) = [13.7, 23.1, 28.1, 38].

        Since:

        30 * 0.2 + 7 * 1.1 = 6 + 7.7 = 13.7

        30 * 0.35 + 7 * 1.8 = 10.5 + 12.6 = 23.1

        30 * 0.4 + 7 * 2.3 = 12 + 16.1 = 28.1

        30 * 0.45 + 7 * 3.5 = 13.5 + 24.5 = 38
        Input/Output

        [time limit] 3000ms (cs)
        [input] integer ride_time

        A positive integer, ride duration in minutes.

        Constraints:
        10 ≤ ride_time ≤ 50.

        [input] integer ride_distance

        A positive integer, ride distance in miles.

        Constraints:
        5 ≤ ride_distance ≤ 20.

        [input] array.float cost_per_minute

        cost_per_minute[i] is a positive number denoting cost per minute for the ith car type. There are at least 4 car types in every city where Uber operates.

        Constraints:
        4 ≤ cost_per_minute.length ≤ 10,
        0.1 ≤ cost_per_minute[i] ≤ 350.0.

        [input] array.float cost_per_mile

        cost_per_mile[i] is a positive number denoting cost per mile for the ith car type. It is guaranteed that cost_per_minute and cost_per_mile have the same number of elements.

        Constraints:
        cost_per_mile.length = cost_per_minute.length,
        0.5 ≤ cost_per_mile[i] ≤ 7.0.

        [output] array.float

        An array of estimated fares for each car type.

        GIVE UP
         */
        public double[] fareEstimator(int ride_time, int ride_distance, double[] cost_per_minute, double[] cost_per_mile)
        {
            List<double> fareEstimatorDetails = new List<double>();

            for (int count = 0; count < cost_per_minute.Length; count++)
            {
                fareEstimatorDetails.Add(cost_per_minute[count] * ride_time + cost_per_mile[count] * ride_distance);
            }

            return fareEstimatorDetails.ToArray();
        }

        /*
        Consider a city where the streets are perfectly laid out to form an infinite square grid. In this city finding the shortest path between two given points (an origin and a destination) is much easier than in other more complex cities. As a new Uber developer, you are tasked to create an algorithm that does this calculation.

        Given user's departure and destination coordinates, each of them located on some street, find the length of the shortest route between them assuming that cars can only move along the streets. Each street can be represented as a straight line defined by the x = n or y = n formula, where n is an integer.

        Example

        For departure = [0.4, 1] and destination = [0.9, 3], the output should be
        perfectCity(departure, destination) = 2.7.

        0.6 + 2 + 0.1 = 2.7, which is the answer.



        Input/Output

        [time limit] 3000ms (cs)
        [input] array.float departure

        An array [x, y] of x and y coordinates. It is guaranteed that at least one coordinate is integer.

        Constraints:
        0.0 ≤ departure[i] ≤ 10.0.

        [input] array.float destination

        An array [x, y] of x and y coordinates. It is guaranteed that at least one coordinate is integer.

        Constraints:
        0.0 ≤ destination[i] ≤ 10.0.

        [output] float

        The shorted distance between two points along the streets.

        */
        public double perfectCity(double[] departure, double[] destination)
        {
            departure = new double[] { 0.4, 1 };
            destination = new double[] { 0.9, 3 };

            //departure = new double[] { 0.4, 1 };
            //destination = new double[] { 1, 2.5 };

            departure = new double[] { 2.4, 1 };
            destination = new double[] { 5, 7.3 };

            departure = new double[] { 0.9, 6 };
            destination = new double[] { 1.1, 5 };

            departure = new double[] { 0, 0.2 };
            destination = new double[] { 7, 0.5 };

            double totalDistance = 0.0;

            double xDistance = Math.Abs(departure[0] - destination[0]);
            double yDistance = Math.Abs(departure[1] - destination[1]);

            if (xDistance > yDistance)
                totalDistance = xDistance + shortestDifference(departure[1], destination[1], xDistance);
            else
                totalDistance = yDistance + shortestDifference(departure[0], destination[0], yDistance);

            return totalDistance;
        }

        double shortestDifference(double double1, double double2, double otherCoordinateDistance)
        {
            bool double1IsWholeNumber = false;
            bool double2IsWholeNumber = false;

            if (double1 % 1 == 0)
                double1IsWholeNumber = true;

            if (double2 % 1 == 0)
                double2IsWholeNumber = true;

            if (double1IsWholeNumber && double2IsWholeNumber)
                return 1 + 1;
            else if ((double1IsWholeNumber && !double2IsWholeNumber) || (!double1IsWholeNumber && double2IsWholeNumber))
            {
                if (otherCoordinateDistance % 2 == 0 || (double1 > 1) || (double2 > 1))
                    return Math.Abs(double1 - double2);
                else
                    return (double1 + double2);
            }
            else
            {
                double double1Remainder = double1 % 1;
                double double2Remainder = double2 % 1;

                if ((double1 > 1) || (double2 > 1))
                    return Math.Abs(double1 - double2);
                else
                {
                    if ((double1Remainder + double2Remainder) > ((1 - double1Remainder) + (1 - double2Remainder)))
                        return (1 - double1Remainder) + (1 - double2Remainder);
                    else
                        return double1Remainder + double2Remainder;
                }

            }
        }

        /*
        Some phone usage rate may be described as follows:

        first minute of a call costs min1 cents,
        each minute from the 2nd up to 10th (inclusive) costs min2_10 cents
        each minute after 10th costs min11 cents.
        You have s cents on your account before the call. What is the duration of the longest call (in minutes rounded down to the nearest integer) you can have?

        Example

        For min1 = 3, min2_10 = 1, min11 = 2 and s = 20, the output should be
        phoneCall(min1, min2_10, min11, s) = 14.

        Here's why:

        the first minute costs 3 cents, which leaves you with 20 - 3 = 17 cents;
        the total cost of minutes 2 through 10 is 1 * 9 = 9, so you can talk 9 more minutes and still have 17 - 9 = 8 cents;
        each next minute costs 2 cents, which means that you can talk 8 / 2 = 4 more minutes.
        Thus, the longest call you can make is 1 + 9 + 4 = 14 minutes long.

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer min1

        Constraints:
        1 ≤ min1 ≤ 10.

        [input] integer min2_10

        Constraints:
        1 ≤ min2_10 ≤ 10.

        [input] integer min11

        Constraints:
        1 ≤ min11 ≤ 10.

        [input] integer s

        Constraints:
        2 ≤ s ≤ 60.

        [output] integer
         */
        public int phoneCall(int min1, int min2_10, int min11, int s)
        {

            min1 = 2;
            min2_10 = 2;
            min11 = 1;
            s = 2;

            if (s < min1)
                return 0;

            if (s == min1)
                return 1;

            int returnVal = 0;

            if ((s - min1) / min2_10 <= 9 && (s - min1) % min11 < min11)
                returnVal = 1 + ((s - min1) / min2_10);
            else
                returnVal = 10 + (s - min1 - (9 * min2_10)) / min11;

            return returnVal;
        }


    }
}
