using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class HeadToHead
    {
        public int ballsDistribution(int colors, int ballsPerColor, int boxSize)
        {

            int currentBox = 0,
                capacity = boxSize,
                result = 0;

            for (int i = 0; i < colors; i++)
            {
                int startBox = currentBox;
                for (int j = 0; j < ballsPerColor; j++)
                {
                    capacity--;
                    if (capacity == 0)
                    {
                        currentBox++;
                        capacity = boxSize;
                    }
                }

                if (startBox < currentBox && capacity < boxSize || startBox + 1 < currentBox)
                {
                    result++;
                }
            }

            return result;
        }

        /*
        Given a string which represents a valid arithmetic expression, find the index of the character in the given expression corresponding to the arithmetic operation which needs to be computed first.

        Note that several operations of the same type with equal priority are computed from left to right.

        Example

        For expr = "(2 + 2) * 2", the output should be
        firstOperationCharacter(expr) = 3.

        There are two operations in the expression: + and *. The result of + should be computed first, since it is enclosed in parentheses. Thus, the output is the index of the '+' sign, which is 3.

        For expr = "2 + 2 * 2", the output should be
        firstOperationCharacter(expr) = 6.

        There are two operations in the given expression: + and *. Since there are no parentheses, * should be computed first as it has higher priority. The answer is the position of '*', which is 6.

        Input/Output

        [time limit] 3000ms (cs)
        [input] string expr

        A string consisting of digits, parentheses, addition and multiplication signs (pluses and asterisks). It is guaranteed that there is at least one arithmetic sign in it.

        Constraints:
        5 ≤ expr.length ≤ 45.

        [output] integer
        */
        public int firstOperationCharacter(string expr)
        {
            List<int> indexesOfAsterisk = new List<int>();
            List<int> indexesOfPlus = new List<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr.Substring(i, 1) == "*")
                    indexesOfAsterisk.Add(i);

                if (expr.Substring(i, 1) == "+")
                    indexesOfPlus.Add(i);
            }

            int retValue = ReturnCorrectIndex(indexesOfAsterisk, expr);

            if (retValue > -1)
                return retValue;

            retValue = ReturnCorrectIndex(indexesOfPlus, expr);

            if (retValue > -1)
                return retValue;

            return -1;
        }

        private int ReturnCorrectIndex(List<int> indexes, string expr)
        {
            foreach (int index in indexes)
            {
                //if for this index, the first characters to the left and right of it are numeric values, then we have found it, 
                //else go to the next index

                bool numericFoundTotheRight = false,
                    numericFoundTotheLeft = false;

                for (int i = index + 1; i < expr.Length; i++)
                {
                    if (expr.Substring(i, 1) == " ")
                        continue;

                    int j;

                    if (Int32.TryParse(expr.Substring(i, 1), out j))
                    {
                        numericFoundTotheRight = true;
                        break;
                    }
                    else
                        break;
                }

                for (int i = index - 1; i >= 0; i--)
                {
                    if (expr.Substring(i, 1) == " ")
                        continue;

                    int j;

                    if (Int32.TryParse(expr.Substring(i, 1), out j))
                    {
                        numericFoundTotheLeft = true;
                        break;
                    }
                    else
                        break;
                }

                if (numericFoundTotheLeft && numericFoundTotheRight)
                    return index;
            }

            return -1;
        }

        /*
        
        Note: А string x is an anagram of a string y if one can get y by rearranging the letters of x. For example, the strings "MITE" and "TIME" are anagrams, so are "BABA" and "AABB", but "ABBAC" and "CAABA" are not.

        You are given two strings s and t of the same length, consisting of uppercase English letters. Your task is to find the minimum number of "replacement operations" needed to get some anagram of the string t from the string s. A replacement operation is performed by picking exactly one character from the string s and replacing it by some other character.

        Example

        For s = "AABAA" and t = "BBAAA", the output should be
        createAnagram(s, t) = 1;
        For s = "OVGHK" and t = "RPGUC", the output should be
        createAnagram(s, t) = 4.
        Input/Output

        [time limit] 3000ms (cs)
        [input] string s

        Constraints:
        5 ≤ s.length ≤ 35.

        [input] string t

        Constraints:
        t.length = s.length.

        [output] integer

        The minimum number of replacement operations needed to get an anagram of the string t from the string s
        */
        public int createAnagram(string s, string t)
        {
            int output = 0;

            for (int i = 0; i < t.ToString().Length; i++)
            {
                if (s.Contains(t.Substring(i, 1)))
                {
                    int index = s.IndexOf(t.Substring(i, 1));
                    s = s.Remove(index, 1);
                }
                else
                    output += 1;
            }

            return output;
        }


        public int[] lazyFriends(int[] houses, int maxDist)
        {

            int[] result = new int[houses.Length];
            int left = 0,
                right = 0;
            for (int i = 0; i < houses.Length; i++)
            {
                while (houses[i] - houses[left] > maxDist)
                {
                    left++;
                }
                while (right + 1 < houses.Length
                    && houses[right + 1] - houses[i] <= maxDist)
                {
                    right++;
                }
                result[i] = right - left;
            }

            return result;
        }

        public int digitSum(int n)
        {
            if (n < 10)
                return n;

            int output = 0, length = n.ToString().Length;

            for (int i = 0; i < length - 1; i++)
            {
                output += n % 10;
                n /= 10;
            }

            return output + n;
        }

        public bool isMonotonous(int[] sequence)
        {
            if (sequence.Length == 1)
            {
                return true;
            }
            int direction = sequence[sequence.Length - 1];
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (direction * (sequence[i + 1] - sequence[i]) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        int leastFactorial(int n)
        {
            int k = 0;
            for (int i = 1; ; i++)
            {
                k *= i;

                if (k > n)
                    break;

            }
            return k;
        }

        public int semiprimeByNumber(int n)
        {
            int[] primeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

            List<int> semiPrimes = new List<int>();

            for (int i = 0; i < primeNumbers.Length; i++)
            {
                for (int j = i; j < primeNumbers.Length; j++)
                    semiPrimes.Add(primeNumbers[i] * primeNumbers[j]);
            }

            int[] sortedArrays = semiPrimes.ToArray();

            Array.Sort(sortedArrays);

            return sortedArrays[n];
        }

        public bool rowsRearranging(int[][] matrix)
        {
            matrix = matrix.OrderBy(b => b[0]).ToArray();

            for (int i = 0; i < matrix.Length - 1; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                    if (matrix[i][j] >= matrix[i + 1][j])
                        return false;

            return true;
        }

        bool nimGameNaive(int[] sequence)
        {
            int oneCount = sequence.Count(i => i == 1);
            if (sequence.Length == 1)
                return true;
            else
            {
                if (sequence.Sum() % 2 != 0)
                    return true;
                else
                    return false;
            }

        }

        int arithmeticProgression(int element1, int element2, int n)
        {

            return element1 - (element1 - element2)*(n-1);

        }

        string bijectiveBase10(int a)
        {
            string z = "";
            while (a > 0)
            {
                int d = a % 10;
                a /= 10;
                if (d == 0)
                {
                    z = 'A' + z;
                    a--;
                }
                else
                {
                    z = d + z;
                }
            }
            return z;
        }

        public bool isLuckyNumber(int n)
        {
            foreach (char c in n.ToString())
                if (c != '4' && c != '7')
                    return false;

            return n.ToString().All(g => g == '4' || g == '7');
        }

        public int squareInTheLabyrinth(bool[][] labMap)
        {
            return 0;
        }

        /*
        A square with a side length of k is moving inside a labyrinth represented by a rectangular grid consisting of free cells and cells with obstacles. The square can be located only at such positions that all of its cells are lying on the free cells of the labyrinth.

        The square can move in one of the four directions (leftwards, rightwards, downwards or upwards), i.e. move each of its cells from its current position to the adjacent cell in that direction.

        Initially the upper left corner of the square coincides with the upper left corner of the labyrinth.

        Given a map of the labyrinth labMap, find the maximal k such that the square is able to reach such position that its bottom right corner lies on the bottom right corner of the labyrinth.

        Example

        For

        labMap =  [[true, true, true,  true],
                   [true, true, false, true],
                   [true, true, true,  true],
                   [true, true, true,  true]]
        the output should be
        squareInTheLabyrinth(labMap) = 2;



        For

        labMap = [[false, true, true],
                  [true,  true, true]]
        the output should be
        squareInTheLabyrinth(labMap) = 0.



        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.boolean labMap

        A rectangular matrix of booleans which represents a labyrinth. true represents a free cell, and false represents a cell with an obstacle.

        Constraints:
        2 ≤ labMap.length ≤ 5,
        2 ≤ labMap[0].length ≤ 5.

        [output] integer

        The maximum length of the square side.
        */

        public int squareInTheLabyrinthOld(bool[][] labMap)
        {
            if (labMap[0][0] == false)
                return 0;

            int count = 0;
            bool falseFound = false;
            while(falseFound == false)
            {
                for (int i = 0; i < labMap.Length; i++)
                {
                    if (labMap[i][count] == false)
                    {
                        falseFound = true;
                        break;
                    }
                }

                for (int i = 0; i < labMap[0].Length && falseFound == false; i++)
                {
                    if (labMap[labMap.Length - 1 - count][i] == false)
                    {
                        falseFound = true;
                        break;
                    }
                }
                count++;
            }

            int count1 = 0;
            falseFound = false;
            while (falseFound == false)
            {
                for (int i = 0; i < labMap[0].Length && falseFound == false; i++)
                {
                    if (labMap[count1][i] == false)
                    {
                        falseFound = true;
                        break;
                    }
                }

                for (int i = 0; i < labMap.Length; i++)
                {
                    if (labMap[i][labMap[0].Length - 1 - count1] == false)
                    {
                        falseFound = true;
                        break;
                    }
                }

                count1++;
            }

            return Math.Max(count - 1, count1 - 1);
        }

        public string[] bishopDiagonal(string bishop1, string bishop2)
        {
            string a = "abcdefgh";

            string sortedBishop1 = "", sortedBishop2 = "", newBishop1 = "", newBishop2 = "";

            if (StringComparer.Ordinal.Compare(bishop1, bishop2) < 0)
            {
                sortedBishop1 = bishop1;
                sortedBishop2 = bishop2;
            }
            else
            {
                sortedBishop1 = bishop2;
                sortedBishop2 = bishop1;
            }

            int index1 = a.IndexOf(sortedBishop1.Substring(0, 1));
            int index2 = a.IndexOf(sortedBishop2.Substring(0, 1));

            if (Math.Abs(index1 - index2) != Math.Abs(Convert.ToInt32(sortedBishop1.Substring(1,1)) - Convert.ToInt32(sortedBishop2.Substring(1, 1))))
                return new string[] { sortedBishop1, sortedBishop2 };
            else
            {
                if (Convert.ToInt32(sortedBishop1.Substring(1, 1)) > Convert.ToInt32(sortedBishop2.Substring(1, 1)))
                {
                    newBishop1 = GetNewPosition(sortedBishop1, "Up", "Left");
                    newBishop2 = GetNewPosition(sortedBishop2, "Down", "Right");
                }
                else
                {
                    newBishop1 = GetNewPosition(sortedBishop1, "Down", "Left");
                    newBishop2 = GetNewPosition(sortedBishop2, "Up", "Right");
                }

                if (StringComparer.Ordinal.Compare(newBishop1, newBishop2) < 0)
                    return new string[] { newBishop1, newBishop2 };
                else
                    return new string[] { newBishop2, newBishop1 };

            }
        }

        private string GetNewPosition(string oldPosition, string upOrDown, string leftOrRight)
        {
            string oldFirstChar = "", firstChar = "", a = "abcdefgh";
            int oldFirstCharIndex = -1, newFirstCharIndex = -1, oldSecondChar = -1, secondChar = -1;

            oldFirstChar = oldPosition.Substring(0, 1);
            oldFirstCharIndex = a.IndexOf(oldFirstChar);
            oldSecondChar = Convert.ToInt16(oldPosition.Substring(1, 1));

            if (upOrDown == "Up")
            {
                if (leftOrRight == "Left")
                {
                    newFirstCharIndex = Math.Max(0, oldFirstCharIndex - (8 - oldSecondChar));
                    secondChar = oldSecondChar + (oldFirstCharIndex - newFirstCharIndex);
                }
                else
                {
                    newFirstCharIndex = Math.Min(7, oldFirstCharIndex + (8 - oldSecondChar));
                    secondChar = oldSecondChar - (oldFirstCharIndex - newFirstCharIndex);
                }
            }
            else
            {
                if (leftOrRight == "Left")
                {
                    newFirstCharIndex = Math.Max(0, oldFirstCharIndex - (oldSecondChar - 1));
                    secondChar = oldSecondChar - (oldFirstCharIndex - newFirstCharIndex);
                }
                else
                {
                    newFirstCharIndex = Math.Min(7, oldFirstCharIndex + (oldSecondChar - 1));
                    secondChar = oldSecondChar + (oldFirstCharIndex - newFirstCharIndex);
                }
            }

            firstChar = a.Substring(newFirstCharIndex, 1);

            return firstChar + secondChar;
        }

        int neighbouringElements(int[][] a)
        {
            int count = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j= 0; j <a[0].Length - 1; j++)
                {
                    if (a[i][j] == a[i][j + 1])
                        count++;
                }
            }

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a[0].Length - 1; j++)
                {
                    if (a[j][i] == a[j+1][i])
                        count++;
                }
            }

            return count;
        }

        int secondRightmostZeroBit(int n)
        {
            string a = Convert.ToString(n, 2);

            int i = Convert.ToString(n, 2).LastIndexOf("0");

            int j = a.Substring(0, i).LastIndexOf("0");

            int l = 2;
            for (int k = 1; i < j; k++)
                l *= 2;

            return l;
        }
    }
}
