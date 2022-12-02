namespace Calendars.Template;

[TestFixture]
public class Tests
{
    [Test]
    public void BasicFirstPart()
    {
        DoWork.FirstPart(basicInput).Should().Be(1234);
    }

    [Test]
    public void FileFirstPart()
    {
        DoWork.FirstPart(fileInput).Should().Be(1234);
    }

    [Test]
    public void BasicSecondPart()
    {
        DoWork.SecondPart(basicInput).Should().Be(1234);
    }

    [Test]
    public void FileSecondPart()
    {
        DoWork.SecondPart(fileInput).Should().Be(1234);
    }

    private static readonly string basicInput = @"TODO";

    private static readonly string fileInput = @"TODO";
}
