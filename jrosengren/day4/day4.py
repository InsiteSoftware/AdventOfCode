# %%
f = open("input", "r")
pairs = f.read().splitlines()

def range_subset(range1, range2):
    return range1.start in range2 and range1[len(range1)-1] in range2

def range_overlap(range1, range2):
    return range1.start in range2 or range1[len(range1)-1] in range2

# %%
containing_pairs = 0
overlapping_pairs = 0
for pair in pairs:
  pair1, pair2 = pair.split(",")[0], pair.split(",")[1]
  range1 = range(int(pair1.split("-")[0]), int(pair1.split("-")[1])+1)
  range2 = range(int(pair2.split("-")[0]), int(pair2.split("-")[1])+1)
  if (range_subset(range1, range2) or range_subset(range2, range1)):
    containing_pairs += 1
  if (range_overlap(range1, range2) or range_overlap(range2, range1)):
    overlapping_pairs += 1
  
print(containing_pairs)
print(overlapping_pairs)


