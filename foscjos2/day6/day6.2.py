def findMarker():
    index = 0

    with open('input.txt', 'r') as file:
        contents = file.read()
        
        for char in contents:
            repeatSet = set(contents[(index):(index+14)])
            
            if (len(repeatSet) == 14):
                index += 14
                break

            index += 1
    
    print(index)

findMarker()