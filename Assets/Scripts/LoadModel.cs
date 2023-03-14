using UnityEngine;
using UniVRM10;

//VRMモデルを読み込み、セットアップするスクリプト
public class LoadModel : MonoBehaviour
{
    public SystemSetting SystemSetting;
    public string VRMpath;
    public Animator animCtrl;
    public RuntimeAnimatorController anime_ctl;
    public EditorRunTerminal EditorRunTerminal;
    public uLipSyncSetup uLipSyncSetup;

    public void Start()
    {
        VRMpath = SystemSetting.VRMpath;
        Load();
    }
    public async void Load()
    {
        Vrm10Instance instance = await Vrm10.LoadPathAsync(VRMpath, canLoadVrm0X: true);
        SetModel(instance.gameObject);
    }

    void SetModel(GameObject go)
    {
        if (go != null)
        {
            animCtrl = go.GetComponent<Animator>();
            animCtrl.applyRootMotion = true;
            if (animCtrl && animCtrl.runtimeAnimatorController == null)
            {
                animCtrl.runtimeAnimatorController = anime_ctl;
            }
            //uLipSyncを設定
            uLipSyncSetup.target = go;
            uLipSyncSetup.SetupBlendShpae();
            uLipSyncSetup.SetupLipSync();

            //AudioSourceを付与
            go.AddComponent<AudioSource>();

            //CallVoiceを付与
            go.AddComponent<CallVoice>();
            EditorRunTerminal.CallVoice = go.GetComponent<CallVoice>();

            //自動表情制御設定
            go.AddComponent<Expression_Ctrl>();

            //自動まばたき設定
            go.AddComponent<VRM10Blinker>();

            //MotionCtrlを付与
            go.AddComponent<MotionCtrl>();


            if (SystemSetting.VoiceApp == "VoiceVox")
            {
                VoiceVox VoiceVox = go.AddComponent<VoiceVox>();
            }
            else if (SystemSetting.VoiceApp == "VoicePeak")
            {
                VoicePeak VoicePeak = go.AddComponent<VoicePeak>();
            }
            if (SystemSetting.VoiceApp == "COEIROINK")
            {
                COEIROINK COEIROINK = go.AddComponent<COEIROINK>();
            }
            if (SystemSetting.VoiceApp == "AssistantSeika")
            {
                SeikaTalk SeikaTalk = go.AddComponent<SeikaTalk>();
            }
        }
    }
}