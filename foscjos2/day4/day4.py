def findOverlaps():
    total = 0

    with open('input.txt', 'r') as file:
        pairingList = file.readlines()

        for pairing in pairingList:
            pairing = pairing.strip().split(',')

            total += calculateOverlaps(pairing[0], pairing[1])

    print(total)

def calculateOverlaps(firstHalf, secondHalf):
    firstHalf = firstHalf.split('-')
    secondHalf = secondHalf.split('-')
    
    if (int(firstHalf[0]) >= int(secondHalf[0]) and int(firstHalf[1]) <= int(secondHalf[1])):
        return 1
        
    if (int(secondHalf[0]) >= int(firstHalf[0]) and int(secondHalf[1]) <= int(firstHalf[1])):
        return 1

    return 0

findOverlaps()