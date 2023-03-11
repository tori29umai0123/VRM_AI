using UnityEngine;
using System.IO;


public class ImageLoad : MonoBehaviour
{
    public static byte[] LoadBytes(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        byte[] result = br.ReadBytes((int)br.BaseStream.Length);
        br.Close();
        return result;
    }

    public static Texture2D readImage(string name)
    {
        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(LoadBytes(name));
        return tex;
    }
}
