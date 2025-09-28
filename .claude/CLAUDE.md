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
- **See `workspaces/XXX/CLAUDE.md` for details**

## Workflow
### Branches
- **`main`**: Stable code
- **`feature/abc###`**: Contest-specific work (created during contests)

### Development Flow
1. **Contest participation**: Implement in `workspaces/csharp/Murnana.AtCoder/Program.cs`, use SourceExpander for single-file submission via `Combined.csx`
2. **Reference**: Check `contests/` for past solutions
