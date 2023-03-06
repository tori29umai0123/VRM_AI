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
    public  string MODE = "text";
    public Image AI_thinking;
    public Image Voice_rec;
    public GameObject Text_input;
    public GameObject Voice_input;
    public TMP_InputField inputField;
    public TextMeshProUGUI recognizeText;
    public TextMeshProUGUI Voice_responce;
    public GameObject Voice_send;
    public GameObject background;
    public void Start()
    {
        MODE = SystemSetting.InputMode;
    }

    private settingAIthinking()
    {
        if (!thinking){
            AI_thinking.enabled = false;
            return;
        }
        AI_thinking.enabled = true;
        Voice_input.SetActive(false);
        Text_input.SetActive(false);
        return;
    }

    private settingInputActivation(string mode){
        isActiveText = false;
        isActiveVoice = false;
        switch(mode){
            case "text":
                isActiveText = true;
                break;
            case "voice":
                isActiveVoice = true;
                break;
            case "script":
                break;
        }
        Text_input.SetActive(isActiveText);
        Voice_input.SetActive(isActiveVoice);
    }

    private settingVoiceActivation(){
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

    private settingTalk(){
        if(talking){
            Voice_input.SetActive(false);
            return;
        }
        Voice_responce.text = "";
    }

    private recognizeVoice(){
        if (recognizeText == "" && Voice_responce.text == ""){
            background.SetActive(false);
            return;
        }
        background.SetActive(true);
        Text_input.SetActive(false);
    }

    public void Update()
    {

        settingAIthinking();
        if(!thinking){
            settingInputActivation();
        }
        settingVoiceActivation();
        settingTalk();
        recognizeVoice()

    }
}