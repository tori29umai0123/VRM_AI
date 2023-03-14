# VRM_AI
https://note.com/tori29umai/n/n81f3dd2343f3

VRMファイルを読み込んでChatGPTのAPIとWhisperを連携させるソフトです。
つまりVRM（3Dモデル）とOpenAIのAPIキーさえあれば3DモデルアバターのAIとおしゃべりできます。
合成音声ソフトは現在『VoicePeak、VoiceVox、COEIROINK』に対応済み。
AssistantSeikaにも仮対応しています。（https://note.com/tori29umai/n/n121642310fd4）

PythonスクリプトとUnityのコードが書ければ自由に拡張できます。

# Usage
https://github.com/tori29umai0123/VRM_AI/releases
から最新版のVRM_AI_v〇〇.zipを解凍し、config.ini、Charactor_settings.txt、を設定し、VRM_AI.exeを実行して下さい。
設定の詳細はVRM_AI_v〇〇.zip内のreadme.txtに書いてあります。

# build
自力でビルドする場合、下記のアセットが必要です。

【UniVRM（VRM 1.0及びVRM 0.x）】
https://github.com/vrm-c/UniVRM
表情制御とまばたきや口パクが干渉しないようにするには、\Assets\VRM10\Runtime\IO\Vrm10Importer.cs"のExpression.OverrideBlink（以下略）を全部書き換える必要がある。

【Advanced INI Parser】
https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706

【uLipSync】
https://github.com/hecomi/uLipSync
uLipSyncを動かすにはJobSystemとBurstCompilerが必要なのでインポートしておいてください。
サンプルスクリプト必要なのでインポートしておいてください。
 uLipSync-v〇〇〇-with-Samples.unitypackage等のwith-Samplesのunitypackageをインポートするとはじめからサンプルがついてきます。
 
【Unityの設定】
このままだと日本語フォントがTextMeshProで使えないので以下のサイトを参考に、NotoSansJP-〇〇 SDF.asset等を作成し各種コンポーネントのフォントに設定すること。 
https://taidanahibi.com/unity/text-mesh-pro/

ビルド後のアスペクトの維持に以下のスクリプトを使用しています。
https://tech.drecom.co.jp/unity-keep-windows-screen-ratio/

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）

# OpenAI_API.exe
Python製のスクリプトです。ローカルアプリAPIサーバーとしてUnityと連携します。以下解説記事。
https://note.com/tori29umai/n/n53e1db740e0b

# sample_API.py
Python製のスクリプトです。OpenAI_API.exeを使わずに独自スクリプトを使いたいとき用のサンプルです。
AItuber配信等したい人向け。

# 拡張スクリプト
有志の方が作ってくださったYoutube APIを使用して配信中のリスナーコメントに対応させる拡張スクリプトです
https://qiita.com/kamatari_san/items/ec89b53e408cbaff785a?utm_campaign=post_article&utm_medium=twitter&utm_source=twitter_share
