using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights
{
    public class MZBot
    {
        /*
        You've just started constructing a military academy. It will take t seconds to erect the building, but given that you're in a hurry you decide this is too long to wait.

        Fortunately, your Alliance offers you help to speed up construction - this is called a boost. Each member of the Alliance can decrease the time needed to finish the building either by 10% of the initial construction time or by 1 minute (whichever is greater). However, you can't get more than 10 boosts for a given construction project. Assuming that your Alliance members act optimally, find the shortest possible time it will take to build the academy.

        Note that if 10% of the total construction time doesn't equal an integer number of seconds, then the time bonus you get is rounded down (for each of the Alliance members independently).

        Example

        For t = 1000 and allianceSize = 10, the output should be
        allianceHelp(t, allianceSize) = 0.
        If each member of the Alliance boosts the building by 10% (i.e. by 100 seconds), your new academy will be finished instantly.

        For t = 999 and allianceSize = 11, the output should be
        allianceHelp(t, allianceSize) = 9.
        Any 10 of your 11 allies can speed the construction up by 10% (which equals 99 seconds since 99.9 is rounded down).

        For t = 100 and allianceSize = 1, the output should be
        allianceHelp(t, allianceSize) = 40.
        Your only Alliance member will boost the construction by 1 minute (i.e. 60 seconds).

        Input/Output

        [time limit] 3000ms (cs)
        [input] integer t

        A positive integer equal to the total construction time (in seconds).

        Constraints:
        1 ≤ t ≤ 1000.

        [input] integer allianceSize

        A non-negative integer equal to the number of your Alliance members.

        Constraints:
        0 ≤ allianceSize ≤ 1000.

        [output] integer

        The shortest possible time it will take to build the academy.
        */

        public int allianceHelp(int t, int allianceSize)
        {
            int maxBoostPermember = (t / 10 > 60) ? t / 10 : 60;
            int maxBoostTotal = maxBoostPermember * (allianceSize >= 10 ? 10 : allianceSize);
            return (t - maxBoostTotal < 0) ? 0 : t - maxBoostTotal;
        }

        /*
        You and your alliance of warriors are trying to kill a monster to score points in a Kingdom vs. Kingdom (KvK) event. Each unit (both a warrior and a monster are considered a unit) has a certain number of health points (healthPoints) and attack damage value (attackDamage). When one unit attacks another, the health of the unit that is under attack is decreased by the attacker's damage value. If a unit's health points are reduced to zero or less, the unit dies and can't take part in the battle anymore.

        The skirmish between the warrior alliance and the monster proceeds in the following way:

        Each turn, you direct one of your warriors to attack the monster.
        If the monster dies, you win.
        If the monster is still alive after an attack, it counter-attacks the same warrior who attacked it in the previous step.
        If all of your warriors die, you lose.
        Find the maximum number of your warriors that will remain after defeating the monster. If it's impossible to kill a monster without losing all your warriors, return 0.

        Example

        For healthPoints = [110, 30, 50] and attackDamage = [12, 11, 20], the output should be
        allianceVersusMonster(healthPoints, attackDamage) = 2.

        One of the optimal strategies is as follows:

        Attack the monster four times with the second warrior. The monster's health will become 110 - 20 * 4 = 30, while the warrior's health will be 50 - 12 * 4 = 2.
        If you use the second warrior again immediately, it will die. Therefore, use the first warrior instead. Its three attacks will deplete the monster's health by 11 * 3 = 33 points, while the monster will respond only twice. After the third attack it will die instantly. Your first warrior's health will be 30 - 12 * 2 = 6 after the fight ends.
        In this way you are able to save both of your warriors and win the battle.
        For healthPoints = [4, 10, 10, 10] and attackDamage = [10, 1, 1, 1], the output should be
        allianceVersusMonster(healthPoints, attackDamage) = 0.

        Each of your warriors will be able to attack the monster only once because they will die after one counter-attack. Each of the attacks will reduce the monster's health by 1. Thus, after three turns, the monster will still have 1 health point but all of your warrior will be dead.

        Input/Output

        [time limit] 3000ms (cs)
        [input] array.integer healthPoints

        Array of at least two positive integers. healthPoints[0] corresponds to the monster's health, while all the following elements refer to warriors of the alliance.

        Constraints:
        2 ≤ healthPoints.length ≤ 30,
        1 ≤ healthPoints[i] ≤ 2 · 109 + 1.

        [input] array.integer attackDamage

        Array of the same length as healthPoints, consisting of positive integers. attackDamage[0] equals the monster's attack damage, while all the following elements refer to warriors of the alliance.

        Constraints:
        2 ≤ attackDamage.length ≤ 30,
        1 ≤ attackDamage[i] ≤ 100.

        [output] integer

        The maximum number of your warriors that will remain after defeating the monster, or 0 if it's impossible to kill a monster without losing all your warriors.
        */

        public int allianceVersusMonster(int[] healthPoints, int[] attackDamage)
        {
            int monsterHealth = healthPoints[0];
            int monsterADV = attackDamage[0];
            int warriorCount = healthPoints.Length - 1;

            var warriorHealthPoints = healthPoints.Skip(1).Select((x, i) => new KeyValuePair<int, int>(i, x % monsterADV)).OrderBy(x => x.Value).ToList();

            int reducedMonsterHealth = 0;

            for (int i = 0; i < warriorHealthPoints.Count(); i++)
            {
                if (warriorHealthPoints[i].Value > 0)
                    reducedMonsterHealth += healthPoints[warriorHealthPoints[i].Key + 1] / monsterADV * attackDamage[warriorHealthPoints[i].Key + 1];
                else
                    reducedMonsterHealth += (healthPoints[warriorHealthPoints[i].Key + 1] / monsterADV - 1) * attackDamage[warriorHealthPoints[i].Key + 1];

                if (reducedMonsterHealth >= monsterHealth || monsterHealth - reducedMonsterHealth < attackDamage[warriorHealthPoints[i].Key + 1])
                    return warriorCount;
            }

            var warriorAttackDamage = attackDamage.Skip(1).Select((x, i) => new KeyValuePair<int, int>(i, x)).OrderByDescending(x => x.Value).ToList();

            for (int i = 0; i < warriorAttackDamage.Count(); i++)
            {
                reducedMonsterHealth += attackDamage[warriorAttackDamage[i].Key + 1];

                if (reducedMonsterHealth >= monsterHealth)
                    return warriorCount;
                else
                    warriorCount -= 1;
            }

            return warriorCount;
        }

        //best solution 1
        bool farmingResources1(int[] friendlyTroops, int[] enemyTroops, int[] loggingCamp, int[][] impassableCells)
        {
            Queue<int[]> nextLevel = new Queue<int[]>();
            HashSet<string> alreadyVisited = new HashSet<string>();

            Action<int, int> CanMoveEnqueue = (x, y) =>
            {
                if (Math.Abs(x) > 20 || Math.Abs(y) > 20)
                    return;
                if (alreadyVisited.Contains(x + "," + y))
                    return;
                if (!impassableCells.Any(a => a[0] == x && a[1] == y))
                {
                    nextLevel.Enqueue(new[] { x, y });
                    alreadyVisited.Add(x + "," + y);
                }
            };

            Func<int[], int> Solve = (troop) => {
                alreadyVisited.Clear();

                Queue<int[]> level = new Queue<int[]>();
                int path = -1;
                int cur = 0;
                level.Enqueue(new[] { troop[0], troop[1] });

                while (path == -1) // BFS!
                {
                    if (level.Count == 0)
                        return int.MaxValue;

                    while (level.Count > 0)
                    {
                        int[] pos = level.Dequeue();
                        if (pos[0] == loggingCamp[0] && pos[1] == loggingCamp[1])
                        {
                            path = cur;
                            break;
                        }
                        int X = pos[0];
                        int Y = pos[1];
                        CanMoveEnqueue(X, Y - 1);
                        CanMoveEnqueue(X + 1, Y - 1);
                        CanMoveEnqueue(X - 1, Y);
                        CanMoveEnqueue(X + 1, Y);
                        CanMoveEnqueue(X - 1, Y + 1);
                        CanMoveEnqueue(X, Y + 1);
                    }
                    level = nextLevel;
                    nextLevel = new Queue<int[]>();
                    cur++;
                }
                return path * troop[2];
            };
            int friendly = Solve(friendlyTroops);
            int enemy = Solve(enemyTroops);
            return (friendly < enemy);
        }
        
        //best solution 2
        public bool farmingResources(int[] friendlyTroops, int[] enemyTroops, int[] loggingCamp, int[][] impassableCells)
        {
            long yours = OptimalPath(new int[] { friendlyTroops[0], friendlyTroops[1], 0 }, loggingCamp, impassableCells);
            Console.WriteLine(yours);
            long enemy = OptimalPath(new int[] { enemyTroops[0], enemyTroops[1], 0 }, loggingCamp, impassableCells);
            Console.WriteLine(enemy);
            if (yours == int.MaxValue && enemy == int.MaxValue)
                return true;
            return friendlyTroops[2] * yours < enemyTroops[2] * enemy;
        }

        int OptimalPath(int[] source, int[] to, int[][] impassable)
        {
            int[] neighbours = new int[] { -1, 0, 1, 0, 0, -1, 1, -1, -1, 1, 0, 1 };
            System.Collections.Generic.Queue<int[]> q = new System.Collections.Generic.Queue<int[]>();
            q.Enqueue(source);
            HashSet<string> hsVisited = new HashSet<string>();
            hsVisited.Add(source[0] + "_" + source[1]);
            while (q.Count > 0)
            {
                int[] cell = q.Dequeue();
                if (cell[0] == to[0] && cell[1] == to[1])
                    return cell[2];
                for (int i = 0; i < 6; i++)
                {
                    int cx = cell[0] + neighbours[i * 2];
                    int cy = cell[1] + neighbours[i * 2 + 1];
                    if (cx >= 20 || cx <= -20 || cy >= 20 || cy <= -20)
                        continue;
                    if (hsVisited.Contains(cx + "_" + cy))
                        continue;
                    bool passable = true;
                    foreach (int[] c in impassable)
                    {
                        if (c[0] == cx && c[1] == cy)
                        {
                            passable = false;
                            break;
                        }
                    }
                    if (passable)
                    {
                        hsVisited.Add(cx + "_" + cy);
                        q.Enqueue(new int[] { cx, cy, cell[2] + 1 });
                    }
                }
            }
            return int.MaxValue;
        }

        //My solution
        public bool farmingResourcesOld(int[] friendlyTroops, int[] enemyTroops, int[] loggingCamp, int[][] impassableCells)
        {
            try
            {
                int totalNumberOfStepsForFriendlies = NumberOfMovesRequired(friendlyTroops[0], friendlyTroops[1], loggingCamp[0], loggingCamp[1], impassableCells) * friendlyTroops[2];
                int totalNumberOfStepsForEnemies = NumberOfMovesRequired(enemyTroops[0], enemyTroops[1], loggingCamp[0], loggingCamp[1], impassableCells) * enemyTroops[2];

                return (totalNumberOfStepsForFriendlies >= totalNumberOfStepsForEnemies ? false : true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        int NumberOfMovesRequired(int startX, int startY, int endX, int endY, int[][] impassableCells)
        {
            //Change the coordinates such that we always have the coordinate with higher x and y coordinates as end coordinates.

            if (startX == endX)
            {
                if (startY > endY)
                {
                    int temp = startY;
                    startY = endY;
                    endY = temp;
                }
            }
            else if (startY == endY)
            {
                if (startX > endX)
                {
                    int temp = startX;
                    startX = endX;
                    endX = temp;
                }
            }

            //neighbouring cells
            if ((startX == endX && Math.Abs(startY - endY) == 1) || (startY == endY && Math.Abs(startX - endX) == 1) || (startX == endY && Math.Abs(startY - endX) == 1) || (startY == endX && Math.Abs(startX - endY) == 1))
                return 1;

            bool straightLine = false;

            int minimumMoves = GetMinimumMoves(startX, startY, endX, endY, ref straightLine);

            List<List<List<int>>> possiblePaths = new List<List<List<int>>>();
            possiblePaths = GetPossiblePaths(possiblePaths, new List<List<int>>(), startX, startY, endX, endY, straightLine);

            bool pathWithoutImpassableCellsFound = true;

            for (int i = 0; i < possiblePaths.Count(); i++)
            {
                var path = possiblePaths[i];

                for (int j= 0; j < impassableCells.Count(); j++)
                {
                    var found = path.Where(p => p[0] == impassableCells[j][0] && p[1] == impassableCells[j][1]).ToList();

                    if (found.Count() > 0)
                    {
                        pathWithoutImpassableCellsFound = false;
                        break;
                    }
                }

                if (pathWithoutImpassableCellsFound || i == possiblePaths.Count() - 1)
                    break;
                else
                    pathWithoutImpassableCellsFound = true;
            }

            if (pathWithoutImpassableCellsFound == true)
                return possiblePaths[0].Count() - 1;

            //Now we know there is no path available without impassable cells. 
            //Now we will replace impassable cells with neighbouring cells. Then find out the path with minimum cells and return the value

            possiblePaths = ReplaceImpassableCells(possiblePaths, impassableCells, 0, minimumMoves).OrderBy(item => item.Count()).ToList();

            return possiblePaths[0].Count() - 1;
        }

        List<List<List<int>>> ReplaceImpassableCells(List<List<List<int>>> possiblePaths, int[][] impassableCells, int currentIndex, int minimumMoves)
        {
            int initialPossiblePathsCount = possiblePaths.Count();

            int newMinimumValue = -1;

            for (int i = currentIndex; i < initialPossiblePathsCount; i++)
            {
                var path = possiblePaths[i];

                if (newMinimumValue == -1)
                    newMinimumValue = minimumMoves * 5;

                List<List<int>> newPathClockWise = new List<List<int>>();
                newPathClockWise = ReturnReplacedPath(newPathClockWise, path, impassableCells, true, newMinimumValue);

                if (newMinimumValue == -1)
                {
                    newMinimumValue = newPathClockWise.Count();
                    possiblePaths.Add(newPathClockWise);
                }
                else
                {
                    if (newPathClockWise.Count() < newMinimumValue)
                    {
                        newMinimumValue = newPathClockWise.Count();
                        possiblePaths.Add(newPathClockWise);
                    }
                }

                List<List<int>> newPathAnticlockWise = new List<List<int>>();
                newPathAnticlockWise = ReturnReplacedPath(newPathAnticlockWise, path, impassableCells, false, newMinimumValue);

                if (newPathAnticlockWise.Count() < newMinimumValue)
                {
                    newMinimumValue = newPathAnticlockWise.Count();
                    possiblePaths.Add(newPathAnticlockWise);
                }

                if (newPathClockWise.Count() == minimumMoves || newPathAnticlockWise.Count() == minimumMoves)
                    break;
            }

            for (int i = currentIndex; i < initialPossiblePathsCount; i++)
                possiblePaths.RemoveAt(0);

            return possiblePaths;
        }

        List<List<int>> ReturnReplacedPath(List<List<int>> path, List<List<int>> originalPath, int[][] impassableCells, bool clockwise, int minimumValue)
        {
            for(int i = 0; i < originalPath.Count; i++)
            {
                //var found = originalPath.Where(p => p[0] == impassableCells[j][0] && p[1] == impassableCells[j][1]).Select(item => item).ToList();
                var found = impassableCells.Where(p => p[0] == originalPath[i][0] && p[1] == originalPath[i][1]).ToList();

                if (found.Count() > 0)
                {
                    List<List<int>> replacedCells = new List<List<int>>();

                    bool dummy = false;

                    ReplaceImpassableCell(replacedCells, new List<int> { path[path.Count() - 1][0], path[path.Count() - 1][1] }, new List<int> { found[0][0], found[0][1] }, new List<int> { originalPath[i + 1][0], originalPath[i + 1][1] }, impassableCells, clockwise, minimumValue, ref dummy);

                    for (int k = 0; k < replacedCells.Count(); k++)
                        path.Add(replacedCells[k]);
                }
                else
                    path.Add(new List<int> { originalPath[i][0], originalPath[i][1] });

            }

            return path;
        }

        List<List<int>> ReplaceImpassableCell(List<List<int>> replacedCells, List<int> secondCell, List<int> impassableCell, List<int> finalCell, int[][] impassableCells, bool clockwise, int minimumValue, ref bool minimumCountExceeded)
        {
            if (minimumCountExceeded)
                return replacedCells;

            bool replaceCompleted = false;
            do
            {
                List<int> thirdCell = ReturnThirdCell(impassableCell[0], impassableCell[1], secondCell[0], secondCell[1], clockwise);

                if (thirdCell[0] == finalCell[0] && thirdCell[1] == finalCell[1])
                    replaceCompleted = true;
                else
                {
                    var found = impassableCells.Where(p => p[0] == thirdCell[0] && p[1] == thirdCell[1]).Select(item => item).ToList();

                    if (found.Count() == 0)
                    {
                        replacedCells.Add(thirdCell);

                        if (replacedCells.Count() > minimumValue && minimumValue > -1)
                        {
                            minimumCountExceeded = true;
                            replaceCompleted = true;
                        }
                        secondCell = thirdCell;
                    }
                    else
                    {
                        List<List<int>> replacedCellsNew = new List<List<int>>();
                        replacedCellsNew = ReplaceImpassableCell(replacedCellsNew, secondCell, thirdCell, impassableCell, impassableCells, clockwise, minimumValue, ref minimumCountExceeded);

                        for (int i = 0; i < replacedCellsNew.Count(); i++)
                        {
                            if (replacedCellsNew[i][0] != finalCell[0] || replacedCellsNew[i][1] != finalCell[1])
                            {
                                replacedCells.Add(replacedCellsNew[i]);
                                if (replacedCells.Count() > minimumValue && minimumValue > -1)
                                {
                                    minimumCountExceeded = true;
                                    replaceCompleted = true;
                                }
                            }
                            else
                            {
                                replaceCompleted = true;
                                break;
                            }
                        }
                    }
                }

            } while (replaceCompleted == false);

            return replacedCells;
        }

        bool FindIfListExistsInList(List<List<List<int>>> source, List<List<int>> searchList)
        {
            bool found = true;

            for(int i = 0; i < source.Count(); i++)
            {
                if (source[i].Count() != searchList.Count())
                    found = false;
                else
                {
                    for(int j = 0; j < source[i].Count(); j++)
                    {
                        if (source[i][j][0] != searchList[j][0] || source[i][j][1] != searchList[j][1])
                        {
                            found = false;
                            break;
                        }
                    }
                }

                if (found == true)
                    break;

                if (i < source.Count() - 1 && found == false)
                    found = true;
            }

            return found;
        }
        List<int> ReturnThirdCell(int firstCellX, int firstCellY, int secondCellX, int secondCellY, bool clockwise)
        {
            int thirdX = 0;
            int thirdY = 0;

            if (clockwise)
            {
                if (firstCellX < secondCellX && firstCellY == secondCellY)
                {
                    thirdX = firstCellX;
                    thirdY = secondCellY + 1;
                }
                if (firstCellX == secondCellX && firstCellY < secondCellY)
                {
                    thirdX = firstCellX - 1;
                    thirdY = secondCellY;
                }
                if (firstCellX > secondCellX && firstCellY < secondCellY)
                {
                    thirdX = firstCellX - 1;
                    thirdY = secondCellY - 1;
                }
                if (firstCellX > secondCellX && firstCellY == secondCellY)
                {
                    thirdX = firstCellX;
                    thirdY = secondCellY - 1;
                }
                if (firstCellX == secondCellX && firstCellY > secondCellY)
                {
                    thirdX = secondCellX + 1;
                    thirdY = secondCellY;
                }
                if (firstCellX < secondCellX && firstCellY > secondCellY)
                {
                    thirdX = firstCellX + 1;
                    thirdY = firstCellY;
                }
            }
            else
            {
                if (firstCellX < secondCellX && firstCellY == secondCellY)
                {
                    thirdX = secondCellX;
                    thirdY = secondCellY - 1;
                }
                if (firstCellX == secondCellX && firstCellY < secondCellY)
                {
                    thirdX = firstCellX + 1;
                    thirdY = firstCellY;
                }
                if (firstCellX > secondCellX && firstCellY < secondCellY)
                {
                    thirdX = firstCellX;
                    thirdY = secondCellY;
                }
                if (firstCellX > secondCellX && firstCellY == secondCellY)
                {
                    thirdX = secondCellX;
                    thirdY = secondCellY + 1;
                }
                if (firstCellX == secondCellX && firstCellY > secondCellY)
                {
                    thirdX = firstCellX - 1;
                    thirdY = firstCellY;
                }
                if (firstCellX < secondCellX && firstCellY > secondCellY)
                {
                    thirdX = firstCellX;
                    thirdY = secondCellY;
                }
            }

            return new List<int> { thirdX, thirdY };
        }
        int GetMinimumMoves(int startX, int startY, int endX, int endY, ref bool straightLine)
        {
            int minimumMoves = 0;

            straightLine = false;

            //Single Line
            if ((startX == endX) || (startY == endY) || (Math.Abs(startX - endX) == Math.Abs(startY - endY)))
            {
                straightLine = true;

                if ((startX == endX) || (startY == endY))
                    minimumMoves = Math.Max(Math.Abs(startX - endX), Math.Abs(startY - endY));
                else
                    minimumMoves = Math.Abs(startX - endX);
            }
            else
                minimumMoves = Math.Max(Math.Max(Math.Max(Math.Abs(startX - endX), Math.Abs(startY - endY)), Math.Abs(startX - endY)), Math.Abs(startY - endX));

            return minimumMoves;
        }

        List<List<List<int>>> GetPossiblePaths(List<List<List<int>>> possiblePaths, List<List<int>> path, int startX, int startY, int endX, int endY, bool straightLine)
        {
            if (path.Count() == 0)
            {
                path.Add(new List<int> { startX, startY });
                GetPossiblePaths(possiblePaths, path, startX, startY, endX, endY, straightLine);
            }
            else
            {
                if (path[path.Count() - 1][0] == endX && path[path.Count() - 1][1] == endY)
                    possiblePaths.Add(path);
                else
                {
                    if (straightLine)
                    {
                        if (startX == endX)
                            for (int i = 1; i < (endY - startY); i++)
                                path.Add(new List<int> { startX, startY + i });
                        else if (startY == endY)
                            for (int i = 1; i < (endX - startX); i++)
                                path.Add(new List<int> { startX + i, startY });
                        else
                            for (int i = 1; i < Math.Abs(endY - startY); i++)
                                path.Add(new List<int> { startX + i * (startX < endX ? 1 : -1), startY + i * (startY < endY ? 1 : -1) });

                        path.Add(new List<int> { endX, endY });

                        possiblePaths.Add(path);

                    }
                    else
                    {
                        List<List<int>> path1 = path.ToList();
                        bool straightLine1 = false;
                        int minimumMoves1 = GetMinimumMoves(startX + (startX < endX ? 1 : -1), startY, endX, endY, ref straightLine1);

                        List<List<int>> path2 = path.ToList();
                        bool straightLine2 = false;
                        int minimumMoves2 = GetMinimumMoves(startX, startY + (startY < endY ? 1 : -1), endX, endY, ref straightLine2);

                        List<List<int>> path3 = path.ToList();
                        bool straightLine3 = false;
                        int minimumMoves3 = GetMinimumMoves(startX + (startX < endX ? 1 : -1), startY + (startY < endY ? 1 : -1), endX, endY, ref straightLine3);

                        if (minimumMoves1 == minimumMoves2)
                        {
                            //minimumMoves1 && minimumMoves2

                            int startX1 = startX + (startX < endX ? 1 : -1), startY1 = startY;

                            path1.Add(new List<int> { startX1, startY1 });

                            if (straightLine1)
                            {
                                if (startX1 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY1); i++)
                                        path1.Add(new List<int> { startX1, startY1 + i * (startY1 < endY ? 1 : -1) });
                                else if (startY1 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX1); i++)
                                        path1.Add(new List<int> { startX1 + i * (startX1 < endX ? 1 : -1), startY1 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY1); i++)
                                        path1.Add(new List<int> { startX1 + i * (startX1 < endX ? 1 : -1), startY1 + i * (startY1 < endY ? 1 : -1) });

                                path1.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path1);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path1, startX1, startY1, endX, endY, straightLine);
                            }


                            int startX2 = startX, startY2 = startY + (startY < endY ? 1 : -1);

                            path2.Add(new List<int> { startX2, startY2 });

                            if (straightLine2)
                            {
                                if (startX2 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY2); i++)
                                        path2.Add(new List<int> { startX2, startY2 + i * (startY2 < endY ? 1 : -1) });
                                else if (startY2 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX2); i++)
                                        path2.Add(new List<int> { startX2 + i * (startX2 < endX ? 1 : -1), startY2 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY2); i++)
                                        path2.Add(new List<int> { startX2 + i * (startX2 < endX ? 1 : -1), startY2 + i * (startY2 < endY ? 1 : -1) });

                                path2.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path2);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path2, startX2, startY2, endX, endY, straightLine);
                            }
                        }
                        else if (minimumMoves1 < minimumMoves2)
                        {
                            //minimumMoves1 && minimumMoves3

                            int startX1 = startX + (startX < endX ? 1 : -1), startY1 = startY;

                            path1.Add(new List<int> { startX1, startY1 });

                            if (straightLine1)
                            {
                                if (startX1 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY1); i++)
                                        path1.Add(new List<int> { startX1, startY1 + i * (startY1 < endY ? 1 : -1) });
                                else if (startY1 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX1); i++)
                                        path1.Add(new List<int> { startX1 + i * (startX1 < endX ? 1 : -1), startY1 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY1); i++)
                                        path1.Add(new List<int> { startX1 + i * (startX1 < endX ? 1 : -1), startY1 + i * (startY1 < endY ? 1 : -1) });

                                path1.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path1);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path1, startX1, startY1, endX, endY, straightLine);
                            }


                            int startX3 = startX + (startX < endX ? 1 : -1), startY3 = startY + (startY < endY ? 1 : -1);

                            path3.Add(new List<int> { startX3, startY3 });

                            if (straightLine3)
                            {
                                if (startX3 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY3); i++)
                                        path3.Add(new List<int> { startX3, startY3 + i * (startY3 < endY ? 1 : -1) });
                                else if (startY3 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX3); i++)
                                        path3.Add(new List<int> { startX3 + i * (startX3 < endX ? 1 : -1 ), startY3 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY3); i++)
                                        path3.Add(new List<int> { startX3 + i * (startX3 < endX ? 1 : -1), startY3 + i * (startY3 < endY ? 1 : -1) });

                                path3.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path3);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path3, startX3, startY3, endX, endY, straightLine);
                            }
                        }
                        else
                        {
                            //minimumMoves2 && minimumMoves3

                            int startX2 = startX, startY2 = startY + (startY < endY ? 1 : -1);

                            path2.Add(new List<int> { startX2, startY2 });

                            if (straightLine2)
                            {
                                if (startX2 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY2); i++)
                                        path2.Add(new List<int> { startX2, startY2 + i * (startY2 < endY ? 1 : -1) });
                                else if (startY2 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX2); i++)
                                        path2.Add(new List<int> { startX2 + i * (startX2 < endX ? 1 : -1), startY2 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY2); i++)
                                        path2.Add(new List<int> { startX2 + i * (startX2 < endX ? 1 : -1), startY2 + i * (startY2 < endY ? 1 : -1) });

                                path2.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path2);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path2, startX2, startY2, endX, endY, straightLine);
                            }

                            int startX3 = startX + (startX < endX ? 1 : -1), startY3 = startY + (startY < endY ? 1 : -1);

                            path3.Add(new List<int> { startX3, startY3 });

                            if (straightLine3)
                            {
                                if (startX3 == endX)
                                    for (int i = 1; i < Math.Abs(endY - startY3); i++)
                                        path3.Add(new List<int> { startX3, startY3 + i * (startY3 < endY ? 1 : -1) });
                                else if (startY3 == endY)
                                    for (int i = 1; i < Math.Abs(endX - startX3); i++)
                                        path3.Add(new List<int> { startX3 + i * (startX3 < endX ? 1 : -1), startY3 });
                                else
                                    for (int i = 1; i < Math.Abs(endY - startY3); i++)
                                        path3.Add(new List<int> { startX3 + i * (startX3 < endX ? 1 : -1), startY3 + i * (startY3 < endY ? 1 : -1) });

                                path3.Add(new List<int> { endX, endY });

                                possiblePaths.Add(path3);

                            }
                            else
                            {
                                GetPossiblePaths(possiblePaths, path3, startX3, startY3, endX, endY, straightLine);
                            }
                        }
                    }
                }
            }

            return possiblePaths;

        }

    }
}
