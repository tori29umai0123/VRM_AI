using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotionCtrl : MonoBehaviour
{
    public int motion;
    public Animator animCtrl;

    private list motionList = [0,1,2,3,4]
    public void Start()
    {
        animCtrl = this.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        // もしmotionにmotionListの中の値が入っていなかったらFalseで返す。できればExceptionでエラー発生させるか、選択式にすると良いかも
        var isMotionInList = Array.Exists(motionList, element => element == motion);
        if (isMotionInList == false){
            return false;
        }
        animCtrl.SetInteger("motion", motion);

    }
}
