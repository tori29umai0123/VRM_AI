# VRM_AI
https://drive.google.com/drive/folders/12Zlpbs-vNHBOyW2toBeXlFWw-5XH5XCh?usp=share_link
をDLしてUnitypakageはUnityにインポートしてください。各種Pythonファイルは自分で環境を作って実行してください。

# Usage
上記のUnitypakageを動かすには以下のアセットが必要です。


UniVRM（VRM 1.0及びVRM 0.xの両バージョンが必要）：https://github.com/vrm-c/UniVRM　

Advanced INI Parser：https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706?locale=ja-JP

uLipSync：https://github.com/hecomi/uLipSync

uLipSyncを動かすにはJobSystemとBurstが必要なのでインポートしておいてください。
サンプルスクリプトも必要なのでインポートしておいてください。
uLipSync-v〇〇〇-with-Samples.unitypackage等のwith-Samplesのunitypackageをインポートするとはじめからサンプルがついてきます。

# Unity_setting
ゲームタブの解像度を1920*1080にする。

このままだと日本語フォントがTextMeshProで使えないので以下のリンクを参考にNotoSansJP-Medium SDF.assetを作成し、
各種TextMeshProコンポーネントにフォント設定すること。

https://taidanahibi.com/unity/text-mesh-pro/

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）
