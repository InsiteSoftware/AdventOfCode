from io import open

def try_parse_int(string):
    try:
        return int(string)
    except Exception:
        return 0 

def main():
    valueList = []
    total_val = 0
    highest_val = 0
    with open("input.txt", "r") as f:
        for line in f:
            val = try_parse_int(line)
            if line == "\n":
                valueList.append(total_val)

                if total_val > highest_val:
                    highest_val = total_val

                total_val = 0
                continue

            total_val += val

    total_val = 0
    print(f"Highest value: {highest_val}")

    valueList.sort(reverse=True)

    for i in range(3):
        total_val += valueList[i]

    print(total_val)
    
if __name__ == "__main__":
    main()