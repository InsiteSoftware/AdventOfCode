import re

def moveCrates():
    result = ''
    setupComplete = False
    crates = []

    with open('input.txt', 'r') as file:
        shitList = file.readlines()

        numOfStacks = int(len(shitList[0]) / 4)
        
        for i in range(numOfStacks):
            crates.append([])

        for line in shitList:
            line = line.strip('\n')

            if (len(line) == 0):
                # we have processed the setup, time to see how the crates shift
                setupComplete = True
                continue
            
            index = 0
            temp = []
            if (setupComplete == False):
                for crate in line[::4]:

                    if (crate == '['):
                        crates[int(index/4)].append(line[index + 1])
                    
                    index += 4
            
            if (setupComplete):
                numberToMove, moveFrom, moveTo = re.findall('\d+', line)
                numberToMove = int(numberToMove)
                moveFrom = int(moveFrom)
                moveTo = int(moveTo)

                for i in range(numberToMove):
                    moving = crates[moveFrom - 1].pop(0)
                    temp.append(moving)
                crates[moveTo - 1] = temp + crates[moveTo - 1]

    for i in range(len(crates)):
        if (len(crates[i]) > 0):
            result += str(crates[i][0])
    print(result)

moveCrates()