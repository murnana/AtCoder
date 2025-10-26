# contest-summarizer エージェント

## 概要

`contest-summarizer` は、AtCoderコンテスト終了後の成果物整理とドキュメント作成を自動化する専門エージェントです。

## 目的

コンテスト参加後、以下の作業を手動で行う必要がありました:

- ✏️ ソリューションファイルのコピー (`Program.cs` → `contests/abc###/`)
- 🌐 問題タイトルのAtCoderからの取得
- 📝 README.mdの作成・フォーマット
- 📦 未提出コードの適切な保存

このエージェントは、これらの繰り返し作業を自動化し、過去のコンテストと一貫したフォーマットで記録を残します。

## 使用方法

### 基本的な呼び出し

コンテスト終了後、以下のように依頼します:

```
"ABC430のコンテストサマリーを作成してください"
```

または、Task toolを使ってエージェントを直接起動することもできます。

### 対話フロー

エージェントは以下の情報を順番に質問します:

#### 1. コンテスト情報
- **コンテストID**: ブランチ名 (`feature/abc429`) から自動推測して確認
- **例**: `abc429`, `abc430`

#### 2. AC問題
- 解けた問題のリスト
- **例**: `A, B` または `A, B, C, D`

#### 3. 未提出コード
- `workspaces/csharp/Murnana.AtCoder/Program.cs` に解きかけのコードが残っているか
- 残っている場合、どの問題用か、理由は何か（TLE懸念、WA、未完成など）
- **例**: `C - TLE懸念のため未提出`

#### 4. コンテスト実績
- **順位**: `7711th / 11184` の形式
- **Rating変化**: `287 → 280 (-7)` の形式
- **Rating最高値**: `342 ― 9 級` の形式
- **コンテスト参加回数**: `34` など

#### 5. 解法メモ（オプション）
- 各問題の解き方の簡潔なメモ
- 1-3個の箇条書き
- **例**:
  - 配列の合計から各要素を引いて判定
  - O(N)で計算可能

### 自動実行される処理

情報収集後、エージェントは以下を自動的に実行します:

1. **ファイル整理**
   - `contests/{contest_id}/` ディレクトリの確認/作成
   - AC問題のソリューションファイルをコピー: `{Letter}.cs`
   - 未提出コードをコピー: `{Letter}-unsubmitted.cs`

2. **メタデータ取得**
   - AtCoderから問題タイトルを自動取得
   - WebFetchツールを使用: `https://atcoder.jp/contests/{contest_id}/tasks`

3. **README.md生成/更新**
   - 過去のコンテスト（ABC428, ABC429など）と同じフォーマットで作成
   - 以下のセクションを含む:
     - 参加後実績（順位、Rating、AC数）
     - 解いた問題（タイトル、URL、解法メモ）
     - 未挑戦・解けなかった問題

4. **確認**
   - 完了後、変更内容を提示
   - ユーザーに確認を求める

## 既存エージェントとの違い

このリポジトリには、3つの専門エージェントがあります:

| エージェント | 使用タイミング | 主な責任 | ツール |
|-------------|--------------|---------|--------|
| `atcoder-problem-analyzer` | **コンテスト前/中** | 問題分析、制約確認、アルゴリズム推奨 | Read, Write, WebFetch, WebSearch |
| `csharp-problem-solver` | **コンテスト中** | C#実装、デバッグ、テスト | Read, Write, Edit, Bash |
| `contest-summarizer` | **コンテスト後** | 成果物整理、README作成、ファイル整理 | Read, Write, Edit, Glob, WebFetch |

### 役割の分離

- **問題分析**: `atcoder-problem-analyzer` が担当
- **実装**: `csharp-problem-solver` が担当
- **記録整理**: `contest-summarizer` が担当（このエージェント）

### 範囲外の機能

`contest-summarizer` は以下を**行いません**:

- ❌ 問題の解き直し（upsolving）
- ❌ コードの分析や改善
- ❌ 公式解説の取得
- ❌ 新しいコードの実装

これらは他のエージェントに委譲します。

## ワークフロー詳細

### Phase 1: 情報収集
```
📋 コンテストID確認
   ↓
📋 AC問題リスト確認
   ↓
📋 未提出コード有無確認
   ↓
📋 実績データ収集
   ↓
📋 解法メモ収集（オプション）
```

### Phase 2: ファイル整理
```
📁 contests/{contest_id}/ ディレクトリ確認
   ↓
📁 既存ファイルチェック（重複回避）
   ↓
📄 {Problem}.cs ファイルコピー（AC分）
   ↓
📄 {Problem}-unsubmitted.cs コピー（未提出分）
```

### Phase 3: メタデータ取得
```
🌐 AtCoder tasks ページにアクセス
   ↓
🔍 問題タイトル抽出
   ↓
📊 問題情報を整理
```

### Phase 4: README生成
```
📝 テンプレート選択（ABC428等を参考）
   ↓
📝 参加後実績セクション作成
   ↓
📝 解いた問題セクション作成
   ↓
📝 未挑戦・解けなかった問題セクション作成
   ↓
📝 画像参照追加 (ratingStatus.png, ratingGraph.png)
```

### Phase 5: 確認
```
✅ 作成/更新ファイルのリスト表示
   ↓
✅ README内容のサマリー表示
   ↓
✅ ユーザーに確認を求める
   ↓
🔧 修正が必要な場合は対応
```

## 実例: ABC429

### 呼び出し

```
User: "ABC429のコンテストサマリーを作成してください"
```

### エージェントの質問と回答例

