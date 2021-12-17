const express = require("express");
const { mintNft } = require("./near");
const app = express();
const port = 3000;

app.use((req, res, next) => {
  console.log(req.method);
  console.log(req.params);
  console.log(req.query);
  next();
});

app.get("/mint", async (req, res) => {
  await mintNft();
  res.send("Nft is minted!");
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
