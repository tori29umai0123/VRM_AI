using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using NekomimiDaimao;

public class VoicetoText : MonoBehaviour
{
    public UImanager UImanager;
    public const string URL = "http://127.0.0.1:5001/";
    public MicRecorder MicRecorder;
    public float muteDuration = 1f;
    public bool VolumeON = false;
    public bool first_voice = false;

    public void ClickRec()
    {
        if (!UImanager.recording)
        {
            UImanager.recording = true;
            MicRecorder.StartRecord();
            first_voice = false;
        }
    }
    public void Update()
    {
        if (UImanager.recording)
        {
            if (MicRecorder.Audio_Volume < 0.1f)
            {
                VolumeON = false;
                StartCoroutine(CheckVolume());
            }
            else
            {
                VolumeON = true;
            }
        }
    }

    IEnumerator CheckVolume()
    {
        float muteTime = 0f; // tracks how long TestON has been false
        while (true)
        {
            if (VolumeON)
            {
                muteTime = 0f; // reset test timer
                if (!first_voice)
                {
                    first_voice = true;
                }
            }
            else
            {
                muteTime += Time.deltaTime; // increment test timer
                if (muteTime >= muteDuration & UImanager.recording)
                {
                    if (first_voice)
                    {
                        StartCoroutine("StopRecord");
                    }
                }
            }
            yield return null; // wait for the next frame to check TestON again
        }
    }

    IEnumerator StopRecord()
    {
        UImanager.recording = false;
        UImanager.listening = true;
        yield return StartCoroutine(MicRecorder.StopRecord());
        StartCoroutine("OnSend", URL);
    }

    IEnumerator OnSend(string url)
    {
        WWWForm form = new WWWForm();
        using UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();
        UnityEngine.Debug.Log(webRequest.downloadHandler.text);
        var responce = webRequest.downloadHandler.text;
        UImanager.recognizeText.text = responce;
        UImanager.listening = false;
    }
}