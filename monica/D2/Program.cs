string[] lines = System.IO.File.ReadAllLines(@"C:\Projects\AdventOfCode\monica\D2\Input.txt");

var results = new List<Tuple<int, string, int>>(); // round, w/l, score
var round = 0;
var finalScore = 0;
var Q1 = false;
foreach (string line in lines)
{
    round++;
    var words = line.Split(' ');
    var visitor = words[0];
    var home = words[1];

    var homeScore = 0;
    var visitorScore = 0;
    var matchResult = "";

    switch (visitor)
    {
        case "A":
            visitorScore = visitorScore + 1;
            break;//rock - 1
        case "B":
            visitorScore = visitorScore + 1;
            break;//paper - 2
        case "C":
            visitorScore = visitorScore + 1;
            break;//scissors - 3
        default: break;
    }

    if (Q1)
    {
        //figure out points first
        switch (home)
        {
            case "X":
                homeScore = homeScore + 1;
                break;//rock - 1
            case "Y":
                homeScore = homeScore + 2;
                break;//paper - 2
            case "Z":
                homeScore = homeScore + 3;
                break;//scissors - 3
            default: break;
        }

        switch (line)
        {
            case "A X": //draw - 3
                matchResult = "draw";
                homeScore = homeScore + 3;
                visitorScore = visitorScore + 3;
                break;
            case "A Y": //win - 6
                matchResult = "win";
                homeScore = homeScore + 6;
                break;
            case "A Z": //lose - 0
                matchResult = "lose";
                visitorScore = visitorScore + 6;
                break;
            case "B X": //lose - 0
                matchResult = "lose";
                visitorScore = visitorScore + 6;
                break;
            case "B Y": //draw - 3
                matchResult = "draw";
                homeScore = homeScore + 3;
                visitorScore = visitorScore + 3;
                break;
            case "B Z": //win - 6
                matchResult = "win";
                homeScore = homeScore + 6;
                break;
            case "C X": //win - 6
                matchResult = "win";
                homeScore = homeScore + 6;
                break;
            case "C Y": //lose - 0
                matchResult = "lose";
                visitorScore = visitorScore + 6;
                break;
            case "C Z": //draw - 3
                matchResult = "draw";
                homeScore = homeScore + 3;
                visitorScore = visitorScore + 3;
                break;
            default: break;
        }
    }

    if (!Q1)
    {
        switch (line)
        {
/*ROCK*/        case "A X": //LOSE 0  SCISSORS-3   
                matchResult = "LOSE";
                homeScore = homeScore + 3;
                break;
            case "A Y": //DRAW 3 ROCK-1
                matchResult = "DRAW";
                homeScore = homeScore + 4;
                break;
            case "A Z": //WIN 6 PAPER 2
                matchResult = "WIN";
                homeScore = homeScore + 8;
                break;
/*PAPER*/   case "B X": //LOSE 0 ROCK 1
                matchResult = "LOSE";
                homeScore = homeScore + 1;
                break;
            case "B Y": //DRAW 3 PAPER 2
                matchResult = "DRAW";
                homeScore = homeScore + 5;
                break;
            case "B Z": //WIN 6 SCISSORS 3
                matchResult = "WIN";
                homeScore = homeScore + 9;
                break;
/*SCISSOR*/ case "C X": //LOSE 0 PAPER 2
                matchResult = "LOSE";
                homeScore = homeScore + 2;
                break;
            case "C Y": //DRAW 3 SCISSORS 3
                matchResult = "DRAW";
                homeScore = homeScore + 6;
                break;
            case "C Z": //WIN 6 ROCK 1
                matchResult = "WIN";
                homeScore = homeScore + 7;
                break;
            default: break;
        }
        finalScore = finalScore + homeScore;

        results.Add(new Tuple<int, string, int>(round, matchResult, homeScore));
    }
}
Console.WriteLine(finalScore);
