# C# Workspace for AtCoder

C#を使ったAtCoder競技プログラミングのワークスペースです。

## Quick Start

1. **問題を解く**: `Murnana.AtCoder/Program.cs` に解答を実装
2. **テスト**: `dotnet run --project Murnana.AtCoder`
3. **提出**: `Murnana.AtCoder/Combined.csx` をAtCoderに提出

## プロジェクト構造

```
workspaces/csharp/
├── Murnana.AtCoder.sln          # Visual Studio ソリューション
└── Murnana.AtCoder/
    ├── Program.cs               # 解答実装ファイル
    ├── Combined.csx             # 提出用ファイル（自動生成）
    └── Murnana.AtCoder.csproj   # プロジェクトファイル
```

## 開発環境

- **言語**: C# 13.0 (.NET 9.0.8 Native AOT)
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

## Claude Code エージェント

AtCoder問題を解く際、以下のエージェントが自動起動します：

- **`atcoder-problem-analyzer`**: 問題分析、制約分析、アルゴリズム推奨
- **`csharp-problem-solver`**: C#での解答実装、テスト、デバッグ

詳細は `.claude/agents/` を参照してください。

## ⚠️ 重要な注意事項

**AtCoderのルールに従ってください：**
- コンテスト中のAI使用は禁止されています
- ブランチ名が `feature/abc###` などの場合、コンテスト中の可能性があります
- Upsolvingや練習では自由にAIを活用してください

## リポジトリ全体の構成

このワークスペースは [murnana/AtCoder](../../) リポジトリの一部です。

- `contests/`: 過去のコンテスト解答（参考実装）
- `workspaces/csharp/`: このワークスペース（開発環境）
- `README.md`: リポジトリ全体の説明

## AtCoder実行環境

AtCoderのC#環境と同じ設定です：

| 項目 | 値 |
|---|---|
| 言語バージョン | C# 13.0 (.NET Native AOT 9.0.8) |
| 実行方法 | AOTコンパイル後のネイティブバイナリ |
| 環境変数 | `DOTNET_EnableWriteXorExecute=0` 等 |

詳細は [AtCoder言語アップデート](https://atcoder.jp/posts/1336) を参照。
