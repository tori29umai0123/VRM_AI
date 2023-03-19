using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラの位置や回転をリセットするスクリプト
//https://qiita.com/Engineer_Grotle/items/5b4a0a7673d22083e341
public class ResetPosition : MonoBehaviour
{
    private Vector3 _initialPosition; // 初期位置
    private Quaternion _initialRotation; // 初期回転


    private void Awake()
    {
        var exefile = Get_ParentDirectory.GetParentDirectory(Application.dataPath, 1);
        var inifile = exefile + "/config.ini";
        INIParser ini = new INIParser();
        ini.Open(inifile);
        var pos_x_string = ini.ReadValue("Camera_setting", "pos_x", "");
        var pos_x = float.Parse(pos_x_string);
        var pos_y_string = ini.ReadValue("Camera_setting", "pos_y", "");
        var pos_y = float.Parse(pos_y_string);
        var pos_z_string = ini.ReadValue("Camera_setting", "pos_z", "");
        var pos_z = float.Parse(pos_z_string);

        var angle_x_string = ini.ReadValue("Camera_setting", "angle_x", "");
        var angle_x = float.Parse(angle_x_string);
        var angle_y_string = ini.ReadValue("Camera_setting", "angle_y", "");
        var angle_y = float.Parse(angle_y_string);
        var angle_z_string = ini.ReadValue("Camera_setting", "angle_z", "");
        var angle_z = float.Parse(angle_z_string);
        ini.Close();
        Transform myTransform = this.transform;

        Vector3 worldPos = myTransform.position;
        worldPos.x = pos_x;
        worldPos.y = pos_y;
        worldPos.z = pos_z;
        gameObject.transform.position = worldPos;
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = angle_x;
        worldAngle.y = angle_y;
        worldAngle.z = angle_z;
        var worldAngle_qua = Quaternion.Euler(worldAngle);
        gameObject.transform.rotation = worldAngle_qua;
    }
    void Start()
    {
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