# サブエージェント間の情報共有

## 概要

Claude Codeのサブエージェント（Task tool）は、互いに直接通信することができません。すべての情報共有は親エージェントを経由する必要があります。

## サブエージェントの特性

### ステートレス性
- 各サブエージェントは独立して実行される
- 実行完了時に1つのレポートのみを返す
- サブエージェント起動後に追加のメッセージを送ることはできない
- サブエージェント側から親に質問することもできない

### 独立性
- 複数のサブエージェントを並列実行しても、互いに通信できない
- 各サブエージェントの結果は個別に親エージェントに返される
- サブエージェント間で共有メモリや共有状態は存在しない

## 情報共有パターン

### パターン1: 順次実行と結果の引き継ぎ

```
ステップ1: サブエージェントAを起動
  ↓
ステップ2: 親エージェントがAの結果を受け取り、解析
  ↓
ステップ3: サブエージェントBを起動（Aの結果をプロンプトに含める）
  ↓
ステップ4: 親エージェントがBの結果を受け取る
```

**実装例:**

```javascript
// ステップ1: 問題分析サブエージェント
Task(
  subagent_type: "atcoder-problem-analyzer",
  prompt: "ABC428のC問題を分析してください"
)
// → 結果: "制約N≤10^5、セグメント木が適切"

// ステップ2: 親エージェントが結果を理解

// ステップ3: 実装サブエージェントに分析結果を渡す
Task(
  subagent_type: "csharp-problem-solver",
  prompt: `
    ABC428のC問題を実装してください。

    分析結果:
    - 制約: N≤10^5
    - 推奨アルゴリズム: セグメント木
    - 時間計算量: O(N log N)

    この情報を元にProgram.csに実装してください。
  `
)
```

### パターン2: 並列実行と親での統合

```
        ┌─ サブエージェントA ─┐
親 ─────┤                      ├──→ 親が結果を統合
        └─ サブエージェントB ─┘
```

**実装例:**

```javascript
// 複数のサブエージェントを並列起動
// (単一メッセージで複数のTask呼び出し)

// サブエージェントA: コードレビュー
Task(subagent_type: "code-reviewer", ...)

// サブエージェントB: テスト実行
Task(subagent_type: "test-runner", ...)

// 両方の結果を親が受け取り、統合してユーザーに報告
```

### パターン3: 共有コンテキストの事前準備（✨推奨）

サブエージェントが共通して必要とする情報を、事前にファイルに書き出しておく方法:

```
ステップ1: 親エージェントが共有情報をファイルに保存
  ↓
ステップ2: サブエージェントA起動（ファイルパスを指定）
  ↓
ステップ3: サブエージェントB起動（同じファイルパスを指定）
```

**実装例:**

```javascript
// ステップ1: 分析結果をファイルに保存
Write(
  file_path: "workspaces/ai/claude/analysis-result.md",
  content: "制約: N≤10^5\n推奨: セグメント木\n..."
)

// ステップ2: サブエージェントAに指示
Task(
  prompt: "workspaces/ai/claude/analysis-result.mdを参照して実装..."
)

// ステップ3: サブエージェントBに指示
Task(
  prompt: "workspaces/ai/claude/analysis-result.mdを参照してテスト..."
)
```

## Language Policy for Token Efficiency

### Hybrid Approach (English + Japanese)

To optimize token consumption while maintaining accuracy and readability:

| Component | Language | Rationale |
|-----------|----------|-----------|
| **Problem Statement Content** | Japanese | Original AtCoder language, quoted as-is |
| **Test Case Data** | Japanese | As provided by AtCoder |
| **Technical Descriptions** | English | 30-40% token reduction for algorithms/complexity |
| **C# Code Comments** | Japanese | Human readability for developers |
| **XML Documentation** | Japanese | Part of code documentation |
| **Metadata/Headers** | English | Structural elements, minimal impact |

### Token Efficiency Impact

**Japanese**: ~2-3 tokens per character
**English**: ~1 token per word (4-5 characters)

**Example comparison:**
- Japanese: "時間計算量はO(N log N)が必要です" → ~28 tokens
- English: "Time complexity O(N log N) required" → ~8 tokens
- **Savings: 71%** for technical descriptions

## AtCoderワークフローでの実践例

### ✨ 推奨ワークフロー: ファイルベースの情報共有

AtCoderプロジェクトでは、`workspaces/ai/claude/` ディレクトリを使用したファイルベースの情報共有を採用しています。

#### フロー概要

