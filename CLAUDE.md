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
  - `subagent-communication.md`: How agents collaborate via shared files

## Specialized Agents

This repository uses specialized Claude Code agents for efficient problem-solving workflows:

### 1. `atcoder-problem-analyzer`
**Purpose**: Analyze AtCoder problems and create structured analysis files

**When to use:**
- Before implementing a solution to understand the problem
- To fetch and analyze official editorials
- To determine optimal algorithms and complexity requirements

**Output**: Creates 3 files in `workspaces/ai/claude/`:
- `problem-statement.md` - Problem description and constraints
- `problem-statement-testcases.md` - Sample test cases
- `problem-statement-explanation.md` - Solution approach and algorithm recommendations

**Example usage:**
```
"Analyze ABC350 problem C"
"Get the official editorial for this problem"
```

### 2. `csharp-problem-solver`
**Purpose**: Implement C# solutions based on problem analysis

**When to use:**
- After problem analysis is complete
- To implement solutions in `workspaces/csharp/Murnana.AtCoder/Program.cs`
- For debugging and optimizing C# solutions

**Prerequisites**: Analysis files from `atcoder-problem-analyzer` should exist in `workspaces/ai/claude/`

**Example usage:**
```
"Implement this problem in C#"
"Debug the current solution in Program.cs"
```

### Agent Workflow (Recommended)

**Two-stage approach** for optimal efficiency:

```
Stage 1: Problem Analysis
  User → atcoder-problem-analyzer
       ↓
  Fetches problem from AtCoder
  Analyzes constraints & algorithms
       ↓
  Outputs 3 files to workspaces/ai/claude/

Stage 2: Implementation
  User → csharp-problem-solver
       ↓
  Reads analysis files
  Implements in Program.cs (Japanese comments)
       ↓
  Tests and debugs solution
```

**Why this approach?**
- ✅ Separation of concerns (analysis vs implementation)
- ✅ Analysis files reusable across multiple languages
- ✅ Token efficiency through hybrid language approach
- ✅ Better debugging (can review analysis separately)

## Workflow
### Branches
- **`main`**: Stable code
- **`feature/abc###`**: Contest-specific work (created during contests)

### Development Flow

#### Using Specialized Agents (Recommended)
1. **Problem Analysis**: Use `atcoder-problem-analyzer` to analyze the problem
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

**See**: `docs/ai/claude/subagent-communication.md` for detailed documentation
