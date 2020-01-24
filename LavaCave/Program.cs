using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaCave
{
    class Program
    {
        //key check
        public static Boolean hasKey = false;
        //game end check
        public static Boolean end = false;

        //this works
        public static void DisplayBoard(string[,] board, Point player) {
            //border
            Console.WriteLine("========");
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    //display all x for a y
                    Console.Write(board[x, y]);
                }
                //new line after printing the x values for every y
                Console.WriteLine();
            }
            //border again
            Console.WriteLine("========");
            Console.WriteLine("You are at: [" + player.x + "," + player.y + "]");
        }

        //turn character based on passed input
        //tested to work
        public static void Turn(Point dir, string turn)
        {
            //reminder that these are collapsed so i don't forget there's code here
            if (turn == "L")
            {
                //west to south
                if (dir.x == -1)
                {
                    dir.x = 0;
                    dir.y = 1;
                }
                //east to north
                else if (dir.x == 1)
                {
                    dir.x = 0;
                    dir.y = -1;
                }
                //south to east
                else if (dir.y == 1)
                {
                    dir.x = 1;
                    dir.y = 0;
                }
                //north to west
                else if (dir.y == -1)
                {
                    dir.x = -1;
                    dir.y = 0;
                }
            }

            if (turn == "R")
            {
                //west to north
                if (dir.x == -1)
                {
                    dir.x = 0;
                    dir.y = -1;
                }
                //east to south
                else if (dir.x == 1)
                {
                    dir.x = 0;
                    dir.y = 1;
                }
                //south to west
                else if (dir.y == 1)
                {
                    dir.x = -1;
                    dir.y = 0;
                }
                //north to east
                else if (dir.y == -1)
                {
                    dir.x = 1;
                    dir.y = 0;
                }
            }
        }

        //check direction player is facing and write compass direction
        //these work, collapsed
        public static void CheckDir(Point player, Point dir)
        {
            if (dir.x == -1)
            {
                Console.WriteLine("You are facing WEST.");
            }
            else if (dir.x == 1)
            {
                Console.WriteLine("You are facing EAST.");
            }

            else if (dir.y == -1)
            {
                Console.WriteLine("You are facing NORTH.");
            }
            else if (dir.y == 1)
            {
                Console.WriteLine("You are facing SOUTH.");
            }
            else
            {
                Console.WriteLine("You have escaped the bounds of acceptable rotation. " +
                    "Please stick to the cardinal directions at magnitude 1, if you don't mind.");
            }
        }

        //eval. the space the player is facing and space player is in
        //all "sense" message combos have been tested and work. collapsed
        public static void Sense(Point player, Point dir, string[,] board)
        {
            Point front = player.Add(dir);

            //Console.WriteLine("You sense nothing unusual.");
            //OOB handler - moved to individual checks to avoid override of message

            //prefix of line
            Console.Write("You sense ");

            //first check room in, sub-if for facing lava
            //lava death happens in move method
            //treasure, then append heat
            if (board[player.x, player.y] == "T")
            {
                if (front.x < 0 || front.x > 3 || front.y < 0 || front.y > 3)
                {
                    Console.WriteLine("a shiny glow.");
                    return;
                }

                Console.Write("a shiny glow");
                if (board[front.x, front.y] == "L")
                {
                    Console.Write(" and a blast of heat");
                }
            }
            //key, then append heat
            else if (board[player.x, player.y] == "K")
            {
                if (front.x < 0 || front.x > 3 || front.y < 0 || front.y > 3)
                {
                    Console.WriteLine("a rusty smell.");
                    return;
                }

                Console.Write("a rusty smell");
                if (board[front.x, front.y] == "L")
                {
                    Console.Write(" and a blast of heat");
                }
            }
            //heat, or else nothing
            else if (board[player.x, player.y] == "." || board[player.x, player.y] == "E")
            {
                if (front.x < 0 || front.x > 3 || front.y < 0 || front.y > 3)
                {
                    Console.WriteLine("nothing unusual.");
                    return;
                }

                if (board[front.x, front.y] == "L")
                {
                    Console.Write("a blast of heat");
                }
                else
                {
                    Console.Write("nothing unusual");
                }
            }
            else
            {
                Console.WriteLine("you are either standing on lava or somewhere else. Please cease this behaviour");
                return;
            }

            //end line with period
            Console.WriteLine(".");
        }

        //movement, death by lava, hitting wall. works.
        public static void Advance(Point player, Point dir, string[,] board)
        {
            Point front = player.Add(dir);
            if (front.x < 0 || front.x > 3 || front.y < 0 || front.y > 3)
            {
                Console.WriteLine();
                Console.Write("You bump into a wall.");
            }
            else if(board[front.x, front.y] == "L")
            {
                Console.WriteLine();
                Console.WriteLine("You fall into lava and burn to a crisp!");
                Console.WriteLine("Game Over.");
                end = true;
            }
            else
            {
                player.x = front.x;
                player.y = front.y;
            }
        }

        //assemble other methods for easy updating every 'turn'. probably not strictly necessary.
        public static void Update(Point player, Point dir, string[,] board)
        {
            CheckDir(player, dir);
            //Console.WriteLine("Dir: " + dir.x + "," + dir.y);
            Sense(player, dir, board);
        }

        //processes commands for Forward, Left, Right, Search, Treasure, Quit, Cheat(X)
        //works, collapsed
        public static void Command(string cmd, Point player, Point dir, string[,] board)
        {
            if (cmd == "F")
            {
                Advance(player, dir, board);
            }
            else if (cmd == "L")
            {
                Turn(dir, "L");
            }
            else if (cmd == "R")
            {
                Turn(dir, "R");
            }
            else if (cmd == "S")
            {
                if(board[player.x, player.y] == "K")
                {
                    Console.WriteLine();
                    Console.Write("You find a key!");
                    //set key space to nothing
                    board[player.x, player.y] = ".";
                    hasKey = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("You can not find anything to pick up.");
                }
            }
            else if (cmd == "T")
            {
                if (board[player.x, player.y] == "T")
                {
                    if (hasKey)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You open the chest and find inner peace!");
                        Console.WriteLine("You Win.");
                        end = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("The treasure chest is locked.");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("You can not find any treasure here.");
                }
            }
            else if (cmd == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Cheat!");
                DisplayBoard(board, player);
            }
            else if (cmd == "Q")
            {
                end = true;
            }
        }

        //swaps existing (hardcoded) tiles and resets player to entrance. collapsed
        //there *seems* to be a bias in result based on the original spaces, but it does properly randomize them.
        public static void SwapTiles(string[,] board, Point player)
        {
            //loop through spaces and swap them once with something else
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Random random = new Random();
                    int swapX = random.Next(0, 4);
                    int swapY = random.Next(0, 4);

                    string temp = board[x, y];
                    board[x, y] = board[swapX, swapY];
                    board[swapX, swapY] = temp;
                }
            }
            //set player position to entrance
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (board[x, y] == "E")
                    {
                        player.x = x;
                        player.y = y;
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            //player location
            Point player = new Point(1, 2);

            //direction the player is 'facing' starts at EAST
            Point dir = new Point(1, 0);

            //init board
            string[,] board = new string[4, 4];
            //fill board
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    board[x, y] = ".";
                }
            }

            //hardcoded spaces
            board[1, 2] = "E";
            board[2, 0] = "L";
            board[2, 2] = "L";
            board[0, 3] = "L";
            board[3, 0] = "T";
            board[3, 3] = "K";


            //game start
            SwapTiles(board, player);

            Console.WriteLine("Welcome to Lava Cave!");
            Console.WriteLine("Loot the treasure without falling into lava.");
            Console.WriteLine("Try the following commands:");
            Console.WriteLine("Move (F)orward, Turn (L)eft, Turn (R)ight,");
            Console.WriteLine("(S)earch for items, Loot the (T)reasure,");
            Console.WriteLine("(Q)uit the game, Use(X) to cheat.");

            //'turns' happen while not dead or not having the treasure
            while (!end)
            {
                Console.WriteLine();

                Update(player, dir, board);

                Console.Write("Enter Command: ");

                string cmd = Console.ReadLine().ToUpper();
                Command(cmd, player, dir, board);
            }

            Console.Write("Press any key to close.");

            //keep console open until keypress so that player can read the result
            Console.ReadLine();
        }
    }
}
