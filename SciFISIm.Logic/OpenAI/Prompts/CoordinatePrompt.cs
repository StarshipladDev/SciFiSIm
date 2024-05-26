using SciFiSim.Logic.Models.Entities.People;
using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SciFiSim.Logic.OpenAI.Prompts
{
    public class CoordinatePrompt : Prompt
    {
        public CoordinatePrompt(int gridSize, List<PersonEntity> people, List<TownCell> targetCells)
        {
            this.model = "gpt-3.5-turbo";
            string promptString = "";


            int personIndex = 0;
            foreach (var person in people)
            {
                promptString += $"{personIndex} {person.personStyle.firstName} {person.personStyle.lastName};";
                personIndex++;
            }
            promptString += ";";
            promptString += $"{gridSize},{gridSize};;;";

            personIndex = 0;
            foreach (var person in people)
            {
                promptString += $"{person.movements.currentCell.x},{person.movements.currentCell.y}S{personIndex}";
                personIndex++;
            }

            this.messages = new List<Message>();
            this.messages.Add(new Message(
                "system",
                 @"You are an assistant bot that generates movements for a set of agents on a grid.The input is a list of people with their IDs and names, a grid size, and a list of starting and target locations.The output is a JSON array where each agent has an 'Id', an array of 'agentMovements'(each movement being an[x, y] coordinate), and a boolean 'target_hunter' indicating if the agent is the target hunter.One agent must move through each target location in order while having movements similar to other agents.The target hunter should be chosen randomly. The Grid is 0-indexed in size, so a size 10 grid goes from 0 - 9

                Example Input:
                1 Jimmy Jameson; 2 Bobby Bobson; 3 Jacob Jacobson; 4 Ronny Ronson; ; 10,10; ; ; 2,2,S1; 3,3,S2; 4,4,S3; 5,5,S4; 6,6T1; 7,7T2; 8,8T3

                Example Output:
                            [    {
                                ""Id"": 1,        ""agentMovements"": [[2, 2], [3, 2], [4, 2], [5, 2], [6, 2], [7, 2], [8, 2], [9, 2], [9, 3], [9, 4], [9, 5], [9, 6], [9, 7], [9, 8], [9, 9]],
                        ""target_hunter"": false
                    },
                    {
                                ""Id"": 2,
                        ""agentMovements"": [[3, 3], [3, 4], [3, 5], [3, 6], [3, 7], [3, 8], [3, 9], [4, 9], [5, 9], [6, 9], [7, 9], [8, 9], [9, 9], [8, 8], [7, 7]],
                        ""target_hunter"": false
                    },
                    {
                                ""Id"": 3,
                        ""agentMovements"": [[4, 4], [5, 4], [6, 4], [7, 4], [8, 4], [9, 4], [9, 5], [9, 6], [9, 7], [9, 8], [9, 9], [8, 8], [7, 7], [6, 6], [5, 5]],
                        ""target_hunter"": false
                    },
                    {
                                ""Id"": 4,
                        ""agentMovements"": [[5, 5], [6, 6], [7, 7], [8, 8], [7, 7], [6, 6], [5, 5], [4, 4], [3, 3], [2, 2], [1, 1], [2, 2], [3, 3], [4, 4], [5, 5]],
                        ""target_hunter"": true
                    }
                ]
                    }
                Additionally, some of the locations in the last section may have an 'H' value, which represents houses that all agents should occasionally go by."
                )
              );

            this.messages.Add(new Message("user", promptString));
        }

    }
}
