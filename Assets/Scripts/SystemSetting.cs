using UnityEngine;

//iniファイルを読み取るスクリプト。Advanced INI Parser前提
public class SystemSetting : MonoBehaviour
{
    public string VRMpath;
    public GameObject Camera;
    public string InputMode;
    public string pythonPath;
    public string scriptPath;
    public string AI_URL;

    public string VoiceApp;
    public string VoicePeak_exe;
    public string VoicePeak_out;
    public string VoicePeak_narrator;
    public string VoiceVox_exe;
    string VoiceVox_narrator_string;
    public int VoiceVox_narrator;
    public string COEIROINK_exe;
    string COEIROINK_narrator_string;
    public int COEIROINK_narrator;

    public string Seika_Voice_exe;
    public string AssistantSeika_exe;
    public string Seikactl_exe;
    public string SeikaSay2_exe;
    string AssistantSeika_narrator_string;
    public int AssistantSeika_narrator;
    public string AudioDevice;

    public string background;
    public string backgroundColor;
    public string backgroundImage;
    public string Responce_display;
    public string Responce_frame;
    public string frame_border_string;
    public int frame_border;
    public string fontColor;
    public string OutlineColor;
    public string Thickness_string;
    public float Thickness;

    public string port_string;
    public int port;


    public void Awake()
    {
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        var inifile = exefile + "/config.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        VRMpath = ini.ReadValue("VRM", "VRMpath", "");
        InputMode = ini.ReadValue("AI_Setting", "InputMode", "");
        pythonPath = ini.ReadValue("AI_Setting", "pythonPath", "");
        scriptPath = ini.ReadValue("AI_Setting", "scriptPath", "");
        AI_URL = ini.ReadValue("AI_Setting", "AI_URL", "");
        VoiceApp = ini.ReadValue("AI_Voice", "VoiceApp", "");
        VoicePeak_exe = ini.ReadValue("AI_Voice", "VoicePeak_exe", "");
        VoicePeak_out = ini.ReadValue("AI_Voice", "VoicePeak_out", "");
        VoicePeak_narrator = ini.ReadValue("AI_Voice", "VoicePeak_narrator", "");
        VoiceVox_exe = ini.ReadValue("AI_Voice", "VoiceVox_exe", "");
        VoiceVox_narrator_string = ini.ReadValue("AI_Voice", "VoiceVox_narrator", "");
        VoiceVox_narrator = int.Parse(VoiceVox_narrator_string);
        COEIROINK_exe = ini.ReadValue("AI_Voice", "COEIROINK_exe", "");
        COEIROINK_narrator_string = ini.ReadValue("AI_Voice", "COEIROINK_narrator", "");
        COEIROINK_narrator = int.Parse(COEIROINK_narrator_string);

        Seika_Voice_exe = ini.ReadValue("AssistantSeika", "Seika_Voice_exe", "");
        AssistantSeika_exe = ini.ReadValue("AssistantSeika", "AssistantSeika_exe", "");
        Seikactl_exe = ini.ReadValue("AssistantSeika", "Seikactl_exe", "");
        SeikaSay2_exe = ini.ReadValue("AssistantSeika", "SeikaSay2_exe", "");
        AssistantSeika_narrator_string = ini.ReadValue("AssistantSeika", "AssistantSeika_narrator", "");
        AssistantSeika_narrator = int.Parse(AssistantSeika_narrator_string);
        AudioDevice = ini.ReadValue("AssistantSeika", "AudioDevice", "");

        background = ini.ReadValue("Other", "BackGround", "");
        Responce_display = ini.ReadValue("Other", "Responce_display", "");
        Responce_frame = ini.ReadValue("Other", "Responce_frame", "");
        frame_border_string = ini.ReadValue("Other", "frame_border", "");
        frame_border = int.Parse(frame_border_string);
        fontColor = ini.ReadValue("Other", "fontColor", "");
        OutlineColor = ini.ReadValue("Other", "OutlineColor", "");
        Thickness_string = ini.ReadValue("Other", "Thickness", "");
        Thickness = float.Parse(Thickness_string);
        port_string = ini.ReadValue("OpenAI_API", "port", "");
        port = int.Parse(port_string);
        ini.Close();
    }

    private void OnApplicationQuit()
    {
        //iniファイルにカメラ位置書き込み
        Transform myTransform = Camera.transform;
        Vector3 worldPos = myTransform.position;
        float pos_x = worldPos.x;
        float pos_y = worldPos.y;
        float pos_z = worldPos.z;
        Vector3 worldAngle = myTransform.eulerAngles;
        float angle_x = worldAngle.x;
        float angle_y = worldAngle.y;
        float angle_z = worldAngle.z;
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        var inifile = exefile + "/config.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        ini.WriteValue("Camera_setting", "pos_x", pos_x);
        ini.WriteValue("Camera_setting", "pos_y", pos_y);
        ini.WriteValue("Camera_setting", "pos_z", pos_z);
        ini.WriteValue("Camera_setting", "angle_x", angle_x);
        ini.WriteValue("Camera_setting", "angle_y", angle_y);
        ini.WriteValue("Camera_setting", "angle_z", angle_z);
        ini.Close();
    }

}
