using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class Challenges
    {
        public string[] CodeFightOld(int n)
        {
            string[] a = new string[n];
            for (int i = 1; i <= n; i++)
            {
                string s = "";

                if (i % 5 == 0 && i % 7 != 0)
                    s = "Code";
                else if (i % 7 == 0 && i % 5 != 0)
                    s = "Fight";
                else if (i % 7 == 0 && i % 5 == 0)
                    s = "CodeFight";
                else
                    s = i.ToString();

                a[i - 1] = s;
            }

            return a;
        }

        int i;
        IEnumerable CodeFightBest(int n)
        {
            while (i++ < n)
                yield return (i % 5 < 1 ? "Code" : "") + (i % 7 < 1 ? "Fight" : i % 5 < 1 ? "" : i + "");
            //yield return i%5<1 ? "Code" + (i%7<1 ? "Fight" : "") : i%7<1 ? "Fight" : i+"";

        }

        public string[] CodeFight(int n)
        {
            return Enumerable.Range(1, n).Select(i => i % 35 == 0 ? "CodeFight" : i % 5 == 0 ? "Code" : i % 7 == 0 ? "Fight" : i.ToString()).ToArray();

            //var a = new string[n];

            //for (int i = 1; i <= n; i++)
            //    a[i - 1] = i % 35 == 0 ? "CodeFight" : i % 7 == 0 ? "Fight" : i % 5 == 0 ? "Code" : i.ToString();

            //return a;
        }

        int z;
        public int betaExorMine(string s)
        {
            //foreach (var c in s)
            //    z ^= c;
            //return z;

            return s.Aggregate(0, (a, b) => a ^ b);
            //return s == "" ? 0 : s.Aggregate((j, k) => (char) (j ^ k));
        }

        int x;
        public int betaExor(string s)
        {
            s.Sum(c => x ^= c);
            return x;
        }

        /*
        Your little brother just started playing Gran Turismo and he is still struggling with the very first driving licence test: Starting and Stopping.

        The main objective of Starting and Stopping is "Accelerating away from the starting point, following a straight line and coming to a complete stop within the goal area situated runwayLength meters away."

        Unfortunately your little brother is so bad at gaming that he just can't calculate when he should hit the brakes to stop the car at the goal area. He always stops either way before it or too far ahead of it due to bad timing of applying the brakes.

        As a skilful programmer and a Physics enthusiast, you have decided to help him by writing a program that determines the time at which he should apply the brakes in order to make his car stop at the goal area. The function you need to write should have the following arguments:

        zeroTo100: the time in which the car goes from speed 0 to 100km/h (in seconds).
        topSpeed: the maximum speed the car can reach (in km/h). Once it's reached, the car can no longer accelerate, thus it will go at a constant topSpeed speed.
        brakingDistance: the distance the car covers when decelerates from 100km/h to a complete stop (in meters).
        runwayLength: the length of the runway from the start point to the goal area (in meters).
        Your program should return a string showing the time at which your little brother should apply the brakes in the format "mm:ss.fff" (minutes:seconds.milliseconds).

        Notes:

        Assume that acceleration and deceleration of the car are constants, i.e. there's no need to take into account the gearing, friction coefficient, gravity or any other factors.
        Initial time is 00:00.000 and it starts increasing once the car starts to move.
        Round the result to with HALF_UP rounding mode and 500 milliseconds step, e.g:
        5.249 sec should be rounded down to 5.000 sec;
        5.250 sec should be rounded up to 5.500 sec;
        5.510 sec should be rounded down to 5.500 sec;
        5.750 should be rounded up to 6.000 sec.
        Example

        For zeroTo100 = 10.0, topSpeed = 100, brakingDistance = 100 and runwayLength = 240,
        the output should be
        granTurismo(10.0, 100, 100, 240) = "00:10.000".

        The car can accelerate to its max speed in about 139 meters , travel at the max speed for 0.04 meters and decelerate back to zero speed at the end of the runway (in about 100 meters).

        For zeroTo100 = 5.6, topSpeed = 160, brakingDistance = 92 and runwayLength = 400,
        the output should be
        granTurismo(5.6, 160, 92, 400) = "00:08.500".

        The car won't have enough time to reach the topSpeed.

        Input/Output

        [time limit] 3000ms (cs)
        [input] float zeroTo100

        The time in which the car accelerates from 0 to 100km/h.

        Constraints:
        2.0s ≤ zeroTo100 ≤ 12.0s.

        [input] integer topSpeed

        The maximum speed the car can reach.

        Constraints:
        100km/h ≤ topSpeed ≤ 360km/h.

        [input] integer brakingDistance

        The distance between which the car decelerates from 100km/h to a complete stop.

        Constraints:
        20m ≤ brakingDistance ≤ 150m.

        [input] integer runwayLength

        The length of the runway from start point to the goal area.

        Constraints:
        200m ≤ runwayLength ≤ 2000m.

        [output] string

        A string representing the time at which your little brother should apply the car's brakes in the format "mm:ss.fff".        
        */

        double t, a, s, ts, d, hkh;
        public string granTurismo(double zeroTo100, int topSpeed, int brakingDistance, int runwayLength)
        {
            ts = (double) topSpeed * 1000 / 3600;
            hkh = (double) 100 * 1000 / 3600;
            //v = u + a*t
            a = (double) 100 * 1000 / 3600 / zeroTo100;
            //v squared = u squared + 2as
            s = (ts * ts)/ (2 * a);
            //s = ut + (1/2)*a*t*t;

            d = (double) (hkh * hkh / 2 / brakingDistance);

            if (s + brakingDistance < runwayLength)
            {
                //breaking time will be same as time taken to max speed
                t = Math.Round(2 * ts / d, MidpointRounding.AwayFromZero)/2;
            }
            else
            {
                //breaking time will be time taken to reach half distance
                t = Math.Round(2 * Math.Sqrt(runwayLength / d), MidpointRounding.AwayFromZero)/2;

            }
            TimeSpan t1 = TimeSpan.FromSeconds(t);

            //return t1.ToString(@"mm\:ss\.fff");
            return string.Format("{0:D2}:{1:D2}.{2:D3}",
                t1.Minutes,
                t1.Seconds,
                t1.Milliseconds);
        }

        /*
        My little brother Jeff learns to read, and has already learnt a bunch of letters. Since boring letters memorizing isn't much fun, I would like to give him a book to read, which consists of various words. The thing is, I'm not sure if he will be able to read it.

        I've extracted all the words from the book, and converted them to lowercase. Now I need your help: given the letters Jeff knows and a word, determine if Jeff will be able to read the word, i.e. if all the letters in the word are familiar to him.

        Example

        For letters = "act" and word = "cat", the output should be
        AlphabetStudy(letters, word) ="Yes"`.

        Jeff knows letters 'a', 'c' and 't', which is enough to read "cat".

        For letters = "q" and word = "abc", the output should be
        AlphabetStudy(letters, word) ="No"`.

        Jeff knows only one letter, which is not enough to read the word.

        Input/Output

        [time limit] 3000ms (cs)
        [input] string letter

        A word consisting of lowercase English letters, all of which are guaranteed to be unique.

        Constraints:
        0 ≤ word.length ≤ 26.

        [input] string word

        A string of lowercase English letters.

        Constraints:
        1 ≤ word.length ≤ 20.

        [output] string

        "Yes" if Jeff will be able to read the word and "No" otherwise.
        */
        public string AlphabetStudy(string l, string w)
        {
            //return l.Union(w).Count() == l.Count() ? "Yes" : "No";
            //return l.Union(w).SequenceEqual(l) ? "Yes" : "No";
            return w.Union(l).Except(l).Any() ? "No" : "Yes";
        }

        /*
        At the county fair there is a contest to guess how many jelly beans are in a jar. Each entrant is allowed to submit a single guess, and cash prizes are awarded to the entrant(s) who come closest without going over. 
        In the event that there are fewer guesses less than or equal to the answer than the number of prizes being awarded, the remaining prizes will be awarded to the remaining entrants who are closest to the correct answer 
        (however, if there are more prizes than entries, the excess prizes will not be awarded). If two or more entrants tie for a finishing position, they will evenly split the sum of the prizes for the range of positions they occupy.

        Given an array representing the prizes paid for each finishing position, an array of the guesses, and the correct answer, return an array of the prizes awarded to each entrant. If a tie results in a fractional prize amount, round up to the nearest penny (e.g. $10 / 3 = $3.34).

        Example

        For prizes = [ [1,1,100], [2,2,50], [3,4,25] ], guesses = [65, 70, 78, 65, 72]
        and answer = 70, the output should be
        awardedPrizes(prizes, guesses, answer = [37.5, 100.0, 0.0, 37.5, 25.0].

        The prizes represent the following prize structure:

        1st place wins $100;
        2nd place wins $50;
        3rd place wins $25;
        4th place wins $25.
        The entrant who guessed 70 was closest, and wins $100 for 1st place.
        The two entrants who guessed 65 were next closest (without going over), and so they split the total prizes for 2nd and 3rd place. Thus each wins (50 + 25) / 2 = $37.50.
        No one else submitted a guess less than the answer, so the entrant who guessed 72 was next closest, and wins $25 for 4th place.
        The entrant who guessed 78 does not win a prize.

        The answer is thus [37.5, 100.0, 0.0, 37.5, 25.0].

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.array.integer prizes

        An array of prize tiers; each tier is an array with three elements: start_position, end_position, and prize_amount.

        The tiers are not necessarily provided in order. However, it is guaranteed that these tiers combine such that there is a single prize for each finishing position from 1 through some position k, and no prizes beyond that point (i.e. no gaps in the prize structure).

        Constraints:
        1 ≤ prizes.length ≤ 20,
        1 ≤ prizes[i][0] ≤ prizes[i][1] ≤ 20,
        1 ≤ prizes[i][2] ≤ 100.

        [input] array.integer guesses

        An array of the guesses made by each entrant in the contest.

        Constraints:
        1 ≤ guesses.length ≤ 100.

        [input] integer answer

        The actual number of jelly beans in the jar.

        Constraints:
        1 ≤ answer ≤ 100.

        [output] array.float

        An array containing the prize awarded to each entrant, in the same order as their guesses.
        */
        double[] awardedPrizes(int[][] prizes, int[] guesses, int answer)
        {
            return new double[] { };
        }
    }
}
