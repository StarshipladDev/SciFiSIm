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
            this.messages.Add(new Message("system", "You are a tool that generates generic sounding british town headlines" +
                @"
                You will be given a list of comma seperated names.
                The form of the puzzle you will return is 10 first and last names, sperated only by commas and with a '|' character at the end of the list of all of the names,
                followed by 30 newspaper headlines.
                Each headline must be seperated by a '/n' character.
                These headliens will be random british-based headlines set in an unammed fake village.
                Every headline must include the text '[Name]' and be about a mundane action they preformed.
                These must be randomly ordered in the other headlines that instead use names you generate.
                As an example, you might return 
                'Jim Garnet, Ozzy Cambridge, Julie Clemment | [Name] eats muffins/n local prior [Name] takes mass /n elderly woman [Name] does a run /n 
                local man [Name] builds wall with neighbour /n [Name] begins swimming lessons'.
                Therefore, your reply must be 10 names, the '|' character, 30 random british town headlines, each containign at most one [Name].
                It is of upmost importance the reply has only a single '|' character and each headline is seperated by '/n'.
                No acctual names should ever be used, only the '[Name]' value, including the brackets around it 
                "
            )
            {

            });

            this.messages.Add(new Message("user", "Make me a puzzle"));
        }
    }
}
