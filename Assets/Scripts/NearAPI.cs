using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;


public class NearAPI : MonoBehaviour
{   
    public static string debug_network = "local";
    private static NearAPI nearAPI;

    private static void Init()
    {
        if (nearAPI == null)
        {
            GameObject gm = new GameObject("nearAPI");
            nearAPI = gm.AddComponent<NearAPI>();
        }
    }

    public static void Mint(){
        Init();
        string jsonReq = "";
        nearAPI.StartCoroutine(SendRequest("Get", "mint", debug_network, jsonReq));
    }   

    private static IEnumerator SendRequest(string reqType, string endpoint, string network, string jsonRaw) {
        string networkURL = "";
        switch (network)
        {
            case "testnet": networkURL = "https://wallet.testnet.near.org/"; break;
            case "mainnet": networkURL = "https://wallet.mainnet.near.org/"; break;
            case "betanet": networkURL = "https://wallet.betanet.near.org/"; break;
            case "local": networkURL = "http://207.154.208.184:3000/"; break;
            default: networkURL = "http://207.154.208.184:3000/"; break;
        }

        UnityWebRequest www;
        if (reqType == "Get")
        {
            www = UnityWebRequest.Get(networkURL + endpoint);
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
        }else if(reqType == "Post")
        {
            www = UnityWebRequest.Post(networkURL + endpoint, jsonRaw);
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
        }else
        {
            yield break;
        }

        
        if(www.result != UnityWebRequest.Result.Success) {
            Debug.Log("Err");
        }
        else {
            string results = www.downloadHandler.data.ToString();
        }
    }
}
