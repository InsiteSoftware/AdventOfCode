def maxCalories():
    maxCals = 0
    currentCals = 0
    
    with open('input-1.txt', 'r') as file:
        calorieList = file.readlines()

        for measurement in calorieList:
            measurement = measurement.strip()
            if (len(measurement) < 1):
                if (currentCals > maxCals):
                    maxCals = currentCals
                currentCals = 0
            else:
                currentCals += int(measurement)
        
        print(maxCals)


maxCalories();