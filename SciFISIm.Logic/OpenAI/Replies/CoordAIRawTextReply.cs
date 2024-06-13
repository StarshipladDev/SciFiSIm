using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.OpenAI.Replies
{
    public class CoordAIRawTextReply: Reply
    {
        public CoordAIRawTextReply(string rawText)
        {

            string updatedText = rawText.Replace("\\n", "\n").Replace("/n", "\n").Replace("\n", "");
            this.replyText = updatedText;
        }
    }
}
