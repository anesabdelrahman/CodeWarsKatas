using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class ValidParenthesesTests
    {
        private ValidParentheses _validParentheses;

        [SetUp]
        public void SetUp()
        {
            _validParentheses = new ValidParentheses();
        }

        [TearDown]
        public void TearDown()
        {
            _validParentheses = null;
        }

        [Test]
        [TestCase("()", true)]
        [TestCase("(((asdfasdfasdf)))", true)]
        [TestCase("(()", false)]
        [TestCase(")((((", false)]
        [TestCase("(]", false)]
        [TestCase(")(c(b(a)))(d)hi(hi)(())(()", false)]
        [TestCase("(c(b(a)))(d)((())()())hi(hi)hi(hi)(hi)(", false)]
        [TestCase(")(hi(hi))(", false)]
        [TestCase("hi(hi)hi(hi)((c(b(a)))(d))hi)((())(()", false)]
        [TestCase("(c(b(a)))(d)", true)]
        public void Test(string input, bool expected)
        {
            Assert.AreEqual(expected, ValidParentheses.IsValidParentheses(input));
            Assert.AreEqual(expected, ValidParentheses.IsValidParentheses(input));
        }
    }

    public class ValidParentheses
    {
        public static bool IsValidParentheses(string input)
        {
            var invalidParentheses = new[] { '[', ']', '{', '}', '<', '>' };
            if (input.Length < 0 && input.Length > 100 || input.Any(x => invalidParentheses.Contains(x)))
                return false;

            var parentheses = input.Where(x => x.Equals('(') || x.Equals(')')).ToList();
            if (parentheses.Count(x => x == '(') != parentheses.Count(x => x == ')'))
                return false;

            while (parentheses.Count > 0)
            {
                if (parentheses[0] != '(') return false;
                parentheses.RemoveAt(0);
                parentheses.Remove(')');
            }

            return parentheses.Count == 0;
        }
    }
}

    
