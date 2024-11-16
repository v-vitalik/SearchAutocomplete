namespace SearchAutocomplete.App
{
    public class AutocompleteResultItem
    {
        public string Value { get; set; }
        public int Rank { get; set; }

        public AutocompleteResultItem(string value, int rank)
        {
            Value = value;
            Rank = rank;
        }
    }
}
