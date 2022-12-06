from io import open

def process_data(data, length):
    storage = []
    for c in data:
        storage.append(c)
        if len(storage) < length:
            continue
        elif len(storage[-length:]) == len(set(storage[-length:])):
            break
    return storage

def main():
    with open("input.txt", "r") as f:
        for line in f:
            print(f"Chars processed: {len(process_data(line, 4))}")
            print(f"Chars processed before message: {len(process_data(line, 14))}")
            
    
if __name__ == "__main__":
    main()