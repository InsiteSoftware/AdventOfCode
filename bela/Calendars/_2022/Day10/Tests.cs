﻿namespace Calendars._2022.Day10;

[TestFixture]
public class Tests
{
    [Test]
    public void SimpleFirstPart()
    {
        DoWork
            .FirstPart(
                @"noop
addx 3
addx -5"
            )
            .Should()
            .Be(0);
    }

    [Test]
    public void BasicFirstPart()
    {
        DoWork.FirstPart(basicInput).Should().Be(13140);
    }

    [Test]
    public void FileFirstPart()
    {
        DoWork.FirstPart(fileInput).Should().Be(14320);
    }

    [Test]
    public void BasicSecondPart()
    {
        DoWork
            .SecondPart(basicInput)
            .Should()
            .Be(
                @"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
"
            );
    }

    [Test]
    public void FileSecondPart()
    {
        DoWork
            .SecondPart(fileInput)
            .Should()
            .Be(
                @"###...##..###..###..#..#..##..###....##.
#..#.#..#.#..#.#..#.#.#..#..#.#..#....#.
#..#.#....#..#.###..##...#..#.#..#....#.
###..#....###..#..#.#.#..####.###.....#.
#....#..#.#....#..#.#.#..#..#.#....#..#.
#.....##..#....###..#..#.#..#.#.....##..
"
            );
    }

    private static readonly string basicInput =
        @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

    private static readonly string fileInput =
        @"noop
noop
noop
addx 6
noop
addx 30
addx -26
noop
addx 5
noop
noop
noop
noop
addx 5
addx -5
addx 6
addx 5
addx -1
addx 5
noop
noop
addx -14
addx -18
addx 39
addx -39
addx 25
addx -22
addx 2
addx 5
addx 2
addx 3
addx -2
addx 2
noop
addx 3
addx 2
addx 2
noop
addx 3
noop
addx 3
addx 2
addx 5
addx 4
addx -18
addx 17
addx -38
addx 5
addx 2
addx -5
addx 27
addx -19
noop
addx 3
addx 4
noop
noop
addx 5
addx -1
noop
noop
addx 4
addx 5
addx 2
addx -4
addx 5
noop
addx -11
addx 16
addx -36
noop
addx 5
noop
addx 28
addx -23
noop
noop
noop
addx 21
addx -18
noop
addx 3
addx 2
addx 2
addx 5
addx 1
noop
noop
addx 4
noop
noop
noop
noop
noop
addx 8
addx -40
noop
addx 7
noop
addx -2
addx 5
addx 2
addx 25
addx -31
addx 9
addx 5
addx 2
addx 2
addx 3
addx -2
noop
addx 3
addx 2
noop
addx 7
addx -2
addx 5
addx -40
addx 20
addx -12
noop
noop
noop
addx -5
addx 7
addx 7
noop
addx -1
addx 1
addx 5
addx 3
addx -2
addx 2
noop
addx 3
addx 2
noop
noop
noop
noop
addx 7
noop
noop
noop
noop";
}
