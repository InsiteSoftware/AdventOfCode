# %%
f = open("input", "r")
rucksacks = f.read().splitlines()

# %%
# "a" = ord("a") - 96
# "A" = ord("A") - 38
total = 0
for rucksack in rucksacks:
  compartment1 = set(rucksack[0:len(rucksack)//2])
  compartment2 = set(rucksack[len(rucksack)//2:])
  matching_set = compartment1 & compartment2
  matching_char = list(matching_set)[0]
  if matching_char.isupper():
    total = total + ord(matching_char) - 38
  else:
    total = total + ord(matching_char) - 96

print(total)

# %%
groups = []
total = 0
for i in range(0, len(rucksacks), 3):
  group_slice = slice(i, i + 3, 1)
  groups.append(rucksacks[group_slice])
for group in groups:
  r1, r2, r3 = set(group[0]), set(group[1]), set(group[2])
  matching_set = r1 & r2 & r3
  matching_char = list(matching_set)[0]
  if matching_char.isupper():
    total = total + ord(matching_char) - 38
  else:
    total = total + ord(matching_char) - 96

print(total)



