def findPriority():
    total = 0
    index = 0
    rucksackList = []

    with open('input.txt', 'r') as file:
        fileContents = file.readlines()

        for rucksack in fileContents:
            rucksack = rucksack.strip()
            rucksackList.append(rucksack)
    
    for x in rucksackList[::3]:
        total += findMatches(x, rucksackList[index + 1], rucksackList[index + 2])
        index += 3

    print(total)

def findMatches(firstRuck, secondRuck, thirdRuck):
    for item in firstRuck:
        if item in secondRuck and item in thirdRuck:
            return convertValue(item)

def convertValue(character):
    if character >= 'A' and character <= 'Z':
        return ord(character) - 38
    else:
        return ord(character) - 96
    
findPriority()