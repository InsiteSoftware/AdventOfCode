from io import open

VALUE_DICT = {'a': 1, 'b': 2, 'c': 3, 'd': 4, 'e': 5, 'f': 6, 'g': 7, 'h': 8, 'i': 9, 'j': 10, 'k': 11, 'l': 12, 'm': 13, 'n': 14, 'o': 15, 'p': 16, 'q': 17, 'r': 18, 's': 19, 't': 20, 'u': 21, 'v': 22, 'w': 23, 'x': 24, 'y': 25, 'z': 26, 'A': 27, 'B': 28, 'C': 29, 'D': 30, 'E': 31, 'F': 32, 'G': 33, 'H': 34, 'I': 35, 'J': 36, 'K': 37, 'L': 38, 'M': 39, 'N': 40, 'O': 41, 'P': 42, 'Q': 43, 'R': 44, 'S': 45, 'T': 46, 'U': 47, 'V': 48, 'W': 49, 'X': 50, 'Y': 51, 'Z': 52 }

def find_duplicates(line_value):
    compartment_size = int(len(line_value) / 2)
    compartment1, compartment2 = line_value[:compartment_size], line_value[compartment_size:]
    dupes = set(compartment1).intersection(compartment2)
    return list(dupes)[0]

def find_badges(group):
    dupes = set(group[0]).intersection(group[1]).intersection(group[2])
    return list(dupes)[0]

def main():
    total_dupes = []
    total_val = 0
    all_badges = []
    badge_sum = 0
    group_size = 3
    elf_group = []

    with open("input.txt", "r") as f:
        for line in f:
            line_val = line.strip('\n')
            total_dupes.append(find_duplicates(line_val))

            print(f"{len(elf_group)}")

            if len(elf_group) < group_size:
                elf_group.append(line_val)
            
            if len(elf_group) == group_size:
                all_badges.append(find_badges(elf_group))
                elf_group = []

    for c in total_dupes:
        total_val += VALUE_DICT[c]

    for b in all_badges:
        badge_sum += VALUE_DICT[b]
    
    print(f"Total duplicated items: {total_val}")
    print(f"Sum of duplicated badges: {badge_sum}")

if __name__ == "__main__":
    main()