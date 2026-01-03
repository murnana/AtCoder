# AIワークフロー - Claude Code編

このリポジトリでは、Claude Code専用エージェントを活用した効率的な問題解決ワークフローを採用しています。

## 専用エージェント

4つの専用エージェントが、問題分析から解答アーカイブまでをサポートします:

1. **atcoder-question-analyzer**: 問題分析と公式解説取得
2. **csharp-problem-solver**: C#実装とテスト
3. **csharp-upsolving-archiver**: Upsolving解答のアーカイブ
4. **contest-summarizer**: コンテスト結果の整理とREADME生成

## 詳細ドキュメント

各エージェントの詳細な仕様と使用方法は、以下のドキュメントを参照してください:

- [AIワークフロー概要](ai/claude/agents/README.md)
- [atcoder-question-analyzer](ai/claude/agents/atcoder-question-analyzer-agent.md)
- [csharp-problem-solver](ai/claude/agents/csharp-problem-solver-agent.md)
- [csharp-upsolving-archiver](ai/claude/agents/csharp-upsolving-archiver-agent.md)
- [contest-summarizer](ai/claude/agents/contest-summarizer-agent.md)
