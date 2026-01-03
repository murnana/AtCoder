# コンテスト結果、または復習後の結果について

このドキュメントでは、 `contests/` ディレクトリーについて詳しく説明します。

## コンテスト解答の整理

### ディレクトリ構造

各コンテストは`contests/`ディレクトリ以下に、コンテストIDごとに整理されています:

```
contests/
├── abc117/
├── abc118/
├── ...
├── abc434/
└── abc435/
```

### コンテストディレクトリの構成

各コンテストディレクトリには以下のファイルが含まれます:

```
contests/abc434/
├── README.md              # コンテスト結果と解答ノート
├── A.cs                   # A問題の解答
├── B.cs                   # B問題の解答
├── C-unsubmitted.cs       # C問題 (未提出/不正解の場合)
├── ratingStatus.png       # レーティング状況グラフ
├── ratingGraph.png        # レーティング推移グラフ
└── upsolving/             # 復習時の回答
    └── C.cs               # C問題のUpsolving解答
```

### ファイル命名規則

- **正解 (AC)**: `A.cs`, `B.cpp` など、問題IDのみ
- **未提出/不正解**: `C-unsubmitted.cs`, `D-wa.cpp` など、ステータスを含む
- **復習時**: `upsolving/C.cs` のように専用ディレクトリに配置

### コンテストREADME

各コンテストの`README.md`には以下の情報を記録します:

- コンテスト名とURL
- 提出URL・成績表URL
- 参加実績 (順位、パフォーマンス、レーティング変動)
- 使用言語環境
- 解いた問題のリスト
- 解けなかった問題のノート
- Upsolvingの記録 (日付、アプローチ、計算量、提出URL)

**例**: [contests/abc434/README.md](../contests/abc434/README.md)

