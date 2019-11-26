using System;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class WhoLikesItTests
    {
        private WhoLikesIt _whoLikesIt;
        [SetUp]
        public void Initialize() => _whoLikesIt = new WhoLikesIt();

        [Test]
        //[TestCase("", "no one likes this")]
        [TestCase("Peter", "Peter likes this")]
        [TestCase("Jacob Alex", "Jacob and Alex like this")]
        [TestCase("Max John Mark", "Max, John and Mark like this")]
        [TestCase("Alex Jacob Mark Max", "Alex, Jacob and 2 others like this")]
        [TestCase("Alex Phil Mark Max Jade Alan", "Alex, Phil and 4 others like this")]
        public void WhenSomeLikesIt_ItShouldReturnTheirNames(string input, string expected)
        {
            var name = input.Split(" ");
            
            var result = _whoLikesIt.Likes(name);
            result.Should().Be(expected);
        }
    }

    public class WhoLikesIt
    {
        public string Likes(string[] name)
        {
            // Although no specs for this but it is good to check/handle nulls.
            if (name == null)
                return string.Empty;

            var result = string.Empty;

            // I thought to Switch over array length as opposed to use a loop through array elements and check indices
            // that way we could improve efficiency and only loop when is needed.
            switch (name.Length)
            {
                case 0:
                    return $"{Statics.NoOne} {Statics.LikeThis}";

                case 1:
                    return $"{name[0]} {Statics.LikesThis}";

                case 2:
                    result += $"{name[0]} {Statics.And} {name[1]}";
                    break;

                case 3:
                {
                    for (var i = 0; i < name.Length; i++)
                    {
                        if (i == name.Length - 1)
                        {
                            result.TrimEnd();
                            result += $" {Statics.And} {name[i]}";
                            break;
                        }

                        if (i == 0)
                        {
                            result += $"{name[i]}";
                            continue;
                        }

                        result += $", {name[i]}";
                    }

                    break;
                }

                default: // no matter how many names being passed in, if they are more than 3 then we only need to access first two.
                    result += $"{name[0]}, {name[1]} {Statics.And} {name.Length - 2} {Statics.Others}";
                    break;
            }

            return $"{result} {Statics.LikeThis}";
        }
    }

    public static class Statics
    {
        public static readonly string LikeThis = "like this";
        public static readonly string LikesThis = "likes this";
        public static readonly string And = "and";
        public static readonly string Others = "others";
        public static readonly string NoOne = "no one";
    }
}
