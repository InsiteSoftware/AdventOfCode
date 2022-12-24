# %%
f = open("input", "r")
input = f.read().splitlines()

# print(input)

# %%
cycle = 1
x = 1
interesting_cycles = [20, 60, 100, 140, 180, 220]
signal_strengths = {}
for line in input:
  words = line.split()
  if words[0] == "noop":
    if cycle in interesting_cycles:
      signal_strengths[cycle] = x * cycle
    cycle += 1
    # print(f"cycle: {cycle}, x: {x}")
  elif words[0] == "addx":
    if cycle in interesting_cycles:
      signal_strengths[cycle] = x * cycle
    cycle += 1
    # print(f"cycle: {cycle}, x: {x}")
    if cycle in interesting_cycles:
      signal_strengths[cycle] = x * cycle
    x += int(words[1])
    cycle += 1
    # print(f"cycle: {cycle}, x: {x}")

# print(signal_strengths)

sum = 0
for k, v in signal_strengths.items():
  sum += v
print(sum)



# %%
x = 1
sprite = [x-1, x, x+1]
cycle = 1
pixel = 0

def render(cycle, sprite, pixel):
  row = divmod(pixel, 40)
  if row[1] == 0:
    print("")
  if row[1] in sprite:
    print("#", end="")
  else:
    print(".", end="")
  # print(row, cycle, x, sprite, pixel)
  pixel += 1
  return pixel

for line in input:
  words = line.split()
  if words[0] == "noop":
    # print(f"cycle: {cycle}, x: {x}, sprite: {sprite}")
    render(cycle, sprite, pixel)
    cycle += 1
    pixel += 1
  if words[0] == "addx":
    # print(f"cycle: {cycle}, x: {x}, sprite: {sprite}")
    render(cycle, sprite, pixel)
    cycle += 1
    pixel += 1
    # print(f"cycle: {cycle}, x: {x}, sprite: {sprite}")
    render(cycle, sprite, pixel)
    x += int(words[1])
    sprite = [x-1, x, x+1]
    cycle += 1
    pixel += 1



