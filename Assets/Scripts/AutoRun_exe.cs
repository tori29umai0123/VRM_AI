using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

//アプリ起動時に必要な連携をアプリを起動し、終了時に閉じるスクリプト
public class AutoRun_exe : MonoBehaviour
{
    public SystemSetting SystemSetting;
    Process OpenAI_API;
    Process VoiceVox;
    Process COEIROINK;
    Process Seika_Voice;
    Process AssistantSeika;
    Process Seikactl;

    void Start()
    {
        if (SystemSetting.InputMode != "script")
        {
            OpenAI_API_RUN();
        }

        if (SystemSetting.VoiceApp == "VoiceVox")
        {
            VoiceVox_RUN();
        }
        else if (SystemSetting.VoiceApp == "COEIROINK")
        {
            COEIROINK_RUN();
        }
        else if (SystemSetting.VoiceApp == "AssistantSeika")
        {
            AssistantSeika_RUN();
        }
    }
    public void OpenAI_API_RUN()
    {
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        var OpenAI_API_exe = exefile + "/OpenAI_API/OpenAI_API.exe";
        OpenAI_API = new Process();
        OpenAI_API.StartInfo.FileName = OpenAI_API_exe;
        OpenAI_API.Start();
    }
    public void VoiceVox_RUN()
    {
        var VoiceVox_exe = SystemSetting.VoiceVox_exe;
        VoiceVox = new Process();
        VoiceVox.StartInfo.FileName = VoiceVox_exe;
        VoiceVox.StartInfo.Arguments = " --host localhost";

        VoiceVox.Start();
    }

    public void COEIROINK_RUN()
    {
        var COEIROINK_exe = SystemSetting.COEIROINK_exe;
        COEIROINK = new Process();
        COEIROINK.StartInfo.FileName = COEIROINK_exe;

        COEIROINK.Start();
    }

    public void AssistantSeika_RUN()
    {
        Seika_Voice = new Process();
        Seika_Voice.StartInfo.FileName = SystemSetting.Seika_Voice_exe;
        Seika_Voice.Start();

        //
        // 本来なら音声合成製品の起動確認処理がここに入る。
        // 今回は3秒間の待ちを入れる事にする
        Thread.Sleep(1000 * 3);

        // AssistantSeikaの起動と製品スキャン実行
        Seikactl_BOOTSEQUENCE();
    }

    private void Seikactl_BOOTSEQUENCE()
    {
        Seikactl = new Process();
        Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
        Seikactl.StartInfo.Arguments = @"boot """ + SystemSetting.AssistantSeika_path + @"""";
        Seikactl.Start();
        Seikactl.WaitForExit();

        if (Seikactl.ExitCode == 0)
        {
            Seikactl = new Process();
            Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
            Seikactl.StartInfo.Arguments = "waitboot 300"; // 最大300秒(5分)待ち
            Seikactl.Start();
            Seikactl.WaitForExit();

            if (Seikactl.ExitCode == 0)
            {
                Seikactl = new Process();
                Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
                Seikactl.StartInfo.Arguments = "prodscan";
                Seikactl.Start();
                Seikactl.WaitForExit();

                if (Seikactl.ExitCode != 0)
                {
                    // AssistantSeikaの製品スキャンに失敗したのでエラーの処理がここに入る
                }
            }
            else
            {
                // AssistantSeikaと通信ができないのでエラーの処理がここに入る
            }
        }
        else
        {
            // AssistantSeikaの起動に失敗したのでエラーの処理がここに入る
        }

    }

    private void OnApplicationQuit()
    {
        var _ = AppExit();
    }

    private async Task AppExit()
    {
        await Task.Run(() =>
        {
            //名前で指定してkill
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("OpenAI_API");
            foreach (System.Diagnostics.Process p in ps)
            {
                p.Kill();
            }

            if (VoiceVox != null)
            {
                VoiceVox.Kill();
            }

            if (COEIROINK != null)
            {
                COEIROINK.CloseMainWindow();
            }

            if (SystemSetting.VoiceApp == "AssistantSeika")
            {
                Seika_Voice.CloseMainWindow();
                Seikactl = new Process();
                Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
                Seikactl.StartInfo.Arguments = @"shutdown";
                Seikactl.Start();
                Seikactl.WaitForExit();

                if (Seikactl.ExitCode != 0)
                {
                    // AssistantSeikaの停止処理に失敗してもやれることはない……（手動で止めろのメッセージを出すぐらい？）
                }
            }

        });
        UnityEngine.Debug.Log("終了");
    }
}