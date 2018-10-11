using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hn
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var results = await httpClient.GetStringAsync("https://api.hnpwa.com/v0/news/1.json");
            var stories = JsonConvert.DeserializeObject<List<HNApiStory>>(results);
            var count = 0;
            var maxTitle = stories.Max(x => x.title.Length);
            foreach (var story in stories) {
                Console.WriteLine($"{count,-2} {story.title.PadRight(maxTitle)} {story.url}");
                count++;
            }
        }
    }

    class HNApiStory {
        public long id { get; set;}
        public string title { get; set;}
        public string url { get; set;}
    }
}
