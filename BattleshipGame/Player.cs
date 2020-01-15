using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    abstract class Player
    {
        public string name;
        public Board userBoard;
        public Board targetBoard;

        public void CreateBoards()
        {
            userBoard = new Board();
            targetBoard = new Board();
        }
    }
}
