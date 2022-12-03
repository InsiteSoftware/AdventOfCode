const fs = require("fs");
const readline = require("readline");

async function getResult() {
  const fileStream = fs.createReadStream("input.txt");

  const rl = readline.createInterface({
    input: fileStream,
    crlfDelay: Infinity,
  });

  let arr = [];
  let sum = 0;
  for await (const line of rl) {
    if (line !== "") {
      sum += Number(line);
    } else {
      if (sum >= max) {
        max = sum;
      }
      arr.push(Number(sum));
      sum = 0;
    }
  }
  let sortArr = arr.sort((a, b) => b - a);
  console.log("The max: ", sortArr[0]);
  console.log("The first 3 total: ", sortArr[0] + sortArr[1] + sortArr[2]);
}

getResult();
