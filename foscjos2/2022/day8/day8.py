import copy

def countTrees():
    total = 0
    forest = []

    with open('input.txt', 'r') as file:
        contents = file.readlines()
        
        for line in contents:
            line = line.strip()
            forest.append(list(line))

    indexRow = 0
    indexColumn = 0
    for row in forest:
        indexColumn = 0
        if indexRow == 0 or indexRow == (len(forest) - 1):
            total += len(row)
            indexRow += 1
            continue
        
        topEdge = forest[:indexRow]
        bottomEdge = forest[indexRow + 1:]

        for tree in row:
            if indexColumn == 0 or indexColumn == (len(row) - 1):
                total += 1
                indexColumn += 1
                continue
            leftEdge = row[:indexColumn]
            rightEdge = row[indexColumn + 1:]

            leftEdge.sort(reverse = True)
            rightEdge.sort(reverse = True)

            if tree > leftEdge[0]:
                total += 1
                indexColumn += 1
                continue
            
            if tree > rightEdge[0]:
                total += 1
                indexColumn += 1
                continue
            
            depth = 0
            timeToEdge = len(topEdge)
            for row2 in topEdge:
                if row2[indexColumn] >= tree:
                    break
                depth += 1
            
            if (depth == timeToEdge):
                total += 1
                indexColumn += 1
                continue

            depth = 0
            timeToEdge = len(bottomEdge)
            for row2 in bottomEdge:
                if row2[indexColumn] >= tree:
                    break
                depth += 1

            if (depth == timeToEdge):
                total += 1
                indexColumn += 1
                continue

            indexColumn += 1

        indexRow += 1

    print(total)

countTrees()