## Pull Request Guidelines

⚠️ **IMPORTANT**: Direct PRs to `main` branch are not allowed.

### Workflow:
1. Create your feature branch from `main`
2. Make your changes
3. Submit PR to `submit` branch first
4. After review and approval, changes will be merged to `main`

### Branch Structure:
- `main` - Production-ready code (protected)
- `submit` - Integration branch for reviews
- `feature/*` - Your development branches

### Before submitting:
- [ ] My PR targets the `submit` branch
- [ ] I've tested my changes locally
- [ ] I've updated documentation if needed
- [ ] My commits have clear messages

### Checklist:
- [ ] Code follows project coding standards
- [ ] All tests pass locally
- [ ] Documentation has been updated (if applicable)
- [ ] No merge conflicts with target branch
- [ ] PR description clearly explains the changes

### Types of Changes:
- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to change)
- [ ] Documentation update

---
**Note**: If you accidentally created a PR to `main`, please close it and create a new one targeting `submit`.

### Need Help?
Check our [Contributing Guidelines](CONTRIBUTING.md) for detailed instructions on the development workflow.