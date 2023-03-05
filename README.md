# VRM_AI
VRM_AI.unitypackageをDLしてインポートしてください

このスクリプトを動かすには以下のアセットが必要です。
【UniVRM】
VRM 1.0 Import/Export及び、VRM 0.x Import/Exportが必要です。
開発時使っていたのはバージョンは
VRM-0.107.2_6ea7.unitypackage
UniVRM-0.107.2_6ea7.unitypackage
です。（動作を保証するものではありません）

【Advanced INI Parser】
https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706?locale=ja-JP
が必要です。Unityアセットストアからインポートしてください。

【uLipSync】
https://github.com/hecomi/uLipSync
が必要です。
uLipSyncを動かすにはJobSystemとBurstCompilerが必要なのでインポートしておいてください。
また、そのサンプルスクリプト
04. VRM
10. Runtime Setup
が必要なのでインポートしておいてください。
uLipSync-v2.6.1-with-Samples.unitypackage
等のwith-Samplesのunitypackageをインポートするとはじめからサンプルがついてきます。

また、このままだと日本語フォントがTextMeshProで使えないので以下のサイトを参考にNotoSansJP-Medium SDF.assetを作成すること。
https://taidanahibi.com/unity/text-mesh-pro/
フォント自体は『Assets\TextMesh Pro\Resources\Fonts & Materials\NotoSansJP-Medium.otf』に入っています。

【Unity側の設定】
ゲームタブの解像度を1920*1080にする。

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）