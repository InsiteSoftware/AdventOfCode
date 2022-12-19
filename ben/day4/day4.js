const fs = require("fs");
const readline = require("readline");

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let count = 0;
  for await (const line of rl) {
    const pairs = line.split(",");
    const p1 = pairs[0].split("-");
    const p2 = pairs[1].split("-");
    if (
      (Number(p1[0]) <= Number(p2[0]) && Number(p1[1]) >= Number(p2[1])) ||
      (Number(p2[0]) <= Number(p1[0]) && Number(p2[1]) >= Number(p1[1]))
    ) {
      count += 1;
    }
  }
  console.log(count);
}

async function getSecondResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let count = 0;
  for await (const line of rl) {
    const pairs = line.split(",");
    const p1 = pairs[0].split("-");
    const p2 = pairs[1].split("-");
    if (Number(p1[1]) >= Number(p2[0]) && Number(p1[0] <= Number(p2[1]))) {
      count += 1;
    }
  }
  console.log(count);
}

getResult();
getSecondResult();
