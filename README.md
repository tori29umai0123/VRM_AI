# VRM_AI
VRM_AI v0.2
VRMファイルを読み込んでChatGPTのAPIとWhisperを連携させるソフトです。
Pythonスクリプトが書ければ自由に拡張できます。あくまで仮公開なので悪しからず。

# Usage
https://github.com/tori29umai0123/VRM_AI/releases
からVRM_AI_v〇〇.zipを解凍し、VRM_AI_v〇〇\setteing.ini、VRM_AI_v〇〇\OpenAI_API\config.ini、VRM_AI_v〇〇\OpenAI_API\system_settings.txt、を設定し、VRM_AI.exeを実行して下さい。
設定の詳細はからVRM_AI_v〇〇.zip内のreadme.txtに書いてあります。

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

※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）
