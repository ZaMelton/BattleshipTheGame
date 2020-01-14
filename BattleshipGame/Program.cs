using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gameBoard = new Board();

            gameBoard.ChooseBoardPositions(gameBoard.board);
        }
    }
}
