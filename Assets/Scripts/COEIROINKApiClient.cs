using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//https://qiita.com/Haruyama_Dev/items/5b8ac0260cdfeff47121
//COEIROINKのREST-APIクライアント
public class COEIROINKApiClient
{
    /// <summary> 基本 URL </summary>
    private const string BASE = "localhost:50031";
    /// <summary> 音声クエリ取得 URL </summary>
    private const string AUDIO_QUERY_URL = BASE + "/audio_query";
    /// <summary> 音声合成 URL </summary>
    private const string SYNTHESIS_URL = BASE + "/synthesis";

    /// <summary> 音声クエリ（Byte配列） </summary>
    private byte[] _audioQueryBytes;
    /// <summary> 音声クエリ（Json文字列） </summary>
    private string _audioQuery;
    /// <summary> 音声クリップ </summary>
    private AudioClip _audioClip;

    /// <summary> 音声クエリ（Json文字列） </summary>
    public string AudioQuery { get => _audioQuery; }
    /// <summary> 音声クリップ </summary>
    public AudioClip AudioClip { get => _audioClip; }

    /// <summary>
    /// 指定したテキストを音声合成、AudioClipとして出力
    /// </summary>
    /// <param name="speakerId">話者ID</param>
    /// <param name="text">テキスト</param>
    /// <returns></returns>
    [Obsolete]
    public IEnumerator TextToAudioClip(int speakerId, string text)
    {
        // 音声クエリを生成
        yield return PostAudioQuery(speakerId, text);

        // 音声クエリから音声合成
        yield return PostSynthesis(speakerId, _audioQueryBytes);
    }

    /// <summary>
    /// 音声合成用のクエリ生成
    /// </summary>
    /// <param name="speakerId">話者ID</param>
    /// <param name="text">テキスト</param>
    /// <returns></returns>
    public IEnumerator PostAudioQuery(int speakerId, string text)
    {
        _audioQuery = "";
        _audioQueryBytes = null;
        // URL
        string webUrl = $"{AUDIO_QUERY_URL}?speaker={speakerId}&text={text}";
        // POST通信
        using (UnityWebRequest request = new UnityWebRequest(webUrl, "POST"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            // リクエスト（レスポンスがあるまで待機）
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                // 接続エラー
                Debug.Log("AudioQuery:" + request.error);
            }
            else
            {
                if (request.responseCode == 200)
                {
                    // リクエスト成功
                    _audioQuery = request.downloadHandler.text;
                    _audioQueryBytes = request.downloadHandler.data;
                    Debug.Log("AudioQuery:" + request.downloadHandler.text);
                }
                else
                {
                    // リクエスト失敗
                    Debug.Log("AudioQuery:" + request.responseCode);
                }
            }
        }
    }

    /// <summary>
    /// 音声合成
    /// </summary>
    /// <param name="speakerID">話者ID</param>
    /// <param name="audioQuery">音声クエリ</param>
    /// <returns></returns>
    [Obsolete]
    public IEnumerator PostSynthesis(int speakerID, string audioQuery)
    {
        return PostSynthesis(speakerID, Encoding.UTF8.GetBytes(audioQuery));
    }

    /// <summary>
    /// 音声合成
    /// </summary>
    /// <param name="speakerId">話者ID</param>
    /// <param name="audioQuery">音声クエリ(Byte配列)</param>
    /// <returns></returns>
    [Obsolete]
    private IEnumerator PostSynthesis(int speakerId, byte[] audioQuery)
    {
        _audioClip = null;
        // URL
        string webUrl = $"{SYNTHESIS_URL}?speaker={speakerId}";
        // ヘッダー情報
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        using (WWW www = new WWW(webUrl, audioQuery, headers))
        {
            // レスポンスが返るまで待機
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                // エラー
                Debug.Log("Synthesis : " + www.error);
            }
            else
            {
                // レスポンス結果をAudioClipで取得
                _audioClip = www.GetAudioClip(false, false, AudioType.WAV);
            }
        }
    }
}