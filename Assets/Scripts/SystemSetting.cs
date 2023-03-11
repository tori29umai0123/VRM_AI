using UnityEngine;
using Image = UnityEngine.UI.Image;

public class SystemSetting : MonoBehaviour
{
    string inifile;
    public string VRMpath;

    public string InputMode;
    public string AI_URL;

    public string VoiceApp;
    public string VoicePeak_exe;
    public string VoicePeak_out;
    public string VoicePeak_narrator;
    public string VoiceVox_exe;
    string VoiceVox_narrator_string;
    public int VoiceVox_narrator;

    public string background;
    public string backgroundColor;
    public string backgroundImage;
    public string Responce_display;

    public void Awake()
    {
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        inifile = exefile + "/config.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        VRMpath = ini.ReadValue("VRM", "VRMpath", "");
        InputMode = ini.ReadValue("AI_Setting", "InputMode", "");
        AI_URL = ini.ReadValue("AI_Setting", "AI_URL", "");
        VoiceApp = ini.ReadValue("AI_Voice", "VoiceApp", "");
        VoicePeak_exe = ini.ReadValue("AI_Voice", "VoicePeak_exe", "");
        VoicePeak_out = ini.ReadValue("AI_Voice", "VoicePeak_out", "");
        VoicePeak_narrator = ini.ReadValue("AI_Voice", "VoicePeak_narrator", "");
        VoiceVox_exe = ini.ReadValue("AI_Voice", "VoiceVox_exe", "");
        VoiceVox_narrator_string = ini.ReadValue("AI_Voice", "VoiceVox_narrator", "");
        VoiceVox_narrator = int.Parse(VoiceVox_narrator_string);
        background = ini.ReadValue("Other", "BackGround", "");
        Responce_display = ini.ReadValue("Other", "Responce_display", "");
        ini.Close();
    }
}
