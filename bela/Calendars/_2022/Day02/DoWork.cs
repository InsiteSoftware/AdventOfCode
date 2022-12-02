namespace Calendars._2022.Day02;
public static class DoWork {
    public static int FirstPart(string o) => o.R("A X", "4").R("B X", "1").R("C X", "7").R("A Y", "8").R("B Y", "5").R("C Y", "2").R("A Z", "3").R("B Z", "9").R("C Z", "6").SP().I().Sum();
    public static int SecondPart(string o) => o.R("A X", "3").R("B X", "1").R("C X", "2").R("A Y", "4").R("B Y", "5").R("C Y", "6").R("A Z", "8").R("B Z", "9").R("C Z", "7").SP().I().Sum();
}