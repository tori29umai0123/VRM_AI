using UnityEngine;

//https://qiita.com/r-ngtm/items/8424dca8537a4dc29616
//一つ上のディレクトリを取得するスクリプト
public class Get_ParentDirectory : MonoBehaviour
{
    public static string GetParentDirectory(string filepath, int n = 1)
    {
        string dir = filepath;
        for (int i = 0; i < n; i++)
        {
            dir = System.IO.Directory.GetParent(dir).FullName;
        }
        return ConvertSystemPathToUnityPath(dir);
    }

    public static string ConvertSystemPathToUnityPath(string path)
    {
        int index = path.IndexOf("Assets");
        if (index > 0)
        {
            path = path.Remove(0, index);
        }
        return path;
    }
}
