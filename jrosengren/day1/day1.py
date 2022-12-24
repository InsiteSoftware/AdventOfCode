# %%
f = open("input", "r")
text = f.read()

# %%
groups = text.split("\n\n")
elves = []
for elf in groups:
  elf_calories = elf.split("\n")
  elf_calories
  elves.append(elf_calories)

max = 0
totals = []
for elf in elves:
  total_calories = sum([int(x) for x in elf])
  totals.append(total_calories)
  if total_calories > max:
    max = total_calories

print(max)

top3 = sorted(totals, reverse=True)[:3]
total_top3 = sum([int(x) for x in top3])

print(total_top3)



