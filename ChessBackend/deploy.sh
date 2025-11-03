#!/bin/bash
set -e

echo "[INFO] Loading environment variables..."
source ./deploy.env

echo "[INFO] Changing directory to repository..."
cd "$GIT_DIR"

echo "[INFO] Pulling latest code..."
git pull || echo "[WARN] Git pull failed or no updates"

echo "[INFO] Cleaning publish folder..."
rm -rf "${PUBLISH_DIR:?}/*"

echo "[INFO] Building and publishing projects..."
dotnet publish "$GIT_DIR/ChessBackend.sln" -c "$BUILD_CONFIGURATION" -o "$PUBLISH_DIR"

echo "[INFO] Creating backup..."
TIMESTAMP=$(date '+%Y%m%d_%H%M')
BACKUP_FILE="${BACKUP_DIR}/deploy_${TIMESTAMP}.tar.gz"
mkdir -p "$BACKUP_DIR"
tar -czf "$BACKUP_FILE" -C "$PUBLISH_DIR" .

echo "[INFO] Deployment completed locally."

# -----------------------------
# Push changes to GitHub (optional)
# -----------------------------
if [[ "${PUSH_GIT:-}" == "true" ]]; then
    echo "[INFO] Adding changes to git..."
    git add .
    git commit -m "Deploy: update published build $TIMESTAMP"
    git push origin main
    echo "[INFO] Changes pushed to GitHub."
fi
