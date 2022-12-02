def max3Calories():
    calorieCounts = []
    currentCals = 0

    with open('input-1.txt', 'r') as file:
        calorieList = file.readlines()

        for measurement in calorieList:
            measurement = measurement.strip()
            if (len(measurement) < 1):
                calorieCounts.append(currentCals)
                currentCals = 0
            else:
                currentCals += int(measurement)
        
        calorieCounts.sort(reverse=True)

        one,two,three = calorieCounts[0:3]

        print(one + two + three)


max3Calories();