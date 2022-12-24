# %%
import math

f = open("input", "r")
input = f.read().splitlines()

for line in input:
  print(line)

# %%
width = len(input[0])
height = len(input)
number_of_edges = (width * 2) + ((height - 2) * 2)

# edges to ignore: input[0], input[-1], input[1:-1][0], input[1:-1][-1]
visible = []
for row in range(1, height-1):
  for col in range(1, width-1):
    # print(row, col)
    value = int(input[row][col])
    # print(f"value: {value}")
    max_left, max_right, max_up, max_down = 0, 0, 0, 0
    for rl in range(0, col):
      # print(f"row: {input[row][rl]}")
      max_left = max(max_left, int(input[row][rl]))
      # print(f"max_left: {max_left}")
    for rr in range(col+1, width):
      # print(f"row: {input[row][rr]}")
      max_right = max(max_right, int(input[row][rr]))
      # print(f"max_right: {max_right}")
    for cu in range(0, row):
      # print(f"col: {input[cu][col]}")
      max_up = max(max_up, int(input[cu][col]))
      # print(f"max_up: {max_up}")
    for cd in range(row+1, height):
      # print(f"col: {input[cd][col]}")
      max_down = max(max_down, int(input[cd][col]))
      # print(f"max_down: {max_down}")
    # print(f"max_h: {max_h}, max_v: {max_v}")
    if value > max_left or value > max_right or value > max_up or value > max_down:
      visible.append({"row": row, "col": col})
    # print("")

print(number_of_edges + len(visible))


# %%
# width = len(input[0])
# height = len(input)
# number_of_edges = (width * 2) + ((height - 2) * 2)

viewing_distance = {}
for row in range(0, height):
  for col in range(0, width):
    # print(row, col)
    value = int(input[row][col])
    # print(f"value: {value}")
    view_left, view_right, view_up, view_down = 0, 0, 0, 0
    for vl in range(col-1, -1, -1):
      if col == 0:
        view_left = 0
      elif value > int(input[row][vl]):
        view_left += 1
      elif value <= int(input[row][vl]):
        view_left += 1
        break
    for vr in range(col+1, width):
      # print(f"vr: {vr}, {input[row][vr]}, {view_right}")
      if col == width-1:
        view_right = 0
      elif value > int(input[row][vr]):
        view_right = view_right + 1
      elif value <= int(input[row][vr]):
        view_right = view_right + 1
        break
    for vu in range(row-1, -1, -1):
      if row == 0:
        view_up = 0
      elif value > int(input[vu][col]):
        view_up = view_up + 1
      elif value <= int(input[vu][col]):
        view_up = view_up + 1
        break
    for vd in range(row+1, height):
      if row == height-1:
        view_down = 0
      elif value > int(input[vd][col]):
        view_down = view_down + 1
      elif value <= int(input[vd][col]):
        view_down = view_down + 1
        break
    viewing_distance[f"{row} {col}"] = [view_left, view_right, view_up, view_down]

# 1, 2, 1, 2
# print(viewing_distance["1 2"])
# print(viewing_distance["3 2"])
# print(viewing_distance)

scenic_score = 0
for tree in viewing_distance:
  score  = math.prod(viewing_distance[tree])
  if score > scenic_score:
    scenic_score = score
print(scenic_score)


