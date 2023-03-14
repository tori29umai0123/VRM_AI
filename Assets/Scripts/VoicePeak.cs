using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.Networking;
using System.Collections;

//VoicePeakで発声するスクリプト
public class VoicePeak : MonoBehaviour
{
    public string Message;
    public string exepath;
    public string outpath;
    public string wavpath;
    public string narrator;
    public float emote_time;
    public Process exProcess;

    public void Awake()
    {
        GameObject Game_system = GameObject.FindGameObjectWithTag("Game_system");
        SystemSetting SystemSetting = Game_system.GetComponent<SystemSetting>();
        exepath = SystemSetting.VoicePeak_exe;
        outpath = "\"" + Application.temporaryCachePath + "/output.wav" + "\"";
        narrator = "\"" + SystemSetting.VoicePeak_narrator + "\"";
        wavpath = Application.temporaryCachePath + "/output.wav";
    }
    public void VoicePeakStart()
    {
        Message = "\"" + EditorRunTerminal.Message + "\"";
        var _ = SpeakAsync();
    }

    private async Task SpeakAsync()
    {
        UnityEngine.Debug.Log("開始");
        await Task.Run(() =>
        {
            exProcess = new Process();
            exProcess.StartInfo.FileName = exepath;
            exProcess.StartInfo.Arguments = "-s " + Message + " -n " + narrator + " -o " + outpath;

            //実行
            exProcess.Start();
            exProcess.WaitForExit();

            Thread.Sleep(1000);
        });
        UnityEngine.Debug.Log("終了");
        StartCoroutine("Play");
    }

    IEnumerator Play()
    {
        var source = this.GetComponent<AudioSource>();
        using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip("file://" + wavpath, AudioType.WAV))
        {
            ((DownloadHandlerAudioClip)req.downloadHandler).streamAudio = true;
            req.SendWebRequest();
            while (!req.isDone)
            {
                yield return null;
            }
            var outwav = DownloadHandlerAudioClip.GetContent(req);
            source.clip = outwav;
            emote_time = source.clip.length;
            source.Play();
            UImanager.talking = true;
            UImanager.thinking = false;
            StartCoroutine("Talking_Off");
        }
    }

    IEnumerator Talking_Off()
    {
        yield return new WaitForSeconds(emote_time);
        UImanager.talking = false;
    }

}
