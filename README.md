# VRM_AI
Unity3DとChatGPTを連携させることができるソフト。
VRMを読み込める。

# Usage
まだビルド版は非公開

# unitypakage
自分で開発する為にUnityで運用するには

https://drive.google.com/drive/folders/12Zlpbs-vNHBOyW2toBeXlFWw-5XH5XCh?usp=sharing
VRM_AI.unitypackageをインポートして、Pythonスクリプトの環境を各自作ってください。

また下記のアセットが必要です。インポートしてください。

UniVRM（VRM 1.0及びVRM 0.x）：https://github.com/vrm-c/UniVRM

Advanced INI Parser：https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706

uLipSync：https://github.com/hecomi/uLipSync

uLipSyncを動かすにはJobSystemとBurstCompilerが必要なのでインポートしておいてください。
サンプルスクリプト必要なのでインポートしておいてください。
uLipSync-v〇〇〇-with-Samples.unitypackage等のwith-Samplesのunitypackageをインポートするとはじめからサンプルがついてきます。

ゲームタブの解像度を1920*1080にする。

また、このままだと日本語フォントがTextMeshProで使えないので以下のサイトを参考にNotoSansJP-〇〇 SDF.assetを作成し各種コンポーネントのフォントに設定すること。
https://taidanahibi.com/unity/text-mesh-pro/

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）
