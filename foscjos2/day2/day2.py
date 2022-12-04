def rockPaperScissors():
    totalScore = 0

    pointsDict = {
        "X": 1,
        "Y": 2,
        "Z": 3
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
    convertDict = {
        "X": "A",
        "Y": "B",
        "Z": "C"
    }

    player2 = convertDict[player2]

    if (player1.lower() == player2.lower()):
        return 3
    if ((player1 == "A" and player2 == "B") 
        or (player1 == "B" and player2 == "C")
        or (player1 == "C" and player2 == "A")) :
        return 6
    else: 
        return 0


rockPaperScissors()