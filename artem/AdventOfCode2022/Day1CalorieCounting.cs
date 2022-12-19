using NUnit.Framework;

namespace AdventOfCode2022;

public class Day1CalorieCounting
{
    private int maxCalorie;
    private int secondMaxCal;
    private int thirdMaxCal;
    
    private int FindMostHighCalorieElf(string[] calories)
    {
        maxCalorie = 0;
        secondMaxCal = 0;
        thirdMaxCal = 0;
        
        var currentCalories = 0;

        foreach (var t in calories)
        {
            if (string.IsNullOrEmpty(t))
            {
                if (thirdMaxCal < currentCalories)
                    RecalculateLeaders(currentCalories);
                
                currentCalories = 0;
                
                continue;
            }
            
            currentCalories += Int32.Parse(t);
        }
        
        if (thirdMaxCal < currentCalories)
            RecalculateLeaders(currentCalories);

        return maxCalorie + secondMaxCal + thirdMaxCal;
    }

    private void RecalculateLeaders(int newCalorieValue)
    {
        switch (newCalorieValue)
        {
            case var newVal when newVal > thirdMaxCal && newVal <= secondMaxCal:
                thirdMaxCal = newVal;
                break;
            case var newVal when newVal > secondMaxCal && newVal <= maxCalorie:
                thirdMaxCal = secondMaxCal;
                secondMaxCal = newVal;
                break;
            case var newVal when newVal >= maxCalorie:
                thirdMaxCal = secondMaxCal;
                secondMaxCal = maxCalorie;
                maxCalorie = newVal;
                break;
        }
    }

    private string[] GetInput()
    {
        var lines = File.ReadLines("../../../Inputs/Day1Input.txt").ToArray();
        
        return lines;
    }
    
    [Test]
    public void SimpleTest()
    {
        var input = new[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };
        
        Assert.AreEqual(45000, FindMostHighCalorieElf(input));
    }
    
    [Test]
    public void PassingTest()
    {
        var input = GetInput();
        
        Assert.AreEqual(209914, FindMostHighCalorieElf(input));
    }
}