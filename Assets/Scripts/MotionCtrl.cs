using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotionCtrl : MonoBehaviour
{
    public int motion;
    public Animator animCtrl;



    public void Start()
    {
        animCtrl = this.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        if (motion == 0)
        {
            animCtrl.SetInteger("motion", 0);
        }

        if (motion == 1)
        {
            animCtrl.SetInteger("motion", 1);
        }

        if (motion == 2)
        {
            animCtrl.SetInteger("motion", 2);
        }


        if (motion == 3)
        {
            animCtrl.SetInteger("motion", 3);
        }

        if (motion == 4)
        {
            animCtrl.SetInteger("motion", 4);
        }
    }
}
