using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode2022;

public class Day8TreetopTreeHouse
{
    private string[] GetInput()
    {
        var lines = System.IO.File.ReadLines("../../../Inputs/Day8Input.txt").ToArray();
        
        return lines;
    }
    
    private class Tree
    {
        public Tree(int height)
        {
            Height = height;
            IsVisible = false;
            ScenicScore = 0;
        }
        public int Height { get; set; }
        public bool IsVisible { get; set; } 
        public int ScenicScore { get; set; } 
    }

    private Tree[][] Forest;
    
    private int CalculateTreetop(string[] input)
    {
        Forest = new Tree[input.Length][];

        for (int i = 0; i < input.Length; i++)
        {
            Forest[i] = new Tree[input[i].Length];
            for (int j = 0; j < input[i].Length; j++)
            {
                Forest[i][j] = new Tree(input[i][j]- '0');
            }
        }

        for (int i = 0; i < Forest.Length; i++)
        {
            HorizontalTraversing(i);
        }
        
        for (int i = 0; i < Forest[0].Length; i++)
        {
            VerticalTraversing(i);
        }

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                if (Forest[i][j].IsVisible)
                {
                    CountScenicScore(i, j);
                }
            }
        }
        
        var result = GetHighestScore();

        return result;
    }

    private void CountScenicScore(int i, int j)
    {
        var top = CountScoreInDirection(i, j, -1, 0);
        var bottom = CountScoreInDirection(i, j, 1, 0);
        var left = CountScoreInDirection(i, j, 0, -1);
        var right = CountScoreInDirection(i, j, 0, 1);

        Forest[i][j].ScenicScore = top * bottom * left * right;
    }
    
    private int CountScoreInDirection(int i, int j, int deltaI, int deltaJ)
    {
        var currentScore = 0;
        var localI = i + deltaI;
        var localJ = j + deltaJ;
        while (GetTreeHeight(localI, localJ) < Forest[i][j].Height)
        {
            currentScore++;
            localI += deltaI;
            localJ += deltaJ;
        }

        if (GetTreeHeight(localI, localJ) != int.MaxValue)
            currentScore++;
        
        return currentScore;
    }

    private int GetTreeHeight(int i, int j)
    {
        if (i < 0 || i >= Forest.Length || j < 0 || j >= Forest.First().Length)
            return int.MaxValue;

        return Forest[i][j].Height;
    }
    
    private int GetHighestScore()
    {
        var result = 0;
        
        for (int i = 0; i < Forest.Length; i++)
        {
            for (int j = 0; j < Forest[i].Length; j++)
            {
                if(Forest[i][j].ScenicScore > result)
                    result = Forest[i][j].ScenicScore;
            }
        }

        return result;
    }
    
    private void HorizontalTraversing(int line)
    {
        var currentHeight = -1;
        for (var i = 0; i < Forest[line].Length; i++)
        {
            if (Forest[line][i].Height > currentHeight)
            {
                currentHeight = Forest[line][i].Height;
                Forest[line][i].IsVisible = true;
            }
        }
        currentHeight = -1;
        
        for (var i = Forest[line].Length-1; i >= 0; i--)
        {
            if (Forest[line][i].Height > currentHeight)
            {
                currentHeight = Forest[line][i].Height;
                Forest[line][i].IsVisible = true;
            }
        }
    }
    
    private void VerticalTraversing(int column)
    {
        var currentHeight = -1;
        for (var i = 0; i < Forest.Length; i++)
        {
            if (Forest[i][column].Height > currentHeight)
            {
                currentHeight = Forest[i][column].Height;
                Forest[i][column].IsVisible = true;
            }
        }
        currentHeight = -1;
        
        for (var i = Forest.Length-1; i >= 0; i--)
        {
            if (Forest[i][column].Height > currentHeight)
            {
                currentHeight = Forest[i][column].Height;
                Forest[i][column].IsVisible = true;
            }
        }
    }
    
    [Test]
    public void SimpleTest()
    {
        var trees = new[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };

        Assert.AreEqual(8, CalculateTreetop(trees));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(230112, CalculateTreetop(input));
    }
}