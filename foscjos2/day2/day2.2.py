def rockPaperScissors():
    totalScore = 0

    pointsDict = {
        "X": 0,
        "Y": 3,
        "Z": 6
    }

    with open('input-2.txt', 'r') as file:
        matchList = file.readlines()

        for match in matchList:
            match = match.split()
            matchResult = determineMatchResult(match[0], match[1])
            totalScore += matchResult
            totalScore += pointsDict[match[1]]
        
    print(totalScore)
            

def determineMatchResult(player1, player2):
    # Determines score based off of what player2 must play
    loseDict = {
        "A": 3,
        "B": 1,
        "C": 2
    }

    winDict = {
        "A": 2,
        "B": 3,
        "C": 1
    }

    drawDict = {
        "A": 1,
        "B": 2,
        "C": 3
    }
    if (player2 == "X") :
        return loseDict[player1]

    if (player2 == "Y"):
        return drawDict[player1]
    
    if (player2 == "Z"):
        return winDict[player1]


rockPaperScissors()