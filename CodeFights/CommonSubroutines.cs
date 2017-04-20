using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class CommonSubroutines
    {
        /*
         STANDARD DEVIATION:
         * 
         For a list of numbers x1, x2, ..., xn, the standard deviation is found as the square root of the following value: 
         ((x1 - x̅)2 + (x2 - x̅)2 + ... + (xn - x̅)2) / (n - 1), where x̅ is the arithmetic mean of the given list. Note that for n = 1 it's impossible to calculate the standard deviation value.
        */

        public double StandardDeviation(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        public string[][] ConvertMultiDimensionListToArray(List<List<string>> input)
        {
            return input.Select(a => a.ToArray()).ToArray();
        }

        //search inputB in inputA
        public string[] FindMatchingArrayInArray(string[] inputA, string[] inputB)
        {
            var commonNames = inputA.Intersect(inputB);
            return commonNames.ToArray();
        }

        public List<List<string>> PossibleCombinationsOfIndexes(int maxLength, int currentIteration, List<List<string>> combinations)
        {
            if (currentIteration > maxLength)
                return combinations;

            if (currentIteration == -1)
                currentIteration = 1;

            List<string> stringCombinations = GetCombinationList(1, maxLength, currentIteration);

            combinations.Add(stringCombinations);

            currentIteration = currentIteration + 1;

            return PossibleCombinationsOfIndexes(maxLength, currentIteration, combinations);
        }

        private List<string> GetCombinationList(int startPosition, int maxLength, int currentIteration)
        {
            List<string> combinationsForCurrentIteration = new List<string>();

            List<string> items;

            do
            {
                string output = "";
                items = new List<string>();

                items = GetStringCombinations(ref startPosition, maxLength, currentIteration, items, ref output);

                if (items.Count() > 0)
                {
                    foreach (string item in items)
                    {
                        combinationsForCurrentIteration.Add(item);
                    }
                    startPosition = startPosition + 1;
                }
            }
            while (items.Count > 0);

            return combinationsForCurrentIteration;
        }

        private List<string> GetStringCombinations(ref int startPosition, int maxLength, int currentIteration, List<string> combinations, ref string output)
        {
            if (startPosition > maxLength)
                return combinations;

            string item = "";

            for (int i = startPosition; i <= maxLength; i++)
            {
                item = startPosition.ToString();

                if ((currentIteration == 1))
                {
                    output = output + item;
                    combinations.Add(output);
                    return combinations;
                }
                else
                {
                    int lastStartPosition = i + 1;

                    List<string> itemswithNewIterationAndNewStartPosition = new List<string>();

                    string output1 = "";

                    itemswithNewIterationAndNewStartPosition = GetStringCombinations(ref lastStartPosition, maxLength, currentIteration - 1, itemswithNewIterationAndNewStartPosition, ref output1);

                    foreach (string newItem in itemswithNewIterationAndNewStartPosition)
                    {
                        if (combinations.Exists(combination => combination == (item + "|" + newItem)) == false)
                            combinations.Add(item + "|" + newItem);
                    }
                }
            }

            startPosition = startPosition + 1;

            return GetStringCombinations(ref startPosition, maxLength, currentIteration, combinations, ref output);
        }


        //using Merge Sort
        public int[] MergeSortedArray(int[] numbers)
        {
            int inputLength = numbers.Length;

            int[][] arrays = new int[inputLength][];
            int[] sortedNumbers = new int[inputLength];

            for (int i = 0; i < inputLength; i++)
            {
                arrays[i] = new int[1] { numbers[i] };
            }

            sortedNumbers = MergeArrays(arrays)[0];

            return sortedNumbers;
        }

        private int[][] MergeArrays(int[][] arrays)
        {
            if (arrays.Length <= 1)
                return arrays;

            int outputArraysLength = arrays.Length / 2 + arrays.Length % 2;

            int[][] outputArrays = new int[outputArraysLength][];

            int outputArrayCount = 0;

            for (int i = 0; i < arrays.Length; i++)
            {
                if ((arrays.Length - i) >= 2)
                {
                    outputArrays[outputArrayCount] = MergeSortedArrays(arrays[i], arrays[i + 1]);
                    outputArrayCount = outputArrayCount + 1;
                    i = i + 1;
                }
                else
                {
                    outputArrays[outputArrayCount] = arrays[i];
                    break;
                }
            }

            return MergeArrays(outputArrays);
        }

        private int[] MergeSortedArrays(int[] array1, int[] array2)
        {
            int outputArrayLength = array1.Length + array2.Length;

            int[] outputArray = new int[outputArrayLength];

            int outputArrayFilledCount = 0;
            int i = 0;
            int j = 0;

            for ( ; i < array1.Length && j < array2.Length; outputArrayFilledCount ++)
            {
                if (array1[i] < array2[j])
                {
                    outputArray[outputArrayFilledCount] = array1[i];
                    i = i + 1;
                }
                else
                {
                    outputArray[outputArrayFilledCount] = array2[j];
                    j = j + 1;
                }
            }

            if (i < array1.Length)
            {
                for (;i<array1.Length;i++)
                {
                    outputArray[outputArrayFilledCount] = array1[i];
                    outputArrayFilledCount = outputArrayFilledCount + 1;
                }
            }

            if (j < array2.Length)
            {
                for (; j < array2.Length; j++)
                {
                    outputArray[outputArrayFilledCount] = array2[j];
                    outputArrayFilledCount = outputArrayFilledCount + 1;
                }
            }

            return outputArray;
        }


        //using merge sort
        public List<string> LexicographicallyMergeSortedList(List<string> input)
        {
            string[] strings = input.ToArray();

            int inputLength = strings.Length;

            string[][] arrays = new string[inputLength][];
            string[] sortedNumbers = new string[inputLength];

            for (int i = 0; i < inputLength; i++)
            {
                arrays[i] = new string[1] { strings[i] };
            }

            sortedNumbers = MergeArraysStringLexicographically(arrays)[0];

            return sortedNumbers.ToList();
        }

        private string[][] MergeArraysStringLexicographically(string[][] arrays)
        {
            if (arrays.Length <= 1)
                return arrays;

            int outputArraysLength = arrays.Length / 2 + arrays.Length % 2;

            string[][] outputArrays = new string[outputArraysLength][];

            int outputArrayCount = 0;

            for (int i = 0; i < arrays.Length; i++)
            {
                if ((arrays.Length - i) >= 2)
                {
                    outputArrays[outputArrayCount] = MergeSortedArraysStringLexicographically(arrays[i], arrays[i + 1]);
                    outputArrayCount = outputArrayCount + 1;
                    i = i + 1;
                }
                else
                {
                    outputArrays[outputArrayCount] = arrays[i];
                    break;
                }
            }

            return MergeArraysStringLexicographically(outputArrays);
        }


        private string[] MergeSortedArraysStringLexicographically(string[] array1, string[] array2)
        {
            int outputArrayLength = array1.Length + array2.Length;

            string[] outputArray = new string[outputArrayLength];

            int outputArrayFilledCount = 0;
            int i = 0;
            int j = 0;

            for (; i < array1.Length && j < array2.Length; outputArrayFilledCount++)
            {
                //if (array1[i] < array2[j])
                if (LexicographicallySmaller(array1[i], array2[j]) == array1[i])
                {
                    outputArray[outputArrayFilledCount] = array1[i];
                    i = i + 1;
                }
                else
                {
                    outputArray[outputArrayFilledCount] = array2[j];
                    j = j + 1;
                }
            }

            if (i < array1.Length)
            {
                for (; i < array1.Length; i++)
                {
                    outputArray[outputArrayFilledCount] = array1[i];
                    outputArrayFilledCount = outputArrayFilledCount + 1;
                }
            }

            if (j < array2.Length)
            {
                for (; j < array2.Length; j++)
                {
                    outputArray[outputArrayFilledCount] = array2[j];
                    outputArrayFilledCount = outputArrayFilledCount + 1;
                }
            }

            return outputArray;
        }









        //using merge sort
        public void MergeSortedArrayOld(int[] numbers, int left, int right)
        {
            if (left == -1 && right ==-1)
            {
                left = 0;
                right = numbers.Length - 1;
            }

            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortedArrayOld(numbers, left, mid);
                MergeSortedArrayOld(numbers, (mid + 1), right);

                MainMerge(numbers, left, (mid + 1), right);
            }
        }

        public void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[250];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= eol)
                temp[pos++] = numbers[left++];

            while (mid <= right)
                temp[pos++] = numbers[mid++];

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        //using bubble sort
        public void BubbleSortedList(List<int> input)
        {
            int temp = -1;            

            bool atleastOneSwapPerformed = false;

            for (int write = 1; write < input.Count; write++)
            {
                if (write > 1 && !atleastOneSwapPerformed)
                    break;
                else
                    atleastOneSwapPerformed = false;

                for (int sort = 0; sort < input.Count - 1; sort++)
                {
                    if (input[sort + 1] < input[sort])
                    {
                        atleastOneSwapPerformed = true;

                        temp = input[sort + 1];
                        input[sort + 1] = input[sort];
                        input[sort] = temp;
                    }
                }
            }
        }

        //using bubble sort
        public void BubbleSortedList11(List<int> input)
        {
            int temp = -1;

            for (int write = 1; write < input.Count; write++)
            {
                for (int sort = 0; sort < input.Count - 1; sort++)
                {
                    if (input[sort + 1] < input[sort])
                    {
                        temp = input[sort + 1];
                        input[sort + 1] = input[sort];
                        input[sort] = temp;
                    }
                }
            }
        }

        public List<string> LexicographicallyBubbleSortedList(List<string> input)
        {
            string temp = "";

            bool atleastOneSwapPerformed = true;

            for (int write = 1; write < input.Count; write++)
            {
                if (!atleastOneSwapPerformed)
                    break;
                else
                    atleastOneSwapPerformed = false;

                for (int sort = 0; sort < input.Count - 1; sort++)
                {
                    if (LexicographicallySmaller(input[sort], input[sort + 1]) == input[sort + 1])
                    {
                        atleastOneSwapPerformed = true;

                        temp = input[sort + 1];
                        input[sort + 1] = input[sort];
                        input[sort] = temp;
                    }
                }
            }

            return input;
        }

        public string LexicographicallySmaller(string inputA, string inputB)
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

        public int Min(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
        public int[] SplitNumber(int input)
        {
            int[] output = new int[input.ToString().Length];

            if (input < 10)
            {
                output[0] = input;
                return output;
            }

            int i = 0;

            do
            {
                output[output.Length - 1 - i] = input % 10;
                input = input / 10;
                i = i + 1;
            }
            while (input > 0);

            return output;
        }

        public void SSISTest()
        {
            string s = "CA_ScoreStatus_20170201_101822_001.csv";

            string s1 = s.Trim().ToUpper().Replace(".CSV", "").Split('_')[4];
        }

    }
}
