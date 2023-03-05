using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetting : MonoBehaviour
{
    string inifile;
    public string VRMpath;

    public string InputMode;
    public string AI_URL;
    public string ChatGPT_log;
    public string whisper_URL;
    public string inVoice;

    public string VoiceApp;

    public string VOICEPEAK_exe;
    public string VOICEPEAK_out;
    public string VOICEPEAK_narrator;
    string VoiceVox_narrator_string;
    public int VoiceVox_narrator;
    public void Awake()
    {
        inifile = Application.dataPath + "/setteing.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        VRMpath = ini.ReadValue("VRM", "VRMpath", "");
        InputMode = ini.ReadValue("AI_Setting", "InputMode", "");
        AI_URL = ini.ReadValue("AI_Setting", "AI_URL", "");
        ChatGPT_log = ini.ReadValue("AI_Setting", "ChatGPT_log", "");
        whisper_URL = ini.ReadValue("AI_Setting", "whisper_URL", "");
        inVoice = ini.ReadValue("AI_Setting", "inVoice", "");
        VoiceApp = ini.ReadValue("AI_Voice", "VoiceApp", "");
        VOICEPEAK_exe = ini.ReadValue("AI_Voice", "VOICEPEAK_exe", "");
        VOICEPEAK_out = ini.ReadValue("AI_Voice", "VOICEPEAK_out", "");
        VOICEPEAK_narrator = ini.ReadValue("AI_Voice", "VOICEPEAK_narrator", "");
        VoiceVox_narrator_string = ini.ReadValue("AI_Voice", "VoiceVox_narrator", "");
        VoiceVox_narrator = int.Parse(VoiceVox_narrator_string);
        ini.Close();
    }
}
