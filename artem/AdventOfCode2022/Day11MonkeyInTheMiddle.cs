using System.Numerics;
using NUnit.Framework;

namespace AdventOfCode2022;

public class Day11MonkeyInTheMiddle
{
    private class Monkey
    {
        public Monkey(Queue<BigInteger> items, Func<BigInteger , BigInteger > operation, Func<BigInteger, bool> test, int ifTrue, int ifFalse)
        {
            Items = items;
            Operation = operation;
            Test = test;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        private Queue<BigInteger> Items { get; set; }
        private Func<BigInteger , BigInteger > Operation { get; set; }
        private Func<BigInteger , bool> Test { get; set; }
        private int IfTrue { get; set; }
        private int IfFalse { get; set; }
        public BigInteger  InspectionCounter = 0;
        
        private void InspectAndThrowItem()
        {
            InspectionCounter++;
            BigInteger item = Items.Dequeue();
            item = Operation(item) % _superMode;

            if (item < 0)
                throw new ArgumentException();
            
            _monkeyList[Test(item) ? IfTrue : IfFalse].GetNewItem(item);
        }
        
        public void PlayTurn()
        {
            var count = Items.Count;
            for (var i = 0; i < count; i++)
            {
                InspectAndThrowItem();
            }
        }

        private void GetNewItem(BigInteger item) => Items.Enqueue(item);
    }

    private void GetTestMonkeys()
    {
        _monkeyList = new List<Monkey>()
        {
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger)79, 98 }),
                o => o * 19,
                i => i % 23 == 0,
                2,
                3
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger)54, 65, 75, 74 }),
                o => o + 6,
                i => i % 19 == 0,
                2,
                0
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger)79, 60, 97 }),
                o => o * o,
                i => i % 13 == 0,
                1,
                3
            ),
            new Monkey(
                new Queue<BigInteger>(new[] { (BigInteger)74 }),
                o => o + 3,
                i => i % 17 == 0,
                0,
                1
            ),
        };
    }
    
    private void GetVariantMonkeys()
    {
        _monkeyList = new List<Monkey>()
        {
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )91, 58, 52, 69, 95, 54 }),
                old => old * 13,
                i => i % 7 == 0,
                1,
                5
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )80, 80, 97, 84 }),
                old => old * old,
                i => i % 3 == 0,
                3,
                5
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )86, 92, 71 }),
                old => old + 7,
                i => i % 2 == 0,
                0,
                4
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )96, 90, 99, 76, 79, 85, 98, 61 }),
                old => old + 4,
                i => i % 11 == 0,
                7,
                6
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )60, 83, 68, 64, 73 }),
                old => old * 19,
                i => i % 17 == 0,
                1,
                0
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )96, 52, 52, 94, 76, 51, 57 }),
                old => old + 3,
                i => i % 5 == 0,
                7,
                3
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )75 }),
                old => old + 5,
                i => i % 13 == 0,
                4,
                2
            ),
            new Monkey(
                new Queue<BigInteger>(new[] {(BigInteger )83, 75 }),
                old => old + 1,
                i => i % 19 == 0,
                2,
                6
            ),
        };
    }

    private static List<Monkey> _monkeyList = new();
    private static BigInteger _superMode = 0;
    
    private BigInteger  GetMoreActiveMonkeys(BigInteger numberOfRounds)
    {
        for (var i = 0; i < numberOfRounds; i++)
        {
            foreach (var t in _monkeyList)
            {
                t.PlayTurn();
            }
        }

        return _monkeyList
            .Select(m => m.InspectionCounter)
            .OrderByDescending(_ => _)
            .Take(2)
            .Aggregate((_, __) => _ * __);
    }

    [Test]
    public void SimpleTest()
    {
        GetTestMonkeys();
        _superMode = 23 * 19 * 13 * 17;
        
        Assert.AreEqual((BigInteger)2713310158, GetMoreActiveMonkeys(10000));
    }
    
    [Test]
    public void PassingTest()
    {
        GetVariantMonkeys();
        _superMode = 7 * 3 * 2 * 11 * 17 * 5 * 13 * 19;
        
        Assert.AreEqual((BigInteger)14106266886, GetMoreActiveMonkeys(10000));
    }
}