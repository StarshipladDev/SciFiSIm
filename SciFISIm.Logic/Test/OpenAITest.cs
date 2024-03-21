using SciFiSim.Logic.OpenAI;
using SciFiSim.Logic.OpenAI.Prompts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Test
{
    public class OpenAITest
    {
        public static async void Main(string[] args)
        {
            await OpenAIClient.GetPuzzleReply(new PuzzleGen());
        }
    }
}
