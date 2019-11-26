using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata
{
    [TestFixture]
    class ArraySortingTests
    {
        private ArraySorter _arraySorter;

        [SetUp]
        public void SetupMethod()
        {
            _arraySorter = new ArraySorter();
        }

        [Test]
        public void WhenSortingPopulatedArray_ShouldSortCorrectly()
        {
            var sourceArray = new [] {5,69,8,3,100,8789,6,9,154,789,22,44,7};

            var result = _arraySorter.MergeSort(sourceArray);

            Assert.NotNull(result);
            result[0].Should().Be(3);
            result[result.Length -1].Should().Be(8789);
        }
    }

    public class ArraySorter
    {
        public static T[] MakeSubarray<T>(T[] source, int begin, int end)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source array is null");
            }

            if (begin > source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(begin),
                    "Begin index is too big");
            }

            if (end > source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(end),
                    "End index is too big");
            }

            if (begin > end)
            {
                throw new ArgumentOutOfRangeException(nameof(begin),
                    "Begin index is larger than end index");
            }

            T[] destination = new T[end - begin];
            if (destination.Length > 0)
            {
                Array.Copy(source, begin, destination, 0, destination.Length);
            }

            return destination;
        }

        public int[] MergeSort(int[] arrayToSort)
        {
            // BASE CASE: arrays with fewer than 2 elements are sorted
            if (arrayToSort.Length < 2)
            {
                return arrayToSort;
            }

            // STEP 1: divide the array in half
            // We use integer division, so we'll never get a "half index"
            var midIndex = arrayToSort.Length / 2;

            var left = MakeSubarray(arrayToSort, 0, midIndex);
            var right = MakeSubarray(arrayToSort, midIndex, arrayToSort.Length);

            // STEP 2: sort each half
            var sortedLeft = MergeSort(left);
            var sortedRight = MergeSort(right);

            // STEP 3: merge the sorted halves
            var sortedArray = new int[arrayToSort.Length];

            var currentLeftIndex = 0;
            var currentRightIndex = 0;

            for (var currentSortedIndex = 0; currentSortedIndex < arrayToSort.Length;
                    currentSortedIndex++)
            {
                // sortedLeft's first element comes next
                // if it's less than sortedRight's first
                // element or if sortedRight is exhausted
                if (currentLeftIndex < sortedLeft.Length
                        && (currentRightIndex >= sortedRight.Length
                        || sortedLeft[currentLeftIndex] < sortedRight[currentRightIndex]))
                {
                    sortedArray[currentSortedIndex] = sortedLeft[currentLeftIndex];
                    currentLeftIndex++;
                }
                else
                {
                    sortedArray[currentSortedIndex] = sortedRight[currentRightIndex];
                    currentRightIndex++;
                }
            }

            return sortedArray;
        }
    }
}
