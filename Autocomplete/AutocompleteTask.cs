using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Autocomplete
{
    public class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count
                && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            else return null;
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var phrasesCount = phrases.Count;
            var leftBorder = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrasesCount) + 1;
            if (leftBorder == phrasesCount) return new string[0];
            var actualCount = Math.Min(count, phrasesCount - leftBorder);
            var result = new List<string>();
            var nextPhraseIndex = 0;
            for (var i = 0; i < actualCount; i++)
            {
                nextPhraseIndex = leftBorder + i;
                if (!phrases[nextPhraseIndex].StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) break;
                result.Add(phrases[nextPhraseIndex]);
            }
            return result.ToArray();
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            var result = right - left - 1;

            return (result <= 0) ? 0 : result;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases_AndCountIsZero()
        {
            var phrases = new List<string>();
            var result = AutocompleteTask.GetTopByPrefix(phrases, "a", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases_AndCountIsGreaterThanZero()
        {
            var phrases = new List<string>();
            var result = AutocompleteTask.GetTopByPrefix(phrases, "a", 5);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesNotContainPrefix_AndCountIsZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "y", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesNotContainPrefix_AndCountIsGreaterThanZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "y", phrases.Count);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesContainPrefix_AndCountIsZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "l", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsNCount_WhenPhrasesContainPrefix_AndCountIsN()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky", "luckyman" };
            var expected = new List<string>() { "luc", "luck" };
            var n = expected.Count;
            var result = AutocompleteTask.GetTopByPrefix(phrases, "lu", n);
            Assert.AreEqual(n, result.Length);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
