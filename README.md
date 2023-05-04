# [WPF] SingleExe on .NET Fw

2023.5.4(GW)

.NET Fw 製の WPFアプリ を単一exeファイルにしてみたい。

.NET なら簡単に単一ファイルにできますが、.NET Fw であればランタイムを必要としないので、単体完結exe を 小ファイルサイズで配布できる魅力があります。



### 前提

.NET Fw 4.8



### 検討まとめ

**うまくいった**

旧型式の csproj であれば単一ファイルを作成できました。

**うまくいかなかった**

- 旧型式のcsproj では ソースジェネレータが動作しませんでした。CommunityToolKit は ViewModel を .NETStandard2.0 の別プロジェクトに分けることで対応できました。

- 新形式のcsprojで単一ファイルを生成できませんでした。



### 調査で知ったこと

- Microsoft純正ツールの [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx) を使用すると .NET アセンブリを単一ファイルにマージできるそうですが、XAML が含まれる WPF には対応していないらしいです。



### References

[WPFアプリケーションをEXEひとつにまとめる - secretbase.log](https://cointoss.hatenablog.com/entry/2017/02/21/121209)

[Combining multiple assemblies into a single EXE for a WPF application | DigitallyCreated](http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application)
