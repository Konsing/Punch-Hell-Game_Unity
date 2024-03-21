using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PunchHell
{
    public static class StageDefinitions
    {
        private static Dictionary<int, List<StageAction>> levels;
        public static List<StageAction> GetLevelDefinition(int level)
        {
            return levels[level];
        }
    }
}
