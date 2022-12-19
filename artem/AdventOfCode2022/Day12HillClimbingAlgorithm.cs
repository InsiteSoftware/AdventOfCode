using System.Drawing;
using NUnit.Framework;

namespace AdventOfCode2022;

public class Day12HillClimbingAlgorithm
{
    private class Coordinate
    {
        public Coordinate(char c)
        {
            C = c;
        }

        public char C { get; set; }
        public int Steps = Int32.MaxValue;
        public bool IsEndPosition = false;
    }
    
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day12Input.txt").ToArray();
        
        return lines;
    }
    
    private static Coordinate[][] _grid;
    
    private int CountSteps(string[] input)
    {
        InitGrid(input);

        CountSteps();

        var tst = _grid.First(l => l.Any(c => c.IsEndPosition));
        return tst.First(c => c.IsEndPosition).Steps;
    }

    private void InitGrid(string[] input)
    {
        _grid = new Coordinate[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            _grid[i] = new Coordinate[input[i].Length];
            for (int j = 0; j < input[i].Length; j++)
            {
                _grid[i][j] = new Coordinate(input[i][j]);

                if (input[i][j] == 'S')
                {
                    _grid[i][j].Steps = 0;
                    _grid[i][j].C = 'a';
                }

                if (input[i][j] == 'a')
                {
                    _grid[i][j].Steps = 0;
                }
                
                if (input[i][j] == 'E')
                {
                    _grid[i][j].IsEndPosition = true;
                    _grid[i][j].C = 'z';
                }
            }
        }
    }

    private void CountSteps()
    {
        bool needToContinue;
        
        do
        {
            needToContinue = RecountSteps();
        } while (needToContinue);
    }

    private bool RecountSteps()
    {
        var needToContinue = false;
        
        for (int i = 0; i < _grid.Length; i++)
        {
            for (int j = 0; j < _grid[i].Length; j++)
            {
                var result = CheckNeighbors(i, j);
                if (result)
                    needToContinue = true;
            }
        }

        return needToContinue;
    }

    private bool CheckNeighbors(int i, int j)
    {
        var needToContinue = false;

        if (CheckNeighbor(i, j, i - 1, j))
            needToContinue = true;
        if (CheckNeighbor(i, j, i + 1, j))
            needToContinue = true;
        if (CheckNeighbor(i, j, i, j + 1))
            needToContinue = true;
        if (CheckNeighbor(i, j, i, j - 1))
            needToContinue = true;
        
        return needToContinue;
    }

    private bool CheckNeighbor(int i1, int j1, int i2, int j2)
    {
        var needToContinue = false;
        
        if (_grid[i1][j1].Steps - 1 > NeighborSeps(i2, j2) &&
            HighEnough(_grid[i1][j1].C, _grid[i2][j2].C))
        {
            needToContinue = true;
            _grid[i1][j1].Steps = NeighborSeps(i2 , j2) + 1;
        }

        return needToContinue;
    }
    
    private bool HighEnough(char c1, char c2)
    {
        return c1 <= c2 + 1;
    }

    private int NeighborSeps(int i, int j)
    {
        if (j < 0 || j >= _grid.First().Length ||
            i < 0 || i >= _grid.Length)
            return int.MaxValue;

        return _grid[i][j].Steps;
    }

    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi",
        };
        
        Assert.AreEqual(29, CountSteps(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(454, CountSteps(input));
    }
}