```
1. atcoder-problem-analyzer エージェント
   ├─ 入力: 問題URL
   ├─ 処理: 問題分析、公式解説取得、アルゴリズム推奨
   └─ 出力: workspaces/ai/claude/ に3つのMarkdownファイル
       ├─ problem-statement.md（問題文と制約）
       ├─ problem-statement-testcases.md（テストケース）
       └─ problem-statement-explanation.md（解法解説）

2. csharp-problem-solver エージェント
   ├─ 入力: 上記3つのファイルを読み込み
   ├─ 処理: C#でProgram.csに実装
   └─ 出力: 動作する解答コード
```

#### 詳細手順

**ステップ1: 問題分析エージェントの実行**

```bash
# ユーザーの操作
"ABC428のC問題を分析してください"
```

atcoder-problem-analyzer が実行する処理：
1. 問題URLから問題文を取得（WebFetch）
2. 公式解説を取得（WebFetch、2段階）
3. 制約分析とアルゴリズム推奨
4. 以下の3ファイルを `workspaces/ai/claude/` に保存：

```markdown
# workspaces/ai/claude/problem-statement.md
Problem metadata, constraints, I/O format
- Headers in English, problem content in Japanese (as-is from AtCoder)

# workspaces/ai/claude/problem-statement-testcases.md
Sample inputs/outputs, edge cases
- Data as provided by AtCoder (typically Japanese)

# workspaces/ai/claude/problem-statement-explanation.md
Solution explanation, algorithm recommendations, complexity analysis, C# hints
- Technical descriptions in English for token efficiency
- Preserves official editorial content in original Japanese
```

**ステップ2: 実装エージェントの実行**

```bash
# ユーザーの操作
"C#でこの問題を実装してください"
```

csharp-problem-solver が実行する処理：
1. `workspaces/ai/claude/` の3ファイルを Read ツールで読み込み
2. 問題の制約、推奨アルゴリズム、解法ステップを理解
3. `workspaces/csharp/Murnana.AtCoder/Program.cs` に実装
   - **コード内コメントは日本語で記述**（人間の可読性優先）
   - XML documentation (`<summary>`, `<remarks>`) も日本語
4. テストケースで動作確認
5. デバッグと修正

#### このアプローチの利点

✅ **明確な責任分離**: 分析と実装が完全に分離
✅ **再利用可能性**: 分析結果を複数の言語で再利用可能
✅ **トレーサビリティ**: ファイルとして残るため後から参照可能
✅ **並列開発**: 分析完了後、複数言語で同時に実装可能
✅ **デバッグ支援**: 分析結果を見直すことでロジックミスを発見しやすい
✅ **トークン効率**: ハイブリッド言語方式で30-40%のトークン削減

#### ファイル配置の理由

**なぜ `workspaces/ai/claude/` なのか？**
- プロジェクトのワークスペース内で管理
- 各言語のワークスペース（csharp, python等）からアクセス可能
- AI支援に特化したディレクトリとして明確に分離
- `.gitignore` で除外すれば一時ファイルとして扱える

### 旧ワークフロー: プロンプト埋め込み方式（非推奨）

```
1. atcoder-problem-analyzer
   入力: 問題文URL
   出力: アルゴリズム分析、制約分析、実装方針

2. 親エージェント
   - 分析結果を理解
   - 実装方針を確認

3. csharp-problem-solver
   入力: 問題文 + 分析結果（プロンプトに埋め込む）← 長くなりがち
   出力: Program.csの実装
```

この方式は分析結果をプロンプトに全て含める必要があり、トークン消費が大きく、再利用性も低いため非推奨です。

## ベストプラクティス

### ✅ 推奨

1. **ファイルベースの共有**: 複雑な情報は中間ファイルとして保存
2. **明示的な情報引き継ぎ**: 前のサブエージェントの結果を、次のサブエージェントのプロンプトに明示的に含める
3. **親での検証**: サブエージェントの結果を親が検証してから次に進む
4. **構造化された出力**: サブエージェントには構造化された形式（JSON、マークダウンなど）でレポートを返すよう指示
5. **専用ディレクトリの活用**: `workspaces/ai/claude/` のような専用ディレクトリで中間ファイルを管理

### ❌ 避けるべき

1. **暗黙的な情報共有を期待**: サブエージェント同士が情報を共有できると仮定しない
2. **長すぎるチェーン**: サブエージェント→親→サブエージェント→親... を何度も繰り返すと非効率
3. **状態の保持を期待**: サブエージェントは前回の実行内容を覚えていない
4. **プロンプトへの過度な埋め込み**: 大量の情報をプロンプトに含めるとトークン消費が大きい

## まとめ

- サブエージェント間の直接通信は**不可能**
- すべての情報共有は**親エージェントを経由**
- 親エージェントは**仲介役**として機能
- 効率的なワークフローには**適切な情報の引き継ぎ設計**が重要
- **ファイルベースの共有**は再利用性と可読性が高く推奨される
