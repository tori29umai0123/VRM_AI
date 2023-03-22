using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

//SeikaTalk�Ŕ�������X�N���v�g
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
        source.clip = Microphone.Start(AudioDevice, false, EditorRunTerminal.Message.Length, 44100); // ���ɂ����48kHz�Ȃ��Ƃ�����̂Ńp�����^�����������ǂ�����
        Invoke("wait", 0.5f);
    }
    public void wait()
    {
        source.Play();
        var _ = SeikaSay2Run();
    }
    private async Task SeikaSay2Run()
    {
        // ������񓯊��ɂ��Ă���ƌォ�痈�����b�Z�[�W�łԂ����̂ł́H
        // �L���[�ɒ��߂�K�v������قǂ̔����͗��Ȃ����̂Ƃ��ď������܂��B

        UnityEngine.Debug.Log("�J�n");
        await Task.Run(() =>
        {
            SeikaSay2 = new Process();
            SeikaSay2.StartInfo.FileName = exepath;
            SeikaSay2.StartInfo.CreateNoWindow = true;
            SeikaSay2.StartInfo.UseShellExecute = false;
            SeikaSay2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; // �ŏ����ł͂Ȃ��Ĕ�\���ɂ��Ă����΂����Ǝv��

            SeikaSay2.StartInfo.Arguments = "-cid " + narrator + " -t " + Message;
            SeikaSay2.Start();
            SeikaSay2.WaitForExit(); // �񓯊��ł͂Ȃ��̂Ŕ����I���܂�SeikaSay2�͏I�����Ȃ�

            // ����WaitForExit���Ă�̂ɉ��̂����̏��������Ȃ��Ɖ������r�؂��B�Ȃ�ŁH
            // �����炭���z�f�o�C�X�̍Đ��^�C�����O�̂����B
            var emote_time = EditorRunTerminal.Message.Length * 50;
            Thread.Sleep(emote_time);
        });
        UnityEngine.Debug.Log("�I��");
        UImanager.talking = false;
        source.Stop();
    }
}