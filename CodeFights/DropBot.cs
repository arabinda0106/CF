using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class DropBot
    {
        /*
        One Very Important User (VIU) has a Very Confidential Document (VCD) stored on his Dropbox account. He doesn't let anyone see the VCD, especially his roommates who often have access to his devices.

        Opening the Dropbox mobile app on the VIU's tablet requires a four-digit passcode. To ensure the confidentiality of the stored information, the device is locked out of Dropbox after 10 consecutive 
        failed passcode attempts. We need to implement a function that given an array of attempts made throughout the day and the correct passcode checks to see if the device should be locked, 
        i.e. 10 or more consecutive failed passcode attempts were made.

        Example

        For
        passcode = "1111" and

        attempts = ["1111", "4444",
                    "9999", "3333",
                    "8888", "2222",
                    "7777", "0000",
                    "6666", "7285",
                    "5555", "1111"]
        the output should be
        incorrectPasscodeAttempts(passcode, attempts) = true.

        The first attempt is correct, so the user must have successfully logged in. However, the next 10 consecutive attempts are incorrect, so the device should be locked. Thus, the output should be true.

        For
        passcode = "1234" and

        attempts = ["9999", "9999",
                    "9999", "9999",
                    "9999", "9999",
                    "9999", "9999",
                    "9999", "1234",
                    "9999", "9999"]
        the output should be
        incorrectPasscodeAttempts(passcode, attempts) = false.

        There are only 9 consecutive incorrect attempts, so there's no need to lock the device.

        Input/Output

        [time limit] 3000ms (cs)
        [input] string passcode

        String consisting of exactly 4 digits representing the correct passcode.

        [input] array.string attempts

        Array representing the passcode attempts in the order they were made. Each element of attempts is a string consisting of exactly 4 digits.

        Constraints:
        0 ≤ attempts.length ≤ 20.

        [output] boolean

        true if 10 or more consecutive failed passcode attempts were made, false otherwise.
        */

        public bool incorrectPasscodeAttempts(string passcode, string[] attempts)
        {
            int totTries = 0;

            for(int i = 0; i < attempts.Length; i ++)
            {
                if (attempts[i] != passcode)
                    totTries += 1;
                else
                    totTries = 0;

                if (totTries == 10)
                    break;
            }

            return (totTries == 10 ? true : false);
        }

        public string losslessDataCompression(string inputString, int width)
        {
            string window = "", output = "";

            for(int i = 0; i < inputString.Length; i++)
            {
                int j = 0;

                if (i <= width)
                {
                    window = inputString.Substring(0, i);
                    j = i;
                }
                else
                {
                    window = inputString.Substring(i - width, width);
                    j = width;
                }

                if (j > inputString.Length - i)
                    j = inputString.Length - i;

                if (window == "")
                {
                    window = inputString.Substring(0, 1);
                    output = window;
                }
                else
                {
                    bool foundMatch = false;

                    int k = j;

                    for (; k > 0; k--)
                    {
                        string newSubString = inputString.Substring(i, k);

                        if (window.Contains(newSubString))
                        {
                            output += "(" + (window.IndexOf(newSubString) + i - window.Length).ToString() + "," + newSubString.Length.ToString() + ")";
                            foundMatch = true;
                            i += (k - 1 > 0 ? k - 1 : 0);
                            break;
                        }
                    }

                    if (!foundMatch)
                        output += inputString.Substring(i, k + 1);
                }
            }

            return output;
        }

        /*
        When a file in a user's Dropbox folder is changed, while synchronizing Dropbox tries to only upload the parts of the file that are different. 
        The first step to accomplish this involves building a representation of the difference between the two versions of the same file.

        As part of Dropbox's engineering team, you've decided to implement a function that will represent the difference between two strings in the following format:

        Two strings are merged into one.
        Text that is present in both versions is left untouched.
        Text that is present only in the old version is enclosed in parentheses ((, )).
        Text that is present only in the new version is enclosed in brackets ([, ]).
        Among all possible representations, your function returns the shortest one (brackets and parentheses do not count).
        Among representations of minimal length, your function returns the lexicographically smallest one.
        For this task, please, assume that any other character < '(' < ')' < '[' < ']'.
        Now all you have to do is to implement this function.

        Example

        For oldVersion = "same_prefix_1233_same_suffix"
        and newVersion = "same_prefix23123_same_suffix", the output should be
        displayDiff(oldVersion, newVersion) = "same_prefix(_1)23[12]3_same_suffix".

        Input/Output

        [time limit] 3000ms (cs)
        [input] string oldVersion

        Constraints:
        1 ≤ oldVersion.length ≤ 35.

        [input] string newVersion

        It is guaranteed that neither oldVersion nor newVersion contains parentheses or brackets.

        Constraints:
        1 ≤ newVersion.length ≤ 35.

        [output] string

        A string built from oldVersion and newVersion satisfying all of the conditions mentioned above.
        */

        public string displayDiff(string oldVersion, string newVersion)
        {
            string output = "", tempOld = "", tempNew = "";
            bool completed = false;

            int oldLength = oldVersion.Length, newLength = newVersion.Length, i = 0, j = 0;

            string commonContentFromRight = "";

            if (oldLength != newLength)
            {
                bool stillMatching = true;
                int k = 0;
                while(stillMatching)
                {
                    if (oldVersion[oldLength - k - 1] == newVersion[newLength - k - 1])
                        commonContentFromRight = oldVersion[oldLength - k - 1].ToString() + commonContentFromRight;
                    else
                        stillMatching = false;

                    k += 1;
                }
            }

            if (commonContentFromRight != "")
            {
                oldVersion = oldVersion.Replace(commonContentFromRight, "");
                newVersion = newVersion.Replace(commonContentFromRight, "");

                oldLength = oldVersion.Length;
                newLength = newVersion.Length;
            }

            while(!completed)
            {
                if (oldVersion[i] == newVersion[j])
                {
                    if (tempOld != "")
                    {
                        output = output + "(" + tempOld + ")";
                        tempOld = "";
                    }
                    if (tempNew != "")
                    {
                        output = output + "[" + tempNew + "]";
                        tempNew = "";
                    }
                    output = output + oldVersion[i].ToString();

                    if (i != j && (i == oldLength - 1 || j == newLength - 1))
                    {
                        if (i == oldLength - 1)
                        {
                            tempNew = tempNew + newVersion.Substring(j + 1, newVersion.Length - j - 1);
                            output = ApendLexicographically(output, "", tempNew);
                        }
                        else
                        {
                            tempOld = tempOld + oldVersion.Substring(i + 1, oldVersion.Length - i - 1);
                            output = ApendLexicographically(output, tempOld, "");
                        }

                        break;
                    }

                    if (i < oldLength)
                        i += 1;

                    if (j < newLength)
                        j += 1;

                }
                else
                {
                    if ((tempOld != "") || (i <= j))
                    {
                        tempOld = tempOld + oldVersion[i].ToString();
                        if (i < oldLength - 1)
                            i += 1;
                        else
                        {
                            tempNew = tempNew + newVersion.Substring(j, newVersion.Length - j);
                            output = ApendLexicographically(output, tempOld, tempNew);
                            completed = true;
                        }
                    }
                    else
                    {
                        bool skipThis = false;

                        if (i < oldLength - 1)
                        {
                            if (newVersion[j] == oldVersion[i + 1])
                                skipThis = true;
                        }

                        if (skipThis == false)
                        {
                            tempNew = tempNew + newVersion[j].ToString();
                        }

                        if ((j < newLength - 1) && (skipThis == false))
                            j += 1;
                        else
                        {
                            if (skipThis)
                            {
                                tempOld = tempOld + oldVersion[i].ToString();
                                i += 1;
                            }
                            else
                            {
                                tempOld = tempOld + oldVersion.Substring(i, oldVersion.Length - i);
                                output = ApendLexicographically(output, tempOld, tempNew);
                                completed = true;
                            }
                        }
                    }
                }

                if (i == oldLength && j == newLength)
                    completed = true;
            }

            if (commonContentFromRight != "")
                output = output + commonContentFromRight;

            return output;
        }

        private string ApendLexicographically(string output, string tempOld, string tempNew)
        {
            if (tempOld != "")
                tempOld = "(" + tempOld + ")";

            if (tempNew != "")
                tempNew = "[" + tempNew + "]";

            int compareResult = String.Compare(tempOld, tempNew);
            if (compareResult < 0)
                output = output + tempOld + tempNew;
            else
                output = output + tempNew + tempOld;
            return output;
        }
    }
}
