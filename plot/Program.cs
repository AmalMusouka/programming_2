using ScottPlot;
Dictionary<int, int>count = [];

foreach (string line in File.ReadAllLines("war_and_peace"))
{
    foreach (string word in line.Split())
    {
        if (word.Length >= 1)
        {
            count[word.Length] = count.GetValueOrDefault(word.Length) + 1;
        }
    }
}

Plot plot = new();
plot.Add.Bars(count.Keys.Select(k => (double)k), count.Values);
plot.SaveSvg("words.svg", 800, 800);