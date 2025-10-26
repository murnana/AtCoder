# CLAUDE.md

AtCoder competitive programming repository guidance for Claude Code.

## Repository Overview

AtCoder competitive programming solutions and contest history in multiple languages.

### ⚠️ Important
- AI usage prohibited during contests
- Warn if branch is `feature/abc###` (likely contest in progress)

**Structure:**
- `contests/`: Past contest solutions
- `workspaces/`: Language-specific workspaces for contests/practice
- `docs/`: Documentation for humans
- `README.md`: Basic repository info with AtCoder links

### Contest Solutions (`contests/`)
- Organized by contest ID (abc117, abc118, etc.)
- Solutions in `.cpp` or `.cs` files
- AtCoder naming convention (A-*, B-*, C-*, etc.)
- Each contest has README.md with details and performance
- Reference for studying past solutions
- C++ solutions are standalone files
- No standardized build system
- **`upsolving/`**: Post-contest review and practice solutions within each contest folder

### Workspaces (`workspaces/`)
- Language/environment-specific directories
- **See `workspaces/XXX/README.md` for details**

### Documentation (`docs/`)
- `docs/ai/claude/`: AI workflow documentation
  - `agents/`: Detailed documentation for each specialized agent
    - [atcoder-question-analyzer](docs/ai/claude/agents/atcoder-question-analyzer-agent.md): Problem analysis
    - [csharp-problem-solver](docs/ai/claude/agents/csharp-problem-solver-agent.md): C# implementation
    - [csharp-upsolving-archiver](docs/ai/claude/agents/csharp-upsolving-archiver-agent.md): Upsolving archival
    - [contest-summarizer](docs/ai/claude/agents/contest-summarizer-agent.md): Contest summary

## Specialized Agents

This repository uses specialized Claude Code agents for efficient problem-solving workflows:

### 1. `atcoder-question-analyzer`
**Purpose**: Analyze AtCoder problems and create structured analysis files

**When to use:**
- Before implementing a solution to understand the problem
- To fetch and analyze official editorials
- To determine optimal algorithms and complexity requirements

**Output**: Creates 3 files in `workspaces/ai/claude/`:
- `problem-statement.md` - Problem description and constraints
- `problem-statement-testcases.md` - Sample test cases
- `problem-statement-explanation.md` - Solution approach and algorithm recommendations

**Editorial fetching**:
- Automatically attempts to fetch official editorials from AtCoder
- If automatic fetch fails, will ask you for the editorial URL
- Can proceed without editorial if unavailable

**Example usage:**
```
"Analyze ABC350 problem C"
"Get the official editorial for this problem"
```

**See also**: [Detailed documentation](docs/ai/claude/agents/atcoder-question-analyzer-agent.md)

### 2. `csharp-problem-solver`
**Purpose**: Implement C# solutions based on problem analysis

**When to use:**
- After problem analysis is complete
- To implement solutions in `workspaces/csharp/Murnana.AtCoder/Program.cs`
- For debugging and optimizing C# solutions

**Prerequisites**: Analysis files from `atcoder-question-analyzer` should exist in `workspaces/ai/claude/`

**Key features**:
- Implements with detailed Japanese comments and XML documentation
- Automatically tests with sample cases
- Follows AtCoder C# environment (.NET 9.0.8 AOT)
- Uses SourceExpander for single-file submission

**Example usage:**
```
"Implement this problem in C#"
"Debug the current solution in Program.cs"
```

**See also**: [Detailed documentation](docs/ai/claude/agents/csharp-problem-solver-agent.md)

### 3. `csharp-upsolving-archiver`
**Purpose**: Archive completed upsolving solutions to contest directory

**When to use:**
- After finishing upsolving (post-contest problem solving)
- When you have a completed solution in `Program.cs` ready to archive
- To move solutions from workspace to permanent storage

**Output**: Archives solution to `contests/{contest_id}/upsolving/{Problem}.cs`

**Example usage:**
```
"ABC429のC問題のupsolvingが終わりました"
"Program.csの解答をcontestsディレクトリに移動して"
```

**See also**: [Detailed documentation](docs/ai/claude/agents/csharp-upsolving-archiver-agent.md)

### 4. `contest-summarizer`
**Purpose**: Organize contest results and create README after contest completion

**When to use:**
- After finishing an AtCoder contest
- To organize solutions from workspace to contest directory
- To create/update README with contest performance

**Output**:
- Copies AC solutions to `contests/{contest_id}/`
- Creates/updates `contests/{contest_id}/README.md`
- Fetches problem titles from AtCoder

**Example usage:**
```
"ABC430のコンテストサマリーを作成して"
"ABC429の成果を整理して"
```

**See also**: [Detailed documentation](docs/ai/claude/agents/contest-summarizer-agent.md)

### Agent Workflow (Recommended)

**Full workflow** covering analysis, implementation, and archival:

```
Stage 1: Problem Analysis
  User → atcoder-question-analyzer
       ↓
  Fetches problem from AtCoder
  Analyzes constraints & algorithms
  Fetches official editorial (with fallback)
       ↓
  Outputs 3 files to workspaces/ai/claude/

Stage 2: Implementation
  User → csharp-problem-solver
       ↓
  Reads analysis files
  Implements in Program.cs (Japanese comments)
       ↓
  Tests and debugs solution

Stage 3: Upsolving Archive (optional)
  User → csharp-upsolving-archiver
       ↓
  Moves completed solution to contests/{contest_id}/upsolving/
  Preserves workspace for next problem

Stage 4: Contest Summary (after contest)
  User → contest-summarizer
       ↓
  Organizes all AC solutions
  Creates README with performance data
  Fetches problem titles from AtCoder
```

**Why this approach?**
- ✅ Separation of concerns (analysis vs implementation vs archival)
- ✅ Analysis files reusable across multiple languages
- ✅ Token efficiency through hybrid language approach
- ✅ Better debugging (can review analysis separately)
- ✅ Clean workspace management (upsolving archival)
- ✅ Consistent contest records (automated README creation)

## Workflow
### Branches
- **`main`**: Stable code
- **`feature/abc###`**: Contest-specific work (created during contests)

### Development Flow

#### Using Specialized Agents (Recommended)
1. **Problem Analysis**: Use `atcoder-question-analyzer` to analyze the problem
   - Fetches problem statement and official editorial
   - Performs constraint analysis
   - Recommends algorithms and approach
   - Outputs analysis to `workspaces/ai/claude/`

2. **Implementation**: Use `csharp-problem-solver` to implement
   - Reads analysis files from `workspaces/ai/claude/`
   - Implements in `workspaces/csharp/Murnana.AtCoder/Program.cs`
   - Uses SourceExpander for single-file submission via `Combined.csx`
   - All code comments in Japanese for readability

3. **Reference**: Check `contests/` for past solutions

#### Direct Implementation (Alternative)
- Directly implement in `workspaces/csharp/Murnana.AtCoder/Program.cs`
- Use SourceExpander for single-file submission via `Combined.csx`

## Language Policy

### Token Efficiency Strategy
To optimize Claude's token usage while maintaining quality:

| Content Type | Language | Reason |
|--------------|----------|--------|
| Problem statements (from AtCoder) | Japanese | Original language, quoted as-is |
| Technical descriptions (algorithms, complexity) | English | 30-40% token reduction |
| C# code comments & XML docs | Japanese | Human readability for developers |
| Analysis file headers | English | Structural elements |
