using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class AsanaBot
    {
        /*
    Given an integer, find the sum of all its digits.

    Example

    For n = 111, the output should be
    digitSum(n) = 3.

    1 + 1 + 1 = 3.

    Input/Output

    [time limit] 3000ms (cs)
    [input] integer n

    Constraints:
    0 ≤ n ≤ 2 · 109.

    [output] integer
     * */
        public int digitSum(int n)
        {
            int sumTotal = 0;

            for (int i = 10; ;)
            {
                if (n / i != 0)
                    sumTotal = sumTotal + n % i;
                else
                {
                    sumTotal = sumTotal + n;
                    break;
                }
                n = n / i;
            }

            return sumTotal;
        }

        public int[] tasksTypes(int[] deadlines, int day)
        {
            int[] taskTypesCount = new int[3];

            int todayCount = 0;
            int upcomingCount = 0;
            int laterCount = 0;

            for (int count = 0; count < deadlines.Length; count++)
            {
                if (deadlines[count] <= day)
                    todayCount = todayCount + 1;
                else if (deadlines[count] <= day + 7)
                    upcomingCount = upcomingCount + 1;
                else
                    laterCount = laterCount + 1;
            }

            taskTypesCount[0] = todayCount;
            taskTypesCount[1] = upcomingCount;
            taskTypesCount[2] = laterCount;

            return taskTypesCount;
        }

        /*
        Asana is exploring a smart-workload feature designed to streamline task assignment between coworkers. Newly created tasks will be automatically assigned to the team member with the lightest workload. For the ith person the following information is known:

        namesi - their name, a string containing only uppercase and lowercase letters;
        statusesi - their vacation indicator status, which is true if the person is on a vacation, or false otherwise;
        projectsi - the number of projects they are currently involved in;
        tasksi - the number of tasks assigned to the report.
        If a person's vacation indicator value is set to true, this means they are on vacation and cannot be assigned new tasks. Conversely, a vacation indicator value of false means they are open to receive task assignments.

        Asana sorts team members according to their availability. Person A has a higher availability than person B if they have fewer tasks to do than B, or if these numbers are equal but A has fewer assigned projects than B. Put another way, we can say that person A has a higher availability than person B if their (tasks, projects) pair is less than the same pair for B.

        Your task is to find the name of the person with the highest availability. It is guaranteed that there is exactly one such person.

        Example

        For names = ["John", "Martin"], statuses = [false, false],
        projects = [2, 1] and tasks = [16, 5],
        the output should be
        smartAssigning(names, statuses, projects, tasks) = "Martin".

        The arguments represent information about two team members:

        "John", with status = false, projects = 2 and tasks = 16;
        "Martin", with status = false, projects = 1 and tasks = 5.
        Here John and Martin's vacation indicators are both true, so both of them are open to new assignments. Martin is only assigned 5 tasks while John is assigned 6, so Martin has the highest availability.

        For names = ["John", "Martin"], statuses = [false, true],
        projects = [2, 1] and tasks = [6, 5],
        the output should be
        smartAssigning(names, statuses, projects, tasks) = "John".

        The arguments stand for the following team members:

        "John", with status = false, projects = 2 and tasks = 1;
        "Martin", with status = true, projects = 1 and tasks = 5.
        In this example Martin cannot be assigned any new tasks because his vacation indicator is true. Therefore, "John" has the highest availability.

        For names = ["John", "Martin"], statuses = [false, false],
        projects = [1, 2] and tasks = [6, 6],
        the output should be
        smartAssigning(names, statuses, projects, tasks) = "John".

        For the following information is given:

        "John", with status = false, projects = 1 and tasks = 6;
        "Martin", with status = false, projects = 2 and tasks = 6.
        Both John and Martin's vacation indicators are false, and the number of tasks each of them is assigned is 6. However, John is involved in just 1 project, while Martin is involved in 2, so John has the highest availability.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string names

        Array of team members' names.

        [input] array.boolean statuses

        Array of vacation indicators of team members, where statuses[i] corresponds to the ith team member: if statuses[i] = true, the ith member is on a vacation. Otherwise, they're free to take the task.

        [input] array.integer projects

        Array of projects each team member is involved in, where projects[i] corresponds to the ith team member.

        [input] array.integer tasks

        Array of tasks each team member is assigned to, where tasks[i] corresponds to the ith team member.

        [output] string

        The name of the person with the highest availability.

        GIVE UP
        START CODING

         */
        public string smartAssigning(string[] names, bool[] statuses, int[] projects, int[] tasks)
        {
            names = new string[] { "John", "Martin", "Ipu" };
            statuses = new bool[] { false, true, false };
            projects = new int[] { 4, 1, 3 };
            tasks = new int[] { 2, 2, 2 };

            if (names.Length == 0)
                return "";

            if (names.Length == 1)
                return names[0];

            //find all the statuses with value as false and store those indexes in a List and then do comparisons with only for those indexes rather than comparing everything.

            List<int> falseStatusIndexList = new List<int>();

            for (int count = 0; count < statuses.Length; count++)
            {
                if (statuses[count] == false)
                    falseStatusIndexList.Add(count);
            }

            if (falseStatusIndexList.Count() == 1)
                return names[falseStatusIndexList[0]];

            int avaliableNameIndex = falseStatusIndexList[0];

            for (int count = 1; count < falseStatusIndexList.Count(); count++)
            {
                if (tasks[avaliableNameIndex] < tasks[falseStatusIndexList[count]])
                    continue;
                else if (tasks[avaliableNameIndex] == tasks[falseStatusIndexList[count]])
                {
                    if (projects[avaliableNameIndex] > projects[falseStatusIndexList[count]])
                        avaliableNameIndex = falseStatusIndexList[count];
                }
                else
                    avaliableNameIndex = falseStatusIndexList[count];

            }

            return names[avaliableNameIndex];
        }


        #region
        /*
        If you have a task that you need to complete on a regular basis, you can set it up in Asana as a recurring task. One option is to schedule the task to repeat every k weeks on specified days of the week.

        It would be useful to be able to view the first n dates for which the task is scheduled. Given the first date for which the task is scheduled, return an array of the first n dates.

        In this task, you'll likely need month lengths and weekday names, provided here:

        Month lengths from January to December: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.

        During leap years February has 29 days.
        Names of weekdays: "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday".

        January 1, 2015 was a Thursday.

        Example

        For firstDate = "01/01/2015", k = 2, daysOfTheWeek = ["Monday", "Thursday"] and n = 4, the output should be

        recurringTask(firstDate, k, daysOfTheWeek, n) = 
            ["01/01/2015", "05/01/2015", "15/01/2015", "19/01/2015"]


        firstDate falls on a Thursday. The first Monday after it is "05/01/2015". Since k = 2, the next two days for which the task is scheduled are Thursday, January 15, and Monday, January 19.

        Input/Output

        [time limit] 3000ms (cs)
        [input] string firstDate

        A string in the format "dd/mm/yyyy", representing some date either in the past, or in the future. It is guaranteed that the date is between 1900 and 3999, both inclusive.

        [input] integer k

        A positive integer.

        Constraints:
        1 ≤ k ≤ 20.

        [input] array.string daysOfTheWeek

        Array containing from 1 to 7 distinct elements, inclusive, each of which equals a weekday name. Weekdays appear in the same order they are given in the description.
        It's guaranteed that the day of the week on which the firstDate falls is present in this list.

        Constraints:
        1 ≤ daysOfTheWeek.length ≤ 7.

        [input] integer n

        Constraints:
        1 ≤ n ≤ 15.

        [output] array.string

        Array containing the first n dates (including the first one) on which the task is scheduled in the chronological order.         
         */
        #endregion
        public string[] recurringTask(string firstDate, int k, string[] daysOfTheWeek, int n)
        {
            firstDate = "01/01/2015";
            k = 2;
            daysOfTheWeek = new string[] { "Monday", "Thursday", "Friday" };
            n = 12;

            string[] firstDateDetails = firstDate.Split('/');

            int month = Convert.ToInt16(firstDateDetails[1]);
            int day = Convert.ToInt16(firstDateDetails[0]);
            int year = Convert.ToInt16(firstDateDetails[2]);

            string firstDateDayOfWeek = new DateTime(year, month, day).DayOfWeek.ToString();

            List<string> recurringTaskDates = new List<string>();

            DateTime dtStart = new DateTime(year, month, day);

            for (int count = 0; recurringTaskDates.Count() < n; count++)
            {
                for (int dayCount = 0; dayCount < 7 && recurringTaskDates.Count() < n; dayCount++)
                {
                    DateTime dt = dtStart.AddDays(dayCount);
                    if (Array.IndexOf(daysOfTheWeek, dt.DayOfWeek.ToString()) > -1)
                        recurringTaskDates.Add(dt.ToString("MM/dd/yyyy"));
                }
                dtStart = dtStart.AddDays(k * 7);
            }

            return recurringTaskDates.ToArray();
        }
    }
}
