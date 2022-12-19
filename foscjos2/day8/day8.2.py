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
            indexRow += 1
            continue
        
        topEdge = forest[:indexRow]
        topEdge.reverse()
        bottomEdge = forest[indexRow + 1:]

        for tree in row:
            left, right, top, bottom = 0, 0, 0, 0
            if indexColumn == 0 or indexColumn == (len(row) - 1):
                indexColumn += 1
                continue
            leftEdge = row[:indexColumn]
            rightEdge = row[indexColumn + 1:]
            leftEdge.reverse()

            for edge in leftEdge:
                if edge >= tree:
                    left += 1
                    break
                left += 1
            
            for edge in rightEdge:
                if edge >= tree:
                    right += 1
                    break
                right += 1
            
            for row2 in topEdge:
                if row2[indexColumn] >= tree:
                    top += 1
                    break
                top += 1

            for row2 in bottomEdge:
                if row2[indexColumn] >= tree:
                    bottom += 1
                    break
                bottom += 1

            indexColumn += 1

            if ((left * right * top * bottom) >= total):
                total = (left * right * top * bottom)

        indexRow += 1

    print(total)

countTrees()