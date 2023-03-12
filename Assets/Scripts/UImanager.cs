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
    public string MODE;
    public Image AI_thinking;
    public Image Voice_rec;
    public GameObject Text_input;
    public GameObject Voice_input;
    public TMP_InputField text_inputField;
    public TMP_InputField voice_inputField;
    public TextMeshProUGUI Voice_responce;
    public GameObject Voice_send;
    public GameObject BG_responce;
    public Image BackGround;
    public Material FontMaterial;

    public void Start()
    {
        MODE = SystemSetting.InputMode;
        BG_SetupImage();
        BG_res_SetupImage();
        FontSet();
    }

    public void BG_SetupImage()
    {
        var BG = SystemSetting.background;

        if (!BG.StartsWith("#"))
        {
            var path = SystemSetting.background;
            Texture2D tex = ImageLoad.readImage(path);
            BackGround.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            return;
        }
        BackGround.color = MyColorUtility.ToColor(SystemSetting.background);
    }

    public void FontSet()
    {
        var fontColor = MyColorUtility.ToColor(SystemSetting.fontColor);
        FontMaterial.SetColor("_FaceColor", fontColor);
        var OutlineColor = MyColorUtility.ToColor(SystemSetting.OutlineColor);
        FontMaterial.SetColor("_OutlineColor", OutlineColor);
        var Thickness = SystemSetting.Thickness;
        FontMaterial.SetFloat("_OutlineWidth", Thickness);
    }

    public void BG_res_SetupImage()
    {
        var RFpatn = SystemSetting.Responce_frame;
        var res_image = BG_responce.GetComponent<Image>();
        var frame_border = SystemSetting.frame_border;
        if (RFpatn != "None")
        {
            res_image.color = new Color(1, 1, 1, 1);
            Texture2D tex = ImageLoad.readImage(RFpatn);
            res_image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero, 100.0f,0, SpriteMeshType.FullRect, new Vector4(frame_border, frame_border, frame_border, frame_border));
            return;
        }
        res_image.color = new Color(0, 0, 0, 0.9f);
    }


    private void settingAIthinking()
    {
        if (!thinking & !listening)
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
            BG_responce.SetActive(true);
            return;
        }
        Voice_responce.text = "";
        BG_responce.SetActive(false);
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