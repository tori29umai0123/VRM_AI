using System.Diagnostics;
using UnityEngine;

public class AutoRun_exe : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public string OpenAI_API_exe;
    public string COEIROINK_exe;
    public string VoiceVox_exe;
    Process OpenAI_API;
    Process VoiceVox;
    Process COEIROINK;

    void Start()
    {

        if (SystemSetting.InputMode != "script")
        {
            var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
            OpenAI_API_exe = exefile + "/OpenAI_API/OpenAI_API.exe";
            OpenAI_API_RUN();
        }

        if (SystemSetting.VoiceApp == "VoiceVox")
        {
            VoiceVox_exe = SystemSetting.VoiceVox_exe;
            VoiceVox_RUN();
        }
        else if (SystemSetting.VoiceApp == "COEIROINK")
        {
            COEIROINK_exe = SystemSetting.COEIROINK_exe;
            COEIROINK_RUN();
        }
    }
    public void OpenAI_API_RUN()
    {
        OpenAI_API = new Process();
        OpenAI_API.StartInfo.FileName = OpenAI_API_exe;
        OpenAI_API.Start();
    }
    public void VoiceVox_RUN()
    {
        VoiceVox = new Process();
        VoiceVox.StartInfo.FileName = VoiceVox_exe;
        VoiceVox.StartInfo.Arguments = " --host localhost";

        //実行
        VoiceVox.Start();
    }


    public void COEIROINK_RUN()
    {
        COEIROINK = new Process();
        COEIROINK.StartInfo.FileName = COEIROINK_exe;

        //実行
        COEIROINK.Start();
    }

    private void OnApplicationQuit()
    {
        if (SystemSetting.InputMode != "script")
        {
            OpenAI_API_Exit();
        }
        VoiceVox_Exit();
        COEIROINK_Exit();
    }

    public void OpenAI_API_Exit()
    {
        //OpenAI_API.Kill();だと孫プロセスが殺せないので名前で指定してkill
        System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("OpenAI_API");
        foreach (System.Diagnostics.Process p in ps)
        {
            p.Kill();
        }
    }

    public void VoiceVox_Exit()
    {
        if (VoiceVox != null)
        {
            VoiceVox.Kill();
        }
    }

    public void COEIROINK_Exit()
    {
        if (COEIROINK != null)
        {
            COEIROINK.Kill();
        }
    }
}
