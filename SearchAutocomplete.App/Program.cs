using SearchAutocomplete.App;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var fileLines = File.ReadAllLines(filePath);
var nString = fileLines[0];
int n = int.Parse(nString);
var mString  = fileLines[1];
var m = int.Parse(mString);
string[] baseStrings = new string[n];
for (int i = 0; i < n; i++)
{
    baseStrings[i] = fileLines[i + 2];
}
string[] inputStrings = new string[m];
for (int i = 0; i < m; i++)
{
    inputStrings[i] = fileLines[i + n + 2];
}

AutocompleteTrie autocompleteTrie = new(baseStrings);
foreach(var input in inputStrings)
{
    var results = autocompleteTrie.PerformAutocomplete(input);
    Console.WriteLine($"{input}:");
    foreach(var res in results)
    {
        Console.WriteLine($"{res.Value} ({res.Rank})");
    }
    Console.WriteLine();
}