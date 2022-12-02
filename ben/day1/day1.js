const fs = require("fs");
const readline = require("readline");

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let sum = 0;
  let max = 0;
  for await (const line of rl) {
    if (line !== "") {
      sum += Number(line);
    } else {
      if (sum >= max) {
        max = sum;
      }
      sum = 0;
    }
  }
  console.log(max);
}

getResult();
