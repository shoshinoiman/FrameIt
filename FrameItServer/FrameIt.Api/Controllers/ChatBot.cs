using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace PixMix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ChatBotController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> RecommendBackground([FromBody] ChatPromptRequest request)
        {
            var systemMessage = new ChatMessage
            {
                Role = "system",
                Content = @"
            אתה עוזר למשתמש לבחור רקע מתאים לעיצוב קולאז'. אלו הרקעים הקיימים:
            
            1. ""memo1"" - תבנית טרופית צבעונית עם 8 תמונות, רקע בגוונים של צהוב וירוק עם דקורציה של פלמינגו צבעוניים (ורוד, צהוב, ירוק), פריסה של 6 תמונות קטנות בצד שמאל ו-2 תמונות גדולות בצד ימין, מתאימה לאירועים קיציים ומסיבות.
            
            2. ""memo2"" - תבנית אורבנית מודרנית עם 12 תמונות, רקע בגוונים של ירוק ובנפיט עם דקורציה של צמחי בית וטקסט בעברית, פריסה של 4 תמונות בצד שמאל ו-8 תמונות בצד ימין, מתאימה לזכרונות יומיומיים ורגעי בית.
            
            3. ""memo3"" - תבנית יצירתית דינמית עם 10 תמונות, רקע צהוב עם פרחים צבעוניים מפוזרים, פריסה גיאומטרית מעוינת של 6 תמונות בצד שמאל ו-4 תמונות בצד ימין עם טקסט דקורטיבי, מתאימה לאירועים מיוחדים ויצירתיים.
            
            4. ""color1"" - תבנית אהבה צבעונית עם 9 תמונות, רקע לבן עם קשתות בענן צבעוניות וכיתוב ""LOVE"" עם לב גאווה, פריסה של 4 תמונות בצד שמאל ו-5 תמונות בצד ימין, מתאימה לחגיגות אהבה ואירועי גאווה.
            
            5. ""color4"" - תבנית חד-תמונה מרכזית עם 5 תמונות, רקע לבן עם קשתות בענן וטקסט מעודד באנגלית, פריסה של תמונה גדולה אחת בצד שמאל ו-4 תמונות בצד ימין, מתאימה להדגשת תמונה מרכזית חשובה.
            
            6. ""full1"" - תבנית מינימליסטית צבעונית עם 4 תמונות, רקע עם מסגרות צבעוניות (ורוד, תכלת, צהוב עם פרחים, ורוד), פריסה של תמונה גדולה אחת בצד שמאל ו-3 תמונות בצד ימין, מתאימה לעיצוב נקי ומודרני.
            
            7. ""brown2"" - תבנית רוסטיק עם טקסט עברי עם 10 תמונות, רקע עץ טבעי עם כיתוב ""להוסיף טקסט"" בעברית, פריסה של 4 תמונות בצד שמאל ו-6 תמונות בצד ימין, מתאימה לזכרונות משפחתיים ואירועים מסורתיים.
            
            8. ""brown1"" - תבנית עץ קלאסית עם 8 תמונות, רקע עץ טבעי פשוט וחם, פריסה סימטרית של 4 תמונות בכל צד, מתאימה לאלבום משפחתי קלאסי ואירועים מסורתיים.
            
            9. ""color2"" - תבנית שמחה עם קשת בענן עם 11 תמונות, רקע תכלת עם קשת בענן צבעונית וטקסט מעודד באנגלית, פריסה של 8 תמונות קטנות בצד שמאל ו-3 תמונות גדולות בצד ימין, מתאימה לאירועי ילדים ורגעים שמחים.
            
            10. ""color3"" - תבנית קשת בענן פשוטה עם 10 תמונות, רקע תכלת עם קשת בענן גדולה ועננים לבנים וכיתוב ""LOVE"", פריסה של 8 תמונות קטנות בצד שמאל ו-2 תמונות גדולות בצד ימין, מתאימה לזכרונות משפחתיים ואירועי אהבה.
      
            11. ""empty"" - תבנית ריקה/בסיסית לבנה, ללא עיצוב או דקורציה, מתאימה למי שרוצה רקע נקי לחלוטין ללא הסחות דעת, מתאימה לכל מספר תמונות.
            
            12. ""full3"" - תבנית אמנותית צבעונית עם 3 תמונות, רקע לבן עם רצועות דקורטיביות צבעוניות בצד שמאל (ורוד, תכלת, ירוק, צהוב עם דוגמאות), פריסה של תמונה אחת בצד שמאל ו-2 תמונות בצד ימין עם מסגרות דקורטיביות, מתאימה לפרויקטים יצירתיים ואמנותיים.
            
            13. ""full2"" - תבנית מסגרות מרובות עם 5 תמונות, רקע לבן עם מסגרת מורכבת רב-שכבתית (צהוב מנוקד, כחול, ופסים צבעוניים), פריסה של תמונה גדולה אחת בצד שמאל ו-4 תמונות קטנות בצד ימין עם מסגרות צבעוניות נפרדות, מתאימה לעיצוב מתוחכם ומורכב.
            
            14. ""green1"" - תבנית טבע אלגנטית עם 3 תמונות, רקע ירוק כהה עם איורי פרחי שמשון לבנים עדינים, פריסה של תמונה גדולה אחת בצד שמאל ו-2 תמונות בצד ימין, מתאימה לאירועי טבע, חתונות כפריות ורגעים רומנטיים.
            
            15. ""green2"" - תבנית טבע מינימליסטית עם 3 תמונות, רקע ירוק כהה עם איורי פרחים וגבעול לבנים פשוטים, פריסה של תמונה אחת בצד שמאל ו-2 תמונות בצד ימין, מתאימה לזכרונות טבעיים, טיולים ואירועי חוץ.

            בהתאם לתיאור של המשתמש (מספר תמונות, סגנון, אירוע), המלץ על התבנית המתאימה ביותר מתוך הרשימה. תן הסבר קצר למה התבנית הזו מתאימה לבקשה שלו."
            };

            var messages = new List<ChatMessage> { systemMessage };
            messages.AddRange(request.Messages);

            var body = new
            {
                model = "gpt-4o-mini",
                messages = messages
            };

            var req = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
            {
                Content = JsonContent.Create(body)
            };
            var apiKey = _configuration["OpenAI:ApiKey"];
            req.Headers.Add("Authorization", $"Bearer {apiKey}");
            //req.Headers.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
            var res = await _httpClient.SendAsync(req);
            if (!res.IsSuccessStatusCode)
                return StatusCode((int)res.StatusCode, await res.Content.ReadAsStringAsync());

            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(">> JSON response from OpenAI:");
            Console.WriteLine(json);
            var reply = JsonDocument.Parse(json).RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();
            Console.WriteLine(">> Extracted reply:");
            Console.WriteLine(reply);
            return Ok(new { reply });
        }

        public class ChatPromptRequest
        {
            [JsonPropertyName("messages")]
            public List<ChatMessage> Messages { get; set; }
        }

        public class ChatMessage
        {
            [JsonPropertyName("role")]
            public string Role { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }
        }
    }
}