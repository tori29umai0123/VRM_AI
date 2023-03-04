using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlink : MonoBehaviour {

    //public
    public float speed = 1.0f;

    //private
    private Text text;
    private Image image;
    private float time;

    private enum ObjType{
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start() {
        //アタッチしてるオブジェクトを判別
        if (this.gameObject.GetComponent<Image>()) {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }else if (this.gameObject.GetComponent<Text>()) {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }
    }

    void Update () {
        //オブジェクトのAlpha値を更新
        if (thisObjType == ObjType.IMAGE) {
            image.color = GetAlphaColor(image.color);
        }
        else if (thisObjType == ObjType.TEXT) {
            text.color = GetAlphaColor(text.color);
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}