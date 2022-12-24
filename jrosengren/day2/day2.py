# %%
f = open("input", "r")
strategy = f.read().splitlines()

# %%
# A for Rock, B for Paper, C for Scissors
# X for Rock, Y for Paper, Z for Scissors
# 1 for Rock, 2 for Paper, 3 for Scissors
# 0 for loss, 3 for draw, 6 for win
# print(f"Strategy: {strategy}")
total_score = 0
LOSS, DRAW, WIN = 0, 3, 6
X, Y, Z = 1, 2, 3
outcomes = {"A X": DRAW,
            "A Y": WIN,
            "A Z": LOSS,
            "B X": LOSS,
            "B Y": DRAW,
            "B Z": WIN,
            "C X": WIN,
            "C Y": LOSS,
            "C Z": DRAW}
for round in strategy:
  shape = globals()[round.split(" ")[1]]
  outcome = outcomes[round]
  score = shape + outcome
  total_score = total_score + score

print(f"Total score: {total_score}")



# %%
# X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
# A for Rock, B for Paper, C for Scissors
# X for Rock, Y for Paper, Z for Scissors
total_score = 0
outcomes = {"A X": [LOSS, "Z"],
            "A Y": [DRAW, "X"],
            "A Z": [WIN, "Y"],
            "B X": [LOSS, "X"],
            "B Y": [DRAW, "Y"],
            "B Z": [WIN, "Z"],
            "C X": [LOSS, "Y"],
            "C Y": [DRAW, "Z"],
            "C Z": [WIN, "X"]}
for round in strategy:
  shape = globals()[outcomes[round][1]]
  outcome = outcomes[round][0]
  score = shape + outcome
  total_score = total_score + score

print(f"Total score: {total_score}")


