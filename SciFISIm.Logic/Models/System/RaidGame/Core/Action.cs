using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public enum FactionType
    {
        Redfor,
        Blufor
    }
    public abstract class Action
    {
        public string? actionTitle = null;
        public Actor? owningActor = null;
        public FactionType factionType;

        public abstract void PreformAction(RaidGameInstance instance, Actor? targetedActor);
    }
}
