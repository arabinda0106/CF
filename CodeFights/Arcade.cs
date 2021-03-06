﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class Arcade
    {
        public int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            return (weight1 + weight2 <= maxW) ? (value1 + value2) : (value1 > value2 && weight1 <= maxW ? value1 : (weight2 <= maxW ? value2 : 0));
        }

        public bool isInfiniteProcess(int a, int b)
        {
            return (a == b) ? false : !((a + 2) <= b && (Math.Abs(a - b) % 2 == 0));
        }

        public int[] metroCard(int lastNumberOfDays)
        {
            return (lastNumberOfDays == 31) ? new int[] { 28, 30, 31 } : lastNumberOfDays == 30 ? new int[] { 30, 31 } : new int[] { 30 };
        }

        /*
        n order to stop the Mad Coder evil genius you need to decipher the encrypted message he sent to his minions. The message contains several numbers that, when typed into a supercomputer, will launch a missile into the sky blocking out the sun, and making all the people on Earth grumpy and sad.

        You figured out that some numbers have a modified single digit in their binary representation. More specifically, in the given number n the kth bit from the right was initially set to 0, but its current value might be different. It's now up to you to write a function that will change the kth bit of n back to 0.

        Example

        For n = 37 and k = 3, the output should be
        killKthBit(n, k) = 33.

        3710 = 1001012 ~> 1000012 = 3310.

        For n = 37 and k = 4, the output should be

        killKthBit(n, k) = 37.

        The 4th bit is 0 already (looks like the Mad Coder forgot to encrypt this number), so the answer is still 37.

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer n

        Constraints:
        0 ≤ n ≤ 231 - 1.

        [input] integer k

        The 1-based index of the changed bit (counting from the right).

        Constraints:
        1 ≤ k ≤ 31.

        [output] integer
        */
        public int killKthBit(int n, int k)
        {
            //return Convert.ToString(n, 2).Length >= k ? Convert.ToInt32(Convert.ToString(n, 2).Remove(Convert.ToString(n, 2).Length - k, 1).Insert(Convert.ToString(n, 2).Length - k, "0"), 2) : 0;

            return n & ~(1 << k - 1);
        }

        public int arrayPacking(int[] a)
        {
            int output = 0;

            for(int i = a.Length - 1; i >=0; i--)
                output = (output << 8) | a[i];

            return output;
        }

    }
}
