using System.Collections.Specialized;
using System.Data.Common;
using System.IO.Pipes;

var lines = File.ReadLines("../../../input.txt");
var total = 0;

foreach (var line in lines)
{

    var game = ParseGame(line);

    // Question 1
    // if (isValid(game))
    // {
    //     total += game.Id;
    // }

    // Question 2
    var mins = FindMinimums(game);
    var power = mins.reds * mins.greens * mins.blues;
    total += power;
}

Console.WriteLine($"The Total is: {total}");

static bool isValid(Game game)
{
    var reds = 12;
    var blues = 14;
    var greens = 13;

    var result = game.Rounds.All(x => x.Verify(reds, blues, greens));

    return result;
}

static (int reds, int greens, int blues) FindMinimums(Game game)
{
    var picks = game.Rounds.SelectMany(x => x.Picks);
    var minRed = 0;
    var minGreen = 0;
    var minBlue = 0;

    foreach (var pick in picks)
    {
        switch (pick.Color)
        {
            case Color.red:
                minRed = minRed < pick.Count ? pick.Count : minRed;
                break;
            case Color.blue:
                minBlue = minBlue < pick.Count ? pick.Count : minBlue;
                break;
            case Color.green:
                minGreen = minGreen < pick.Count ? pick.Count : minGreen;
                break;
        }
    }

    return (minRed, minGreen, minBlue);
}


static Game ParseGame(string line)
{
    var game = new Game();
    var colon = line.IndexOf(':');

    game.Id = int.Parse(line.Substring(0, colon).Split(" ").Last());
    game.Rounds = line
        .Substring(colon + 1)
        .Trim()
        .Split(";")
        .Select(x => new Round()
        {
            Picks = x.Split(",").Select(y =>
            {
                var raw = y.Trim().Split(" ");

                return new Pick()
                {
                    Count = int.Parse(raw[0]),
                    Color = (Color)Enum.Parse(typeof(Color), raw[1]),
                };
            })
        }).ToList();

    return game;
}

public enum Color
{
    red,
    blue,
    green,
}

public class Game
{
    public int Id { get; set; }
    public IEnumerable<Round> Rounds { get; set; } = new List<Round>();

}

public class Round
{
    public IEnumerable<Pick> Picks { get; set; } = new List<Pick>();
    public bool Verify(int reds, int blues, int greens)
    {
        var r = Picks.Where(x => x.Color == Color.red).Sum(x => x.Count);
        var b = Picks.Where(x => x.Color == Color.blue).Sum(x => x.Count);
        var g = Picks.Where(x => x.Color == Color.green).Sum(x => x.Count);

        return r <= reds && b <= blues && g <= greens;
    }
}

public class Pick
{
    public int Count { get; set; }
    public Color Color { get; set; }
}