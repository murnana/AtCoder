# csharp-upsolving-archiver エージェント

## 概要

`csharp-upsolving-archiver` は、AtCoder問題のupsolving（復習）完了後、C#ソリューションを適切なディレクトリに整理し、プルリクエストを自動作成する専門エージェントです。

## 目的

Upsolving完了後、以下の作業を手動で行う必要がありました:

- 📁 ソリューションファイルのコピー (`Program.cs` → `contests/abc###/upsolving/`)
- 📝 README.mdへのUpsolving情報追加
- 🔀 Gitブランチの確認と適切な使用
- 📦 コミットメッセージの作成
- 🔗 プルリクエストの作成

このエージェントは、これらの繰り返し作業を自動化し、一貫したフォーマットで学習記録を残します。

## 使用方法

### 基本的な呼び出し

Upsolving完了後、以下のように依頼します:

```
"ABC429のC問題の復習が終わりました"
"このupsolvingの問題解けました。アーカイブお願いします"
"Program.csの解答をcontestsディレクトリに移動してPR作って"
```

### 自動実行される処理

エージェントは以下を自動的に実行します:

#### 1. **コンテストと問題の識別**
   - `workspaces/csharp-dotnet-7-0-7-aot/Murnana.AtCoder/Program.cs` を読み取り
   - XMLコメントや問題URLからコンテストID (abc429, abc430など) を特定
   - 問題レター (A, B, C, D...) を特定
   - 不明な場合はユーザーに質問

#### 2. **ディレクトリ準備**
   - `contests/{contest-id}/upsolving/` ディレクトリの確認
   - 存在しない場合は自動作成
   - ファイル名の決定: `{Problem-Letter}.cs` (例: `C.cs`)

#### 3. **README.md更新**
   - `contests/{contest-id}/README.md` を読み取り
   - 該当問題のセクションを見つける
   - **Upsolving** サブセクションを追加:
     ```markdown
     **Upsolving (YYYY-MM-DD):**
     - 公式解説を参考に組み合わせ論によるO(N)解法を実装
     - 各値xの出現回数B_xから、C(B_x, 2) × (N - B_x) で3つ組を計算
     - 詳細なインライン解説を追加し、数式の意味を具体例で説明
     - AC達成: https://atcoder.jp/contests/abc429/submissions/70486173
     - `upsolving/C.cs`: 復習後の解法（詳細コメント付き）
     ```

#### 4. **Gitワークフロー**
   - 既存の `feature/upsolving-{contest-id}` ブランチを検索
   - **ブランチが存在する場合**: 既存ブランチを使用（同一コンテストの複数問題を1つのブランチで管理）
   - **ブランチが存在しない場合**: 新しいブランチを作成
   - 変更ファイルのみをステージング:
     - `contests/{contest-id}/upsolving/{Problem-Letter}.cs`
     - `contests/{contest-id}/README.md`

#### 5. **コミットとPR作成**
   - 詳細なコミットメッセージを自動生成
   - リモートブランチにプッシュ
   - 教育的な内容のプルリクエストを作成

## ワークフロー詳細

### Phase 1: 問題識別

```
📖 Program.cs を読み取り
   ↓
🔍 XMLコメントから問題情報を抽出
   ├─ コンテストID (abc429)
   ├─ 問題レター (C)
   └─ 問題タイトル (Odd One Subsequence)
   ↓
✅ ユーザーに確認（必要な場合）
```

### Phase 2: ディレクトリとファイル準備

```
📁 contests/{contest-id}/ 確認
   ↓
📁 upsolving/ サブディレクトリ確認/作成
   ↓
📄 同名ファイルの存在確認
   ├─ 存在しない → 続行
   └─ 存在する → 上書き確認
   ↓
📄 Program.cs → {Problem-Letter}.cs コピー
```

### Phase 3: README更新

```
📝 README.md 読み取り
   ↓
🔍 該当問題のセクションを検索
   ↓
📝 Upsolvingサブセクションを追加
   ├─ 日付
   ├─ 解法の要約
   ├─ アルゴリズムと計算量
   ├─ AC提出リンク
   └─ ファイル参照
```

### Phase 4: Gitブランチ戦略

```
🔀 git branch -a で既存ブランチ確認
   ↓
   ├─ feature/upsolving-{contest-id} 存在
   │    ↓
   │    ✅ 既存ブランチを使用（同一コンテストの複数問題対応）
   │
   └─ ブランチ未存在
        ↓
        ✨ 新しいブランチ作成
        git checkout -b feature/upsolving-{contest-id}
```

### Phase 5: コミットとPR

```
📦 変更ファイルをステージング
   ├─ upsolving/{Problem-Letter}.cs
   └─ README.md
   ↓
📝 詳細なコミットメッセージ生成
   ├─ 絵文字プレフィックス (📚)
   ├─ Summary セクション
   ├─ Changes セクション
   └─ Learning Outcomes セクション
   ↓
🚀 リモートにプッシュ
   ↓
🔗 プルリクエスト作成
   ├─ Title: 📚 {Contest-ID} Problem {Letter} Upsolving...
   ├─ Description: 詳細な解法説明
   └─ References: 問題URL, 解説, 提出結果
```
