# 🚀 Potopopi CamSync v1.3.1 - Stability & AI Update

This release focuses on improving the reliability of the AI engine and stabilizing Immich synchronization.

### ✨ New Features
- **Configurable AI Blur Sensitivity**: You can now adjust the blur threshold in Settings. Lower values are more lenient, perfect for bokeh-heavy portrait photography.
- **Advanced Blur Detection**: Implemented a new grid-based Laplacian variance method for more accurate identification of out-of-focus areas.

### 🦾 Improvements & Fixes
- **Automated Release Pipeline**: Merging to `main` now automatically bumps the version, updates documentation, builds the application, and creates a GitHub Release.
- **Dynamic Test Execution**: Integration tests now automatically run on local development machines but skip in CI environments to prevent stalls, ensuring better local code quality.
- **AI Module Detection**: Fixed a bug where the app would re-prompt for AI module downloads even if they were already present in the runtimes folder.
- **Immich Sync Stabilization**:
    - Gracefully handles `409 Conflict` (Duplicate) errors, reporting them as "Skipped" instead of "Failed."
    - Updated connectivity checks to use the `/users/me` endpoint for more reliable API key validation.
    - Enhanced diagnostic logging for server-side errors.
- **Progress Tracking**: Corrected the sync progress percentage to accurately account for files skipped by the AI or the Immich filter.

---
*Note: This is an automated release triggered by a bugfix merge.*
