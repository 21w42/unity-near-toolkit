const nearAPI = require("near-api-js");
const { PRIVATE_KEY } = require("../core/config");

const { KeyPair, connect, keyStores, WalletConnection } = nearAPI;

let contract = undefined;
const accountId = "phoneiostest.testnet";
let tokenId = 45;

const init = async () => {
  const keyStore = new keyStores.InMemoryKeyStore();

  const keyPair = KeyPair.fromString(PRIVATE_KEY);
  await keyStore.setKey("testnet", accountId, keyPair);

  const config = {
    networkId: "testnet",
    keyStore, // optional if not signing transactions
    nodeUrl: "https://rpc.testnet.near.org",
    walletUrl: "https://wallet.testnet.near.org",
    helperUrl: "https://helper.testnet.near.org",
    explorerUrl: "https://explorer.testnet.near.org",
  };
  const near = await connect(config);

  const account = await near.account(accountId);

  // const response = await account.state();
  // console.log(response);

  contract = new nearAPI.Contract(account, accountId, {
    //   viewMethods: ["Nft_mint"],
    changeMethods: ["nft_mint"],
    sender: account,
  });
};

const mintNft = async () => {
  if (!contract) {
    await init();
  }
  tokenId++;
  const meta = {
    token_id: tokenId.toString(),
    receiver_id: accountId,
    token_metadata: {
      title: "NFT Soul",
      description: "NFT of a soul that belonged to a harmless ghost",
      media:
        "https://bafybeia6ts5d45np5l5dudar6gcy4a2tdxnyllv6ulxi7kjfcixcpw2p44.ipfs.dweb.link/",
    },
  };
  await contract.nft_mint({
    args: meta,
    gas: "300000000000000",
    amount: "5770000000000000000000",
  });
};

module.exports = { mintNft };
