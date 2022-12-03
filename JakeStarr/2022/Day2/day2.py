from enum import Enum
from io import open

class Points(Enum):
    LOSS = 0
    TIE = 3
    WIN = 6

class Objects(Enum):
    NONE = 0
    ROCK = 1
    PAPER = 2
    SCISSORS = 3

def determine_opp_choice(value):
    if value == "A":
        return Objects.ROCK
    elif value == "B":
        return Objects.PAPER
    elif value == "C":
        return Objects.SCISSORS

def determine_desired_outcome(value):
    if value == "X":
        return Points.LOSS
    elif value == "Y":
        return Points.TIE
    elif value == "Z":
        return Points.WIN

def determine_winner(ply, opp):
    if (ply == Objects.PAPER and opp == Objects.SCISSORS) or (ply == Objects.ROCK and opp == Objects.PAPER) or (ply == Objects.SCISSORS and opp == Objects.ROCK):
        return Points.LOSS
    elif (ply == Objects.ROCK and opp == Objects.SCISSORS) or (ply == Objects.PAPER and opp == Objects.ROCK) or (ply == Objects.SCISSORS and opp == Objects.PAPER):
        return Points.WIN
    else:
        return Points.TIE

def calculate_points_p1(value_pair):
    ply_choice = value_pair[1]
    opp_obj = determine_opp_choice(value_pair[0])
    ply_obj = Objects.NONE
    points = 0

    if ply_choice == "X":
        ply_obj = Objects.ROCK
    elif ply_choice == "Y":
        ply_obj = Objects.PAPER
    elif ply_choice == "Z":
        ply_obj = Objects.SCISSORS

    points += ply_obj.value
    points += determine_winner(ply_obj, opp_obj).value

    return points

def calculate_points_p2(value_pair):
    points = 0
    opp_obj = determine_opp_choice(value_pair[0])
    ply_obj = Objects.NONE
    desired_outcome = determine_desired_outcome(value_pair[1])

    if desired_outcome == Points.LOSS:
        if opp_obj == Objects.ROCK:
            ply_obj = Objects.SCISSORS
        elif opp_obj == Objects.PAPER:
            ply_obj = Objects.ROCK
        elif opp_obj == Objects.SCISSORS:
            ply_obj = Objects.PAPER
    elif desired_outcome == Points.TIE:
        ply_obj = opp_obj
    elif desired_outcome == Points.WIN:
        if opp_obj == Objects.ROCK:
            ply_obj = Objects.PAPER
        elif opp_obj == Objects.PAPER:
            ply_obj = Objects.SCISSORS
        elif opp_obj == Objects.SCISSORS:
            ply_obj = Objects.ROCK

    points += ply_obj.value
    points += determine_winner(ply_obj, opp_obj).value

    return points

def main():
    ply_total_points_p1 = 0
    ply_total_points_p2 = 0
    with open("input.txt", "r") as f:
        for line in f:
            val = line.split()
            ply_total_points_p1 += calculate_points_p1(val)
            ply_total_points_p2 += calculate_points_p2(val)
    print(f"Total points earned p1: {ply_total_points_p1}")
    print(f"Total points earned p2: {ply_total_points_p2}")

if __name__ == "__main__":
    main()