using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class GoBot
    {
        /*   
        GoDaddy makes a lot of different top-level domains available to its customers. A top-level domain is one that goes directly after the last dot ('.') in the domain name, for example .com in example.com. To help the users choose from available domains, GoDaddy is introducing a new feature that shows the type of the chosen top-level domain. You have to implement this feature.
        To begin with, you want to write a function that labels the domains as "commercial", "organization", "network" or "information" for .com, .org, .net or .info respectively.
        For the given list of domains return the list of their labels.

        Example

        For domains = ["en.wiki.org", "codefights.com", "happy.net", "code.info"], the output should be
        domainType(domains) = ["organization", "commercial", "network", "information"].

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.string domains

        A list of domains, where each domain contains at least one dot. It is guaranteed that each top-level domain of these domains belongs to one of the types described above.

        Constraints:
        4 ≤ domains.length ≤ 25,
        5 ≤ domains[i].length ≤ 20.

        [output] array.string

        The list of labels for the given domains.
        */

        //My solution
        public string[] domainTypeOld(string[] domains)
        {
            string[] output = new string[domains.Length];

            int index = 0;
            foreach(string domain in domains)
            {
                string extn = domain.Substring(domain.LastIndexOf('.'), domain.Length - domain.LastIndexOf('.'));
                switch(extn)
                {
                    case ".org":
                        output[index] = "organization";
                        break;
                    case ".com":
                        output[index] = "commercial";
                        break;
                    case ".net":
                        output[index] = "network";
                        break;
                    case ".info":
                        output[index] = "information";
                        break;
                }

                index += 1;
            }

            return output;
        }

        //Best C# solution
        public string[] domainType(string[] domains)
        {
            return domains.Select(d => {
                var split = d.Split('.');
                var last = split[split.Length - 1];
                string output = string.Empty;
                switch (last)
                {
                    case "org":
                        output = "organization";
                        break;
                    case "com":
                        output = "commercial";
                        break;
                    case "net":
                        output = "network";
                        break;
                    case "info":
                        output = "information";
                        break;
                    default:
                        break;
                }
                return output;
            }).ToArray();
        }

        /*
        Domain name forwarding lets GoDaddy domain owners automatically redirect their site visitors to a different site URL. 
        Sometimes the visitors have to go through multiple redirects before ending up on the correct site.

        Using the DNS Manager, GoDaddy customers can view redirects in a simple visual format. One handy feature is the ability to group the domains by the final website they redirect to. 
        Your task is to implement this feature.

        For the given redirects list, organize its domains into groups where for a specific group each domain eventually redirects visitors to the same website.

        Example

        For

        redirects = [["godaddy.net", "godaddy.com"], 
                     ["godaddy.org", "godaddycares.com"], 
                     ["godady.com", "godaddy.com"],
                     ["godaddy.ne", "godaddy.net"]]
        the output should be

        domainForwarding(redirects) = [["godaddy.com", "godaddy.ne", "godaddy.net", "godady.com"], 
                                       ["godaddy.org", "godaddycares.com"]]
        In the first group, "godaddy.ne" redirects to "godaddy.net", which in turn redirects to "godaddy.com". "godady.com" redirects visitors to "godaddy.com" as well.
        In the second group, "godaddy.org" redirects visitors to "godaddycares.com".

        Note, that domains in each group are sorted lexicographically. The first group goes before the second because "godaddy.com" is lexicographically smaller than "godaddycares.com".

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.string redirects

        Each of redirects[i] consists of two domains. The second element is the domain to which the first element redirects. Each domain is a string that may consist of lowercase Latin letters, hyphens ('-') and full stops ('.').
        It is guaranteed that domain redirects do not contain cycles, i.e. it is impossible to get back to the current site after any number of redirects. It is also guaranteed that each domain redirects to no more than one another domain, i.e. for each i ≠ j redirects[i][0] ≠ redirects[j][0].

        Constraints:
        1 ≤ redirects.length ≤ 15,
        redirects[i].length == 2,
        1 ≤ redirects[i][j].length ≤ 25.

        [output] array.array.string

        Return the array of domain groups, such that each domain from redirects belongs to one of the group, and domains from one group redirect visitors to the same website. Arrange the domains in each group in lexicographical order, and sort the groups by the domains they redirect to (also lexicographically).
        */

        public string[][] domainForwarding(string[][] redirects)
        {
            List<List<string>> output = new List<List<string>>();

            var finalRedirects = redirects.Select(i => i[1]).Distinct().ToList();

            foreach(string redirect in finalRedirects)
            {
                var temp = redirects.Where(i => i[1] == redirect).Select(j => j[0]).ToList();
                temp.Add(redirect);

                output.Add(temp);
            }

            for (int count = output.Count() - 1; count >= 0; count-- )
            {
                var redirectList = output[count];

                var temp = output.Where(i => i.Contains(redirectList[redirectList.Count() - 1]) && i[i.Count() - 1] != redirectList[redirectList.Count() - 1]).ToList();

                if (temp.Count() > 0)
                {
                    var temp1 = redirectList.Where(i => i != redirectList[redirectList.Count() - 1]).Select(j => j).ToList();

                    string lastItem = temp[0][temp[0].Count() - 1];
                    temp[0].Remove(lastItem);

                    foreach (string s in temp1)
                        temp[0].Add(s);

                    temp[0].Add(lastItem);

                    output.RemoveAt(count);
                }
            }

            var sortedList = output.OrderBy(x => x[x.Count() - 1], StringComparer.Ordinal).ToList();

            for (int index = 0; index < sortedList.Count(); index++)
                sortedList[index] = sortedList[index].OrderBy(i => i, StringComparer.Ordinal).ToList();


            return sortedList.Select(i => i.ToArray()).ToArray();

        }

        //Best Solution 1
        string[][] domainForwarding1(string[][] redirects)
        {
            bool hasChainRedirects;

            do
            {
                hasChainRedirects = false;

                foreach (var redirectTo in redirects)
                {
                    foreach (var redirectFrom in redirects)
                    {
                        if (redirectFrom[0] == redirectTo[1])
                        {
                            redirectTo[1] = redirectFrom[1];
                            hasChainRedirects = true;
                        }
                    }
                }
            } while (hasChainRedirects);

            var redirectMap = new Dictionary<string, List<string>>();

            foreach (var redirect in redirects)
            {
                if (!redirectMap.ContainsKey(redirect[1]))
                {
                    redirectMap.Add(redirect[1], new List<string>());
                }

                redirectMap[redirect[1]].Add(redirect[0]);
            }

            foreach (var map in redirectMap)
            {
                map.Value.Sort();
            }

            return redirectMap.Select(x => (new string[] { x.Key }.Concat(x.Value)).ToArray()).ToArray();
        }

        //Best Solution 2
        string[][] domainForwarding2(string[][] redirects)
        {
            /*var db = redirects
                .Select(r => new {
                    domain = r[0],
                    redirect = r[1],
                    linked = redirects.Select(r2 => r2[0]).Contains(r[1])
                })
                .ToArray();
            Console.WriteLine(string.Join("\n",
                db.Select(e => "\""+ e.domain +"\", \""+ e.redirect +"\", " + e.linked)
                    .ToArray()
            ));*/
            //Console.WriteLine(db.Where(r => !r.linked).Select(r => r.redirect).Distinct().Count());
            return redirects.Where(r => !redirects.Select(r2 => r2[0]).Contains(r[1]))
                .Select(r => r[1]).Distinct()
                .Select(r => new {
                    redirects = redirects
                        .Where(r2 => r2[1] == r || r2[0] == r).SelectMany(r2 => r2)
                        .Concat(GetLinkedRedirects(redirects, r))
                        .Distinct()
                        .OrderBy(r2 => r2, StringComparer.Ordinal)
                        .ToArray(),
                    target = r
                })
                .OrderBy(r => r.target)
                .Select(r => r.redirects)
                .ToArray();
            //return new string[][] {};
        }

        IEnumerable<string> GetLinkedRedirects(string[][] db, string redirect)
        {
            var domains = db.Where(r => r[1] == redirect).Select(r => r[0]);
            domains = domains.Concat(domains.SelectMany(d => GetLinkedRedirects(db, d)));
            return domains;
        }


        /*
        Typosquatting is a hack that relies on mistakes made by Internet users when inputting a website address into a web browser. So if a user is trying to go to godaddy.com but they accidentally type in goddady.com and someone else owns that domain, they could pretend to be GoDaddy and steal valuable user information.

        Assume that GoDaddy is introducing a new feature that helps users protect their domains from typosquatting. It is known that a typosquatter's URL is usually similar to the victim's domain, but has some typos in it, where a typo means that letters in two adjacent positions have been swapped.

        Given n, the number of additional domains the owner is willing to buy to protect their domain against typosquatting, GoDaddy calculates the maximum number k such that all of the domains with k or fewer typos can be bought (excluding the original domain itself).

        Your task is to implement an algorithm that finds k given n and a domain name.

        Example

        For n = 7 and domain = "godaddy.com", the output should be
        typosquatting(n, domain) = 1.

        For k = 1 the following typos can be made:

        "ogdaddy.com"
        "gdoaddy.com"
        "goadddy.com"
        "goddady.com"
        "godadyd.com"
        "godaddy.ocm"
        "godaddy.cmo"
        7 domains to buy altogether. That's exactly the number of domains the user can afford, so the answer is 1.

        For n = 9 and domain = "omg.tv", the output should be
        typosquatting(n, domain) = 2.

        For k = 1, the following typos can be made:

        "mog.tv"
        "ogm.tv"
        "omg.vt"
        For k = 2, 4 more typos can be obtained:

        "mgo.tv" (from "mog.tv")
        "mog.vt" (from "mog.tv" or "omg.vt")
        "gom.tv" (from "ogm.tv")
        "ogm.vt" (from "ogm.tv" or "omg.vt")
        For k = 3, there're 3 more typos to consider:

        "gmo.tv" (from "mgo.tv" of "gom.tv")
        "mgo.vt" (from "mgo.tv" or "mog.vt")
        "gom.vt" (from "gom.tv" or "ogm.vt")
        Since n = 9, it's not enough to buy all domains with 3 or fewer typos, but it's enough to buy with 2 or fewer, so the answer is 2.

        Note that equal domain strings that may be obtained differently are considered the same.

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer n

        The number of domains the domain owner is willing to buy.

        Constraints:
        0 ≤ n ≤ 104.

        [input] string domain

        The domain to protect.

        Constraints:
        3 ≤ domain.length ≤ 20.

        [output] integer

        The maximum k such that all of the domains with k or fewer typos can be bought. If it is possible to buy all the domains which can be obtained from domain by an arbitrary number of typos, return -1 instead.
        */

        public int typosquatting(int n, string domain)
        {
            domain = RemoveRepeatingCharacters(domain);

            string domainWithoutDots = RemoveRepeatingCharacters(domain.Replace(".", ""));

            if (domainWithoutDots.Length == 1 || (domainWithoutDots.Length == 2 && n == 1))
                return -1;

            if (n == 0)
                return n;

            Dictionary<string, int> combinations = new Dictionary<string, int>();

            combinations.Add(domain, 0);

            int combinationsTotal = combinations.Count() - 1;

            bool combinationCountReachedMax = false, oneNewconditionFound = false;

            int k = 0;

            do
            {
                oneNewconditionFound = false;

                //int k = Convert.ToInt16(combinations[1]..Last.Value[1]);
                string[] combinationsForK = combinations.Where(c => c.Value == k).Select(c1 => c1.Key).ToArray();

                for (int i1 = 0; i1 < combinationsForK.Count(); i1++)
                {
                    string[] split = combinationsForK[i1].Split('.');

                    for (int i = 0; i < split.Length; i++)
                    {
                        string domainSegment = split[i].ToString();

                        for (int j = 0; j < domainSegment.Length - 1; j++)
                        {
                            string changed = domainSegment.Substring(0, j) + domainSegment.Substring(j + 1, 1) + domainSegment.Substring(j, 1) + domainSegment.Substring(j + 2, domainSegment.Length - j - 2);

                            string[] splitCopy = new string[split.Length];

                            Array.Copy(split, splitCopy, split.Length);

                            splitCopy[i] = changed;

                            string newDomain = string.Join(".", splitCopy);

                            var exists = combinations.Where(c2 => c2.Key == newDomain);
                            if (exists.Count() == 0)
                            {
                                if (combinationCountReachedMax == true)
                                    return k;

                                oneNewconditionFound = true;
                                combinations.Add(newDomain, (k + 1));
                                if (combinations.Count() - 1 >= n)
                                {
                                    combinationCountReachedMax = true;
                                }
                            }
                        }
                    }
                }
                k += 1;
                combinationsTotal = combinations.Count() - 1;
            }
            while (combinationsTotal < n && oneNewconditionFound == true);

            return k;
        }

        private string RemoveRepeatingCharacters(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                    output += input.Substring(i, 1);
                else
                {
                    if (input.Substring(i - 1, 1) != input.Substring(i, 1))
                        output += input.Substring(i, 1);
                }
            }
            return output;
        }

        public int typosquattingOld(int n, string domain)
        {
            domain = RemoveRepeatingCharacters(domain);

            string domainWithoutDots = RemoveRepeatingCharacters(domain.Replace(".", ""));

            if (domainWithoutDots.Length == 1 || (domainWithoutDots.Length == 2 && n == 1))
                return -1;

            if (n == 0)
                return n;

            List<string[]> combinations = new List<string[]>();

            combinations.Add(new string[] { domain, "0" });

            int combinationsTotal = combinations.Count() - 1;

            bool combinationCountReachedMax = false, oneNewconditionFound = false;

            do
            {
                oneNewconditionFound = false;

                int k = Convert.ToInt16(combinations[combinationsTotal][1]);
                string[] combinationsForK = combinations.Where(c => Convert.ToInt16(c[1]) == k).Select(c1 => c1[0]).ToArray();

                for (int i1 = 0; i1 < combinationsForK.Count(); i1++)
                {
                    string[] split = combinationsForK[i1].Split('.');

                    for (int i = 0; i < split.Length; i++)
                    {
                        string domainSegment = split[i].ToString();

                        for (int j = 0; j < domainSegment.Length - 1; j++)
                        {
                            string changed = domainSegment.Substring(0, j) + domainSegment.Substring(j + 1, 1) + domainSegment.Substring(j, 1) + domainSegment.Substring(j + 2, domainSegment.Length - j - 2);

                            string[] splitCopy = new string[split.Length];

                            Array.Copy(split, splitCopy, split.Length);

                            splitCopy[i] = changed;

                            string newDomain = string.Join(".", splitCopy);

                            var exists = combinations.Where(c2 => c2[0] == newDomain);
                            if (exists.Count() == 0)
                            {
                                if (combinationCountReachedMax == true)
                                    return k;

                                oneNewconditionFound = true;
                                combinations.Add(new string[] { newDomain, (k + 1).ToString() });
                                if (combinations.Count() - 1 >= n)
                                {
                                    combinationCountReachedMax = true;
                                }
                            }
                        }
                    }
                }
                combinationsTotal = combinations.Count() - 1;
            }
            while (combinationsTotal < n && oneNewconditionFound == true);

            return Convert.ToInt16(combinations[combinationsTotal][1]);
        }
    }
}
