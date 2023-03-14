using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラの位置や回転をリセットするスクリプト
//https://qiita.com/Engineer_Grotle/items/5b4a0a7673d22083e341
public class ResetPosition : MonoBehaviour
{

    private Vector3 _initialPosition; // 初期位置
    private Quaternion _initialRotation; // 初期回転

    void Start()
    {
        // 初期位置・初期回転の取得
        _initialPosition = gameObject.transform.position;
        _initialRotation = gameObject.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }
    }

    // 初期化関数
    public void Reset()
    {
        gameObject.transform.position = _initialPosition; // 位置の初期化
        gameObject.transform.rotation = _initialRotation; // 回転の初期化
    }
}