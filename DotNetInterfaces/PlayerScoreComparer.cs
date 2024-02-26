using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterfaces
{
    public class PlayerScoreComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Null Reference Exception");
            }

            return x.Score.CompareTo(y.Score);
        }
    }
}
