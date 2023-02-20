class TreasureHunter
{
    public static void Main()
    {
        Console.Title = "Treasure Hunter";
        Console.CursorVisible = false;
        Console.WriteLine("Welcome to the TREASURE HUNTER game...");
        Console.Write("Please select character symbol... ");
        char po = Convert.ToChar(Console.Read());

        char[,] map =
        {
            {'#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ','#',' ',' ',' ',' ','#',' ','#','#'},
            {'#',' ',' ','#',' ',' ',' ',' ','#',' ',' ','#'},
            {'#',' ',' ','#',' ',' ',' ',' ','#',' ',' ','#'},
            {'#','#',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
            {'#',' ',' ','#',' ',' ',' ',' ','#',' ','#','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#'}
        };

        char[] bag = new char[1];

        int userX = 1;
        int userY = 1;
        int treasureCount = 1;
        int demandPosX = GetPosition();
        int demandPosY = GetPosition();

        bool needGenerate = true;

        Console.Clear();
        while (true)
        {
            Console.SetCursorPosition(0, 13);
            Console.Write("Bag: ");
            foreach (var i in bag)
            {
                Console.Write(i + " ");
            }

            Console.SetCursorPosition(0,0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }

            if (needGenerate == true)
            {
                needGenerate = false;
                for (int k = 0; k < 5; k++)
                {
                    if (map[demandPosX, demandPosY] == '#' | map[demandPosX, demandPosY] == 'X')
                    {
                        demandPosX = GetPosition();
                        demandPosY = GetPosition();
                    }
                    else
                    {
                        Console.SetCursorPosition(demandPosX, demandPosY);
                        map[demandPosX, demandPosY] = 'X';
                        treasureCount++;
                        Console.Write('X');
                    }
                }
            }

            Console.SetCursorPosition(userY, userX);
            Console.Write(po);
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != '#')
                    {
                        userX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    }
                    break;
            }
            if (treasureCount == bag.Length - 1)
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You won!!!");
            }
            else
            {
                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = ' ';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;
                }
            }
            Console.Clear();
        }

        Console.WriteLine();
    }

    private static int GetPosition()
    {
        Random rand = new Random();
        int result = rand.Next(2,10);
        return result;
    }

}