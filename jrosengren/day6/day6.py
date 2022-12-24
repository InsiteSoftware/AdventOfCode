# %%
f = open("input", "r")
signal = f.read()
# signal = "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
# signal = "bvwbjplbgvbhsrlpgdmjqwftvncz"
# signal = "nppdvjthqldpwncqszvftbrmjlhg"
# signal = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"
# signal = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"

# %%
# print(signal)
signal_array = [char for char in signal]
# print(signal_array)
processed = []
for char in signal_array:
  # print(processed[-4:])
  # print(f"Unique Index: {unique}")
  processed.append(char)
  if len(processed) <= 3:
    continue
  elif len(processed[-4:]) == len(set(processed[-4:])):
    break
sop = len(processed)
print(sop)

signal_array = signal_array[sop:]
# print(signal_array)
processed = []
for char in signal_array:
  processed.append(char)
  # print(processed[-14:])
  if len(processed) <= 13:
    continue
  elif len(processed[-14:]) == len(set(processed[-14:])):
    break
som = len(processed) + sop
print(som)


