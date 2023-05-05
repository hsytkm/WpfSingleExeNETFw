# [WPF] SingleExe on .NET Fw

2023.5.4(GW) ~

### 目的

.NET Fw 製の WPFアプリ を単一exeファイルにできるかを知りたい。

### 背景

- .NET 環境であればオプション1つで単一ファイルを生成できますが、.NET Fw の配布の手軽さには魅力があります。（ランタイムを必要とせず、単体exe を 小サイズで配布できます。）

- サポート終了日が 最新 .NET よりも .NETFw の方が長く、商用アプリの選択候補になり得ます。（MSからは推奨されていません）

### 検討まとめ

**うまくいった点**

- 旧型式の csproj で単一ファイルを作成できました。
- 新形式の csproj でも **MahApps を導入しなければ**、 単一ファイルを作成できました。

**うまくいかなかった点**

- 旧型式のcsproj では ソースジェネレータが動作しませんでした。CommunityToolKit は ViewModel を .NETStandard2.0 の別プロジェクトに分けることで対応しました。

- 新形式のcsproj + MahApps で単一ファイルのビルドが通りませんでした。 MahApps が `Culture=de` にすることが原因のようです。 [for the ColorPicker name - Issue #2315](https://github.com/MahApps/MahApps.Metro/issues/2315#issuecomment-914944785)

### 調査で知ったこと

**自分で試していません**

- Microsoft純正ツールの [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx) を使用すると .NET アセンブリを単一ファイルにマージできるそうですが、XAML が含まれる WPF には対応していないらしいです。
- 今回試した方法は 混合モードアセンブリ だとうまく行かないらしい。(C++/CLI と結合できないってことだと思われる) 

### フレームワーク比較

.NET Fw のメジャーバージョンは リリースから 10年 サポートされるそうで、.NET LTS版の 3年 と比較して長いです。

今のリリース計画が継続した場合、2025年リリースの .NET10 (LTS) の期限が 2028年 となり、その場合でも .NET Fw 4.8 のサポート期限（2029年予定）の方が長くなります。


|               | メモ                     | Windowsプレインストール | リリース日         | サポート期限       |
| ------------- | ------------------------ | ----------------------- | ------------------ | ------------------ |
| .NET 8 (予定) | 次のLTS                  | なし                    | 未定 (2023年11月?) | 未定 (2026年11月?) |
| .NET 6        | 現在のLTS                | なし                    | 2021年11月         | 2024年11月         |
| .NET Fw 4.8.1 | 最新のFw                 | なし                    | 2022年8月9日       | 未定 (2032年?)     |
| .NET Fw 4.8   | Win11プレインストール    | Win10, 11               | 2019年4月18日      | 未定 (2029年?)     |
| .NET Fw 4.6.2 | サポート終了公表済みのFw | Win10                   | 2016年8月2日       | 2027年1月12日      |

### References

[WPFアプリケーションをEXEひとつにまとめる - secretbase.log](https://cointoss.hatenablog.com/entry/2017/02/21/121209)

[Combining multiple assemblies into a single EXE for a WPF application | DigitallyCreated](http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application)
