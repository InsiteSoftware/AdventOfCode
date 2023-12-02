def findPriority():
    total = 0

    with open('input.txt', 'r') as file:
        rucksackList = file.readlines()

        for rucksack in rucksackList:
            rucksack = rucksack.strip()
            length = int(len(rucksack)/2)
            firstHalf = rucksack[0:length]
            secondHalf = rucksack[length:]
            total += findMatches(firstHalf, secondHalf)
    
    print(total)

def findMatches(firstHalf, secondHalf):
    for item in firstHalf:
        if (item in secondHalf):
            return convertValue(item)

def convertValue(character):
    if character >= 'A' and character <= 'Z':
        return ord(character) - 38
    else:
        return ord(character) - 96
    
findPriority()