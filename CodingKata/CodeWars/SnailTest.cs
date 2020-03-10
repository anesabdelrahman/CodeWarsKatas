using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class SnailTest
    {
        private SnailSolution _snailSolution;

        [SetUp]
        public void SetUp()
        {
            _snailSolution = new SnailSolution();
        }

        [TearDown]
        public void TearDown()
        {
            _snailSolution = null;
        }

        [Test]
        public void SnailTest1()
        {
            int[][] array =
            {
                new []{1, 2, 3},
                new []{4, 5, 6},
                new []{7, 8, 9}
            };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            //var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4 };
            Test(array, r);
        }

        [Test]
        public void SnailTest2()
        {
            int[][] array =
            {
                new []{1, 2, 3, 1},
                new []{4, 5, 6, 2},
                new []{7, 8, 9, 3}
            };
            var r = new[] { 1, 2, 3, 1, 2, 3, 9, 8, 7, 4, 5, 6 };
            //var r = new[] { 1, 2, 3, 1, 2, 3, 9, 8, 7, 4 };
            Test(array, r);
        }

        [Test]
        public void SnailTest3()
        {
            int[][] array =
            {
                new []{1, 2, 3},
                new []{4, 5, 6},
                new []{1, 2, 4},
                new []{7, 8, 9}
            };
            var r = new[] { 1, 2, 3, 6, 4, 9, 8, 7, 1, 4, 5, 2 };
            //var r = new[] { 1, 2, 3, 6, 4, 9, 8, 7, 1, 4 };
            Test(array, r);
        }

        [Test]
        public void SnailTest4()
        {
            int[][] array =
            {
                new []{1, 2, 3, 1},
                new []{4, 5, 6, 2},
                new []{7, 8, 9, 3},
                new []{7, 8, 9, 4}
            };
            var r = new[] { 1, 2, 3, 1, 2, 3, 4, 9, 8, 7, 7, 4, 5, 6, 9, 8 };
            //var r = new[] { 1, 2, 3, 1, 2, 3, 4, 9, 8, 7, 7, 4 };
            Test(array, r);
        }

        [Test]
        public void SnailTest5()
        {
            int[][] array =
            {
                new []{1, 2, 3, 1, 9},
                new []{4, 5, 6, 2, 3},
                new []{7, 8, 9, 3, 1},
                new []{7, 8, 9, 4, 7},
                new []{4, 5, 6, 2, 3}
            };

            var r = new[] { 1, 2, 3, 1, 9, 3, 1, 7, 3, 2, 6, 5, 4, 7, 7, 4, 5, 6, 2, 3, 4, 9, 8, 8, 9};
            //var r = new[] { 1, 2, 3, 1, 9, 3, 1, 7, 3, 2, 6, 5, 4, 7, 7, 4 };
            Test(array, r);
        }
        public string Int2dToString(int[][] a)
        {
            return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
        }

        public void Test(int[][] array, int[] result)
        {
            var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
            Console.WriteLine(text);
            var actual = SnailSolution.Test(array);
            Assert.AreEqual(result, actual);
        }
    }

    public class SnailSolution
    {
        public static int[] Test(int[][] array)
        {
            return Snail(array);
        }

        private static int[] Snail(int[][] array)
        {
            var tempResult = Filler(array, out var source);

            while (source.Count > 0 || source.FirstOrDefault()?.Count > 0)
            {
                var sourceCopy = source.Select(x => x.ToArray()).ToArray();
                tempResult.AddRange(Filler(sourceCopy, out source));
            }

            return tempResult.ToArray();
        }

        private static List<int> Filler(int[][] array, out List<List<int>> source)
        {
            var result = new List<int>();
            source = array.Select(x => x.ToList()).ToList();
            var firstWallIndex = source.Count - 2;
            var iterations = array.Length == 1 ? 1 : ((array.Length - 2) * 2) + 2;
            
            for (var i = 0; i < iterations; i++)
            {
                if (i == 0)
                {
                    result.AddRange(array[i]);
                    source.Remove(source[i]);
                    continue;
                }

                if (i < array.Length - 1)
                {
                    result.Add(array[i].LastOrDefault());
                    source[i - 1].RemoveAt(source[i - 1].LastIndexOf(source[i - 1].LastOrDefault()));
                    continue;
                }

                if (i == array.Length - 1)
                {
                    result.AddRange(array[array.Length - 1].Reverse());
                    source.Remove(source[i - 1]);
                    continue;
                }

                if (i > array.Length - 1)
                {
                    if (i < ((array.Length - 2) * 2) + 2)
                    {
                        result.Add(array[firstWallIndex].FirstOrDefault());
                        source[firstWallIndex - 1].Remove(source[firstWallIndex - 1].FirstOrDefault());
                        firstWallIndex--;
                        continue;
                    }

                    if (source.Count == 1 )
                    {
                        result.AddRange(source.FirstOrDefault());
                        source.Remove(source.FirstOrDefault());
                    }
                }
            }
            return result;
        }

        public static int[] Test1(int[][] array)
        {
            var result = new List<int>();
            result.AddRange(array[0]);
            result.AddRange(array[array.Length - 1].Reverse());
            var iterations = (array[0].Length) * ((array.Length) - 2);
            var forwardModifier = 0;
            var backwardModifier = 0;

            for (var i = 0; i < iterations-1; i++)
            {

                if (array[0] != null && i < array.Length - 2)
                {
                    result.Insert(array[i].Length + forwardModifier, array[i+1][array[i+1].Length - 1]);
                    forwardModifier++;
                    continue;
                }

                if (/*(array.Length != array[0].Length && i >= array.Length - 2 && i < array.Length - 1)*/
                     (array.Length == array[0].Length && i >= array.Length - 2 && i <= array.Length))
                {
                    result.Add(array[i - backwardModifier][0]);
                    backwardModifier++;
                    backwardModifier++;
                    continue;
                }


                //if ((i >= array.Length - 2 && i <= array.Length))
                //{
                //    result.Add(array[i - backwardModifier][0]);
                //    backwardModifier++;
                //    backwardModifier++;
                //    continue;
                //}

                //if (i == array.Length - 1)
                //{
                //    result.Add(array[i - backwardModifier][0]);
                //    continue;
                //}

                //if (i > iterations / array.Length)
                //{
                //    backwardModifier++;
                //    result.Add(array[i-backwardModifier][0]);
                //}



                //forwardModifier++;
                //result.Insert(array[i].Length + 1, array[i][0]);
            }

            return result.ToArray();
        }
    }
}

    
