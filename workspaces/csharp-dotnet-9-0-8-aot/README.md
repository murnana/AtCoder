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
dotnet publish -c Release -o publish --no-restore --nologo -v q --tl:off
./publish/Main
```

### その他
```bash
dotnet clean          # クリーンアップ
dotnet restore        # パッケージ復元
dotnet build          # 開発ビルド
```

## AtCoder実行環境

AtCoderのC# AOT環境（2025年11月1日 ABC430から適用）と同じ設定です：

| 項目           | 値                                  |
| -------------- | ----------------------------------- |
| 言語バージョン | C# 13.0 (.NET 9.0.8 AOT)            |
| コンパイル     | `dotnet publish -c Release`         |
| 実行方法       | AOTコンパイル後のネイティブバイナリ |
| 環境変数       | `DOTNET_EnableWriteXorExecute=0` 等 |

詳細は以下を参照：
- [言語アップデート告知](https://atcoder.jp/posts/1593) - 2025年11月1日 ABC430から適用
- [言語環境詳細](https://img.atcoder.jp/file/language-update/2025-10/language-list.html)

## C# 13.0の新機能

.NET 9.0.8とC# 13.0では以下の機能が利用可能です：

- **パラメータコレクション**: `params ReadOnlySpan<T>` によるゼロアロケーション配列操作
- **拡張型**: `implicit operator` による型安全なラッパー型の簡潔な定義
- **部分プロパティ**: ソースジェネレーター対応の改善
- **Ref構造体の改善**: より柔軟なライフタイム管理

競技プログラミングでは、特にパラメータコレクションによるパフォーマンス向上が期待できます。
