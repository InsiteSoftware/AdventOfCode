const fs = require("fs");
const readline = require("readline");

const resultMap = {
  "A X": 3,
  "B X": 0,
  "C X": 6,
  "A Y": 6,
  "B Y": 3,
  "C Y": 0,
  "A Z": 0,
  "B Z": 6,
  "C Z": 3,
};

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let sum = 0;
  for await (const line of rl) {
    if (line.includes("X")) {
      sum += 1;
    } else if (line.includes("Y")) {
      sum += 2;
    } else {
      sum += 3;
    }
    sum += resultMap[line];
  }

  console.log("The sum: ", sum);
}

const pointMap = {
  "A X": 3,
  "B X": 1,
  "C X": 2,
  "A Y": 1,
  "B Y": 2,
  "C Y": 3,
  "A Z": 2,
  "B Z": 3,
  "C Z": 1,
};

const secondMap = {
  X: 0,
  Y: 3,
  Z: 6,
};
// A 1: rock,  B 2: paper, C 3:Scissors
async function getSecondResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let sum = 0;
  for await (const line of rl) {
    const game = line.split(" ");
    sum += secondMap[game[1]];
    sum += pointMap[line];
  }

  console.log("The second sum: ", sum);
}

getResult();
getSecondResult();
