const fs = require("fs");
const readline = require("readline");

const alpha = Array.from(Array(26)).map((e, i) => i + 65);
const alphabetUpper = alpha.map((x) => String.fromCharCode(x));
const alphabetLower = alpha.map((x) => String.fromCharCode(x).toLowerCase());
const alphabet = alphabetLower.concat(alphabetUpper);

const pointMap = {};

for (let i = 0; i < alphabet.length; i++) {
  pointMap[alphabet[i]] = i + 1;
}

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let sum = 0;
  for await (const line of rl) {
    const mid = line.length / 2;
    const p1 = line.substring(0, mid);
    const p2 = line.substring(mid);
    for (const l of p1) {
      if (p2.includes(l)) {
        sum += pointMap[l];
        break;
      }
    }
  }
  console.log(sum);
}

async function getSecondResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let sum = 0;
  let group = [];
  for await (const line of rl) {
    group.push(line);
    if (group.length === 3) {
      for (const l of group[0]) {
        if (group[1].includes(l) && group[2].includes(l)) {
          sum += pointMap[l];
          group = [];
          break;
        }
      }
    }
  }
  console.log("Final", sum);
}

getResult();
getSecondResult();
