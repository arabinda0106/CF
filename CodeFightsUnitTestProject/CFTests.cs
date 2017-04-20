using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using CodeFights;

namespace CodeFightsUnitTestProject
{
    [TestClass]
    public class CFTests
    {
        /*
        [TestMethod]
        public void FunctionTest()
        {
            //arrange

            //act
            CompanyBots cb = new CompanyBots();

            int actual = cb.Function(4);

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }
        */

        //[TestMethod]
        public void BubbleSortedListTest1()
        {
            //arrange
            int[] input = new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80, 79, 78, 77, 76, 75, 74, 73, 72, 71, 70, 69, 68, 67, 66, 65, 64, 63, 62, 61, 60, 59, 58, 57, 56, 55, 54, 53, 52, 51, 50 };

            //input = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            CommonSubroutines subroutines = new CommonSubroutines();
            List<int> actual = input.ToList();
            
            subroutines.BubbleSortedList(actual);

            int[] expected = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            //assert
            CollectionAssert.AreEqual(expected.ToList(), actual);

        }

        //[TestMethod]
        public void MergeSortedArrayTest()
        {
            //arrange
            int[] actual = new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80, 79, 78, 77, 76, 75, 74, 73, 72, 71, 70, 69, 68, 67, 66, 65, 64, 63, 62, 61, 60, 59, 58, 57, 56, 55, 54, 53, 52, 51, 50 };

            //actual = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            CommonSubroutines subroutines = new CommonSubroutines();

            int[] actualSorted = new int[actual.Length];

            actualSorted = subroutines.MergeSortedArray(actual);

