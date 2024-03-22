using SciFiSim.Logic.OpenAI;
using SciFiSim.Logic.OpenAI.Prompts;
using SciFiSim.Logic.OpenAI.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Test
{
    public class OpenAITest
    {
        public static async Task<Reply> Main(string[] args)
        {
            Reply returnText = await OpenAIClient.GetPuzzleReply(new PuzzleGen());
            return returnText;
        }
    }
}
