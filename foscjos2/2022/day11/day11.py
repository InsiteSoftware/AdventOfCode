def monkeyBusiness():
    result = 0
    monkeys = {}

    with open('input.txt', 'r') as file:
        contents = file.readlines()

        for line in contents:
            line = line.strip()

            print(line)

    print(result)

monkeyBusiness()