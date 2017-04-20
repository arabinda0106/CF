using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class CodeFightBot
    {
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

        public int shortestSolutionLength(string[] source)
        {
            int characterCount = 0;

            bool currentlyIgnoringComments = false;

            for (int i = 0; i < source.Count(); i++)
            {
                if (source[i].Trim().Length > 0)
                {
                    if (!currentlyIgnoringComments && ((source[i].Contains("//") && source[i].Contains("/*") && source[i].IndexOf("//") < source[i].IndexOf("/*")) || (source[i].Contains("//") && !source[i].Contains("/*"))))
                    {
                        source[i] = source[i].Split(new string[] { "//" }, StringSplitOptions.None)[0];
                    }
                    else
                    {
                        if (source[i].Contains("/*") || currentlyIgnoringComments)
                        {
                            string temp = source[i].Trim();

                            int commentStartIndex = temp.IndexOf("/*");
                            int commentEndIndex = -1;

                            if (commentStartIndex > -1)
                                commentEndIndex = temp.Substring(commentStartIndex + 2, temp.Length - commentStartIndex - 2).LastIndexOf("*/");
                            else
                                commentEndIndex = temp.LastIndexOf("*/");

                            if (commentStartIndex > -1 && commentEndIndex > -1)
                                commentEndIndex = commentStartIndex + 2 + commentEndIndex;

                            if (currentlyIgnoringComments == false)
                            {
                                if (commentEndIndex > -1)
                                {
                                    temp = temp.Substring(0, commentStartIndex) + temp.Substring(commentEndIndex + 2, temp.Length - commentEndIndex - 2);
                                    currentlyIgnoringComments = false;

                                    if (temp.Contains("//"))
                                        temp = temp.Split(new string[] { "//" }, StringSplitOptions.None)[0];
                                }
                                else
                                {
                                    temp = temp.Substring(0, commentStartIndex);
                                    currentlyIgnoringComments = true;
                                }
                            }
                            else
                            {
                                if (commentEndIndex > -1)
                                {
                                    temp = temp.Substring(commentEndIndex + 2, temp.Length - commentEndIndex - 2);

                                    currentlyIgnoringComments = false;

                                    if (temp.Contains("//"))
                                        temp = temp.Split(new string[] { "//" }, StringSplitOptions.None)[0];
                                }
                                else
                                    temp = "";
                            }
                            source[i] = temp;
                        }
                    }
                    characterCount = characterCount + source[i].Trim().Replace(" ", "").Length;
                }
            }
            return characterCount;
        }
    }
}
