 ## ドキュメンテーション方針

 Windows環境、Mac環境、Linux環境のいずれであっても、閲覧・更新ができ、また、生産性の高いドキュメント及び、ドキュメント履歴管理・レビュー運用を柔軟かつ迅速に実現するため、原則`Markdown`形式で作成し、`Pull Request` でのレビュー運用を行うものとする。

 ## Markdown 基本ルール

 GitHubでのドキュメント閲覧を前提として、GitHub仕様に準拠した`Markdown`を作成する.

 ## Markdown エディタ

 Markdown エディタはFormatter の制御を統一するために、`Visual Studio Code`及びプラグインを用いて行う。

| プラグイン 　　    | 必須 |  説明                      |
| ------------------------ | :--: | -------------------|
| Markdown All in One      |  〇  |  Markdown に必要なプラグインの多くが入っている。 |
|  Prettier   |  〇  | Markdown のフォーマットを自動整形してくれる。<br>VSCode 設定`Setting`から、`Default Formatter`を`Prettier`に設定、`Format On Save`にチェックを入れる。<br> (俺はその項目見つからなかった) |
| Text Table  |  〇  |Markdown 内でのテーブル作成が容易になる。`Ctrl`+`Shipt`+`P`で Command Pallet を起動して`create table`を選択して`n*n`指定でテーブルフォーマットが作れたり、`Ctrl+Q`２回押下で Table Mode になって編集ができる。<br>(Table Modeは改行すると表が自動生成される、ほかの機能はよくわからん) |
| Draw.io Integration             |      | 図などの作画が VSCode 内で簡単にできる。`Editable PNG`形式で作成することで、作成した図表ファイルをそのまま Markdown に埋め込める。                                                                               |
| Paste Image                     |      | クリップボードに保存した画像を`Ctrl`+`Alt`+`V`でそのままファイル化及び画像埋め込みで Marddown 内に埋め込みができる。<br>保存先パスの設定が必要。|
| Markdown Preview Github Styling |      | Markdown のプレビューが GitHub 表示に近くなる。<br>VSCode 設定`Setting`から、`Markdown-preview-github-styles: Color Theme`を`light`に設定すると、GitHub の表示により近くなる。|

## 基本ディレクトリ構成

```
これ要はざっくりこんな感じでMarkdown関連のフォルダー作って運用してけばいいんじゃね？っていう図だと思われる
.
┝ .vscode
│　└extensions.json : VSCodeで使用をリコメンドするプラグインを定義します。
┝ 01-xxx : 個別ドキュメントを格納します。フォルダ名は適宜定義します。
┝ 02-yyy : 個別ドキュメントを格納します。フォルダ名は適宜定義します。
└ assets : Markdownから参照する画像ファイルを格納するフォルダです。
 　┝ paste : クリップボードにコピーして貼り付けた画像を自動保存するフォルダです。
 　┝ 01-xxx : 入手・作成画像ファイルを手動で保存するフォルダです。フォルダ名は適宜定義します。
 　└ 02-yyy : 入手・作成画像ファイルを手動で保存するフォルダです。フォルダ名は適宜定義します。

```

## 見出しルール

ドキュメント内には`#`を用いて適切に見出しをつけることで、見出し一覧が自動で作成されて、見出しへのジャンプが容易にできたり、アンカーリンク付きのURLが取得できる。　(要はリンクが埋め込まれた文字や文章のことっぽい)

あとから情報を探しやすいように、適切な単位で見出しを区切る。

```
# 見出し1
## 見出し2
### 見出し3
#### 見出し4
##### 見出し5
###### 見出し6
```

結果↓

# 見出し1
## 見出し2
### 見出し3
#### 見出し4
##### 見出し5
###### 見出し6


## テーブル作成ルール

テーブル作成は、GitHub の仕様に基づいて作成する。

https://docs.github.com/ja/get-started/writing-on-github/working-with-advanced-formatting/organizing-information-with-tables

`Text Tables`ブラグインを導入している場合、`Ctrl`+`Shipt`+`P`で Command Pallet を起動して`create table`を選択して`n*n`指定でテーブルを作成できる。

ファイルを作成したら、Markdown 内から作成した図をそのまま呼び出せる。
作成した表は、保存すると、Formatter により自動的に列横幅などが調整される。

**補足：テーブル操作**

- 左右中央寄せの列を作る
  `-----`の行を`:---:`のように書くとその列は文字位置が中央寄せになる。

- Table Mode を切り替える
  `Ctrl`+`Q`を２回連続押下することで、Table Mode に切替らえます。Table Mode にすることで、テーブル操作が簡単に行えるようになる。

- (Table Mode)行を追加する
  テーブル末行内で`Enter`を押下すると、１行テーブルが増える。

- 行を入れ替える
  VisualStudioCode 標準の動きについては、`Alt`+上下キーで行を入れ替えれる。

- (Table Mode)列を入れ替える
  `Alt`+左右キーで列を入れ替えれる。

  ## ドキュメント内の画像参照

構成図などのイメージ及びイメージソースファイルに関しては、本リポジトリ内`assets`配下に格納して、ドキュメント内からはルート相対パスで参照するものする。(実際は臨機応変に)

例えば次のようなパスと参照方法になる。

**画像ファイルの格納パス**

```
assets/sample/sample.png

```

**Markdown での参照方法**

```

![](assets/sample/sample.png)

```

**表示のサイズ指定もできる(例)**

```

<img src="Sample/Sample.JPG" width=1000 />

```
※注意：画像参照を貼り付けるときに直前の行にテキスト行などが存在すると、プレビューでは改行されて画像が表示されるが、GitHub 上では回り込んで表示されてしまう。画像参照を設定するときは、上の行を空行を入れるように注意する。
(要は画像とか表示する文の前後は行空けろってこと。表示する環境によって変わったりするらしい)

**表示例**

<img src="MarkdownTest/ria.JPG" width=1000 />

