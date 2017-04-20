using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class TackBot
    {
        /*
        In Thumbtack, users are able to rate Pros based on their experience working with them. Each rating is an integer ranging from 1 to 5, and all ratings are averaged to produce a single number rating for any given Pro. Those Pros who have a rating lower than a specified threshold are manually reviewed by Thumbtack staff to ensure high quality of service.

        You're given a list of ratings for some Pros. Find out which Pros should be manually reviewed.

        Example

        For threshold = 3.5 and

        ratings = [[3, 4],
                   [3, 3, 3, 4],
                   [4]]
        the output should be ratingThreshold(threshold, ratings) = [1].

        Assume that we have 3 Pros that have received the following ratings: [3, 4], [3, 3, 3, 4] and [4]. Then
        And if threshold = 3.5 the answer is ratingThreshold(threshold, ratings) = [1].
        The first Pro's rating is 3.5, the second one's is 3.25, and the last one's is 4, so only the second Pro should be reviewed manually (the output is their 0-based index).

        Input/Output

        [time limit] 3000ms (cs)
        [input] float threshold

        A positive number not greater than 5. Those Pros whose ratings are lower than threshold should be manually reviewed.

        Constraints:
        1 ≤ threshold ≤ 5.

        [input] array.array.integer ratings

        For each valid i, ratings[i] is a non-empty array that represents the last ratings the ith Pro has received.

        Constraints:
        0 ≤ ratings.length ≤ 5,
        1 ≤ ratings[i].length ≤ 15,
        1 ≤ ratings[i][j] ≤ 5.

        [output] array.integer

        0-based indices of the Pros that should be reviewed, sorted in ascending order.
        */
        public int[] ratingThreshold(double threshold, int[][] ratings)
        {
            List<int> output = new List<int>();

            for(int i = 0; i < ratings.Length; i++)
                if (ratings[i].Average(j => j) < threshold)
                    output.Add(i);

            return output.ToArray();
        }

        /*
        Thumbtack helps Professionals (Pros) grow their business by identifying new customers. Upon registering on Thumbtack, a Pro specifies which categories of services they provide. 
        To help match customer requests with qualified Pros, Thumbtack maintains a list of Pros grouped by service categories.

        Given a list of pros and their category preferences, return the list of Pros for each category.

        Example

        For pros = ["Jack", "Leon", "Maria"] and

        preferences = [["Computer repair", "Handyman", "House cleaning"],
                       ["Computer lessons", "Computer repair", "Data recovery service"],
                       ["Computer lessons", "House cleaning"]]
        the output should be

        proCategorization(pros, preferences) = [[["Computer lessons"], ["Leon", "Maria"]],
                                                [["Computer repair"], ["Jack", "Leon"]],
                                                [["Data recovery service"], ["Leon"]],
                                                [["Handyman"], ["Jack"]],
                                                [["House cleaning"], ["Jack", "Maria"]]]
        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string pros

        A sorted non-empty array of unique strings consisting of English letters.

        Here and below we assume that strings are sorted lexicographically.

        Constraints:
        1 ≤ pros.length ≤ 5,
        3 ≤ pros[i].length ≤ 10.

        [input] array.array.string preferences

        Array of the same length as pros. For each valid i preferences[i] is a sorted array of unique elements, representing the categories the ith Pro provides services in.

        Constraints:
        1 ≤ preferences.length ≤ 5,
        1 ≤ preferences[i].length ≤ 10,
        3 ≤ preferences[i][j].length ≤ 25.

        [output] array.array.array.string

        Array of category descriptions sorted by category names. Each category should be listed in the following format: [[<category>], [<Pro1>, <Pro2>...]] where <category> is a category name, and <Proi> is a Pro that provides services in it.

        Each category present in preferences should be returned (in the right order), and Pros in each subarray should be sorted.
        */
        public string[][][] proCategorization(string[] pros, string[][] preferences)
        {
            HashSet<string> categoriesBeforeSorted = new HashSet<string>();
            List<List<List<string>>> output = new List<List<List<string>>>();

            foreach (string[] pro in preferences)
                foreach (string preference in pro)
                    categoriesBeforeSorted.Add(preference);

            var categories = categoriesBeforeSorted.OrderBy(x => x, StringComparer.Ordinal).ToList();

            foreach (string category in categories)
            {
                List<string> professionals = new List<string>();

                for(int i = 0; i < preferences.Length; i++)
                    if (preferences[i].Contains(category))
                        professionals.Add(pros[i]);

                output.Add(new List<List<string>> { new List<string> { category }, professionals });
            }

            return output.Select(i=> i.Select(j=>j.ToArray()).ToArray()).ToArray();
        }

        /*
        Thumbtack tries to identify spam coming from multiple user accounts by comparing job request descriptions and identifying clusters that have high similarity. 
        Their data analysis engineers are testing out a new clusterization algorithm that uses the Jaccard index. As a prospective team member, you've been asked to implement this algorithm.

        You are given a list of requests and IDs of the users who submitted them. Implement the following algorithm to identify possible spammers:

        first, split each request into a set of words and convert them to lowercase. We formally define a word as a substring consisting of English letters, 
        such that characters to the left of the leftmost letter and to the right of the rightmost letter are not letters;
        next, calculate the Jaccard index of each pair of sets;
        divide the sets into clusters so that:
        each set belongs to some cluster;
        if Jaccard index of two sets A and B is not less than the given threshold (meaning they are too similar), 
        they belong to the same cluster. Note that if A and B as well as B and C satisfy this criteria, then A, B and C belong to the same cluster;
        for each cluster that has more than one element, return the list of their author IDs in ascending order.
        Example

        For

        requests = ["I need a new window.",
                    "I really, really want to replace my window!",
                    "Replace my window.",
                    "I want a new window.",
                    "I want a new carpet, I want a new carpet, I want a new carpet.",
                    "Replace my carpet"]
        IDs = [374, 2845, 83, 1848, 1837, 1500] and
        threshold = 0.5, the output should be
        spamClusterization(requests, IDs, threshold) = [[83, 1500], [374, 1837, 1848]].

        The sets of words obtained after the first step are:

        {"i", "need", "a", "new", "window"} - 5 elements;
        {"i", "really", "want", "to", "replace", "my", "window"} - 7 elements;
        {"replace", "my", "window"} - 3 elements;
        {"i", "want", "a", "new", "window"} - 5 elements;
        {"i", "want", "a", "new", "carpet"} - 5 elements (note that a set consists only of unique elements);
        {"replace", "my", "carpet"} - 3 elements.
        Here's a table of Jaccard indices for each pair of request (there are 6 requests in total):

        1	2	3	4	5	6
        1	-	2/10 = 1/5	1/7	4/6 = 2/3	3/7	0/8 = 0
        2	1/5	-	3/7	3/9 = 1/3	2/10 = 1/5	2/8 = 1/4
        3	1/7	3/7	-	1/7	0/8 = 0	2/4 = 1/2
        4	4/6	3/9	1/7	-	4/6 = 2/3	0/8 = 0
        5	3/7	1/5	0	2/3	-	1/7
        6	0	1/4	1/2	0	1/7	-
        Since threshold = 0.5, there are two clusters with more than one element. The first one contains the third and the sixth requests, 
        and the second one contains requests number one, four and five (since Jaccard index of the first and fourth requests and of the fourth 
        and fifth requests is larger than threshold, they all belong to the same cluster). After sorting their author IDs, we arrive at the answer.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string requests

        A non-empty list of requests. Each request is a non-empty string consisting of English letters, punctuation marks and whitespace characters.

        Constraints:
        1 ≤ requests.length ≤ 10,
        1 ≤ requests[i].length ≤ 65.

        [input] array.integer IDs

        Array of unique elements of the same size as requests.

        Constraints:
        1 ≤ IDs.length ≤ 10,
        1 ≤ IDs[i] ≤ 3000.

        [input] float threshold

        Constraints:
        0.0 ≤ threshold ≤ 1.0.

        [output] array.array.integer

        Each element of the output should contain IDs of users whose requests ended up in the same cluster sorted in ascending order. Output array elements should be sorted by the smallest IDs they contain.
        */

        public int[][] spamClusterization(string[] requests, int[] IDs, double threshold)
        {
            if (requests.Length <= 1)
            {
                if (threshold == 0)
                    return new int[][] { };
                else
                    return new int[][] { new int[] { IDs[0] } };
            }

            List<List<string>> words = new List<List<string>>();

            foreach(string request in requests)
            {
                string[] s = request.Split(' ');
                HashSet<string> ls = new HashSet<string>();
                foreach(string w in s)
                {
                    string word = ReturnWord(w.ToLower());
                    if (word != "")
                        ls.Add(word);
                }
                if (ls.Count() > 0)
                    words.Add(ls.ToList());
                else
                    words.Add(new List<string> { });
            }

            double[][] jaccardIndexes = new double[requests.Length][];

            for (int i = 0; i < requests.Length; i ++)
            {
                jaccardIndexes[i] = new double[requests.Length];

                for (int j = 0; j < requests.Length; j++)
                    if (i != j)
                        jaccardIndexes[i][j] = GetJaccardIndex(words[i], words[j]);
            }

            Dictionary<double, List<int>> output = new Dictionary<double, List<int>>();

            for (int i = 0; i < jaccardIndexes.Length; i++)
            {
                for (int j = 0; j < jaccardIndexes[i].Count(); j++)
                {
                    if (jaccardIndexes[i][j] >= threshold && i != j)
                    {
                        List<int> ls = new List<int>();

                        ls.Add(IDs[i]);
                        ls.Add(IDs[j]);

                        ls = ls.OrderBy(k => k).ToList();

                        if (output.Count == 0)
                            output.Add(jaccardIndexes[i][j], ls);
                        else
                        {
                            if (!output.ContainsKey(jaccardIndexes[i][j]))
                                output.Add(jaccardIndexes[i][j], ls);
                            else
                                output[jaccardIndexes[i][j]] = output[jaccardIndexes[i][j]].Union(ls).ToList().OrderBy(l => l).ToList(); ;

                        }
                    }
                }
            }

            return output.Select(m => m.Value).ToList().OrderBy(n => n[0]).Select(o => o.ToArray()).ToArray();

            //List<List<int>> output = new List<List<int>>();

            //for (int i = 0; i < jaccardIndexes.Length; i++)
            //{
            //    HashSet<int> row = new HashSet<int>();

            //    for (int j = 0; j < jaccardIndexes[i].Count(); j++)
            //    {
            //        if (jaccardIndexes[i][j] >= threshold && i != j)
            //        {
            //            row.Add(IDs[i]);
            //            row.Add(IDs[j]);

            //            if (output.Count() == 0)
            //                output.Add(row.OrderBy(k => k).ToList());
            //            else
            //            {
            //                bool matchFound = false;
            //                for (int l = 0; l < output.Count(); l++)
            //                {
            //                    int size = output[l].Intersect(row.ToList()).Count();

            //                    if (size > 0 && size <= Math.Max(output[l].Count(), row.Count()))
            //                    {
            //                        output[l] = output[l].Union(row.ToList()).ToList().OrderBy(m => m).ToList();
            //                        matchFound = true;
            //                        break;
            //                    }
            //                }

            //                if (!matchFound)
            //                    output.Add(row.OrderBy(k => k).ToList());
            //            }
            //        }
            //    }
            //}

            //return output.OrderBy(m => m[0]).Select(n => n.ToArray()).ToArray();

        }

        private string ReturnWord(string input)
        {
            int j = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if ((int)input[i] < 97 || (int)input[i] > 122)
                    j += 1;
                else
                    break;

            }

            input = input.Remove(0, j);

            j = 0;

            for (int i = input.Length - 1; i >=0 ; i--)
            {
                if ((int)input[i] < 97 || (int)input[i] > 122)
                    j += 1;
                else
                    break;

            }

            input = input.Remove(input.Length - j, j);

            return input;
        }

        /*
        A Thumbtack customer has just submitted a request for a house painter to paint a one bedroom house in San Francisco. Our job is to find Pros who provide this service 
        and whose travel distance preference is ideal for the job. To measure how well the Pro and the request match, we calculate their matching score and non-matching score as follows:

        if the Pro's distance from the customer's house does not exceed their maximum preferred travel distance, then their matching score equals the distance between the pro and the customer;
        otherwise we calculate a non-matching score as the difference between the distance from the pro to the customer, and their maximum preferred travel distance.
        For example, let's say a pro Jane has a maximum travel distance of 10 miles.

        If a customer is located 5 miles away, their matching score is 5 miles.
        If a customer is located 12 miles away, their "non-matching" score is 2 miles.
        To select the top 5 Pros, we sort them so that those who have a matching score are always shown before those who have a non-matching score, and both matching scores and non-matching scores are sorted in ascending order. 
        If two or more Pros have equal scores, they are sorted by their names in lexicographical order.

        You're given a list of pros who match the "house painting" category, their distances from the customer's house, and their travelPreferences, which denotes the maximum distance each Pro is willing to travel for a given job. Return the top 5 Pros sorted as described above. If there are fewer than 5 Pros, return them all.

        Example

        For

        pros = ["Michael", "Mary", "Ann", "Nick", "Dan", "Mark"],

        distances = [12, 10, 19, 15, 5, 20] and

        travelPreferences = [12, 8, 25, 10, 3, 10], the output should be

        requestMatching(pros, distances, travelPreferences) = ["Michael", "Ann", "Dan", "Mary", "Nick"].

        Here's how Pros will be sorted in accordance with their scores:

        "Michael": matching score equals 12;
        "Ann": matching score equals 19;
        "Dan": non-matching score equals 5 - 3 = 2;
        "Mary": non-matching score equals 10 - 8 = 2;
        "Nick": non-matching score equals 15 - 10 = 5;
        "Mark": non-matching score equals 20 - 10 = 10.
        For

        pros = ["Ann", "Michael", "Mary"],

        distances = [5, 5, 5] and

        travelPreferences = [3, 10, 7], the output should be

        requestMatching(pros, distances, travelPreferences) = ["Mary", "Michael", "Ann"].

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string pros

        A non-empty array of unique Pros' names.

        Constraints:

        1 ≤ pros.length ≤ 10,

        1 ≤ pros[i].length ≤ 10.

        [input] array.integer distances

        Array of positive integers. For each valid i distances[i] denotes the distance from the ith Pro to the customer's house.

        Constraints:

        distance.length = pros.length,

        2 ≤ distances[i] ≤ 20.

        [input] array.integer travelPreferences

        Array of positive integers. For each valid i travelPreferences[i] denotes the maximum preferred travel distance of the ith Pro.

        Constraints:

        travelPreferences.length = pros.length,

        1 ≤ travelPreferences[i] ≤ 25.

        [output] array.string

        Top 5 (or fewer) Pros sorted as described above.
        */
        public string[] requestMatching(string[] pros, int[] distances, int[] travelPreferences)
        {
            Dictionary<string, int> matchingDistances = new Dictionary<string, int>();
            Dictionary<string, int> nonMatchingDistances = new Dictionary<string, int>();

            for (int i = 0; i < pros.Length; i++)
            {
                if (distances[i] <= travelPreferences[i])
                    matchingDistances.Add(pros[i], distances[i]);
                else
                    nonMatchingDistances.Add(pros[i], Math.Abs(distances[i] - travelPreferences[i]));
            }

            List<string> matchingDistancesList = matchingDistances.OrderBy(a => a.Value).ThenBy(b => b.Key, StringComparer.Ordinal).Select(c => c.Key).ToList();
            List<string> nonMatchingDistancesList = nonMatchingDistances.OrderBy(a => a.Value).ThenBy(b => b.Key, StringComparer.Ordinal).Select(c => c.Key).ToList();

            if (pros.Length <= 5)
                return matchingDistancesList.Union(nonMatchingDistancesList).ToArray();
            else
            {
                if (matchingDistancesList.Count() >= 5)
                    return matchingDistancesList.Take(5).ToArray();
                else
                    return matchingDistancesList.Union(nonMatchingDistancesList.Take(5 - matchingDistancesList.Count())).ToArray();
            }
        }

        /*
        When a customer submits a job request on Thumbtack, this information is sent to Pros in the area who might be interested in it. If it looks like there's a fit, a Pro can respond with a custom quote that includes a personal message and a price estimate.

        Thumbtack tries to help Pros pick a price estimate range using historical contractData, which contains prices for the same job type in the same area. You have been asked to implement the following two-step price suggestion algorithm:

        In the first step, contractData, which is guaranteed to have an even length, is sorted and divided into two groups:
        the first group contains the first half of the elements in contractData.
        the second group contains the other half;
        In the second step, the median values of the first and the second groups are found:
        the median of the first group is rounded down and returned as the lower price bound;
        the median of the second group is rounded up and returned as the upper price bound.
        If the data is insufficient (i.e. contractData contains fewer than 2 elements), a suggestion cannot be made, so nothing should be returned.
        Using the given contractData, find the lower and the upper bounds of the suggested price estimate range.

        Example

        For contractData = [10, 15, 14, 7, 11, 15], the output should be

        priceSuggestion(contractData) = [10, 15].
        The first step produces groups [7, 10, 11] and [14, 15, 15];
        The second step returns 10 and 15.
        For contractData = [], the output should be

        priceSuggestion(contractData) = [].
        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer contractData

        A list of prices for the same job type in the same area that's guaranteed to have an even length.

        Constraints:

        0 ≤ contractData.length ≤ 8,

        1 ≤ contractData[i] ≤ 200.

        [output] array.integer

        Array of two elements denoting the suggested price range, or an empty array if the given data is insufficient.

        GIVE UP
        START CODING
         */
        public int[] priceSuggestion(int[] contractData)
        {
            if (contractData.Length < 2)
                return new int[] { };

            Array.Sort(contractData);

            if (contractData.Length == 2)
                return contractData;

            int halfLength = contractData.Length / 2;

            int[] firstHalf = contractData.Take(halfLength).ToArray();
            int[] secondHalf = contractData.Skip(halfLength).Take(halfLength).ToArray();

            if (halfLength % 2 == 0)
            {
                int firstMedian = (firstHalf[(halfLength / 2) - 1] + firstHalf[halfLength / 2]) / 2;
                int secondMedian = 0;

                if ((secondHalf[(halfLength / 2) - 1] + secondHalf[halfLength / 2]) % 2 == 0)
                    secondMedian = (secondHalf[(halfLength / 2) - 1] + secondHalf[halfLength / 2]) / 2;
                else
                    secondMedian = ((secondHalf[(halfLength / 2) - 1] + secondHalf[halfLength / 2]) / 2) + 1;

                return new int[] { firstMedian, secondMedian };

                //return new int[] { (int)Math.Round((double)(firstHalf[(halfLength / 2) - 1] + firstHalf[halfLength / 2]) / 2), (int)Math.Ceiling((double)(secondHalf[(halfLength / 2) - 1] + secondHalf[halfLength / 2]) / 2) };
            }
            else
                return new int[] { firstHalf[halfLength / 2], secondHalf[halfLength / 2] };
        }

        /*
        As you might already know, Thumbtack helps Professionals (Pros) grow their business by identifying new 
        customers. Upon registering on Thumbtack, Pros must select categories that match the type of services 
        they provide. To make this step easier for Pros, Thumbtack would like to provide smart suggestions of 
        categories that usually accompany those the Pro has already selected. To do this, Thumbtack engineers 
        analyze historical user requestData and categories in proSelections using a Jaccard index statistic.

        Your task is to implement the following algorithm that returns a single category recommendation:

        for each request from requestData:
        calculate the Jaccard index of this request and proSelections;
        Assign a score to each category that is present in the request but not in proSelections equal to 
        the value of the Jaccard index;
        divide each score by the number of summands it was obtained from;
        return the category with the highest positive score. If several categories have the same positive 
        score, return the lexicographically smallest one. If there are no categories with positive score, 
        return an empty string instead.
        Example

        For

        requestData = [["Accounting", "Administrative Support", "Advertising", 
                                      "Bodyguard", "Auctioneering"],
                       ["Accounting", "Administrative Support"],
                       ["Advertising", "Auctioneering", "Bodyguard"],
                       ["Bodyguard", "Services Business", "Consulting"]]
        and proSelections = ["Accounting", "Advertising"], the output should be

        categoryRecommendations(requestData, proSelections) = "Administrative Support".

        Here's how scores are calculated:
        * i = 0: Jaccard index equals 2/5 and should be added to "Administrative Support", "Bodyguard", "Auctioneering";
        * i = 1: Jaccard index equals 1/3 and should be added to "Administrative Support";
        * i = 2: Jaccard index equals 1/4 and should be added to "Auctioneering", "Bodyguard";
        * i = 3: Jaccard index equals 0 and should be added to "Bodyguard", "Services Business", "Consulting";

        So the final scores equal:
        * "Administrative Support": (2/5 + 1/3) / 2 = 11/30;
        * "Auctioneering": (2/5 + 1/4) / 2 = 13/40;
        * "Bodyguard": (2/5 + 1/4 + 0) / 3 = 13/60;
        * "Consulting": 0/1 = 0;
        * "Services Business": 0/1 = 0.

        For

        requestData = [["Accounting", "Bodyguard"],
                       ["Accounting", "Auctioneering"]]
        and proSelections = ["Accounting"], the output should be

        categoryRecommendations(requestData, proSelections) = "Auctioneering".

        "Auctioneering" and "Bodyguard" have the same score, but "Auctioneering" is lexicographically smaller than "Bodyguard".

        For requestData = [["Bodyguard"]] and proSelections = ["Bodyguard"], the output should be

        categoryRecommendations(requestData, proSelections) = "".

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.string requestData

        List of user requests. It is guaranteed that requestData contains at least one element, and that each element is non-empty and consists of unique items.

        Constraints:

        1 ≤ requestData.length ≤ 10,

        1 ≤ requestData[i].length ≤ 10,

        1 ≤ requestData[i][j].length ≤ 25.

        [input] array.string proSelections

        A non-empty array of unique elements.

        Constraints:

        1 ≤ proSelections.length ≤ 10,

        1 ≤ proSelections[i].length ≤ 15.

        [output] string

        A category suggested by the algorithm described above.
        */
        public string categoryRecommendations(string[][] requestData, string[] proSelections)
        {
            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            for(int i = 0; i < requestData.Length; i++)
            {
                double jacIndex = GetJaccardIndex(requestData[i].ToList(), proSelections.ToList());
                for(int j = 0; j < requestData[i].Length; j++)
                {
                    if (!proSelections.Contains(requestData[i][j]))
                    {
                        if (!output.ContainsKey(requestData[i][j]))
                            output.Add(requestData[i][j], new List<double>() { jacIndex });
                        else
                        {
                            List<double> jacIndexList = output[requestData[i][j]];
                            jacIndexList.Add(jacIndex);
                            output[requestData[i][j]] = jacIndexList;
                        }
                    }
                }
            }

            string result = "";

            if (output.Count() > 0)
            {
                var final = output.ToDictionary(k => k.Key, k => k.Value.Average()).Where(k1 => k1.Value > 0).ToList().OrderByDescending(l => l.Value).ThenBy(m => m.Key, StringComparer.Ordinal).ToList();
                if (final.Count() > 0)
                    result = final[0].Key;
            }

            return result;
        }

        private double GetJaccardIndex(List<string> ls1, List<string> ls2)
        {
            return (double)ls1.Intersect(ls2).Count() / ls1.Union(ls2).Count();
        }

    }
}
