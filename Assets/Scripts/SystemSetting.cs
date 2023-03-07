using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetting : MonoBehaviour
{
    string inifile;
    public string VRMpath;

    public string InputMode;
    public string AI_URL;
    public string whisper_URL;
    public string inVoice;

    public string VoiceApp;

    public string VoicePeak_exe;
    public string VoicePeak_out;
    public string VoicePeak_narrator;
    string VoiceVox_narrator_string;
    public int VoiceVox_narrator;
    public void Awake()
    {
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        inifile = exefile + "/setteing.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        VRMpath = ini.ReadValue("VRM", "VRMpath", "");
        InputMode = ini.ReadValue("AI_Setting", "InputMode", "");
        AI_URL = ini.ReadValue("AI_Setting", "AI_URL", "");
        whisper_URL = ini.ReadValue("AI_Setting", "whisper_URL", "");
        inVoice = ini.ReadValue("AI_Setting", "inVoice", "");
        VoiceApp = ini.ReadValue("AI_Voice", "VoiceApp", "");
        VoicePeak_exe = ini.ReadValue("AI_Voice", "VoicePeak_exe", "");
        VoicePeak_out = ini.ReadValue("AI_Voice", "VoicePeak_out", "");
        VoicePeak_narrator = ini.ReadValue("AI_Voice", "VoicePeak_narrator", "");
        VoiceVox_narrator_string = ini.ReadValue("AI_Voice", "VoiceVox_narrator", "");
        VoiceVox_narrator = int.Parse(VoiceVox_narrator_string);
        ini.Close();
    }
}
