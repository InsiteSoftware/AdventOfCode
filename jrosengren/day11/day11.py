# %%
import math

f = open("input", "r")
input = f.read()

print(input)

# %%
monkey_data = input.split("\n\n")
rounds = 10000
class Monkey:
  def __init__(self, number=None, worry_levels=None, operation=None, test=None, true=None, false=None, inspections=0):
    self.number = number
    self.worry_levels = worry_levels
    self.operation = operation
    self.test = test
    self.true = true
    self.false = false
    self.inspections = inspections

  def __repr__(self):
    return f"Monkey {self.number} has worry levels {self.worry_levels}, operation {self.operation}, test {self.test}, true {self.true}, false {self.false}, and inspections {self.inspections}"

monkeys = []
for monkey in monkey_data:
  number = monkey.split("\n")[0].split(" ")[1].split(":")[0]
  worry_levels = monkey.split("\n")[1].split(": ")[1].split(", ")
  operation = monkey.split("\n")[2].split(": ")[1].split("old ")[1].split(" ")
  test = monkey.split("\n")[3].split("by ")[1]
  true = monkey.split("\n")[4].split(": ")[1].split("monkey ")[1]
  false = monkey.split("\n")[5].split(": ")[1].split("monkey ")[1]
  monkeys.append(Monkey(number, worry_levels, operation, test, true, false))

lcm = 1
for monkey in monkeys:
  lcm *= (lcm*int(monkey.test))

for round in range(rounds):
  for monkey in monkeys:
    worry_levels = monkey.worry_levels
    operation = monkey.operation[0]
    operator = monkey.operation[1]
    true_monkey = Monkey()
    false_monkey = Monkey()
    for sub_monkey in monkeys:
      if sub_monkey.number == monkey.true:
        true_monkey = sub_monkey
      elif sub_monkey.number == monkey.false:
        false_monkey = sub_monkey
    divisor = monkey.test
    initial_worry_levels = []
    for level in worry_levels:
      if operator == "old":
        if operation == "*":
          initial_worry_levels.append(int(level) * int(level))
        elif operation == "+":
          initial_worry_levels.append(int(level) + int(level))        
      else:
        if operation == "*":
          initial_worry_levels.append(int(level) * int(operator))
        elif operation == "+":
          initial_worry_levels.append(int(level) + int(operator))
    # second_worry_levels = [int(int(i)/3) for i in initial_worry_levels]
    # for level in second_worry_levels:
    #   if level % int(divisor) == 0:
    #     true_monkey.worry_levels.append(level)
    #   else:
    #     false_monkey.worry_levels.append(level)
    #   monkey.inspections += 1
    second_worry_levels = [int(i)%lcm for i in initial_worry_levels]
    for level in second_worry_levels:
      if level % int(divisor) == 0:
        true_monkey.worry_levels.append(level)
      else:
        false_monkey.worry_levels.append(level)
      monkey.inspections += 1
    monkey.worry_levels = []

inspections = []     
for monkey in monkeys:
  inspections.append(monkey.inspections)

print(inspections)

monkey_business = sorted(inspections, reverse=True)[0] * sorted(inspections, reverse=True)[1]

print(monkey_business)



