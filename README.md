# RentalPokemonSearcher
RentalPokemonSearcherはPWT レンタルマスターのレンタルポケモン検索ツールです.

Config.txtで各種パラメータを設定することで,
 - 性格値乱数初期SEEDの総当たり
 - レンタルポケモンの特定
 - 現在SEEDの特定
 - 消費数の表示

を行うことができます.

起動時に1~6匹のポケモンを指定することで, 順不同で検索を行い, 1匹も指定しない場合はすべての検索結果が出力されます.

指定するポケモンは以下のリンク, もしくはPokemonList.txtから確認できます.

(https://wiki.ポケモン.com//wiki/バトルサブウェイのポケモン一覧#スーパートレイン)

現在は"右のクジ"のみ対応していますが, "真ん中のクジ", "左のクジ"にも対応する予定です.

## Config.txt
 - Nazo値：バージョンに対応した値を設定.
 - VCount, Timer0：バージョンに対応した値を設定.

    【BW/BW2】全28バージョンパラメータ纏め (https://blog.bzl-web.com/entry/2020/09/18/235128)
 - Mac：6ケタのMacアドレスの内, 上4ケタをMac1, 下2ケタをMac2に設定.

    Mac：AA-BB-CC-DD-EE-FFのとき  Mac1：0xAABCCDD, Mac2：0xEEFF
 - GxFra：固定値？よくわからん
 - Frame：初代DSなら8、DSLiteなら6. よくわからん.
 - key：キー入力に対応した値を設定.
 - Prm：固定値.

 - DateTime：検索する時間を設定.
 - AddTimes：DateTimeに追加したい条件を設定. DateTime = 00:00:30, AddSeconds = 0にすれば起動時間を30秒に固定できる.
 - Count：初期SEED検索の回数を設定.
 - PIDCount：性格値乱数消費数の上限を設定.
 - CountFlag：1のとき, SEEDを1つ見つけたら終了する.
 - Drawing："R" 右のクジ, "M" 真ん中のクジ, "L" 左のクジ

## 5genSeedUnti
BW2の初期SEED検索の簡易版です. 
Config.txtの各種パラメータを参照して検索を行います.

キー入力, Timer0の値は固定. DateTimeを使用しているので秒→分→時の順番で総当たりを行っています.

ハッシュ化の処理は (https://github.com/yatsuna827/5genInitialSeedSearch) を ~~パクリ~~ 参考にしています.

## 技術的解説
PWT乱数のあれこれ (https://namofure.hatenablog.com/entry/2025/05/29/214716)

## バージョン情報
 - v1.1.0 真ん中のクジ, 左のクジに対応
 - v1.0.1 完全一致検索処理の修正
 - v1.0.0 初版

## 製作者
ジラーテ(@namofure)
