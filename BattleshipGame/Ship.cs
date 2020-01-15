using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Ship
    {
        public int lengthOfShip;
        public string name;
        public string firstLetter;
        public string direction;
        public string startPosition;
        public string endPosition;
        public List<(int, int)> coordinates;

        public string GetCoordinates()
        {
            Console.WriteLine($"Please choose a start position for your {name} (Example: A15)");
            string startPosition = Console.ReadLine().ToLower();

            if (startPosition.Length > 3 || startPosition.Length < 2)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }

            if (startPosition[0] < 97 || startPosition[0] > 116)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }

            string column = startPosition.Remove(0, 1);
            try
            {
                int columnInt = Int32.Parse(column);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }

            return startPosition;
        }

        public string GetDirection()
        {
            Console.WriteLine("Do you want the ship to continue left, right, up or down of that position?");
            string shipDirection = Console.ReadLine().ToLower();

            return shipDirection;

            //bool validInput = false;
            //while (validInput = false)
            //{
            //    switch (shipDirection)
            //    {
            //        case "up":
            //            validInput = true;
            //            return shipDirection;
            //        case "down":
            //            validInput = true;
            //            return shipDirection;
            //        case "left":
            //            validInput = true;
            //            return shipDirection;
            //        case "right":
            //            validInput = true;
            //            return shipDirection;
            //        default:
            //            Console.WriteLine("Invalid input. Please choose an appropriate direction..");
            //            shipDirection = Console.ReadLine().ToLower();
            //            break;
            //    }
            //}
            //return "error";
        }
    }
}

