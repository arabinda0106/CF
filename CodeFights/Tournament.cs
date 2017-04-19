using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class Tournament
    {
        /*

        You are playing a number guessing game with your friend. Your friend thought of some integer x from 1 to n. In order to guess the number, you can ask two types of questions:

        "is x smaller or equal to a?" for some integer a;
        "is x greater or equal to a?" for some integer a.
        If the answer to your question is "yes", you should pay your friend $2, otherwise you should pay him $1.

        How much will you have to pay to your friend, assuming that you apply the strategy that minimizes the amount of money you have to pay in order to guess the number in the worst case scenario?

        Example

        For n = 3, the output should be
        numberGuessingNaive(n) = 3.

        Input/Output

        [time limit] 4000ms (js)
        [input] integer n

        A positive integer.

        Constraints:
        1 ≤ n ≤ 1000.

        [output] integer

        Acceptable answers:
        n 534
        14

        n 4
        4

        n 1 
        0

        n 3 
        3

         */
        public int numberGuessingNaive(int n)
        {
            n = 4;

            int[] pay = new int[n+1];

            for (int i = 2; i < n; i++)
            {
                pay[i] = i;
                for (int m = 1; m < i; m++)
                {
                    pay[i] = Math.Min(pay[i], Math.Max(1 + pay[m], 2 + pay[i - m]));
                }
            }

            int k = pay[n-1];

            return k;
        }

    }
}