```
Agent: ABC429のコンテストサマリーを作成します。以下の情報を教えてください:

1. 解いた問題: (例: A, B)
User: A, B

2. 未提出のコード: Program.csに残っていますか？
User: はい、C問題用です。TLE懸念のため未提出です。

3. 順位: (例: 7711th / 11184)
User: 7711th / 11184

4. Rating変化: (例: 287 → 280)
User: 287 → 280

5. Rating最高値: (例: 342 ― 9 級)
User: 342 ― 9 級

6. コンテスト参加回数: (例: 34)
User: 34
```

### 実行結果

```
✅ コンテストサマリーを作成しました

📁 作成/更新したファイル:
   - contests/abc429/A.cs
   - contests/abc429/B.cs
   - contests/abc429/C-unsubmitted.cs
   - contests/abc429/README.md

📊 参加後実績:
   - 順位: 7711th / 11184
   - Rating: 287 → 280 (-7)
   - AC: 2問 (A, B)

📝 解いた問題:
   - A - Too Many Requests
   - B - N - 1

⚠️ 未提出:
   - C - Odd One Subsequence (TLE懸念)

内容を確認してください。修正が必要な箇所はありますか？
```

### 生成されたREADME.md

```markdown
# Polaris.AI プログラミングコンテスト 2025（AtCoder Beginner Contest 429）

会場: [Polaris.AI プログラミングコンテスト 2025（AtCoder Beginner Contest 429） - AtCoder](https://atcoder.jp/contests/abc429)

自分の提出: https://atcoder.jp/contests/abc429/submissions?f.User=murnana
自分の成績表: https://atcoder.jp/users/murnana/history/share/abc429


## 参加後実績

|                    |                 |
| -----------------: | :-------------- |
|               順位 | 7711th / 11184  |
|             Rating | 287 → 280 (-7) |
|       Rating最高値 | 342 ― 9 級      |
| コンテスト参加回数 | 34              |
|             AC数   | 2問 (A, B)      |

![ratingStatus](ratingStatus.png)
![ratingGraph](ratingGraph.png)


## 解いた問題

### A - Too Many Requests
...

### B - N - 1
...


## 未挑戦・解けなかった問題

### C - Odd One Subsequence
...
```

## ファイル命名規則

エージェントは以下の命名規則を使用します:

| 状態 | ファイル名 | 例 |
|------|-----------|-----|
| Accepted | `{Letter}.cs` | `A.cs` |
| 未提出（任意の理由） | `{Letter}-unsubmitted.cs` | `C-unsubmitted.cs` |
| Wrong Answer（実際に提出した場合） | `{Letter}-WA.cs` | `D-WA.cs` |
| Time Limit Exceeded（実際に提出した場合） | `{Letter}-TLE.cs` | `E-TLE.cs` |

**デフォルト**: 未提出コードは常に `-unsubmitted.cs` を使用します（実際にWA/TLEで提出した場合を除く）。

## トラブルシューティング

### AtCoderにアクセスできない

**症状**: WebFetchがタイムアウトまたはエラー

**対処法**:
1. エージェントが問題タイトルを手動入力するよう質問します
2. 後でREADMEを手動編集することもできます

### ファイルが既に存在する

**症状**: `contests/abc429/A.cs` が既に存在する

**対処法**:
1. エージェントが上書き確認を求めます
2. 上書きしない場合はスキップされます

### Program.csが空

**症状**: 未提出コードをコピーしようとしたが、`Program.cs` が空または別の問題のコード

**対処法**:
1. エージェントに「未提出コードはない」と伝えます
2. 必要に応じて、gitの履歴から復元して後で手動コピーできます

### コミット履歴からソリューションを取得したい

**症状**: AC問題のソリューションファイルが手元にない（既にProgram.csは別のコードに変わっている）

**対処法**:
1. エージェントを呼び出す前に、gitの履歴から各ソリューションを復元します:
   ```bash
   git show HEAD~3:workspaces/csharp/Murnana.AtCoder/Program.cs > contests/abc429/A.cs
   ```
2. または、エージェントに「ソリューションファイルは既に配置済み」と伝えます

### README形式をカスタマイズしたい

**症状**: デフォルトのREADMEテンプレートに追加セクションを入れたい

**対処法**:
1. エージェント実行後、手動でREADMEを編集します
2. または、`.claude/agents/contest-summarizer.md` のテンプレートを編集します（上級者向け）

## 参考資料

### 関連ドキュメント

- [subagent-communication.md](./subagent-communication.md) - エージェント間通信の仕組み
- [CLAUDE.md](../../CLAUDE.md) - リポジトリ全体のAI運用ガイド

### 関連エージェント

- [atcoder-problem-analyzer](./.claude/agents/atcoder-problem-analyzer.md) - 問題分析エージェント
- [csharp-problem-solver](./.claude/agents/csharp-problem-solver.md) - C#実装エージェント

### 過去のコンテスト例

参考にできる過去のコンテストREADME:

- [contests/abc428/README.md](../../contests/abc428/README.md) - シンプルな形式
- [contests/abc429/README.md](../../contests/abc429/README.md) - 詳細な解法メモ付き
- [contests/abc117/README.md](../../contests/abc117/README.md) - 解けなかった問題の解説メモ付き

## まとめ

`contest-summarizer` エージェントは:

✅ **時間節約**: 手動作業を自動化
✅ **一貫性**: フォーマットを統一
✅ **エラー削減**: ファイル名やリンクのミスを防止
✅ **学習記録**: 構造化された解法メモを保存
✅ **責任分離**: 問題解決と記録整理を明確に分離

次回のコンテスト後は、このエージェントを使って効率的に記録を残しましょう！
