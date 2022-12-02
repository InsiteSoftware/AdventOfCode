namespace Calendars.Template;

[TestFixture]
public class Tests
{
    [Test]
    public void BasicFirstPart()
    {
        var result = DoWork.FirstPart(basicInput);
        result.Should().Be(1234);
    }

    [Test]
    public void FileFirstPart()
    {
        var result = DoWork.FirstPart(fileInput);
        Console.WriteLine(result);
    }

    [Test]
    public void BasicSecondPart()
    {
        var result = DoWork.SecondPart(basicInput);
        result.Should().Be(1234);
    }

    [Test]
    public void FileSecondPart()
    {
        var result = DoWork.SecondPart(fileInput);
        Console.WriteLine(result);
    }

    private static readonly string basicInput = @"TODO";

    private static readonly string fileInput = @"TODO";
}
