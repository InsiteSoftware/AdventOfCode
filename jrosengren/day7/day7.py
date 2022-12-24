# %%
from collections import defaultdict

f = open("input", "r")
input = f.readlines()

SIZE = defaultdict(int)
path = []
for line in input:
  words = line.strip().split()
  if words[1] == "ls":
    continue
  elif words[0] == "dir":
    continue
  elif words[1] == "cd":
    if words[2] == "..":
      path.pop()
    else:
      path.append(words[2])
  else:
    size = int(words[0])
    for i in range(len(path)+1):
      SIZE["/".join(path[:i])] += size

max_used = 70000000 - 30000000
total_used = SIZE["/"]
need_to_free = total_used - max_used

p1 = 0
p2 = 1e9
for k,v in SIZE.items():
  # print(k,v)
  if v <= 100000:
    p1 += v
  if v >= need_to_free:
    p2 = min(p2, v)

print(p1)
print(p2)


