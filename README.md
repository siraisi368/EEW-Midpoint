# EEW-Midpoint Version 1.2
<h2>このソフトは生命線(@userlifeline)氏の「P2P-Midpoint」のリスペクトソフトウェアです。</h2>
<h2>最新verは右側にあるReleaseからダウウンロードしてください。</h2>
<h2>・主な機能</h2>
 -EEW-Midpoint.exe<br>
  宛先サーバーからjson(APIデータ)をダウンロード、保存するソフトウェアです。<br>
 -https.exe<br>
  EEW-Midpointがダウンロードしてきたデータをソフトから読み込めるようにするためにlocalhost限定で公開する機能を備えています(簡易Webサーバ)<br>
<h2>・使い方</h2>
 1.EEW-Midpoint.exeを起動します(この時点ではまだEEW-Midpoint対応ソフトウェアは立ち上げないでください)<br>
 2.https.exeを起動します。初起動の際はWindowsファイアウォールのダイアログが表示されますが、「アクセスを許可する」をクリックしてください。<br>
 3.EEW-Midpoint対応ソフトウェアを起動します。<br>
<h2>・ファイル解説</h2>
 -settingsフォルダ内のsettings.json<br>
  https.exeの使用するポート番号を設定することができます。使用するソフトによって各自変更をお願いします。<br>
  主に対応ソフトで使用するポート番号は「58722」です。<br>
 -同一フォルダのsettings.json.d<br>
  settings.jsonのデフォルト設定が入っているファイルです。設定の初期化をしたい際に使います。<br>
  初期化をするときは現在のsetting.jsonを削除し、settings.json.dの「.d」の部分を削除してください。<br>
 -webフォルダ内のjsonファイル二つ<br>
  EEW-Midpointが取得先から拾ってきたjsonファイルです。消さないでください。(消しても復活します)<br>
<h2>・settings.jsonの設定例</h2>
  <br>
 ☆ポート番号「23057」(Life of the earth氏作成EEWServerポート)の場合☆<br>
  <br>
  {"port":23057}<br>
<br>
 ☆ポート番号「58733」(EEW-Midpoint予備ポート)の場合☆<br>
  <br>
  {"port":58733}<br>
<br>
上のように設定してください。(上記以外のフォーマットで設定すると起動しなくなります)<br>
<h2>・EEW-Midpoint対応ソフトウェアを開発しようと考えている方向けの情報</h2>
 -APIリスト<br>
  強震モニタEEW API: http://127.0.0.1:58722(or58733)/kyomoni.json<br>
  iedredEEW API: http://127.0.0.1:58722(or58733)/iedred.json<br>
<br>
  利用者がポート設定を変更している可能性があるため、両対応することをおすすめします(C#の場合はifやswitchでhttpリクエストを送信して反応があった方を使うように動作させる等工夫をお願いいたします。)<br>
  質問はバグ報告先のDiscordかtwitterのどちらかにお願いいたします。<br>

<h2>・使用言語</h2>
 -Python<br>
 -C#<br>

<h2>・ソースコード</h2>
 GitHub:https://github.com/siraisi368/EEW-Midpoint<br>
 ライセンス:Apache License 2.0<br>
<h2>・謝辞(敬称略)</h2>
 -原案:生命線(@userlifeline)氏作成「P2P-Midpoint」<br>
 -デバッグ:Hiromu_MGBY(@MGBY_1225)<br>
 -APIデータ提供<br>
  防災科学技術研究所(強震モニタAPI)<br>
  iedred(iedred緊急地震速報API)<br>

<h2>・バグ報告先</h2>
 -Discord:MasatoSiraisi#0014<br>
 -Twitter:@Siraisi_Ch<br>
