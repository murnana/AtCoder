# Claude Code エージェント一覧

このディレクトリには、AtCoderの競技プログラミングワークフローを効率化する専門エージェントのドキュメントが含まれています。

## エージェント概要

| エージェント | タイミング | 主な機能 | 入力 | 出力 |
|------------|----------|---------|------|------|
| [atcoder-question-analyzer](./atcoder-question-analyzer-agent.md) | **実装前** | 問題分析、制約確認、アルゴリズム推奨 | 問題URLまたは問題文 | `workspaces/ai/claude/`に3つのMD |
| [csharp-problem-solver](./csharp-problem-solver-agent.md) | **実装時** | C#実装、デバッグ、テスト | 分析ファイル | `Program.cs` |
| [csharp-upsolving-archiver](./csharp-upsolving-archiver-agent.md) | **upsolving完了後** | 解答のアーカイブ | `Program.cs` | `contests/{id}/upsolving/` |
| [contest-summarizer](./contest-summarizer-agent.md) | **コンテスト後** | 成果物整理、README作成 | コンテスト情報 | `contests/{id}/README.md` |

## 推奨ワークフロー

### 1. 問題分析フェーズ

**エージェント**: [atcoder-question-analyzer](./atcoder-question-analyzer-agent.md)

```
"ABC350のC問題を解析して"
```

**実施内容**:
- 問題文と制約の取得
- 公式解説の取得（フォールバック戦略付き）
- 制約分析と計算量要件の算出
- 最適なアルゴリズムの推奨

**出力**: `workspaces/ai/claude/`に3つの分析ファイル

---

### 2. 実装フェーズ

**エージェント**: [csharp-problem-solver](./csharp-problem-solver-agent.md)

```
"この問題をC#で実装して"
```

**実施内容**:
- 分析ファイルの読み込み
- `Program.cs`への実装（日本語コメント付き）
- サンプルケースでのテスト
- デバッグと最適化

**出力**: `workspaces/csharp-dotnet-7-0-7-aot/Murnana.AtCoder/Program.cs`

---

### 3. Upsolvingアーカイブ（オプション）

**エージェント**: [csharp-upsolving-archiver](./csharp-upsolving-archiver-agent.md)

```
"ABC429のC問題のupsolvingが終わりました"
```

**実施内容**:
- `Program.cs`の解答を`contests/{contest_id}/upsolving/`に移動
- ワークスペースをクリーンアップ
- PRの作成（オプション）

**出力**: `contests/abc429/upsolving/C.cs`

---

### 4. コンテスト成果整理

**エージェント**: [contest-summarizer](./contest-summarizer-agent.md)

```
"ABC430のコンテストサマリーを作成して"
```

**実施内容**:
- AC問題の整理とコピー
- 問題タイトルの自動取得
- README.mdの作成（実績、解法メモ付き）
- 未提出コードの保存

**出力**: `contests/abc430/README.md`とソリューションファイル

---

## エージェント選択ガイド

### 問題を理解したい

→ [atcoder-question-analyzer](./atcoder-question-analyzer-agent.md)

- 制約から計算量要件を知りたい
- 最適なアルゴリズムを確認したい
- 公式解説を取得したい

### 問題を実装したい

→ [csharp-problem-solver](./csharp-problem-solver-agent.md)

- C#でコードを書きたい
- デバッグしたい
- サンプルケースでテストしたい

### Upsolvingした問題を整理したい

→ [csharp-upsolving-archiver](./csharp-upsolving-archiver-agent.md)

- ワークスペースから解答を移動したい
- 次の問題のためにProgram.csをクリアしたい
- Upsolving解答を永続化したい

### コンテスト結果をまとめたい

→ [contest-summarizer](./contest-summarizer-agent.md)

- コンテスト後に成果を整理したい
- READMEを自動生成したい
- 実績を記録したい

---

## 各エージェントの詳細

各エージェントの詳細なドキュメントは、上記リンクから参照してください。

- [atcoder-question-analyzer-agent.md](./atcoder-question-analyzer-agent.md) - 問題分析の詳細、フォールバック戦略、出力ファイル形式
- [csharp-problem-solver-agent.md](./csharp-problem-solver-agent.md) - 実装規約、コードテンプレート、パフォーマンス最適化
- [csharp-upsolving-archiver-agent.md](./csharp-upsolving-archiver-agent.md) - アーカイブフロー、PR作成、ワークスペース管理
- [contest-summarizer-agent.md](./contest-summarizer-agent.md) - README生成、実績記録、メタデータ取得

---

## 関連ドキュメント

- [CLAUDE.md](../../../../CLAUDE.md) - リポジトリ全体のクイックリファレンス
- [エージェント定義ファイル](../../../../.claude/agents/) - 各エージェントの実装詳細

---

## 設計原則

これらのエージェントは以下の原則に基づいて設計されています:

### 1. 関心の分離 (Separation of Concerns)
- 各エージェントは単一の責任を持つ
- 分析→実装→整理の明確なフェーズ分離

### 2. ファイルベースの連携
- エージェント間はファイルを介して情報共有
- ステートレスな設計で再現性を確保

### 3. トークン効率
- 問題文は日本語（原文保持）
- 技術的説明は英語（30-40%のトークン削減）
- コードコメントは日本語（人間の可読性優先）

### 4. フォールバック戦略
- 自動取得失敗時の代替手段を用意
- ユーザー確認を通じた確実な処理継続

### 5. 教育的価値
- 詳細なコメントと解説
- 再利用可能なパターンの明示
- 学習リソースとしての活用
