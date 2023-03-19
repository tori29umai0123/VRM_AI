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
        AssistantSeika = new Process();
        AssistantSeika.StartInfo.FileName = SystemSetting.AssistantSeika_exe;
        AssistantSeika.Start();
        Invoke("Seikactl_RUN", 3);
    }

    public void Seikactl_RUN()
    {
        Seikactl = new Process();
        Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
        Seikactl.StartInfo.Arguments = " prodscan";
        Seikactl.Start();
    }

    private void OnApplicationQuit()
    {
        var _ = AppExit();
    }

    private async Task AppExit()
    {
        await Task.Run(() =>
        {
            if (VoiceVox != null)
            {
                VoiceVox.Kill();
            }

            if (COEIROINK != null)
            {
                COEIROINK.CloseMainWindow();
            }

            if (Seika_Voice != null)
            {
                Seika_Voice.CloseMainWindow();
            }

            if (AssistantSeika != null)
            {
                AssistantSeika.CloseMainWindow();
            }

            //名前で指定してkill
            System.Diagnostics.Process[] ps1 = System.Diagnostics.Process.GetProcessesByName("OpenAI_API");
            foreach (System.Diagnostics.Process p in ps1)
            {
                p.Kill();
            }

            System.Diagnostics.Process[] ps2 = System.Diagnostics.Process.GetProcessesByName("PetitGate32w");
            foreach (System.Diagnostics.Process p in ps2)
            {
                p.Kill();
            }
            System.Diagnostics.Process[] ps3 = System.Diagnostics.Process.GetProcessesByName("PetitGate64w");
            foreach (System.Diagnostics.Process p in ps3)
            {
                p.Kill();
            }
            System.Diagnostics.Process[] ps4 = System.Diagnostics.Process.GetProcessesByName("PetitGateHttpw");
            foreach (System.Diagnostics.Process p in ps4)
            {
                p.Kill();
            }
            System.Diagnostics.Process[] ps5 = System.Diagnostics.Process.GetProcessesByName("Seikactl");
            foreach (System.Diagnostics.Process p in ps5)
            {
                p.CloseMainWindow();
            }
            System.Diagnostics.Process[] ps6 = System.Diagnostics.Process.GetProcessesByName("SeikaSay2");
            foreach (System.Diagnostics.Process p in ps6)
            {
                p.Kill();
            }
            Thread.Sleep(3000);
        });
        UnityEngine.Debug.Log("終了");
    }
}