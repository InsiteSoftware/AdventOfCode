def followTail():
    result = 0
    currentTail = {'row': 0, 'col': 0}
    currentHead = {'row': 0, 'col': 0}
    resultSet = {0: {0: True}}


    with open('input.txt', 'r') as file:
        contents = file.readlines()
        
        for line in contents:
            line = line.strip().split()

            if line[0] == 'L':
                for movement in range(int(line[1])):
                    currentHead['col'] -= 1

                    if currentTail['col'] - currentHead['col'] > 1:
                        currentTail['row'] = currentHead['row']
                        currentTail['col'] -= 1
                    if currentTail['row'] not in resultSet:
                        resultSet[currentTail['row']] = {currentTail['col']: True}
                    elif currentTail['col'] not in resultSet[currentTail['row']]:
                        resultSet[currentTail['row']][currentTail['col']] = True
            if line[0] == 'R':
                for movement in range(int(line[1])):
                    currentHead['col'] += 1

                    if currentHead['col'] - currentTail['col'] > 1:
                        currentTail['row'] = currentHead['row']
                        currentTail['col'] += 1
                    if currentTail['row'] not in resultSet:
                        resultSet[currentTail['row']] = {currentTail['col']: True}
                    elif currentTail['col'] not in resultSet[currentTail['row']]:
                        resultSet[currentTail['row']][currentTail['col']] = True
            if line[0] == 'D':
                for movement in range(int(line[1])):
                    currentHead['row'] -= 1

                    if currentTail['row'] - currentHead['row'] > 1:
                        currentTail['col'] = currentHead['col']
                        currentTail['row'] -= 1
                    if currentTail['row'] not in resultSet:
                        resultSet[currentTail['row']] = {currentTail['col']: True}
                    elif currentTail['col'] not in resultSet[currentTail['row']]:
                        resultSet[currentTail['row']][currentTail['col']] = True
            if line[0] == 'U':
                for movement in range(int(line[1])):
                    currentHead['row'] += 1

                    if currentHead['row'] - currentTail['row'] > 1:
                        currentTail['col'] = currentHead['col']
                        currentTail['row'] += 1
                    if currentTail['row'] not in resultSet:
                        resultSet[currentTail['row']] = {currentTail['col']: True}
                    elif currentTail['col'] not in resultSet[currentTail['row']]:
                        resultSet[currentTail['row']][currentTail['col']] = True

    for x in resultSet:
        for y in resultSet[x]:
            result += 1
    print(result)

followTail()