# %%
import re
from collections import OrderedDict

f = open("starting-stacks", "r")
starting_stacks = f.read().splitlines()
f = open("move-list", "r")
move_list = f.read().splitlines()
starting_stacks = starting_stacks[:-1]
search = re.compile(r"^(\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   )$")
# search = re.compile(r"^(\[([A-Z])\]|   ) (\[([A-Z])\]|   ) (\[([A-Z])\]|   )$")

def move_crate_9000(columns, start, end, number):
  for x in range(number):
    columns[end].append(columns[start].pop())
  return columns

def move_crate_9001(columns, start, end, number):
  print(f"Starting columns: {columns}")
  columns[end].extend(columns[start][-number:])
  columns[start] = columns[start][:-number]
  print(f"Ending columns: {columns}")
  return columns

# %%
#     [D]    
# [N] [C]    
# [Z] [M] [P]
#  1   2   3 

# move 1 from 2 to 1
# move 3 from 1 to 3
# move 2 from 2 to 1
# move 1 from 1 to 2
# print(starting_stacks)
rows = OrderedDict()
index = len(starting_stacks)
columns = OrderedDict()
for column in range(9):
  column += 1
  columns[column] = []
for stack in starting_stacks:
  result = search.search(stack)
  rows[index] = result.group(2,4,6,8,10,12,14,16,18)
  index -= 1
# print(rows)
# print(columns)
for index, row in reversed(rows.items()):
  # print(index, row)
  # print(columns)
  column = 1
  for crate in row:
    if crate != None:
      columns[column].append(crate)
    column += 1
  # print(columns)
# print(columns)

# print(move_list)
for move in move_list:
  # print(move)
  result = re.search(r"move (\d+) from (\d+) to (\d+)", move)
  # columns_9000 = move_crate_9000(columns, int(result.group(2)), int(result.group(3)), int(result.group(1)))
  columns_9001 = move_crate_9001(columns, int(result.group(2)), int(result.group(3)), int(result.group(1)))
  # print(columns_9001)
  
# print(columns_9000)
# print(columns_9001)

# tops = []
# for index in columns_9000:
#   # print(index)
#   tops.append(columns_9000[index].pop())
# print("".join(tops))

tops = []
for index in columns_9001:
  # print(index)
  tops.append(columns_9001[index].pop())
print("".join(tops))

# %%



