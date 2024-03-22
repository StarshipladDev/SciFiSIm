using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.HTMLTemplates
{
    public class Grid
    {
        public static string GetGrid(string clueArray)
        {
            var mappings = new Dictionary<string, string>
            {
                 { "[", "Α" },
                { "]", "Β" },
                { "GAMMA", "Γ" },
                { "DELTA", "Δ" },
                { "EPSILON", "Ε" },
                { "ZETA", "Ζ" },
                { "ETA", "Η" },
                { "THETA", "Θ" },
                { "IOTA", "Ι" },
                { "KAPPA", "Κ" },
                { "LAMBDA", "Λ" },
                { "MU", "Μ" },
                { "NU", "Ν" },
                { "XI", "Ξ" },
                { "OMICRON", "Ο" },
                { "PI", "Π" },
                { "RHO", "Ρ" },
                { "SIGMA", "Σ" },
                { "TAU", "Τ" },
                { "UPSILON", "Υ" },
                { "PHI", "Φ" },
                { "CHI", "Χ" },
                { "PSI", "Ψ" },
                { "OMEGA", "Ω" }
            // Add more mappings as needed
            };
            string returnText = "<div style = \"width: 100%; height: 100% \">";
            string[] clueArrayItems = clueArray.Replace("\r",String.Empty).Split("/n");
            List<string> colors = new List<string> { "red", "blue", "green" };
            Random rand = new Random();
            foreach (var item in clueArrayItems)
            {
                string updatedItem = ReplaceGreekLetters(item, mappings, colors, rand);
                returnText += $"<div> {updatedItem}</div>";
            }
            returnText += "</div>";
            return returnText;
        }
        static string ReplaceGreekLetters(string input, Dictionary<string, string> mappings, List<string> colors, Random rand)
        {
            string textToReturn = input;
            string colorToUser = colors[rand.Next(colors.Count())];
            textToReturn = textToReturn.Replace("[", $"<span style = \"color: {colorToUser}\"> ");
            textToReturn = textToReturn.Replace("]", "</span>");
            return textToReturn;
        }


        // Replace English representation of Greek letters with Unicode characters
    }

}
