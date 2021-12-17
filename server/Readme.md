> export ID=phoneiostest.testnet

near call $ID nft_mint '{"token_id": "10", "receiver_id": "'$ID'", "token_metadata": { "title": "NEAR Hack Badge", "description": "NFT of NEAR Hack Badge received in Kyiv, Arsenalna on 16.12.21", "media": "https://bafybeiezwejfrmigg2mefe5egfysnbrjr4iqstgleh7nwgh4vjgdpqe7oe.ipfs.dweb.link/", "copies": 1}}' --accountId $ID --deposit 0.1
