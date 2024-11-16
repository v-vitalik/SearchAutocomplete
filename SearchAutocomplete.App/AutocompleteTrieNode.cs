namespace SearchAutocomplete.App
{
    public class AutocompleteTrieNode
    {
        public Dictionary<char, AutocompleteTrieNode> Children { get; set; }
        public int Rank { get; set; }
        public bool IsWord { get; set; }
        public AutocompleteTrieNode(int rank = 0, bool isWord = false)
        {
            Children = [];
            Rank = rank;
            IsWord = isWord;
        }
    }
}
