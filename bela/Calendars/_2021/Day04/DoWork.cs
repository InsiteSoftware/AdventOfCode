namespace Calendars._2021.Day04;

public static class DoWork
{
    public static int FirstPart(string input)
    {
        var lines = input.Replace("\r", "").Split('\n');
        var numbersPulled = new Queue<int>(lines[0].Split(',').Select(int.Parse));
        var boards = new List<int[,]>();

        for (var x = 2; x < lines.Length; x += 6)
        {
            var newBoard = new int[5, 5];

            void AddRow(int offset)
            {
                var row = lines[x + offset]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (var y = 0; y < 5; y++)
                {
                    newBoard[offset, y] = row[y];
                }
            }
            AddRow(0);
            AddRow(1);
            AddRow(2);
            AddRow(3);
            AddRow(4);
            boards.Add(newBoard);
        }

        void ForEachSpaceOnBoard(Action<int, int> action)
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    action(x, y);
                }
            }
        }

        void ForEachSpaceOnBoards(Action<int[,], int, int> action)
        {
            foreach (var board in boards)
            {
                ForEachSpaceOnBoard((x, y) => action(board, x, y));
            }
        }
        
        while (numbersPulled.Any())
        {
            var nextNumber = numbersPulled.Dequeue();
            ForEachSpaceOnBoards((board, x, y) =>
            {
                if (board[x, y] == nextNumber)
                {
                    board[x, y] = 0;
                }
            });

            int Winner(int[,] board)
            {
                var sum = 0;
                ForEachSpaceOnBoard((x, y) =>
                {
                    sum += board[x, y];
                });

                return sum * nextNumber;
            }

            int[][] BuildResult(Action<int[][], int, int> action)
            {
                var result = new int[5][];
                for(var x = 0; x < 5; x++)
                {
                    result[x] = new int[5];
                }
                
                ForEachSpaceOnBoard((x, y) =>
                {
                    action(result, x, y);
                });

                return result;
            }


            int[][] GetRows(int[,] board)
            {
                return BuildResult((result, x, y) =>
                {
                    result[x][y] = board[x, y];
                });
            }
            
            int[][] GetColumns(int[,] board)
            {
                return BuildResult((result, x, y) =>
                {
                    result[x][y] = board[y, x];
                });
            }
            
            foreach (var board in boards)
            {
                if (GetRows(board).Any(o => o.Sum() == 0))
                {
                    return Winner(board);
                }

                if (GetColumns(board).Any(o => o.Sum() == 0))
                {
                    return Winner(board);
                }
            }
        }
        return 0;
    }

    public static int SecondPart(string input)
    {
        var lines = input.Replace("\r", "").Split('\n');

        return 0;
    }
}
