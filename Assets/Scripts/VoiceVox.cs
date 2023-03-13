using UnityEngine;
using System.Collections;

public class VoiceVox : MonoBehaviour
{
    public string Message;
    public int narrator;
    public float emote_time;
    public void Awake()
    {
        GameObject Game_system = GameObject.FindGameObjectWithTag("Game_system");
        SystemSetting SystemSetting = Game_system.GetComponent<SystemSetting>();
        narrator = SystemSetting.VoiceVox_narrator;
    }

    public void VoiceVoxStart()
    {
        Message = EditorRunTerminal.Message;
        StartCoroutine("Play");
    }

    [System.Obsolete]
    IEnumerator Play()
    {
        UImanager.talking = true;
        UImanager.thinking = false;

        var source = this.GetComponent<AudioSource>();

        VoiceVoxApiClient client = new VoiceVoxApiClient();

        yield return client.TextToAudioClip(narrator, Message);

        if (client.AudioClip != null)
        {
            source.clip = client.AudioClip;
            emote_time = source.clip.length;
            source.Play();
            StartCoroutine("Talking_Off");
        }
    }

    IEnumerator Talking_Off()
    {
        yield return new WaitForSeconds(emote_time);
        UImanager.talking = false;
    }
}
