using Newtonsoft.Json;
using SciFiSim.Logic.OpenAI.Prompts;
using SciFiSim.Logic.OpenAI.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SciFiSim.Logic.OpenAI
{
    public class OpenAIClient
    {
        public static async Task<Reply> GetPuzzleReply(Prompt prompt)
        {
            HttpClient client = new HttpClient();
            Config config = new Config();
            XmlDocument doc = new XmlDocument();
            doc.Load("Credentials.config"); // Replace with the path to your XML file

            // Get the value of the 'openaikey' element
            XmlNode openaikeyNode = doc.SelectSingleNode("//openaikey");
            if (openaikeyNode != null)
            {
                string openaikeyValue = openaikeyNode.InnerText;
                config.openaikey = openaikeyValue;
            }
            else
            {
                Console.WriteLine("'openaikey' element not found in XML file.");
            }
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.openaikey);
            var promptRequest = System.Text.Json.JsonSerializer.Serialize(prompt);
            var requestContent = new StringContent(promptRequest, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("https://api.openai.com/v1/chat/completions");
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, requestContent);
            string resposneText = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(resposneText);
            string replyContent = result.choices[0].message.content;
            PuzzleReply reply = new PuzzleReply(replyContent);
            return reply;

        }
    }
}
