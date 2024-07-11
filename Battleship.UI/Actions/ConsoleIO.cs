using Battleship.UI.Ships;

namespace Battleship.UI.Actions
{
    public static class ConsoleIO
    {
        public static Coordinate GetPlayerCoordinate(string prompt)
        {
            char[] characters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
            int outputInt;
            char outputChar;

            do  
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                string inputCharacter = input.Substring(0, 1).ToUpper();
                string inputInteger = input.Substring(1);
         
                if (char.TryParse(inputCharacter, out outputChar) && int.TryParse(inputInteger, out outputInt))
                {
                    if (characters.Contains(outputChar) && outputInt >= 1 && outputInt <= 10)
                    {
                        return new Coordinate(CharToCoordinate(outputChar), outputInt - 1);
                    }
                }
                Console.WriteLine("That is not a valid input!");
            } while (true);
        }

        public static ShipDirection GetPlayerShipDirection()
        {
            do
            {
                Console.Write("Place ship (V)ertical or (H)orizontal: ");
                string input = Console.ReadLine().ToUpper();

                if (input == "V")
                {
                    return ShipDirection.Vertical;
                }
                else if (input == "H")
                {
                    return ShipDirection.Horizontal;
                }
                Console.WriteLine("That is not a valid input!");
            } while (true);
        }

        public static int CharToCoordinate(char c)
        {
            switch (c)
            {
                case 'A':
                    return 0;
                case 'B':
                    return 1;
                case 'C':
                    return 2;
                case 'D':
                    return 3;
                case 'E':
                    return 4;
                case 'F':
                    return 5;
                case 'G':
                    return 6;
                case 'H':
                    return 7;
                case 'I':
                    return 8;
                case 'J':
                    return 9;
                default:
                    return -1;
            }
        }

        public static string CoordinateToCharacter(int coordinate)
        {
            switch (coordinate)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
                default:
                    return null;
            }
        }

        public static string ShipTypeLetter(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.AircraftCarrier:
                    return "A";
                case ShipType.Battleship:
                    return "B";
                case ShipType.Cruiser:
                    return "C";
                case ShipType.Submarine:
                    return "S";
                case ShipType.Destroyer:
                    return "D";
                default:
                    return null;
            }
        }

        public static string ShipTypeName(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.AircraftCarrier:
                    return "Aircraft Carrier";
                case ShipType.Battleship:
                    return "Battleship";
                case ShipType.Cruiser:
                    return "Cruiser";
                case ShipType.Submarine:
                    return "Submarine";
                case ShipType.Destroyer:
                    return "Destroyer";
                default:
                    return null;
            }
        }

        public static int ShipTypeSize(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.AircraftCarrier:
                    return 5;
                case ShipType.Battleship:
                    return 4;
                case ShipType.Cruiser:
                    return 3;
                case ShipType.Submarine:
                    return 3;
                case ShipType.Destroyer:
                    return 2;
                default:
                    return 0;
            }
        }

        public static void PrintGameBoard(string[] a)
        {
            Console.WriteLine($"   A  B  C  D  E  F  G  H  I  J");
            Console.WriteLine($" 1 {a[0]}  {a[1]}  {a[2]}  {a[3]}  {a[4]}  {a[5]}  {a[6]}  {a[7]}  {a[8]}  {a[9]}");
            Console.WriteLine($" 2 {a[10]}  {a[11]}  {a[12]}  {a[13]}  {a[14]}  {a[15]}  {a[16]}  {a[17]}  {a[18]}  {a[19]}");
            Console.WriteLine($" 3 {a[20]}  {a[21]}  {a[22]}  {a[23]}  {a[24]}  {a[25]}  {a[26]}  {a[27]}  {a[28]}  {a[29]}");
            Console.WriteLine($" 4 {a[30]}  {a[31]}  {a[32]}  {a[33]}  {a[34]}  {a[35]}  {a[36]}  {a[37]}  {a[38]}  {a[39]}");
            Console.WriteLine($" 5 {a[40]}  {a[41]}  {a[42]}  {a[43]}  {a[44]}  {a[45]}  {a[46]}  {a[47]}  {a[48]}  {a[49]}");
            Console.WriteLine($" 6 {a[50]}  {a[51]}  {a[52]}  {a[53]}  {a[54]}  {a[55]}  {a[56]}  {a[57]}  {a[58]}  {a[59]}");
            Console.WriteLine($" 7 {a[60]}  {a[61]}  {a[62]}  {a[63]}  {a[64]}  {a[65]}  {a[66]}  {a[67]}  {a[68]}  {a[69]}");
            Console.WriteLine($" 8 {a[70]}  {a[71]}  {a[72]}  {a[73]}  {a[74]}  {a[75]}  {a[76]}  {a[77]}  {a[78]}  {a[79]}");
            Console.WriteLine($" 9 {a[80]}  {a[81]}  {a[82]}  {a[83]}  {a[84]}  {a[85]}  {a[86]}  {a[87]}  {a[88]}  {a[89]}");
            Console.WriteLine($"10 {a[90]}  {a[91]}  {a[92]}  {a[93]}  {a[94]}  {a[95]}  {a[96]}  {a[97]}  {a[98]}  {a[99]}");
        }

        public static string GetPlayerName()
        {
            do
            {
                Console.Write("Enter player name: ");
                string input = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("You must enter a player name!");
            } while (true);
        }
    }
}
