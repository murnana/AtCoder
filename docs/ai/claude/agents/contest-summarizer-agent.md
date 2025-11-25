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
- `workspaces/csharp-dotnet-7-0-7-aot/Murnana.AtCoder/Program.cs` に解きかけのコードが残っているか
- 残っている場合、どの問題用か、理由は何か（TLE懸念、WA、未完成など）
- **例**: `C - TLE懸念のため未提出`

#### 4. コンテスト実績
- **自動取得**: AtCoderから自動的に取得
  - `https://atcoder.jp/users/murnana/history/share/{contest_id}` から順位、Performance、Rating変化、参加回数を取得
  - `https://atcoder.jp/users/murnana` からRating最高値を取得
- **確認**: 取得したデータをユーザーに提示して確認
- **修正可能**: 必要に応じてユーザーが手動で修正

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
     - 参加後実績（言語環境、順位、Rating、AC数）
     - 解いた問題（タイトル、URL、解法メモ）
     - 未挑戦・解けなかった問題

4. **確認**
   - 完了後、変更内容を提示
   - ユーザーに確認を求める

## 既存エージェントとの違い

このリポジトリには、3つの専門エージェントがあります:

| エージェント                | 使用タイミング      | 主な責任                             | ツール                            |
| --------------------------- | ------------------- | ------------------------------------ | --------------------------------- |
| `atcoder-question-analyzer` | **コンテスト前/中** | 問題分析、制約確認、アルゴリズム推奨 | Read, Write, WebFetch, WebSearch  |
| `csharp-problem-solver`     | **コンテスト中**    | C#実装、デバッグ、テスト             | Read, Write, Edit, Bash           |
| `contest-summarizer`        | **コンテスト後**    | 成果物整理、README作成、ファイル整理 | Read, Write, Edit, Glob, WebFetch |

### 役割の分離

- **問題分析**: `atcoder-question-analyzer` が担当
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
📋 解法メモ収集（オプション）
```

### Phase 1.5: 成績データ自動取得
```
🌐 AtCoderから成績情報を取得
   ↓
📊 Contest result: https://atcoder.jp/users/murnana/history/share/{contest_id}
   → 順位、Performance、Rating変化、参加回数
   ↓
📊 User profile: https://atcoder.jp/users/murnana
   → Rating最高値
   ↓
✅ ユーザーに取得データの確認を求める
   ↓
🔧 必要に応じてユーザーが修正
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
