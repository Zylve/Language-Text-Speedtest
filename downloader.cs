using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

public static class DownloadClass {
    private static readonly HttpClient _client = new HttpClient();
    private static string _plaintext;
    public static async Task Main(string[] args) {
        for(int i = 0; i < Convert.ToInt32(args[0]); i++) {
            HttpResponseMessage response = await _client.GetAsync("https://en.wikipedia.org/api/rest_v1/page/random/html");
            response.EnsureSuccessStatusCode();

            string html = await response.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            try {
                doc.DocumentNode.SelectNodes("//style|//script").ToList().ForEach(n => n.Remove());
                foreach(HtmlNode node in doc.DocumentNode.SelectNodes("//text()")) {
                    _plaintext += node.InnerText + " ";
                }
            } catch(Exception e) { }

            Regex reg = new Regex("[^a-zA-Z ]");
            _plaintext = reg.Replace(_plaintext, " ");

            string[] words = _plaintext.Split(' ');

            using(FileStream fs = File.Open("words.txt", FileMode.Append)) {
                foreach(string word in words) {
                    if(word != "" || word != " ") {
                        byte[] info = new UTF8Encoding(true).GetBytes($"{word}\n");
                        fs.WriteAsync(info, 0, info.Length);
                    }
                }
            }

            _plaintext = "";

            Console.WriteLine($"Parsed article {i + 1} of {args[0]}");
        }
    }
}