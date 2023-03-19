using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

//�A�v���N�����ɕK�v�ȘA�g���A�v�����N�����A�I�����ɕ���X�N���v�g

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
        // �{���Ȃ特���������i�̋N���m�F�����������ɓ���B
        // �����3�b�Ԃ̑҂������鎖�ɂ���
        Thread.Sleep(1000*3);

        // AssistantSeika�̋N���Ɛ��i�X�L�������s
        Seikactl_BOOTSEQUENCE();
    }

    private void Seikactl_BOOTSEQUENCE()
    {
        Seikactl = new Process();
        Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
        Seikactl.StartInfo.Arguments = @"boot """ + SystemSetting.AssistantSeika_path + @"""";
        Seikactl.Start();
        Seikactl.WaitForExit();

        if( Seikactl.ExitCode == 0)
        {
            Seikactl = new Process();
            Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
            Seikactl.StartInfo.Arguments = "waitboot 300"; // �ő�300�b(5��)�҂�
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
                    // AssistantSeika�̐��i�X�L�����Ɏ��s�����̂ŃG���[�̏����������ɓ���
                }
            }
            else
            {
                // AssistantSeika�ƒʐM���ł��Ȃ��̂ŃG���[�̏����������ɓ���
            }
        }
        else
        {
            // AssistantSeika�̋N���Ɏ��s�����̂ŃG���[�̏����������ɓ���
        }

    }

    private void OnApplicationQuit()
    {
        if (SystemSetting.InputMode != "script")
        {
            OpenAI_API_Exit();
        }
        VoiceVox_Exit();
        COEIROINK_Exit();
        AssistantSeika_Exit();
    }

    public void OpenAI_API_Exit()
    {
        //OpenAI_API.Kill();���Ƒ��v���Z�X���E���Ȃ��̂Ŗ��O�Ŏw�肵��kill
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
    public void AssistantSeika_Exit()
    {
        // AssistantSeika�̒�~�B
        Seikactl_SHUTDOWNSEQUENCE();

        // AssistantSeika�̌�ɉ����������i���I������
        Seika_Voice.Kill();
    }

    private void Seikactl_SHUTDOWNSEQUENCE()
    {
        Seikactl = new Process();
        Seikactl.StartInfo.FileName = SystemSetting.Seikactl_exe;
        Seikactl.StartInfo.Arguments = @"shutdown";
        Seikactl.Start();
        Seikactl.WaitForExit();

        if (Seikactl.ExitCode != 0)
        {
            // AssistantSeika�̒�~�����Ɏ��s���Ă����邱�Ƃ͂Ȃ��c�c�i�蓮�Ŏ~�߂�̃��b�Z�[�W���o�����炢�H�j
        }

    }

}