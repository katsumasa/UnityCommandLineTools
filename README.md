# UnityCommandLineTools
![GitHub package.json version](https://img.shields.io/github/package-json/v/katsumasa/UnityCommandLineTools)

Unityに同梱されているCommandLineToolをスクリプトから制御する

## 概要

UnityEditorに同梱されている各種コマンドラインツールをスクリプト内から実行する為のパッケージです。


## 対応済みTools

- WebExtract
- binary2text
- diff
- mcs
- pdb2mdp

## インストール

1. Window > Package ManagerでPackage Managerを開く
2. Package Manager左上の+のプルダウンメニューからAdd package form git URL...を選択する
3. ダイアログへ`https://github.com/katsumasa/UnityCommandLineTools.git`を設定し、Addボタンを押す

## 使い方

AssetBunldeの中身を確認する為には、大まかに下記の手順となります。

1. AssetBunldを展開(WebExtract)
2. バイナリファイルを人間が読めるTextファイルへ変換する(binary2text)

### AssetBundleを展開する

1. Window > UTJ > UnityCommandLineTools > WebExtractを選択する
<br><br>
![e2c5dac8f34695ff68916aacea7ab70a](https://user-images.githubusercontent.com/29646672/178429593-f87e7bc7-ba41-4d59-bc4b-463658bef1ac.gif)
<br><br><br>
2. Open Binaryボタンを押して、目的のAssetBundleファイルを選択する
<br><br>
![d77d426e58a6a80bbd5658418b884cc1](https://user-images.githubusercontent.com/29646672/178430600-56a13895-f255-46aa-afec-9d810b2bc08f.gif)
<br><br><br>
3. Doneボタンを押してAssetBundleを展開します。
AssetBundleと同じフォルダーに{AssetBundle名}_dataというフォルダが作成され、そのフォルダー内にCAB-Hash値というファイル名のバイナリファイルが作成されます。
<br><br>
![b2936a47a2e0347126403db9fe1d2ee0](https://user-images.githubusercontent.com/29646672/178435837-96c628e3-555d-4cdc-ac68-616d00461b28.gif)
<br><br><br>

### バイナリファイルをテキストファイルへ変換する

1. Window > UTJ > UnityCommandLineTools > binary2Textを選択する
2. Open Binaryで展開されたAssetBundle(CAB-Hash値)ファイルを選択する
3. Save Asでテキストファイルの出力先を選択する
4. Doneを押す
<br><br>
![bfd60e726ed9e912882d55108fe92cb8](https://user-images.githubusercontent.com/29646672/178438515-754eee56-61ef-48c5-9cbd-ded31b50162f.gif)


ClassIDに関しては[こちら](https://docs.unity3d.com/ja/current/Manual/ClassIDReference.html)をご確認下さい。
また、[こちら](https://support.unity.com/hc/en-us/articles/217123266-How-do-I-determine-what-is-in-my-Scene-bundle-)の記事がテキストファイルの内容の理解を助けます。


## その他

不具合・要望に関してはIssuesからお問い合わせ下さい、対応の約束は出来かねますが可能であれば対応致します。

以上
