using NUnit.Framework;

namespace AdventOfCode2022;

public class Day14RegolithReservoir
{
    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day14Input.txt").ToArray();
        
        return lines;
    }

    private HashSet<string> Stones;
    private HashSet<string> Sand;
    private int lowestPoint;
    private int leftestPoint;
    private int rightestPoint;

    private int CountSandBlocks(string[] input)
    {
        Stones = new HashSet<string>();
        Sand = new HashSet<string>();
        lowestPoint = int.MinValue;
        leftestPoint = int.MaxValue;
        rightestPoint = int.MinValue;
        
        FillStones(input);
        var startPoint = (x: 500, y: 0);
        var ifDrainPossible = IfCoordIsAvailable(startPoint);

        while (ifDrainPossible)
        {
            ifDrainPossible = DrainSand(startPoint);
        }
        
        return Sand.Count;
    }

    private string StringifyCoord(int x, int y) => $"{x},{y}";
    private string StringifyCoord((int x, int y) coord) => StringifyCoord(coord.x, coord.y);
    
    private bool DrainSand((int x, int y) coord)
    {
        if (coord.y > lowestPoint)
            return false;
        
        if(!IfCoordIsAvailable(coord))
            return false;
        
        if(IfCoordIsAvailable(coord.x, coord.y + 1))
        {
            return DrainSand((coord.x, coord.y + 1));
        } else if (IfCoordIsAvailable(coord.x - 1, coord.y + 1))
        {
            return DrainSand((coord.x - 1, coord.y + 1));
        } else if (IfCoordIsAvailable(coord.x + 1, coord.y + 1))
        {
            return DrainSand((coord.x + 1, coord.y + 1));
        }
        
        var coordStr = StringifyCoord(coord);
        Sand.Add(coordStr);
        return true;
    }

    private bool IfCoordIsAvailable((int x, int y) coord) => IfCoordIsAvailable(coord.x, coord.y);
    private bool IfCoordIsAvailable(int x, int y)
    {
        var coord = StringifyCoord(x, y);
        if (Stones.Contains(coord))
            return false;

        if (Sand.Contains(coord))
            return false;

        return true;
    }
    
    private void FillStones(string[] input)
    {
        foreach (var stones in input)
        {
            var stonePoints = stones.Split(" -> ");
            FillStoneLines(stonePoints);
        }

        leftestPoint -= 200;
        rightestPoint += 200;
        lowestPoint += 2;
        FillStoneLine(leftestPoint, lowestPoint, rightestPoint, lowestPoint);
    }

    private void FillStoneLines(string[] stonePoints)
    {
        for (int i = 1; i < stonePoints.Length; i++)
        {
            var prev = stonePoints[i - 1].Split(',');
            var next = stonePoints[i].Split(',');
            var x1 = int.Parse(prev[0]);
            var y1 = int.Parse(prev[1]);
            var x2 = int.Parse(next[0]);
            var y2 = int.Parse(next[1]);
            
            FillStoneLine(x1, y1, x2, y2);
        }
    }

    private void FillStoneLine(int x1, int y1, int x2, int y2)
    {
        if (lowestPoint < Math.Max(y1, y2))
        {
            lowestPoint = Math.Max(y1, y2);
        }
        
        if (leftestPoint > Math.Min(x1, x2))
        {
            leftestPoint = Math.Min(x1, x2);
        }
        
        if (rightestPoint < Math.Max(x1, x2))
        {
            rightestPoint = Math.Max(x1, x2);
        }
        
        var deltaX = Math.Sign(x2 - x1);
        var deltaY = Math.Sign(y2 - y1);

        var newX = x1;
        var newY = y1;
        
        while (newX != x2 || newY != y2)
        {
            var coordStr = StringifyCoord(newX, newY);
            if (!Stones.Contains(coordStr))
            {
                Stones.Add(coordStr);
            }

            newX += deltaX;
            newY += deltaY;
        }

        var endOfLine = StringifyCoord(x2, y2);
        if (!Stones.Contains(endOfLine))
        {
            Stones.Add(endOfLine);
        }
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "498,4 -> 498,6 -> 496,6",
            "503,4 -> 502,4 -> 502,9 -> 494,9"
        };
        
        Assert.AreEqual(93, CountSandBlocks(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(24943, CountSandBlocks(input));
    }
}