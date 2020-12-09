using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;
using UnityEngine;
// using Newtonsoft.Json;


[System.Serializable]
public class RecordedData
{
    public byte[] data;
}
[System.Serializable]
public class TextData
{
    public string data;
}
[System.Serializable]
public class ResultObj
{
    public string message;
    public string srcData;
    public int status;
    public string[] translatedData;
}


public class AppHttpClient
{
    private static string apiURL = "http://35.193.231.143:5000/";
    public static async Task<string[]> GetTranslatedSentence(string sentnce) {
        var client = new HttpClient();
        ResultObj result;
        var dataObj = new TextData();
        dataObj.data = sentnce;
        var json = JsonUtility.ToJson(dataObj);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var url = apiURL + "translate";

        var response = await client.PostAsync(url, data);
        result = JsonUtility.FromJson<ResultObj>(response.Content.ReadAsStringAsync().Result);
        // Debug.Log(result.translatedData);
        return result.translatedData;
        
    }
    public static async Task<string> GetTranslatedSentenceFromAudio(byte[] audiobyte) {
        var client = new HttpClient();
        string result = "";
        var dataObj = new RecordedData();
        dataObj.data = audiobyte;
        var json = JsonUtility.ToJson(dataObj);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var url = apiURL + "translateAudio";
               
        var response = await client.PostAsync(url, data);
        result = response.Content.ReadAsStringAsync().Result;
        Debug.Log(result);
        return "አመሰግናለው ሰላም";
    }
    
}