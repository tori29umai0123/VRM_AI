# VRM_AI
Unity3DとChatGPTを連携させることができるソフト。
VRMを読み込める。

# Usage
https://drive.google.com/drive/folders/12Zlpbs-vNHBOyW2toBeXlFWw-5XH5XCh?usp=sharing
をDLし、unitypakageをインポートして、Pythonスクリプトの環境を各自作ってください。

また下記のアセットが必要です。インポートしてください。

UniVRM（VRM 1.0及びVRM 0.x）：https://github.com/vrm-c/UniVRM

Advanced INI Parser：https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706?locale=ja-JP

uLipSync：https://github.com/hecomi/uLipSync

uLipSyncを動かすにはJobSystemとBurstCompilerが必要なのでインポートしておいてください。
サンプルスクリプト必要なのでインポートしておいてください。
uLipSync-v〇〇〇-with-Samples.unitypackage等のwith-Samplesのunitypackageをインポートするとはじめからサンプルがついてきます。

# Unity_setting
ゲームタブの解像度を1920*1080にする。

また、このままだと日本語フォントがTextMeshProで使えないので以下のサイトを参考にNotoSansJP-Medium SDF.assetを作成すること。
https://taidanahibi.com/unity/text-mesh-pro/

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）
