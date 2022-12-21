namespace TestProject1
{
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases_AndCountIsZero()
        {
            var phrases = new List<string>();
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "a", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases_AndCountIsGreaterThanZero()
        {
            var phrases = new List<string>();
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "a", 5);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesNotContainPrefix_AndCountIsZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "y", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesNotContainPrefix_AndCountIsGreaterThanZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "y", phrases.Count);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_WhenPhrasesContainPrefix_AndCountIsZero()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky" };
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "l", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsNCount_WhenPhrasesContainPrefix_AndCountIsN()
        {
            var phrases = new List<string>() { "luc", "luck", "lucky", "luckyman" };
            var expected = new List<string>() { "luc", "luck" };
            var n = expected.Count;
            var result = Autocomplete.AutocompleteTask.GetTopByPrefix(phrases, "lu", n);
            Assert.AreEqual(n, result.Length);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
