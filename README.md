# VRM_AI
https://note.com/tori29umai/n/n81f3dd2343f3

VRMファイルを読み込んでChatGPTのAPIとWhisperを連携させるソフトです。
つまりVRM（3Dモデル）とOpenAIのAPIキーさえあれば3DモデルアバターのAIとおしゃべりできます。
Pythonスクリプトが書ければ自由に拡張できます。あくまで仮公開なので悪しからず。

# Usage
https://github.com/tori29umai0123/VRM_AI/releases
から最新版のVRM_AI_v〇〇.zipを解凍し、config.ini、Charactor_settings.txt、を設定し、VRM_AI.exeを実行して下さい。
設定の詳細はVRM_AI_v〇〇.zip内のreadme.txtに書いてあります。  
※ これは元の @tori29umai0123 さんが公開されているものです。本リポジトリのものはまだビルド済み実行ファイルはありません。


# build
自力でビルドする場合、下記のアセットが必要です。

【UniVRM（VRM 1.0及びVRM 0.x）】
https://github.com/vrm-c/UniVRM  
Unityエディタ初回起動時に、自動で利用可能となります。  
表情制御とまばたきや口パクが干渉しないようにするには、\Assets\VRM10\Runtime\IO\Vrm10Importer.cs"のExpression.OverrideBlink（以下略）を全部書き換える必要がある。

【Advanced INI Parser】
https://assetstore.unity.com/packages/tools/advanced-ini-parser-23706  
アセットストアからインポートしていただく必要があります。

【Selected U3D Japanese Font】
https://assetstore.unity.com/packages/2d/fonts/selected-u3d-japanese-font-337  
アセットストアからインポートしていただく必要があります。  
日本語フォントとして使用しています。

【uLipSync】
https://github.com/hecomi/uLipSync  
uLipSync自体は自動で利用可能となりますが、Unityエディタ起動後に Package Manager を開き、uLipSync の Samples のうち、04. VRM を追加でインポートする必要があります。


※Unity 2021.3.15f1環境で開発しました。（動作を保証するものではありません）  
※Kirurobo は 2021.3.16f で編集しました。

# OpenAI_API.exe
Python製のスクリプトです。ローカルアプリAPIサーバーとしてUnityと連携します。以下解説記事。
https://note.com/tori29umai/n/n53e1db740e0b
