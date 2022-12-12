def findSignalStrength():
    result = 0
    cycle = 1
    register = 1
    signalStrengths = {20: 0, 60: 0, 100: 0, 140: 0, 180: 0, 220: 0}

    with open('input.txt', 'r') as file:
        contents = file.readlines()

        for line in contents:
            line = line.strip()
            
            if line == 'noop':
                cycle += 1
            else:
                cycle += 1

                if cycle % 40 == 20:
                    signalStrengths[cycle] = updateSignalStrength(cycle, register)

                cycle += 1

                if cycle % 40 == 20:
                    signalStrengths[cycle] = updateSignalStrength(cycle, register)

                register += int(line.split()[1])
            
            if cycle % 40 == 20:
                signalStrengths[cycle] = updateSignalStrength(cycle, register)

    for signal in signalStrengths:
        result += signalStrengths[signal]

    print(result)

def updateSignalStrength(cycle, register):
    return cycle * register

findSignalStrength()