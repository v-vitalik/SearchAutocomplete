namespace SearchAutocomplete.App.Tests
{
    public class AutocompleteTrieTests
    {
        [Test]
        public void PerformAutocomplete_ShouldReturnZeroResults_WhenNoMatchingInput()
        {
            // Arrange
            AutocompleteTrie trie = new AutocompleteTrie([]);


            // Act
            List<AutocompleteResultItem> results = trie.PerformAutocomplete("abcdef");


            //Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void PerformAutocomplete_ShouldreturnCorrectResult_WhenValidInput()
        {
            // Arrange
            string[] baseInputs = ["art", "arts", "articles", "article", "articulate", "articulation"];
            AutocompleteTrie trie = new AutocompleteTrie(baseInputs);


            // Act
            List<AutocompleteResultItem> results = trie.PerformAutocomplete("art");

            //Assert
            Assert.That(results.Count, Is.EqualTo(5));
            for (int i = 0; i < 5; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(results[i].Value, Is.EqualTo(baseInputs[i]));
                    Assert.That(results[i].Rank, Is.EqualTo(i + 1));
                });
            }
        }
    }
}
