using UnityEngine;

public class CallVoice : MonoBehaviour
{
    public string VoiceApp;
    public static float emote_time;

    public void Awake()
    {
        GameObject Game_system = GameObject.FindGameObjectWithTag("Game_system");
        SystemSetting SystemSetting = Game_system.GetComponent<SystemSetting>();
        VoiceApp = SystemSetting.VoiceApp;
    }
    public void Speak()
    {
        if (VoiceApp == "VoiceVox")
        {
            if (this.gameObject.GetComponent<VoiceVox>() == null)
            {
                VoiceVox VoiceVox = this.gameObject.AddComponent<VoiceVox>();
                VoiceVox.VoiceVoxStart();
            }
            else
            {
                VoiceVox VoiceVox = this.gameObject.GetComponent<VoiceVox>();
                VoiceVox.VoiceVoxStart(); 
            }
        }
        else if (VoiceApp == "VoicePeak")
        {
            if (this.gameObject.GetComponent<VoicePeak>() == null)
            {
                VoicePeak VoicePeak = this.gameObject.AddComponent<VoicePeak>();
                VoicePeak.VoicePeakStart();
            }
            else
            {
                VoicePeak VoicePeak = this.gameObject.GetComponent<VoicePeak>();
                VoicePeak.VoicePeakStart();
            }
        }
    }
}