const fs = require("fs");
const readline = require("readline");

const stacks = {
  1: ["Q", "M", "G", "C", "L"],
  2: ["R", "D", "L", "C", "T", "F", "H", "G"],
  3: ["V", "J", "F", "N", "M", "T", "W", "R"],
  4: ["J", "F", "D", "V", "Q", "P"],
  5: ["N", "F", "M", "S", "L", "B", "T"],
  6: ["R", "N", "V", "H", "C", "D", "P"],
  7: ["H", "C", "T"],
  8: ["G", "S", "J", "V", "Z", "N", "H", "P"],
  9: ["Z", "F", "H", "G"],
};

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");
  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let res = "";
  for await (const line of rl) {
    const elements = line.split(" ");
    const movingAmount = elements[1];
    const from = elements[3];
    const to = elements[5];
    for (let i = 1; i <= movingAmount; i++) {
      const movingNumber = stacks[from].pop();
      if (movingNumber) {
        stacks[to].push(movingNumber);
      }
    }
  }

  for (const key in stacks) {
    if (stacks[key].length === 0) {
      continue;
    }
    res += stacks[key].pop();
  }
  console.log(res);
}
getResult();

async function getSecondResult() {
  const fileStream = fs.createReadStream("input.txt");
  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let res = "";
  for await (const line of rl) {
    const elements = line.split(" ");
    const movingAmount = elements[1];
    const from = elements[3];
    const to = elements[5];

    if (stacks[from].length > 0) {
      if (movingAmount === 1) {
        const movingNumber = stacks[from].pop();
        stacks[to].push(movingNumber);
      } else {
        const movingStack = stacks[from].slice(
          stacks[from].length - movingAmount
        );
        stacks[to] = stacks[to].concat(movingStack);
        stacks[from] = stacks[from].slice(
          0,
          stacks[from].length - movingAmount
        );
      }
    } else {
      continue;
    }
  }

  for (const key in stacks) {
    if (stacks[key].length === 0) {
      continue;
    }
    res += stacks[key].pop();
  }
  console.log(res);
}

getSecondResult();
