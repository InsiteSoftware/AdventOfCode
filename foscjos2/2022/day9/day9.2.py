def followTail():
    result = 0
    currentTail = {'row': 0, 'col': 0}
    currentHead = {'row': 0, 'col': 0}
    currentPositions = {0: {'row': 0, 'col': 0},
                        1: {'row': 0, 'col': 0},
                        2: {'row': 0, 'col': 0},
                        3: {'row': 0, 'col': 0},
                        4: {'row': 0, 'col': 0},
                        5: {'row': 0, 'col': 0},
                        6: {'row': 0, 'col': 0},
                        7: {'row': 0, 'col': 0},
                        8: {'row': 0, 'col': 0},
                        9: {'row': 0, 'col': 0}}
    resultSet = {0: {0: True}}


    with open('input.txt', 'r') as file:
        contents = file.readlines()
        
        for line in contents:
            line = line.strip().split()

            if line[0] == 'L':
                for movement in range(int(line[1])):
                    for knot in currentPositions:
                        if knot == 0:
                            currentPositions[knot]['col'] -= 1
                            continue
                        currentPositions[knot]['row'], currentPositions[knot]['col'] = calcMove(currentPositions[knot - 1]['row'], currentPositions[knot - 1]['col'], currentPositions[knot]['row'], currentPositions[knot]['col'])

                    if currentPositions[9]['row'] not in resultSet:
                        resultSet[currentPositions[9]['row']] = {currentPositions[9]['col']: True}
                    elif currentPositions[9]['col'] not in resultSet[currentPositions[9]['row']]:
                        resultSet[currentPositions[9]['row']][currentPositions[9]['col']] = True
                
            if line[0] == 'R':
                for movement in range(int(line[1])):
                    for knot in currentPositions:
                        if knot == 0:
                            currentPositions[knot]['col'] += 1
                            continue
                        currentPositions[knot]['row'], currentPositions[knot]['col'] = calcMove(currentPositions[knot - 1]['row'], currentPositions[knot - 1]['col'], currentPositions[knot]['row'], currentPositions[knot]['col'])

                    if currentPositions[9]['row'] not in resultSet:
                        resultSet[currentPositions[9]['row']] = {currentPositions[9]['col']: True}
                    elif currentPositions[9]['col'] not in resultSet[currentPositions[9]['row']]:
                        resultSet[currentPositions[9]['row']][currentPositions[9]['col']] = True
                
            if line[0] == 'D':
                for movement in range(int(line[1])):
                    for knot in currentPositions:
                        if knot == 0:
                            currentPositions[knot]['row'] -= 1
                            continue
                        currentPositions[knot]['row'], currentPositions[knot]['col'] = calcMove(currentPositions[knot - 1]['row'], currentPositions[knot - 1]['col'], currentPositions[knot]['row'], currentPositions[knot]['col'])

                    if currentPositions[9]['row'] not in resultSet:
                        resultSet[currentPositions[9]['row']] = {currentPositions[9]['col']: True}
                    elif currentPositions[9]['col'] not in resultSet[currentPositions[9]['row']]:
                        resultSet[currentPositions[9]['row']][currentPositions[9]['col']] = True
            if line[0] == 'U':
                for movement in range(int(line[1])):
                    for knot in currentPositions:
                        if knot == 0:
                            currentPositions[knot]['row'] += 1
                            continue
                        currentPositions[knot]['row'], currentPositions[knot]['col'] = calcMove(currentPositions[knot - 1]['row'], currentPositions[knot - 1]['col'], currentPositions[knot]['row'], currentPositions[knot]['col'])

                    if currentPositions[9]['row'] not in resultSet:
                        resultSet[currentPositions[9]['row']] = {currentPositions[9]['col']: True}
                    elif currentPositions[9]['col'] not in resultSet[currentPositions[9]['row']]:
                        resultSet[currentPositions[9]['row']][currentPositions[9]['col']] = True
                
    for x in resultSet:
        for y in resultSet[x]:
            result += 1
    print(result)

def calcMove(headRow, headCol, tailRow, tailCol):
    # take a head and tail, return new x/y coords for the tail to move to
    # assumes the head has already been moved for this round
    if headRow == tailRow:
        if headCol - tailCol > 1:
            tailCol += 1
        elif tailCol - headCol > 1:
            tailCol -= 1
    elif headCol == tailCol:
        if headRow - tailRow > 1:
            tailRow += 1
        elif tailRow - headRow > 1:
            tailRow -= 1
    else:
        if headRow - tailRow > 1:
            tailRow += 1
            if headCol - tailCol > 1:
                tailCol += 1
            elif tailCol - headCol > 1:
                tailCol -= 1
            else:
                tailCol = headCol
        elif tailRow - headRow > 1:
            tailRow -= 1
            if headCol - tailCol > 1:
                tailCol += 1
            elif tailCol - headCol > 1:
                tailCol -= 1
            else:
                tailCol = headCol
        elif headCol - tailCol > 1:
            tailCol += 1
            if headRow - tailRow > 1:
                tailRow += 1
            elif tailRow - headRow > 1:
                tailRow -= 1
            else:
                tailRow = headRow
        elif tailCol - headCol > 1:
            tailCol -= 1
            if headRow - tailRow > 1:
                tailRow += 1
            elif tailRow - headRow > 1:
                tailRow -= 1
            else:
                tailRow = headRow
                
    return tailRow, tailCol

followTail()