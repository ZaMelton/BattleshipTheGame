using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Cruiser : Ship
    {
        public Cruiser()
        {
            lengthOfShip = 3;
            name = "Cruiser";
            firstLetter = "C";
        }
    }
}
