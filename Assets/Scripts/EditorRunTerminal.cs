using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class EditorRunTerminal : MonoBehaviour
{
    private const string URL = "http://127.0.0.1:5000/";
    public static string Message;
    public static string Emo;
    public static float Emo_Weight;
    public UImanager UImanager;
    public string logPath = "C:/convogpt_API/Unity_scripts/log.json";

    public void RunTerminal()
    {
        UImanager.thinking = true;
        StartCoroutine("OnSend", URL);
    }

    IEnumerator OnSend(string url)
    {
        WWWForm form = new WWWForm();
        if (UImanager.MODE == "text")
        {
            form.AddField("inputtext", UImanager.inputField.text);
        }
        if (UImanager.MODE == "Voice")
        {
            form.AddField("inputtext", UImanager.recognizeText.text);
        }

        if (UImanager.MODE == "script")
        {
                form.AddField("inputtext", "script_input");
        }

        using UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();
        UnityEngine.Debug.Log(webRequest.downloadHandler.text);
        var responce = webRequest.downloadHandler.text;
        string[] res = responce.Split(',');
        Emo = res[0];
        Emo_Weight = float.Parse(res[1]);
        Message = res[2];
        LoadModel.CallVoice.Speak();
        UImanager.inputField.text = "";
        UImanager.recognizeText.text = "";
        UImanager.Voice_responce.text = Message;
    }

private void OnApplicationQuit()
    {
        if (System.IO.File.Exists(logPath))
        {
            File.Delete(@logPath);
        }
    }
}