using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.OpenAI.Replies
{
    public class PuzzleReply : Reply
    {
        private const int _headlineSize = 30;
        public PuzzleReply(string replyText, List<string> listOfNames)
        {
            string returnText = "";
            if (replyText.Split('|').Length > 0)
            {
                string[] headLines = replyText.Replace("\\n", "\n").Replace("/n", "\n").Split('|')[1].Split("\n");
                string[] names = replyText.Split('|')[0].Split(",");

                Random rand = new Random();
                while (listOfNames.Count() > 0)
                {
                    int headlineindex = rand.Next(headLines.Length);
                    if (headLines[headlineindex].Contains("[Name]"))
                    {
                        headLines[headlineindex] = (headLines[headlineindex].Replace("[Name]", $"[{listOfNames[0]}]"));
                        listOfNames.Remove(listOfNames[0]);
                    }

                }
                int countOfItems = 0;
                foreach (var item in headLines)
                {
                    headLines[countOfItems] = (item.Replace("[Name]", $"[{names[rand.Next(names.Length)]}]") + "/n");
                    returnText += headLines[countOfItems];
                    countOfItems++;
                }
            }
            else
            {
                returnText = replyText;
            }
            this.replyText = returnText;
        }
    }
}