            int[] expected = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            //assert
            CollectionAssert.AreEqual(expected, actualSorted);
        }

        //[TestMethod]
        public void catalogUpdateTest1()
        {
            //arrange
            string[][] catalog = new string[][] { new string [] { "Books", "Classics", "Fiction " },
                                       new string [] { "Electronics","Cell Phones","Computers","Ultimate item" },
                                       new string [] { "Grocery","Beverages","Snacks" },
                                       new string [] { "Snacks","Chocolate","Sweets" },
                                       new string [] { "root","Books","Electronics","Grocery" }
                                     };

            string[][] updates = new string[][] { new string [] { "Snacks", "Marmalade" },
                                       new string [] { "Fiction ","The Chronicles of Narnia" },
                                       new string [] { "Fiction ","Fiction stories" },
                                       new string [] { "Books","Abc" },
                                       new string [] { "Snacks","Tuc" },
                                       new string [] { "root","T-shirts-men" },
                                       new string [] { "T-shirts-men","My little pony t-shirt" },
                                       new string [] { "Fiction ","Harry Potter" },
                                       new string [] { "root","T-shirts" },
                                       new string [] { "T-shirts","CodeFights" },
                                       new string [] { "Fiction stories","Frozen heart" },
                                       new string [] { "Fiction stories","Marvel films" },
                                       new string [] { "Marvel films","Ant-man" },
                                       new string [] { "Marvel films","Avengers" }
                                    };

            CompanyBots cb = new CompanyBots();

            string[][] actualCatalog = cb.catalogUpdate(catalog, updates);

            string[][] expectedCatalog = new string[][] { new string [] { "Books", "Abc", "Classics", "Fiction " },
                                       new string [] { "Electronics","Cell Phones","Computers","Ultimate item" },
                                       new string [] { "Fiction ","Fiction stories", "Harry Potter", "The Chronicles of Narnia" },
                                       new string [] { "Fiction stories","Frozen heart","Marvel films" },
                                       new string [] { "Grocery","Beverages","Snacks" },
                                       new string [] { "Marvel films","Ant-man","Avengers" },
                                       new string [] { "Snacks","Chocolate", "Marmalade","Sweets","Tuc" },
                                       new string [] { "T-shirts","CodeFights" },
                                       new string [] { "T-shirts-men","My little pony t-shirt" },
                                       new string [] { "root","Books","Electronics","Grocery", "T-shirts", "T-shirts-men" }
                                     };

            //assert

            for (int i =0; i < expectedCatalog.Count(); i++)
            {
                CollectionAssert.AreEqual(expectedCatalog[i], actualCatalog[i]);
            }

        }

        //[TestMethod]
        public void shoppingCartTest()
        {
            //arrange
            string[] requests = new string[] { "add : milk", "add : pickles", "remove : milk", "add : milk", "quantity_upd : pickles : +4" };

            CompanyBots cb = new CompanyBots();

            string[] actual = cb.shoppingCart(requests);

            string[] expected = new string[] { "pickles : 5", "milk : 1" };

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void FindMatchingArrayInArrayTest()
        {
            //arrange

            string[] inputA = new string[] { "apples", "pineapples" };
            string[] inputB = new string[] { "apples", "bananas", "kiwis" };

            CommonSubroutines cs = new CommonSubroutines();
            string[] actual = cs.FindMatchingArrayInArray(inputA, inputB);

            //assert
            string[] expected = new string[] { "apples" };

            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void merchantMinimizationTest()
        {
            //arrange

            string[] items = new string[] { "apples", "bananas", "kiwis" };

            string[][] merchants = new string[][] { new string[] { "apples", "pineapples" },
                                                    new string[] { "apples", "kiwis" },
                                                    new string[] { "kiwis", "papayas", "bananas" },
                                                    new string[] { "bananas", "apples" }
                                                  };

            CompanyBots cb = new CompanyBots();

            int[] actual = cb.merchantMinimization(items, merchants);

            int[] expected = new int[] { 0, 2 };

            //assert

            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void merchantMinimizationTest1()
        {
            //arrange

            string[] items = new string[] { "system block", "monitor", "mouse", "earphones", "keyboard", "microphone", "web-camera" };

            string[][] merchants = new string[][] { new string[] { "monitor","mouse","earphones" },
                                                    new string[] { "system block","monitor" },
                                                    new string[] { "earphones","microphone" },
                                                    new string[] { "web-camera" },
                                                    new string[] { "web-camera", "mouse", "monitor" },
                                                    new string[] { "system block", "mouse" }
                                                  };

            CompanyBots cb = new CompanyBots();

            int[] actual = cb.merchantMinimization(items, merchants);

            int[] expected = new int[] { -1 };

            //assert

            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void merchantMinimizationTest2()
        {
            //arrange

            string[] items = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };

            string[][] merchants = new string[][] { new string[] { "a", "b" },
                                                    new string[] { "a", "b", "c" },
                                                    new string[] { "a", "b", "d" },
                                                    new string[] { "f", "g", "h" },
                                                    new string[] { "j", "k", "l" },
                                                    new string[] { "c", "d", "e" },
                                                    new string[] { "l" },
                                                    new string[] { "j", "k" },
                                                    new string[] { "a" },
                                                    new string[] { "a" },
                                                    new string[] { "a" },
                                                    new string[] { "a" },
                                                    new string[] { "a" },
                                                    new string[] { "c", "d", "e", "f", "g", "h", "i" }
                                                  };

            CompanyBots cb = new CompanyBots();

            int[] actual = cb.merchantMinimization(items, merchants);

            int[] expected = new int[] { 0, 4, 13 };

            //assert

            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void PossibleCombinationsOfIndexesTest()
        {
            //arrange

            int maxLength = 5;
            List<List<string>> actual = new List<List<string>>();

            CommonSubroutines cs = new CommonSubroutines();

            actual = cs.PossibleCombinationsOfIndexes(maxLength, -1, new List<List<string>>());

            //assert
            List<List<string>> expected = new List<List<string>>();

            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void serverFarmTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            //int[] jobs = new int[] { 15, 30, 15, 5, 10 };
            //int servers = 3;

            //int[] jobs = new int[] { 15, 2, 14, 14, 14, 258 };
            //int servers = 8;

            int[] jobs = new int[] { 8, 7, 15, 15, 13, 6, 18, 4, 16, 1, 2, 19, 2, 15, 18, 6, 20, 16, 10, 7, 3, 7, 9, 7, 12, 1, 16, 15, 7, 12, 20, 17, 17, 4, 20, 15, 20, 6, 15, 3, 5, 17, 5, 5, 19, 17, 4, 15, 2, 7 };
            int servers = 9;

            int[][] actual = cb.serverFarm(jobs, servers);

            int[][] expected = new int[][] { new int[] { 1 },
                                             new int[] { 0, 4},
                                             new int[] { 2, 3},
                                            };

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void dailyOHLCTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            int[] timestamp = new int[] { 801840015, 1346505615, 1346505615, 1346505615, 1346505615, 1346516000, 1592632799, 1592632799, 1592669600, 1592669600 };
            string[] instrument = new string[] { "LAG", "HPQ", "HPQ", "HPQ", "AAOL", "LAG", "LAG", "GOOG", "AAOL", "HPQ" };
            string[] side = new string[] { "sell", "sell", "buy", "sell", "sell", "buy", "sell", "sell", "buy", "sell" };
            double[] price = new double[] { 50.4, 75.64, 42.62, 92.69, 48.53, 20.85, 61.33, 32.61, 36.53, 28.74 };
            int[] size = new int[] { 543, 448, 140, 889, 857, 270, 305, 115, 243, 450 };

            string[][] actual = cb.dailyOHLC(timestamp, instrument, side, price, size);

            //assert
        }

        //[TestMethod]
        public void dailyOHLCTest1()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            int[] timestamp = new int[] { 1450625399, 1450625399, 1450625399, 1450625399, 1450625399, 1450625399, 1450625399, 1450625399, 1450625399, 1450625399 };
            string[] instrument = new string[] { "AAPL", "AAPL", "AAPL", "aa", "AAPL", "aa", "AAPL", "aa", "AAPL", "AAPL" };
            string[] side = new string[] { "sell", "sell", "buy", "buy", "buy", "buy", "buy", "buy", "buy", "sell" };
            double[] price = new double[] { 1, 10, 2, 9, 3, 8.8, 4.44, 7, 5, 6 };
            int[] size = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            string[][] actual = cb.dailyOHLC(timestamp, instrument, side, price, size);

            //assert
        }

        //[TestMethod]
        public void LexicographicallyMergeSortedListTest()
        {
            //arrange

            CommonSubroutines cs = new CommonSubroutines();

            List<string> actual = cs.LexicographicallyMergeSortedList(new string[] { "AA", "AAPL" }.ToList());

        }

        //[TestMethod]
        public void companyBotStrategyTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            int[][] trainingData = new int[][] { new int[] { 3, 1 },
                                                 new int[] { 6, 1 },
                                                 new int[] { 4, 1 },
                                                 new int[] { 5, 1 }
                                               };

            double actual = cb.companyBotStrategy(trainingData);

            double expected = 4.5;

            //assert

            Assert.Equals(expected, actual);
        }

        //[TestMethod]
        public void taskMakerTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            string[] source = new string[] { "ans = 0;",
                                             "for (var i = 0; i < n; i++) {",
                                             "    for (var j = 0; j < n; j++) {",
                                             "//DB 1//for (var j = 0; j < n + 1; j++) {",
                                             "        ans++;",
                                             "    }",
                                             "",
                                             "}",
                                             "return ans;" };
            int challengeId = 2;

            //string[] actual = cb.taskMakerSimple(source, challengeId);
            string[] actual = cb.taskMaker(source, challengeId);

            string[] expected = new string[] { "ans = 0;",
                                             "for (var i = 0; i < n; i++) {",
                                             "    for (var j = 0; j < n; j++) {",
                                             "        ans++;",
                                             "    }",
                                             "",
                                             "}",
                                             "return ans;" };

            //assert

            CollectionAssert.AreEqual(expected, actual);

        }

        //[TestMethod]
        public void plagiarismCheckTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            /*
            string[] code1 = new string[] { "function return_four() {",
                                            "  return 3 + 1;" };
            string[] code2 = new string[] { "function return_four() {",
                                            "  return 1 + 3;" };
            */

            /*
            string[] code1 = new string[] { "def is_even_sum(a, b):",
                                            "    return (a + b) % 2 == 0" };
            string[] code2 = new string[] { "def is_even_sum(summand_1, summand_2):",
                                            "    return (summand_1 + summand_2) % 2 == 0" };
            */

            /*
            string[] code1 = new string[] { "def return_first(f, s):",
                                            "  t = f",
                                            "  return f" };
            string[] code2 = new string[] { "def return_first(f, s):",
                                            "  f = f",
                                            "  return f" };
            */

            /*
            string[] code1 = new string[] { "function is_even_sum(a, b) {",
                                            "  return (a + b) % 2 === 0;",
                                            "}" };
            string[] code2 = new string[] { "function is_even_sum(a, b) {",
                                            "  return (a + b) % 2 !== 1;",
                                            "}" };
            */

            string[] code1 = new string[] { "def return_smth(a, b):",
                                            "  a = 3",
                                            "  return a + a" };
            string[] code2 = new string[] { "def return_smth(b, a):",
                                            "  b = 2",
                                            "  return b + b" };
            /*
                                    string[] code1 = new string[] { "ab = 2",
                                                                    "a = 3",
                                                                    "b = 3 + a",
                                                                    "ba = 1" };
                                    string[] code2 = new string[] { "ab = 2",
                                                                    "a = 3",
                                                                    "b = 3 + ab",
                                                                    "a = 1" };
                                    */

            bool actual = cb.plagiarismCheck(code1, code2);

            bool expected = false;

            //assert
            Assert.AreEqual(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void marathonTaskScoreTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            int actual = cb.marathonTaskScore(100, 400, 4, 30);

            int expected = 310;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void opponentMatchingTest()
        {
            //arrange

            CompanyBots cb = new CompanyBots();

            int[] XP = new int[] { 200, 100, 70, 130, 100, 800, 810 };

            int[][] actual = cb.opponentMatching(XP);

            int[][] expected = new int[][] { new int[] { 1, 4 },
                                             new int[] { 5, 6 },
                                             new int[] { 2, 3 }
            };

            //assert
            for (int i = 0; i < expected.Count(); i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        //[TestMethod]
        public void createAnagramTest()
        {
            //arrange
            string s = "OVGHK";
            string t = "RPGUC";

            s = "AABAA";
            t = "BBAAA";

            //act
            HeadToHead hth = new HeadToHead();

            int actual = hth.createAnagram(s, t);

            int expected = 4;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void domainTypeTest()
        {
            //arrange

            string[] domains = new string[] { "en.wiki.org", "codefights.com", "happy.net", "code.info" };

            //act
            GoBot gb = new GoBot();

            string[] actual = gb.domainType(domains);

            string[] expected = new string[] { };

            //assert
            CollectionAssert.AreEqual(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void domainForwardingTest()
        {
            //arrange

            string[][] redirects = new string[][] { new string[] { "godaddy.net", "godaddy.com" },
                                                    new string[] { "godaddy.org", "godaddycares.com" },
                                                    new string[] { "godady.com", "godaddy.com" },
                                                    new string[] { "godaddy.ne", "godaddy.net" }
            };

            //act
            GoBot gb = new GoBot();

            string[][] actual = gb.domainForwarding(redirects);

            string[][] expected = new string[][] { new string[] { "godaddy.com", "godaddy.ne", "godaddy.net", "godady.com" },
                                                   new string[] { "godaddy.org", "godaddycares.com" }
            };

            //assert
            for (int i = 0; i < expected.Count(); i++)
                CollectionAssert.AreEqual(expected[i], actual[i]);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void typosquattingTest()
        {
            //arrange

            int n = 9;
            string domain = "omg.tv";

            //n = 7;
            //domain = "godaddy.com";

            n = 10000;
            //domain = "aaaaaaaaaa.aaaaaaaaaa";
            //domain = "abcdefghi.jklmnopqrst";
            //domain = "efgh";
            //domain = "abcd.efgh.jklm.nopq.rst";
            domain = "abc.def.ghi.jkl.mno.pqr.st";

            //n = 85;
            //domain = "godaddygodaddy.com";

            //act
            GoBot gb = new GoBot();

            int actual = gb.typosquatting(n, domain);

            int expected = 6;

            //assert
            Assert.AreEqual(actual, expected);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void isInfiniteProcessTest()
        {
            //arrange

            //act
            Arcade a = new Arcade();

            bool actual = a.isInfiniteProcess(10, 10);

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void metroCardTest()
        {
            //arrange

            //act
            Arcade a = new Arcade();

            int[] actual = a.metroCard(32);

            int expected = 0;

            //assert
            //Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void killKthBitTest()
        {
            //arrange

            //act
            Arcade a = new Arcade();

            int actual = a.killKthBit(37, 3);

            int expected = 0;

            //assert
            //Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void arrayPackingTest()
        {
            //arrange

            int[] a1 = new int[] { 24, 85, 0};

            //act
            Arcade a = new Arcade();

            int actual = a.arrayPacking(a1);

            int expected = 0;

            //assert
            //Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void allianceHelpTest()
        {
            //arrange

            //act
            MZBot mb = new MZBot();

            int actual = mb.allianceHelp(100, 10);

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void allianceVersusMonsterTest()
        {
            //arrange

            int[] healthPoints = new int[] { 110, 30, 50 }, 
                attackDamage = new int[] { 12, 11, 20 };

            healthPoints = new int[] { 4, 10, 10, 10 };
            attackDamage = new int[] { 10, 1, 1, 1 };

            healthPoints = new int[] { 11, 4, 4, 4 };
            attackDamage = new int[] { 1, 1, 1, 1 };

            //act
            MZBot mb = new MZBot();

            int actual = mb.allianceVersusMonster(healthPoints, attackDamage);

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void farmingResourcesTest()
        {
            //arrange

            int[] friendlyTroops = new int[] { -2, 2, 3 }, 
                enemyTroops = new int[] { 1, 0, 9 },
                loggingCamp = new int[] { 0, 0 };

            int[][] impassableCells = new int[][] { new int[] { -1, 1 } };

            friendlyTroops = new int[] { 2, -1, 20 };
            enemyTroops = new int[] { 0, 3, 11 };
            loggingCamp = new int[] { 1, 1 };

            impassableCells = new int[][] { new int[] { 0, 2 },
                                            new int[] { 1, 2 }
                                          };

            friendlyTroops = new int[] { 0, -3, 1 };
            enemyTroops = new int[] { 2, -3, 1 };
            loggingCamp = new int[] { -3, 0 };

            impassableCells = new int[][] { new int[] { -1, -2 },
                                            new int[] { -2, -1 },
                                            //new int[] { -2, 0 },
                                            new int[] { -3, -1 }
                                          };

            //friendlyTroops = new int[] { -2, 2, 3 };
            //enemyTroops = new int[] { 3, 0, 9 };
            //loggingCamp = new int[] { 1, 0 };

            //impassableCells = new int[][] { new int[] { -1, 1 } };

            //act
            MZBot mb = new MZBot();

            bool actual = mb.farmingResources(friendlyTroops, enemyTroops, loggingCamp, impassableCells);

            bool expected = true;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void FunctionTest()
        {
            //arrange

            //act
            Challenges c = new Challenges();

            int actual = c.betaExor("CodeFight");

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void granTurismoTest()
        {
            //arrange

            double zeroTo100 = 10.0;
            int topSpeed = 100;
            int brakingDistance = 100;
            int runwayLength = 240;

            zeroTo100 = 5.6;
            topSpeed = 160;
            brakingDistance = 92;
            runwayLength = 400;

            //zeroTo100 = 2.8;
            //topSpeed = 360;
            //brakingDistance = 40;
            //runwayLength = 200;

            //zeroTo100 = 5.3;
            //topSpeed = 180;
            //brakingDistance = 62;
            //runwayLength = 1000;

            //act
            Challenges c = new Challenges();

            string actual = c.granTurismo(zeroTo100, topSpeed, brakingDistance, runwayLength);

            string expected = "";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void semiprimeByNumberTest()
        {
            //arrange

            //act
            HeadToHead c = new HeadToHead();

            int actual = c.semiprimeByNumber(15);

            int expected = 0;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void rowsRearrangingTest()
        {
            //arrange

            int[][] matrix = new int[][] { new int[] { 6, 4},
                                           new int[] { 2, 2},
                                           new int[] { 4, 3},
                                         };
            matrix = new int[][] { new int[] { 0, 1},
                                           new int[] { 1, 2},
                                           new int[] { -1, 4},
                                         };

            //act
            HeadToHead c = new HeadToHead();

            bool actual = c.rowsRearranging(matrix);

            bool expected = true;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void AlphabetStudyTest()
        {
            //arrange

            //act
            Challenges c = new Challenges();

            string actual = c.AlphabetStudy("act", "cat");

            string expected = "";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void Test1()
        {
            //arrange

            bool[][] labMap = new bool[][] { new bool[] { true, true, true, true, true, true },
                                             new bool[] { true,true,true,true,true,false },
                                             new bool[] { true,true,true,true,true,true },
                                             new bool[] { true, true, true, true, true, true }
                                           };

            labMap = new bool[][] { new bool[] { true,true,false,true,true },
                                    new bool[] { true,true,true,true,true },
                                    new bool[] { true,false,true,true,true }
                                  };

            labMap = new bool[][] { new bool[] { true,true,true,true,true,true },
                                    new bool[] { true,true,true,true,true,true },
                                    new bool[] { true,true,true,false,true,true },
                                    new bool[] { true,true,true,true,true,true },
                                  };

            labMap = new bool[][] { new bool[] { true,true,true,true,true,true,true,true },
                                    new bool[] { true,true,false,true,true,true,true,true },
                                    new bool[] { true,true,true,true,true,false,true,true },
                                    new bool[] { true,true,true,true,true,true,true,true },
                                  };

            labMap = new bool[][] { new bool[] { true,true,true,true,true },
                                    new bool[] { true,true,true,true,true },
                                    new bool[] { true,false,true,true,true }
                                  };

            //act
            HeadToHead hth = new HeadToHead();

            int actual = hth.squareInTheLabyrinth(labMap);

            int expected = 4;

            //assert
            //Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void bishopDiagonalTest()
        {
            //arrange

            //act
            HeadToHead h = new HeadToHead();

            string[] actual = h.bishopDiagonal("d7", "f5");

            string expected = "";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void ratingThresholdTest()
        {
            //arrange
            double threshold = 0;
            int[][] ratings = new int[][] { new int[] { } };
            //act
            TackBot tb = new TackBot();

            int[] actual = tb.ratingThreshold(threshold, ratings);

            int[] expected = new int[] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void proCategorizationTest()
        {
            //arrange
            string[] pros = new string[] { "Jack", "Leon", "Maria" };
            string[][] preferences = new string[][] { new string[] { "Computer repair", "Handyman", "House cleaning" },
                                                      new string[] { "Computer lessons", "Computer repair", "Data recovery service" },
                                                      new string[] { "Computer lessons", "House cleaning"},
            };
            
            //act
            TackBot tb = new TackBot();

            string[][][] actual = tb.proCategorization(pros, preferences);

            string[][][] expected = new string[][][] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void spamClusterizationTest()
        {
            //arrange
            string[] requests = new string[] {
                                                "I need a new window.",
                                                "I really, really want to replace my window!",
                                                "Replace my window.",
                                                "I want a new window.",
                                                "I want a new carpet, I want a new carpet, I want a new carpet.",
                                                "Replace my carpet"
                                             };
            int[] IDs = new int[] { 374, 2845, 83, 1848, 1837, 1500 };
            double threshold = 0.5;

            requests = new string[] { "I need a new window.", "I need a new window." };
            IDs = new int[] { 239, 240 };
            threshold = 1;

            //requests = new string[] { "1 20 2.", "12 220 42." };
            //IDs = new int[] { 239, 240 };
            //threshold = 0;

            //act
            TackBot tb = new TackBot();

            int[][] actual = tb.spamClusterization(requests, IDs, threshold);

            int[][] expected = new int[][] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void requestMatchingTest()
        {
            //arrange
            string[] pros = new string[] { "Michael", "Mary", "Ann", "Nick", "Dan", "Mark" };
            int[] distances = new int[] { 12, 10, 19, 15, 5, 20 };
            int[] travelPreferences = new int[] { 12, 8, 25, 10, 3, 10 };
            
            //act
            TackBot tb = new TackBot();

            string[] actual = tb.requestMatching(pros, distances, travelPreferences);

            string[] expected = new string[] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void priceSuggestionTest()
        {
            //arrange
            int[] contractData = new int[] { 1, 5, 6, 3, 2, 4, 7, 8 };

            //contractData = new int[] { 3, 1 };

            //act
            TackBot tb = new TackBot();

            int[] actual = tb.priceSuggestion(contractData);

            int[] expected = new int[] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void categoryRecommendationsTest()
        {
            //arrange
            string[][] requestData = new string[][] {
                                            new string[] { "Accounting", "Administrative Support", "Advertising", "Bodyguard", "Auctioneering"},
                                            new string[] { "Accounting", "Administrative Support" },
                                            new string[] { "Advertising", "Auctioneering", "Bodyguard" },
                                            new string[] { "Bodyguard", "Services Business", "Consulting" }
                                                    };
            string[] proSelections = new string[] { "Accounting", "Advertising" };
            //act
            TackBot tb = new TackBot();

            string actual = tb.categoryRecommendations(requestData, proSelections);

            string expected = "";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void losslessDataCompressionTest()
        {
            //arrange

            //act
            DropBot db = new DropBot();

            string actual = db.losslessDataCompression("abacabadabacaba", 7);

            string expected = "";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void displayDiffTest()
        {
            //arrange
            string oldVersion = "", newVersion = "";

            oldVersion = "same_prefix_1233_same_suffix";
            newVersion = "same_prefix23123_same_suffix";
            //expected = "same_prefix(_1)23[12]3_same_suffix";

            oldVersion = "a";
            newVersion = "b";

            oldVersion = "ab";
            newVersion = "bb";

            oldVersion = "same_prefix_1233_same_suffix";
            newVersion = "same_prefix231233_same_suffix";
            //expected = "same_prefix(_)[23]1233_same_suffix";
            //received = "same_prefix(_1)23[12]3(_same_suffix)[3]";


            oldVersion = "same_prefix_";
            newVersion = "same_prefix23";

            oldVersion = "same_prefix_12533_same_suffix";
            newVersion = "same_prefix23123_same_suffix";
            //expected = "same_prefix(_1)2(5)3[12]3_same_suffix";
            //received = "same_prefix(_1)2(53)[312]3_same_suffix";

            oldVersion = "s_1253";
            newVersion = "s2312";
            //expected = "s(_1)2(5)3[12]";
            //received = "s(_1)2(53)[312];

            //act
            DropBot db = new DropBot();

            string actual = db.displayDiff(oldVersion, newVersion);

            string expected = "same_prefix(_1)23[12]3_same_suffix";

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void deliveryTest()
        {
            //arrange
            int[] order = new int[] { 200, 20, 15 };
            int[][] shoppers = new int[][] {
                                                new int[] { 300, 40, 5 },
                                                new int[] { 600, 40, 10 },
                                           };
            order = new int[] { 100, 4, 3 };
            shoppers = new int[][] { new int[] { 100, 33, 1 } };

            //act
            InstaBot ib = new InstaBot();

            bool[] actual = ib.delivery(order, shoppers);

            bool[] expected = new bool[] { };

            //assert
            //Assert.Equals(expected, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void isAdmissibleOverpaymentTest()
        {
            //arrange
            double[] prices = new double[] { 110, 95, 70 };
            string[] notes = new string[] {
                                            "10.0% higher than in-store",
                                            "5.0% lower than in-store",
                                            "Same as in-store"
                                          };
            double x = 5;

            //act
            InstaBot ib = new InstaBot();

            bool actual = ib.isAdmissibleOverpayment(prices, notes, x);

            bool expected = true;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        public void busyHolidaysTest()
        {
            //arrange
            string[][] shoppers = new string[][] {
                                                    new string[] { "15:10", "16:00" },
                                                    new string[] { "17:40", "22:30" }
                                                 };
            string[][] orders = new string[][] {
                                                    new string[] { "17:30", "18:00" },
                                                    new string[] { "15:00", "15:45" }
                                               };
            int[] leadTime = new int[] { 15, 30 };

            shoppers = new string[][] {
                                                    new string[] { "23:00","23:59" },
                                                    new string[] { "22:30", "23:30" }
                                                 };
            orders = new string[][] {
                                                    new string[] { "23:15","23:35" },
                                                    new string[] { "23:00", "23:31" }
                                               };
            leadTime = new int[] { 20, 30 };


            shoppers = new string[][] {
                                                    new string[] { "23:00","23:59" },
                                                    new string[] { "22:30", "23:30" }
                                                 };
            orders = new string[][] {
                                                    new string[] { "23:15","23:35" },
                                                    new string[] { "23:00", "23:31" }
                                               };
            leadTime = new int[] { 20, 31 };

            shoppers = new string[][] {
                                                    new string[] { "09:25","23:31" },
                                                    new string[] { "21:34","23:01" },
                                                    new string[] { "10:04","19:13" },
                                                    new string[] { "23:38","23:40" },
                                                    new string[] { "19:30","22:18" },
                                                 };
            orders = new string[][] {
                                                    new string[] { "03:00","13:12" },
                                                    new string[] { "20:19","21:56" },
                                                    new string[] { "04:14","12:39" },
                                                    new string[] { "23:35","23:39" },
                                                    new string[] { "19:04","21:21" },
                                               };
            leadTime = new int[] { 227, 22, 155, 1, 111 };


            /*
shoppers: [["09:25","23:31"], 
 ["21:34","23:01"], 
 ["10:04","19:13"], 
 ["23:38","23:40"], 
 ["19:30","22:18"]]
orders: [["03:00","13:12"], 
 ["20:19","21:56"], 
 ["04:14","12:39"], 
 ["23:35","23:39"], 
 ["19:04","21:21"]]
leadTime: [227, 22, 155, 1, 111]
            */

            //act
            InstaBot ib = new InstaBot();

            bool actual = ib.busyHolidays(shoppers, orders, leadTime);

            bool expected = true;

            //assert
            Assert.Equals(expected, actual);

            //CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WinSCPTestTest()
        {
            //arrange

            //act
            WinSCPTest ftp = new WinSCPTest();

            ftp.Test();

        }

    }
}
