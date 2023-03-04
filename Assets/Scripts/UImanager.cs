using UnityEngine;
using Image = UnityEngine.UI.Image;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static bool thinking = false;
    public static bool recording = false;
    public static bool talking = false;
    public static bool listening = false;
    public static string MODE = "text";
    public Image AI_thinking;
    public Image Voice_rec;
    public GameObject Text_input;
    public GameObject Voice_input;
    public TMP_InputField inputField;
    public TextMeshProUGUI recognizeText;
    public TextMeshProUGUI Voice_responce;
    public GameObject Voice_send;
    public GameObject background;

    public void Update()
    {
        if (thinking)
        {
            AI_thinking.enabled = true;
            Voice_input.SetActive(false);
            Text_input.SetActive(false);
        }
        else
        {
            AI_thinking.enabled = false;
        }
        if (!thinking & MODE == "text")
        {
            Voice_input.SetActive(false);
            Text_input.SetActive(true);
        }
        else if (!thinking & MODE == "Voice")
        {
            Voice_input.SetActive(true);
            Text_input.SetActive(false);
        }
        else if (!thinking & MODE == "script")
        {
            Text_input.SetActive(false);
            Voice_input.SetActive(false);
        }
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
        if (!talking)
        {
            Voice_responce.text = "";
        }
        else
        {
            Voice_input.SetActive(false);
        }
        if (recognizeText.text != "" | Voice_responce.text != "")
        {
            background.SetActive(true);
            Text_input.SetActive(false);
        }
        else
        {
            background.SetActive(false);
        }
    }
}