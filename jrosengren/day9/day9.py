# %%
f = open("input", "r")
input = f.read().splitlines()

# print(input)

# %%
# knots = [[1, 1], [1, 1]]
knots = [[1, 1], [1, 1], [1, 1], [1, 1], [1, 1], [1, 1], [1, 1], [1, 1], [1, 1], [1, 1]]

def move_knot(head, tail):
  x_distance = head[0] - tail[0]
  y_distance = head[1] - tail[1]
  # print(x_distance, y_distance)
  if y_distance == 0:
    if x_distance > 1:
      return [tail[0] + 1, tail[1]]
    elif x_distance < -1:
      return [tail[0] - 1, tail[1]]
    else:
      return tail
  elif x_distance == 0:
    if y_distance > 1:
      return [tail[0], tail[1] + 1]
    elif y_distance < -1:
      return [tail[0], tail[1] - 1]
    else:
      return tail
  elif (x_distance == 1 and y_distance == 2) or (x_distance == 2 and y_distance == 1) or (x_distance == 2 and y_distance == 2):
    return [tail[0] + 1, tail[1] + 1]
  elif (x_distance == 2 and y_distance == -1) or (x_distance == 1 and y_distance == -2) or (x_distance == 2 and y_distance == -2):
    return [tail[0] + 1, tail[1] - 1]
  elif (x_distance == -1 and y_distance == -2) or (x_distance == -2 and y_distance == -1) or (x_distance == -2 and y_distance == -2):
    return [tail[0] - 1, tail[1] - 1]
  elif (x_distance == -1 and y_distance == 2) or (x_distance == -2 and y_distance == 1) or (x_distance == -2 and y_distance == 2):
    return [tail[0] - 1, tail[1] + 1]
    re
  else:
    return tail

tail_visited = []
for line in input:
  words = line.split()
  if words[0] == "R":
    for r in range(int(words[1])):
      knots[0][0] += 1
      for knot in range(1, len(knots)):
        knots[knot] = move_knot(knots[knot-1], knots[knot])
        print(f"knot: {knots[knot]}")
      tail_visited.append(knots[-1])
      print(f"head: {knots[0]}, tail: {knots[-1]}")
  elif words[0] == "L":
    for l in range(int(words[1])):
      knots[0][0] -= 1
      for knot in range(1, len(knots)):
        knots[knot] = move_knot(knots[knot-1], knots[knot])
        print(f"knot: {knots[knot]}")
      tail_visited.append(knots[-1])
      print(f"head: {knots[0]}, tail: {knots[-1]}")
  elif words[0] == "U":
    for u in range(int(words[1])):
      knots[0][1] += 1
      for knot in range(1, len(knots)):
        knots[knot] = move_knot(knots[knot-1], knots[knot])
        print(f"knot: {knots[knot]}")
      tail_visited.append(knots[-1])
      print(f"head: {knots[0]}, tail: {knots[-1]}")
  elif words[0] == "D":
    for d in range(int(words[1])):
      knots[0][1] -= 1
      for knot in range(1, len(knots)):
        knots[knot] = move_knot(knots[knot-1], knots[knot])
        print(f"knot: {knots[knot]}")
      tail_visited.append(knots[-1])
      print(f"head: {knots[0]}, tail: {knots[-1]}")
  print("")

# print(f"head: {head}, tail: {tail}")
# print(tail_visited)
unique_visited = set(tuple(i) for i in tail_visited)
# print(unique_visited)
print(len(unique_visited))


