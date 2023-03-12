using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EditorRunTerminal : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public string URL;
    public static string Message;
    public static string Emo;
    public static float Emo_Weight;
    public UImanager UImanager;

    public void Start()
    {
        URL = SystemSetting.AI_URL;
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
            form.AddField("inputtext", UImanager.text_inputField.text);
        }
        if (UImanager.MODE == "voice")
        {
            form.AddField("inputtext", UImanager.voice_inputField.text);
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
        UImanager.text_inputField.text = "";
        UImanager.voice_inputField.text = "";
        UImanager.Voice_responce.text = Message;
    }
}