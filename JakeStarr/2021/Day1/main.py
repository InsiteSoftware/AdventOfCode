from io import open

def main():
    with open("input.txt", "r") as f:
        for line in f:
            print(line, end="")

if __name__ == "__main__":
    main()