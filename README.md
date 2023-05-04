# [WPF] SingleExe on .NET Fw

2023.5.4(GW)

.NET Fw 製の WPFアプリ を単一exeファイルにしてみたい。

.NET なら簡単に単一ファイルにできますが、.NET Fw であればランタイムを必要としないので、単体完結exe を 小ファイルサイズで配布できる魅力があります。



### 成果まとめ

旧型式の csproj であれば単一ファイルを作成できました。

が、旧型式のcsproj だと ソースジェネレータが動作しないようで、 CommunityToolkit を使用できませんでした… つらい。



### 調査で知ったこと

- Microsoft製のツールの [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx) を使用すると .NET アセンブリを単一ファイルにマージできるそうですが、XAML が含まれる WPF には対応していないらしいです。



### References

[WPFアプリケーションをEXEひとつにまとめる - secretbase.log](https://cointoss.hatenablog.com/entry/2017/02/21/121209)

[Combining multiple assemblies into a single EXE for a WPF application | DigitallyCreated](http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application)
