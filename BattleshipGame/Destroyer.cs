﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            lengthOfShip = 2;
            name = "Destroyer";
            firstLetter = "D";
        }
    }
}
