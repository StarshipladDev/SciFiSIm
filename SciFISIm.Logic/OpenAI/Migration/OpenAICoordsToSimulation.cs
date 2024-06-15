using Newtonsoft.Json;
using SciFiSim.Logic.Models.Entities.Town;
using SciFiSim.Logic.Models.System.Logic;
using SciFiSim.Logic.OpenAI.Prompts;
using SciFiSim.Logic.OpenAI.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.OpenAI.Migration
{
    public static class OpenAICoordsToSimulation
    {
        public static async Task RenderCoordsReplyToSimulation(Simulation simulation, List<TownCell> terroristTargetCells)
        {
            CoordinatePrompt targetPrompt = new CoordinatePrompt(simulation.simulation.town.townCells.GetLength(0), simulation.simulation.persons, terroristTargetCells);
            Reply reply = await OpenAIClient.GetCoordReply(targetPrompt);
            CoordinateReply coordReply = JsonConvert.DeserializeObject<CoordinateReply>(reply.replyText);

            int personCounter = 0;
            foreach (Movement move in coordReply.movements)
            {
                if (personCounter < simulation.simulation.persons.Count)
                {

                    Stack<TownCell> cells = new Stack<TownCell>();
                    for (int i = move.agentMovements.GetLength(0) - 1; i > -1; i--)
                    {
                        cells.Push(simulation.simulation.town.townCells[move.agentMovements[i, 0], move.agentMovements[i, 1]]);
                    }
                    simulation.simulation.persons[personCounter].movements.listOfFutureMovements = cells;
                    personCounter++;
                }

            }
        }
    }
}
