def findSignalStrength():
    result = ''
    currentLine = ''
    cycle = 1
    register = 1

    with open('input.txt', 'r') as file:
        contents = file.readlines()

        for line in contents:
            line = line.strip()
            
            if line == 'noop':
                if abs(register - len(currentLine)) <= 1:
                    currentLine += '#'
                else: 
                    currentLine += '.'
            else:
                if abs(register - len(currentLine)) <= 1:
                    currentLine += '#'
                else: 
                    currentLine += '.'

                if cycle % 40 == 0:
                    result += currentLine + '\n'
                    currentLine = ''

                cycle += 1

                if abs(register - len(currentLine)) <= 1:
                    currentLine += '#'
                else: 
                    currentLine += '.'

                register += int(line.split()[1])
            
            if cycle % 40 == 0:
                result += currentLine + '\n'
                currentLine = ''
                
            cycle += 1

    print(result)

findSignalStrength()




# noop does nothing - takes ONE cycle
# addx adds its value to the X register - takes TWO cycles
# Signal strength = cycle * X
# Find sum of signal strengths at 20th, 60th, 100th, 140th, 180th, and 220th cycles

# Pt 2: CRT Monitor
# register determines middle of a 3-pixel wide sprite

# Sprite moves avout - if it lands on a pixel currently being drawn we light that pixel up
# otherwise that pixel is a dud and it does not matter if we come back to it