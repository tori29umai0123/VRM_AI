using UnityEngine;
using Image = UnityEngine.UI.Image;
using TMPro;

public class UImanager : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public static bool thinking = false;
    public static bool recording = false;
    public static bool talking = false;
    public static bool listening = false;
    public string MODE = "text";
    public Image AI_thinking;
    public Image Voice_rec;
    public GameObject Text_input;
    public GameObject Voice_input;
    public TMP_InputField text_inputField;
    public TMP_InputField voice_inputField;
    public TextMeshProUGUI Voice_responce;
    public GameObject Voice_send;
    public GameObject background;
    public void Start()
    {
        MODE = SystemSetting.InputMode;
    }

    private void settingAIthinking()
    {
        if (!thinking)
        {
            AI_thinking.enabled = false;
            return;
        }
        AI_thinking.enabled = true;
        Voice_input.SetActive(false);
        Text_input.SetActive(false);
        return;
    }

    private void settingInputActivation(string mode)
    {
        var isActiveText = false;
        var isActiveVoice = false;
        switch (mode)
        {
            case "text":
                isActiveText = true;
                isActiveVoice = false;
                break;
            case "voice":
                isActiveText = false;
                isActiveVoice = true;
                break;
            case "script":
                isActiveText = false;
                isActiveVoice = false;
                break;
        }
        Text_input.SetActive(isActiveText);
        Voice_input.SetActive(isActiveVoice);
    }

    private void settingVoiceActivation()
    {
        if (recording | listening)
        {
            Voice_send.SetActive(false);
        }
        if (recording)
        {
            Voice_rec.enabled = true;
            Voice_rec.color = new Color32(255, 0, 0, 255);
        }
        else if (listening)
        {
            Voice_rec.enabled = false;
        }
        else
        {
            Voice_rec.enabled = true;
            Voice_rec.color = new Color32(255, 255, 255, 255);
            Voice_send.SetActive(true);
        }
    }

    private void settingTalk()
    {
        if (talking & SystemSetting.Responce_display == "true")
        {
            Voice_responce.enabled = true;
            background.SetActive(true);
            return;
        }
        Voice_responce.enabled = false;
        background.SetActive(false);
    }
    public void Update()
    {
        if (!thinking & !recording & !talking & !listening)
        {
            settingInputActivation(MODE);
        }
        if (!thinking)
        {
            settingVoiceActivation();
        }
        settingAIthinking();
        settingVoiceActivation();
        settingTalk();
    }
}