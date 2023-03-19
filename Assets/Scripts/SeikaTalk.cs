using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

//SeikaTalkで発声するスクリプト
public class SeikaTalk : MonoBehaviour
{
    public string Message;
    public string exepath;
    public string narrator;
    public string AudioDevice;
    public AudioSource source;
    public Process SeikaSay2;

    public void Awake()
    {
        GameObject Game_system = GameObject.FindGameObjectWithTag("Game_system");
        SystemSetting SystemSetting = Game_system.GetComponent<SystemSetting>();
        exepath = SystemSetting.SeikaSay2_exe;
        narrator = SystemSetting.AssistantSeika_narrator;
        AudioDevice = SystemSetting.AudioDevice;
    }
    public void SeikaTalkStart()
    {
        Message = "\"" + EditorRunTerminal.Message + "\"";
        UImanager.talking = true;
        UImanager.thinking = false;
        source = this.GetComponent<AudioSource>();
        source.clip = Microphone.Start(AudioDevice, false, EditorRunTerminal.Message.Length, 44100); // 環境によって48kHzなこともあるのでパラメタ化した方が良いかも
        Invoke("wait", 0.5f);
    }
    public void wait()
    {
        source.Play();
        var _ = SeikaSay2Run();
    }
    private async Task SeikaSay2Run()
    {
        // 発声を非同期にしていると後から来たメッセージでつぶされるのでは？
        // キューに貯める必要があるほどの発言は来ないものとして処理します。

        UnityEngine.Debug.Log("開始");
        await Task.Run(() =>
        {
            SeikaSay2 = new Process();
            SeikaSay2.StartInfo.FileName = exepath;
            SeikaSay2.StartInfo.CreateNoWindow = true;
            SeikaSay2.StartInfo.UseShellExecute = false;
            SeikaSay2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; // 最小化ではなくて非表示にしておけばいいと思う

            SeikaSay2.StartInfo.Arguments = "-cid " + narrator + " -t " + Message;
            SeikaSay2.Start();
            SeikaSay2.WaitForExit(); // 非同期ではないので発声終了までSeikaSay2は終了しない

            // ↑でWaitForExitしてるのに何故かこの処理を入れないと音声が途切れる。なんで？
            var emote_time = EditorRunTerminal.Message.Length * 50;
            Thread.Sleep(emote_time);
        });
        UnityEngine.Debug.Log("終了");
        UImanager.talking = false;
        source.Stop();
    }
}