using System.Text;

namespace SearchAutocomplete.App
{
    public class AutocompleteTrie
    {
        private readonly AutocompleteTrieNode _root;
        public AutocompleteTrie(string[] initialStrings)
        {
            _root = new();
            for (int i = 0; i < initialStrings.Length; i++)
            {
                AddStringToATrie(initialStrings[i], i + 1);
            }
        }

        public List<AutocompleteResultItem> PerformAutocomplete(string input)
        {
            var node = _root;
            foreach (char c in input)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return [];
                }
                node = node.Children[c];
            }

            List<AutocompleteResultItem> allResults = [];
            StringBuilder inputSb = new(input);
            FindAllStringsFromNode(node, inputSb, allResults);
            return allResults.OrderBy(x => x.Rank).Take(5).ToList();
        }

        private void FindAllStringsFromNode(AutocompleteTrieNode node, StringBuilder current, List<AutocompleteResultItem> list)
        {
            if (node.IsWord)
            {
                list.Add(new(current.ToString(), node.Rank));
            }

            foreach (var child in node.Children)
            {
                current.Append(child.Key);
                FindAllStringsFromNode(child.Value, current, list);
                current.Length--;
            }
        }

        private void AddStringToATrie(string s, int rank)
        {
            var node = _root;
            foreach (char c in s)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new();
                }
                node = node.Children[c];
            }
            node.Rank = rank;
            node.IsWord = true;
        }
    }
}
