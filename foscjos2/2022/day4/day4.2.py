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
    firstRange = list(range(int(firstHalf[0]), int(firstHalf[1]) + 1))
    secondRange = list(range(int(secondHalf[0]), int(secondHalf[1]) + 1))

    if (int(firstHalf[0]) in secondRange or int(firstHalf[1]) in secondRange):
        return 1
    if (int(secondHalf[0]) in firstRange or int(secondHalf[1]) in firstRange):
        return 1    

    return 0

findOverlaps()



# find any overlap
# if start1 > start2 && start1