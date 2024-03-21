using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.OpenAI.Prompts
{
    public class PuzzleGen : Prompt
    {
        public PuzzleGen()
        {
            this.model = "gpt-3.5-turbo";
            
            this.messages = new List<Message>();
            this.messages.Add(new Message("system","You are a tool that generates puzzels." +
                "The format of the puzle is 30 news headlines about mundane events in a small british town," +
                "each headline will be followed by a greek alphabet letter written in captial letters, whereas" +
                "the headline is written in lower case. Each greek latter should be repeated at least once except" +
                $"4 of them. Each headline should also have one word that is the [KEYWORD] that is, unlike the rest " +
                $"of the scentence, written in full caps. The answer will be the 4 headline's [KEYWORD]s preceding " +
                $"the 4 non-repeated greek alphabet lettersd. The greek alphabet letters should be written in english " +
                $"such as 'PI' or 'TAU'. The only things to be written in all caps should be the greek alphabet words " +
                $"and the [KEYWORD] in each headline . An example with 4 headlines and 2 keywords as the answer would be " +
                $"'boy eats CAKE' ALPHA , 'woman steals TOFFEE' BETA, 'Dog chases CAT' BETA , 'DOG buys dish' DELTA ,with" +
                $" the answer being CAKE,DOG as those keywords preceded the non-repeated greek alphabet cahracters ALPHA and" +
                $" DELTA, whereas ALPHA appeared twice. The prompt you return should have 4 KEYWORDs in total and 30 headlines. " +
                $"The answer should be returned at the end of each reply"));
            this.messages.Add(new Message("user", "Generate me a puzzle"));
        }
    }
}
