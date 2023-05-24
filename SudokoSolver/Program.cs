
using System.Diagnostics.Metrics;
using System.Numerics;

int[,] matrix = new int[9, 9]
{
    {6,7,1,2,5,3,4,9,8 },
    {4,9,8,1,7,6,2,3,5 },
    {5,2,3,8,9,4,1,6,7 },
    {8,9,4,3,2,5,7,1,6 },
    {1,6,2,7,8,9,5,4,3 },
    {7,3,5,6,4,1,9,8,2 },
    {2,4,7,9,3,8,6,5,9 },
    {9,1,8,5,6,2,3,7,4 },
    {3,5,6,4,1,7,8,2,1 },
};

int[,] noNmatrix = new int[9, 9]
{
   {6,7,1,2,5,3,4,9,8 },
    {4,9,8,1,7,6,2,3,5 },
    {1,2,3,8,9,4,1,6,7 },
    {8,9,4,3,2,5,7,1,6 },
    {2,6,1,7,8,9,5,4,3 },
    {7,3,5,6,4,1,9,8,2 },
    {2,4,7,9,3,8,6,5,9 },
    {9,1,8,5,6,2,3,7,4 },
    {3,5,6,4,1,7,8,2,1 },
};



var cordinates = CheckMatrix(noNmatrix);

Console.WriteLine(string.Join(", ", cordinates));

Console.WriteLine();

PrintSudoko(noNmatrix, cordinates);

static void PrintSudoko(int[,] matrix, List<string> cordinates)
{
    char check = '\u221A';

    bool flag = false;

    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            foreach (var cordinate in cordinates)
            {
                var line = cordinate.Split(" ");

                int wrongRow = int.Parse(line[0]);
                int wrongCol = int.Parse(line[1]);

                if (row == wrongRow && col == wrongCol)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"|X{matrix[row, col]}|");
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write($"|{check}{matrix[row, col]}|");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        Console.WriteLine();
    }
}

static List<string> CheckMatrix(int[,] matrix)
{
    List<string> cordinates = new List<string>();

    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            if (row == 1 && col == 1 || row == 1 && col == 4 || row == 1 && col == 7 ||
               row == 4 && col == 1 || row == 4 && col == 4 || row == 4 && col == 7 ||
               row == 7 && col == 1 || row == 7 && col == 4 || row == 7 && col == 7)
            {
                for (int num = 1; num <= 9; num++)
                {
                    int counter = 0;
                    for (int insideRow = row - 1; insideRow <= row + 1; insideRow++)
                    {
                        for (int insideCol = col - 1; insideCol <= col + 1; insideCol++)
                        {
                            if (matrix[insideRow, insideCol] == num)
                            {
                                counter++;
                                if (counter == 2)
                                {
                                    cordinates.Add($"{insideRow} {insideCol}");
                                }

                                if (!IsValid(matrix, insideRow, insideCol, matrix[insideRow, insideCol]))
                                {
                                    cordinates.Add($"{insideRow} {insideCol}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    return cordinates;
}

static bool IsValid(int[,] matrix, int row, int col, int currentCell)
{
    for (int i = 0; i < 9; i++)
    {
        if (currentCell == matrix[i, col] && i != row)
        {
            return false;
        }

        if (currentCell == matrix[row, i] && i != col)
        {
            return false;
        }
    }

    return true;
}
