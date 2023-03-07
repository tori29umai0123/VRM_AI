using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MotionCtrl : MonoBehaviour
{
    public int motion;
    public Animator animCtrl;

    private int[] motionList = new int[5] { 1, 2, 3, 4, 5 };
    public void Start()
    {
        animCtrl = this.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        // もしmotionにmotionListの中の値が入っていなかったらFalseで返す。できればExceptionでエラー発生させるか、選択式にすると良いかも
        bool isMotionInList = Array.Exists(motionList, element => element == motion);
        if (isMotionInList == false)
        {
            return;
        }
        animCtrl.SetInteger("motion", motion);
    }
}