using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.OpenAI.Replies
{
    /* Sample Reply 
    { 
                    ""movements"" : [    
                    {
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
    */
    public class CoordinateReply
    {
        [JsonProperty("movements")]
        public Movement[] movements;
    }
    public class Movement
    {

        [JsonProperty("Id")]
        public int Id;

        [JsonProperty("agentMovements")]
        public int[,] agentMovements;

        [JsonProperty("target_hunter")]
        bool target_hunter;
    }
}
