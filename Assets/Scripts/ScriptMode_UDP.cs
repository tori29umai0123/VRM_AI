using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Diagnostics;

//https://jump1268.hatenablog.com/entry/2018/11/25/143459
public class ScriptMode_UDP : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public UImanager UImanager;
    public EditorRunTerminal EditorRunTerminal;
    static UdpClient udp;
    IPEndPoint remoteEP = null;
    int i = 0;
    public int LOCA_LPORT;
    public static string Message;
    public static string Emo;
    public static float Emo_Weight;
    public bool scriptMode;
    public string text;
    public List<string> textList = new List<string>();
    Process test_API;

    void Start()
    {
        if (SystemSetting.InputMode == "script")
        {
            var pythonPath = SystemSetting.pythonPath;
            var scriptPath = " " + SystemSetting.scriptPath;
            test_API = new Process();
            test_API.StartInfo.FileName = pythonPath;
            test_API.StartInfo.Arguments = scriptPath;
            test_API.Start();

            LOCA_LPORT = SystemSetting.port;
            udp = new UdpClient(LOCA_LPORT);
            udp.Client.ReceiveTimeout = 10000;
            Invoke("ScriptModeON", 2);
        }
    }

    public void ScriptModeON()
    {
        scriptMode = true;
    }

    IEnumerator talking()
    {
        var responce = textList[0];
        textList.RemoveAt(0);
        string[] res = responce.Split(',');
        if (res.Length == 3)
        {
            EditorRunTerminal.Emo = res[0];
            EditorRunTerminal.Emo_Weight = float.Parse(res[1]);
            EditorRunTerminal.Message = res[2];
        }
        else
        {
            EditorRunTerminal.Emo = null;
            EditorRunTerminal.Emo_Weight = 0;
            EditorRunTerminal.Message = responce;
        }
        LoadModel.CallVoice.Speak();
        UImanager.Voice_responce.text = EditorRunTerminal.Message;
        yield break;
    }

    private async Task MesageGet()
    {
        UnityEngine.Debug.Log("äJén");
        await Task.Run(() =>
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            text = Encoding.UTF8.GetString(data);
            textList.Add(text);
            Thread.Sleep(10000);
        });
        UnityEngine.Debug.Log("èIóπ");
        StartCoroutine("talking");
    }

    void Update()
    {
        if (scriptMode)
        {
            var _ = MesageGet();
        }
    }

    private void OnApplicationQuit()
    {
        test_API.Kill();
    }
}