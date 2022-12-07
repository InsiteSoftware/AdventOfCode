def findMarker():
    index = 0

    with open('input.txt', 'r') as file:
        contents = file.read()
        
        for char in contents:
            repeatSet = set(contents[(index):(index+4)])
            
            if (len(repeatSet) == 4):
                index += 4
                break

            index += 1
    
    print(index)

findMarker()