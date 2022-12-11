using NUnit.Framework;

namespace AdventOfCode2022;

public class Day9RopeBridge
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day9Input.txt").ToArray();
        
        return lines;
    }

    private class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
    
    private Coordinate[] Knots { get; set; }
    private HashSet<string> TailPositions;

    private int CountTailPositions(string[] input, int knotsNumber)
    {
        TailPositions = new HashSet<string>();
        Knots = new Coordinate[knotsNumber];

        for (var i = 0; i < Knots.Length; i++)
        {
            Knots[i] = new Coordinate(0, 0);
        }

        foreach (var t in input)
        {
            MakeMove(t);
        }

        return TailPositions.Count;
    }

    private void MakeMove(string move)
    {
        var direction = move[0];
        var steps = int.Parse(move.Substring(2));

        for (int i = 0; i < steps; i++)
        {
            MoveHead(direction);
            for (int j = 1; j < Knots.Length; j++)
            {
                MoveKnot(j);        
            }
            
            var tailPosition = $"{Knots.Last().Y}:{Knots.Last().X}";
            TailPositions.Add(tailPosition);
        }
    }

    private void MoveHead(char direction)
    {
        switch (direction)
        {
            case 'R' : 
                Knots[0].X += 1;
                break;
            case 'L':
                Knots[0].X -= 1;
                break;
            case 'U':
                Knots[0].Y += 1;
                break;
            case 'D':
                Knots[0].Y -= 1;
                break;
        }
    }

    private void MoveKnot(int i)
    {
        var deltaX = Knots[i-1].X - Knots[i].X;
        var deltaY = Knots[i-1].Y - Knots[i].Y;
        
        if (Math.Abs(deltaX) > 1 || Math.Abs(deltaY) > 1)
        {
            Knots[i].X += Math.Sign(deltaX);
            Knots[i].Y += Math.Sign(deltaY);
        }
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2",
            
        };

        Assert.AreEqual(13, CountTailPositions(input, 2));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(5779, CountTailPositions(input, 2));
    }
    
    [Test]
    public void PassingTestPart2()
    {
        var input = GetInput();
        
        Assert.AreEqual(2331, CountTailPositions(input, 10));
    }
}