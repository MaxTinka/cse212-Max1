using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();
        
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;
            
            var reversed = new string(new char[] { word[1], word[0] });
            
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            
            seen.Add(word);
        }
        
        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();
                
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        
        if (word1.Length != word2.Length) return false;
        
        var charCount = new Dictionary<char, int>();
        
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
        
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c)) return false;
            
            charCount[c]--;
            if (charCount[c] == 0)
                charCount.Remove(c);
        }
        
        return charCount.Count == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();
        
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null && 
                    !string.IsNullOrEmpty(feature.Properties.Place))
                {
                    results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
                }
            }
        }
        
        return results.ToArray();
    }
}
