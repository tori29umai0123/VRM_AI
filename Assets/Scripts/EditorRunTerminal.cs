using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class EditorRunTerminal : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public string URL;
    public static string Message;
    public static string Emo;
    public static float Emo_Weight;
    public UImanager UImanager;
    public string logPath;

    public void Start()
    {
        URL = SystemSetting.AI_URL;
        logPath = SystemSetting.ChatGPT_log;
    }

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
        if (UImanager.MODE == "voice")
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
        if (res.Length == 3)
        {
            Emo = res[0];
            Emo_Weight = float.Parse(res[1]);
            Message = res[2];
        }
        else
        {
            Emo = null;
            Emo_Weight = 0;
            Message = responce;
        }
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