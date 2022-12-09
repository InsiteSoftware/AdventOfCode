namespace AOC_2022._8;

public static class Code
{
    private static void TraverseColumn(int[,] trees, HashSet<string> visibleTrees, int column, int columnLength)
    {
        var largest = -1;
        for (var i = 0; i < columnLength; i++)
        {
            if (trees[i, column] > largest)
            {
                visibleTrees.Add($"{i}, {column}");
                largest = trees[i, column];
            }
        }
        
        largest = -1;
        for (var i = columnLength - 1; i > 0 ; i--)
        {
            if (trees[i, column] > largest)
            {
                visibleTrees.Add($"{i}, {column}");
                largest = trees[i, column];
            }
        }
    }

    private static void TraverseRow(int[,] trees, HashSet<string> visibleTrees, int row, int rowLength)
    {
        var largest = -1;
        for (var i = 0; i < rowLength; i++)
        {
            if (trees[row, i] > largest)
            {
                visibleTrees.Add($"{row}, {i}");
                largest = trees[row, i];
            }
        }

        largest = -1;
        for (var i = rowLength - 1; i > 0; i--)
        {
            if (trees[row, i] > largest)
            {
                visibleTrees.Add($"{row}, {i}");
                largest = trees[row, i];
            }
        }
    }
    
    public static int GetPart1Answer(string[] lines)
    {
        var trees = new int[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                trees[i, j] = Convert.ToInt32(lines[i][j].ToString());
            }
        }

        var visibleTrees = new HashSet<string>();
        for (var i = 0; i < lines[0].Length; i++)
        {
            TraverseColumn(trees, visibleTrees, i, lines.Length);
        }
        
        for (var i = 0; i < lines.Length; i++)
        {
            TraverseRow(trees, visibleTrees, i, lines[0].Length);
        }
        
        return visibleTrees.Count;
    }

    private static int CalculateScenicScore((int row, int column) tree, int[,] trees, int width, int height)
    {
        int GetRowViewingDistances()
        {
            var left = 1;
            for (var i = tree.column - 1; i > 0; i--)
            {
                if (trees[tree.row, tree.column] > trees[tree.row, i])
                    left++;
                else
                    break;
            }

            var right = 1;
            for (var i = tree.column + 1; i < width - 1; i++)
            {
                if (trees[tree.row, tree.column] > trees[tree.row, i])
                    right++;
                else
                    break;
            }

            return left * right;
        }
        
        int GetColumnViewingDistance()
        {
            var top = 1;
            for (var i = tree.row - 1; i > 0; i--)
            {
                if (trees[tree.row, tree.column] > trees[i, tree.column])
                    top++;
                else
                    break;
            }

            var bottom = 1;
            for (var i = tree.row + 1; i < height - 1; i++)
            {
                if (trees[tree.row, tree.column] > trees[i, tree.column])
                    bottom++;
                else
                    break;
            }

            return top * bottom;
        }

        return GetRowViewingDistances() * GetColumnViewingDistance();
    }
    
    public static int GetPart2Answer(string[] lines)
    {
        var trees = new int[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                trees[i, j] = Convert.ToInt32(lines[i][j].ToString());
            }
        }

        var bestTree = (tree: "-1, -1", score: 0); 
        for (var i = 1; i < lines.Length - 1; i++)
        {
            for (var j = 1; j < lines[i].Length - 1; j++)
            {
                var score = CalculateScenicScore((i, j), trees, lines[0].Length, lines.Length);
                if (score > bestTree.score)
                    bestTree = ($"{i}, {j}", score);
            }
        }
        
        return bestTree.score;
    }
}