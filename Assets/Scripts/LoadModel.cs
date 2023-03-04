using UnityEngine;
using UniVRM10;
public class LoadModel : MonoBehaviour
{
    public string VRMpath = "D:/Documents/3d/Rui/Rui.vrm";
    public Animator animCtrl;
    public RuntimeAnimatorController anime_ctl;
    public static CallVoice CallVoice;
    public uLipSyncSetup uLipSyncSetup;

    public void Awake()
    {
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
            uLipSyncSetup.target = go;
            uLipSyncSetup.SetupBlendShpae();
            uLipSyncSetup.SetupLipSync();

            //AudioSourceを付与
            go.AddComponent<AudioSource>();

            //AudioSourceを付与
            go.AddComponent<CallVoice>();
            CallVoice = go.GetComponent<CallVoice>();

            //自動表情制御設定
            go.AddComponent<Expression_Ctrl>();

            //自動まばたき設定
            go.AddComponent<VRM10Blinker>();

            //MotionCtrlを付与
            go.AddComponent<MotionCtrl>();

        }
    }
}