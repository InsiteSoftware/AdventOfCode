namespace Calendars._2021.Day06;

[TestFixture]
public class Tests
{
    [Test]
    public void BasicFirstPart()
    {
        DoWork.FirstPart(basicInput).Should().Be(5934);
    }

    [Test]
    public void FileFirstPart()
    {
        DoWork.FirstPart(fileInput).Should().Be(366057);
    }

    [Test]
    public void BasicSecondPart()
    {
        DoWork.SecondPart(basicInput).Should().Be(26984457539);
    }

    [Test]
    public void FileSecondPart()
    {
        DoWork.SecondPart(fileInput).Should().Be(1653559299811);
    }

    // 1 3 5 9

    private static readonly string basicInput =
        @"3,4,3,1,2
";

    private static readonly string fileInput =
        @"1,2,1,3,2,1,1,5,1,4,1,2,1,4,3,3,5,1,1,3,5,3,4,5,5,4,3,1,1,4,3,1,5,2,5,2,4,1,1,1,1,1,1,1,4,1,4,4,4,1,4,4,1,4,2,1,1,1,1,3,5,4,3,3,5,4,1,3,1,1,2,1,1,1,4,1,2,5,2,3,1,1,1,2,1,5,1,1,1,4,4,4,1,5,1,2,3,2,2,2,1,1,4,3,1,4,4,2,1,1,5,1,1,1,3,1,2,1,1,1,1,4,5,5,2,3,4,2,1,1,1,2,1,1,5,5,3,5,4,3,1,3,1,1,5,1,1,4,2,1,3,1,1,4,3,1,5,1,1,3,4,2,2,1,1,2,1,1,2,1,3,2,3,1,4,5,1,1,4,3,3,1,1,2,2,1,5,2,1,3,4,5,4,5,5,4,3,1,5,1,1,1,4,4,3,2,5,2,1,4,3,5,1,3,5,1,3,3,1,1,1,2,5,3,1,1,3,1,1,1,2,1,5,1,5,1,3,1,1,5,4,3,3,2,2,1,1,3,4,1,1,1,1,4,1,3,1,5,1,1,3,1,1,1,1,2,2,4,4,4,1,2,5,5,2,2,4,1,1,4,2,1,1,5,1,5,3,5,4,5,3,1,1,1,2,3,1,2,1,1
";
}
