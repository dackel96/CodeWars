using System;
class MainClass
{

    public static int SeatingStudents(int[] arr)
    {
        int matrixRow = arr[0] / 2;

        int[,] classroom = new int[matrixRow, 2];

        var takenSeats = new List<int>();

        for (int i = 1; i < arr.Length; i++)
        {
            takenSeats.Add(arr[i]);
        }

        int student = 0;
        for (int row = 0; row < classroom.GetLength(0); row++)
        {
            for (int col = 0; col < classroom.GetLength(1); col++)
            {
                classroom[row, col] = student + 1;
                student++;
            }
        }

        int result = 0;


        while (takenSeats.Any())
        {
            for (int row = 0; row < classroom.GetLength(0); row++)
            {
                for (int col = 0; col < classroom.GetLength(1); col++)
                {
                    int seat = 0;
                    if (takenSeats.Any())
                    {
                        seat = takenSeats.First();
                    }

                    if (classroom[row, col] == seat)
                    {
                        takenSeats.Remove(seat);
                    }
                    else if (classroom[row, col] != seat)
                    {
                        if (IsInRange(classroom, row, col + 1) && classroom[row, col + 1] != seat)
                        {
                            result++;
                        }

                        if (IsInRange(classroom, row + 1, col) && classroom[row + 1, col] != seat)
                        {
                            result++;
                        }
                    }
                    else
                    {
                        takenSeats.Remove(seat);
                    }
                }

            }
        }

        return result;
    }

    private static bool IsInRange(int[,] board, int row, int col)
    {
        return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
    }

    static void Main()
    {
        var arr = new int[]
        {
          8,1,8
        };

        Console.WriteLine(SeatingStudents(arr));
    }

}