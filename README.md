# WPF Plugin Demo

2024GW

WPFアプリの一部の機能をプラグインで提供して、外部提供する際にdllを消すことで機能を削りたい。



## お試しの感想

MEF / MEF2 の両方を試したけど MEF2 は手順が複雑で、単体アセンブリの読み込みでも時間が掛かった。（MEF2 で検索しても情報がほとんど出てこないし、MEF1 の方が楽に使えそうな印象）

さぁ MEF1 でいろいろ試すか！ と思ったところで かずきさん のまとめブログを見つけてしまい、そこに作ろうと思っていたアプリそのもの（WPFでタブを動的ロード）があったので終了。 [かずきさんアプリ](http://code.msdn.microsoft.com/Managed-Extensibility-3332350b)



## MEF（Managed Extensibility Framework）

MEFは .NET の一部として提供されるプラグインシステムです。MEFを使用すると、アプリケーションに外部からダイナミックにロード可能なコンポーネント（プラグイン）を追加できます。`System.ComponentModel.Composition` 名前空間を使用します。



## MEF2（Managed Extensibility Framework 2）

MEF2（Managed Extensibility Framework 2）は、.NET Framework 4.5から導入されたMEFの改良版であり、機能強化やパフォーマンス向上が図られています。

`System.Composition` 名前空間を使用します。



## ソースツリー

1. `MEF1` フォルダ

   MEF を試してる。 WPFアプリにアセンブリを読み出してメソッドを実行している。

2. `MEF2` フォルダ

   MEF2 を試してる。 WPFアプリにアセンブリを読み出してメソッドを実行している。



## References

**MEF**

[MEF (Managed Extensibility Framework) - .NET Framework | Microsoft Learn](https://learn.microsoft.com/ja-jp/dotnet/framework/mef/?redirectedfrom=MSDN)

[Managed Extensibility Framework - Managed Extensibility Framework による .NET 4 で構成可能なアプリケーションの構築 | Microsoft Learn](https://learn.microsoft.com/ja-jp/archive/msdn-magazine/2010/february/managed-extensibility-framework-building-composable-apps-in-net-4-with-the-managed-extensibility-framework)

[Managed Extensibility Framework入門 まとめ - かずきのBlog@hatena](https://blog.okazuki.jp/entry/20110507/1304772329)  ★まずこちらを見ましょう

[MEFの使い方 #C# - Qiita](https://qiita.com/katachi/items/dbc23dcd6fb6740ad0f0)

[C# + WPF + MEFを使ってアプリにプラグインを実装してみる その1 #C# - Qiita](https://qiita.com/Shiranui_Isuzu/items/84ddd6613da6c825a524)

[C# + WPF + MEFを使ってアプリにプラグインを実装してみる その2 #C# - Qiita](https://qiita.com/Shiranui_Isuzu/items/33652cb6b97fac18c37e)

**MEF2**

[.NET 4.5 の新機能 MEF (Managed Extensibility Framework) 2 - InfoQ](https://www.infoq.com/jp/news/2012/04/MEF-2/)

[C#のプラグイン機構MEF2に関するメモ #C# - Qiita](https://qiita.com/ousttrue/items/8da18f91fed8642abe5f)
