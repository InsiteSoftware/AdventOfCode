﻿namespace Calendars._2022.Day15;

[TestFixture]
public class Tests
{
    [Test]
    public void ManhattanDistance()
    {
        new Point(5, 0).DistanceTo(1, 0).Should().Be(4);
    }

    [Test]
    public void ManhattanDistance2()
    {
        new Point(20, 1).DistanceTo(15, 3).Should().Be(7);
    }

    [Test]
    public void BasicFirstPart()
    {
        DoWork.FirstPart(basicInput, 10).Should().Be(26);
    }

    [Test]
    public void FileFirstPart()
    {
        // Too high 5114987
        // Too low 5073342
        DoWork.FirstPart(fileInput, 2000000).Should().Be(5166077);
    }

    [Test]
    public void BasicSecondPart()
    {
        DoWork.SecondPart(basicInput, 20).Should().Be("56000011");
    }

    [Test]
    public void FileSecondPart()
    {
        DoWork.SecondPart(fileInput, 4000000).Should().Be("13071206703981");
    }

    private static readonly string basicInput =
        @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";

    private static readonly string fileInput =
        @"Sensor at x=2793338, y=1910659: closest beacon is at x=2504930, y=2301197
Sensor at x=2887961, y=129550: closest beacon is at x=2745008, y=-872454
Sensor at x=3887055, y=2785942: closest beacon is at x=4322327, y=2605441
Sensor at x=3957399, y=2164042: closest beacon is at x=3651713, y=1889668
Sensor at x=1268095, y=1265989: closest beacon is at x=1144814, y=2000000
Sensor at x=2093967, y=2103436: closest beacon is at x=2504930, y=2301197
Sensor at x=2980126, y=1348046: closest beacon is at x=3651713, y=1889668
Sensor at x=508134, y=3998686: closest beacon is at x=1123963, y=4608563
Sensor at x=2982740, y=3604350: closest beacon is at x=2756683, y=3240616
Sensor at x=2372671, y=3929034: closest beacon is at x=2756683, y=3240616
Sensor at x=437628, y=1124644: closest beacon is at x=570063, y=959065
Sensor at x=3271179, y=3268845: closest beacon is at x=3444757, y=3373782
Sensor at x=1899932, y=730465: closest beacon is at x=570063, y=959065
Sensor at x=1390358, y=3881569: closest beacon is at x=1123963, y=4608563
Sensor at x=554365, y=989190: closest beacon is at x=570063, y=959065
Sensor at x=2225893, y=2703661: closest beacon is at x=2504930, y=2301197
Sensor at x=3755905, y=1346206: closest beacon is at x=3651713, y=1889668
Sensor at x=3967103, y=3930797: closest beacon is at x=3444757, y=3373782
Sensor at x=3534099, y=2371166: closest beacon is at x=3651713, y=1889668
Sensor at x=3420789, y=1720583: closest beacon is at x=3651713, y=1889668
Sensor at x=2222479, y=3278186: closest beacon is at x=2756683, y=3240616
Sensor at x=100457, y=871319: closest beacon is at x=570063, y=959065
Sensor at x=1330699, y=2091946: closest beacon is at x=1144814, y=2000000
Sensor at x=598586, y=99571: closest beacon is at x=570063, y=959065
Sensor at x=3436099, y=3392932: closest beacon is at x=3444757, y=3373782
Sensor at x=3338431, y=3346334: closest beacon is at x=3444757, y=3373782
Sensor at x=3892283, y=688090: closest beacon is at x=3651713, y=1889668
Sensor at x=1485577, y=1929020: closest beacon is at x=1144814, y=2000000
Sensor at x=2991003, y=2951060: closest beacon is at x=2756683, y=3240616
Sensor at x=2855486, y=2533468: closest beacon is at x=2504930, y=2301197
Sensor at x=750865, y=1619637: closest beacon is at x=1144814, y=2000000
Sensor at x=3378101, y=3402212: closest beacon is at x=3444757, y=3373782
Sensor at x=3515528, y=2950404: closest beacon is at x=3444757, y=3373782
Sensor at x=163133, y=2640553: closest beacon is at x=-1016402, y=3057364
Sensor at x=1765550, y=3021994: closest beacon is at x=2756683, y=3240616
Sensor at x=534625, y=1056421: closest beacon is at x=570063, y=959065
Sensor at x=3418549, y=3380980: closest beacon is at x=3444757, y=3373782
Sensor at x=29, y=389033: closest beacon is at x=570063, y=959065";
}