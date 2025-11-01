# C# Workspace for AtCoder

C#を使ったAtCoder競技プログラミングのワークスペースです。

## Quick Start

1. **問題を解く**: `Murnana.AtCoder/Program.cs` に解答を実装
2. **テスト**: `dotnet run --project Murnana.AtCoder`
3. **提出**: `Murnana.AtCoder/Combined.csx` をAtCoderに提出

## プロジェクト構造

```
./
├── Murnana.AtCoder.sln          # Visual Studio ソリューション
└── Murnana.AtCoder/
    ├── Program.cs               # 解答実装ファイル
    ├── Combined.csx             # 提出用ファイル（自動生成）
    └── Murnana.AtCoder.csproj   # プロジェクトファイル
```

## 開発環境

- **言語**: C# 11.0 (.NET 7.0.7 Native AOT)
- **主要ライブラリ**:
  - `ac-library-csharp` (3.9.2-atcoder1): AtCoder公式アルゴリズム・データ構造
  - `SourceExpander` (8.2.0): 単一ファイル提出用のコード展開
  - `MathNet.Numerics` (5.0.0): 数値計算ライブラリ

## コマンド

### 開発ビルド
```bash
dotnet run --project Murnana.AtCoder
```

### 提出用AOTコンパイル
```bash
export DOTNET_EnableWriteXorExecute=0
export DOTNET_CLI_TELEMETRY_OPTOUT=1
dotnet publish -c Release -o publish -v q --nologo --tl:off
./publish/Main
```

### その他
```bash
dotnet clean          # クリーンアップ
dotnet restore        # パッケージ復元
dotnet build          # 開発ビルド
```

## AtCoder実行環境

AtCoderのC#環境と同じ設定です：

| 項目           | 値                                  |
| -------------- | ----------------------------------- |
| 言語バージョン | C# 11.0 (.NET 7.0.7 AOT)            |
| 実行方法       | AOTコンパイル後のネイティブバイナリ |
| 環境変数       | `DOTNET_EnableWriteXorExecute=0` 等 |

詳細は [ルール - Polaris.AI プログラミングコンテスト 2025（AtCoder Beginner Contest 429）](https://atcoder.jp/contests/abc429/rules) を参照。
