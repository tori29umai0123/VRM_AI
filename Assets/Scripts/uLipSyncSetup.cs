using UnityEngine;
using System.Collections.Generic;

public class uLipSyncSetup : MonoBehaviour
{
    [System.Serializable]
    public class PhonemeBlendShapeInfo
    {
        public string phoneme;
        public string blendShapeClip;
    }

    public GameObject target;
    public uLipSync.Profile profile;
    public PhonemeBlendShapeInfo[] phonemeBlendShapeTable = new PhonemeBlendShapeInfo[]
    { 
        new PhonemeBlendShapeInfo(){phoneme = "A", blendShapeClip = "aa"},
        new PhonemeBlendShapeInfo(){phoneme = "I", blendShapeClip = "ih"},
        new PhonemeBlendShapeInfo(){phoneme = "U", blendShapeClip = "ou"},
        new PhonemeBlendShapeInfo(){phoneme = "E", blendShapeClip = "ee"},
        new PhonemeBlendShapeInfo(){phoneme = "O", blendShapeClip = "oh"},
    };
    public uLipSync.uLipSync _lipsync;
    public uLipSync.uLipSyncExpressionVRM _blendShape;



    public void Start()
    {
        if (!target) return;
        SetupBlendShpae();
        SetupLipSync();
    }

    public void SetupBlendShpae()
    {
        _blendShape = target.AddComponent<uLipSync.uLipSyncExpressionVRM>();
        foreach (var info in phonemeBlendShapeTable)
        {
            _blendShape.AddBlendShape(info.phoneme, info.blendShapeClip);
        }
    }
    public void SetupLipSync()
    {
        if (!_blendShape) return;

        _lipsync = target.AddComponent<uLipSync.uLipSync>();
        _lipsync.profile = profile;
        _lipsync.onLipSyncUpdate.AddListener(_blendShape.OnLipSyncUpdate);
    }
}