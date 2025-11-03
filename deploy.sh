#!/bin/bash
set -e

source "./deploy.env"

mkdir -p "$PUBLISH_DIR"
mkdir -p "$DEPLOY_DIR"
mkdir -p "$BACKUP_DIR"

echo "[INFO] Changing directory to repository..."
cd "$GIT_DIR"

if [ ! -d ".git" ]; then
    echo "[INFO] Cloning repository..."
    git clone "$GIT_REPO" .
else
    echo "[INFO] Pulling latest code..."
    git pull
fi

echo "[INFO] Building project..."
dotnet clean
dotnet build -c "$BUILD_CONFIGURATION"

echo "[INFO] Publishing project..."
dotnet publish -c "$BUILD_CONFIGURATION" -o "$PUBLISH_DIR"

TIMESTAMP=$(date '+%Y%m%d_%H%M')
if [ -d "$DEPLOY_DIR" ]; then
    BACKUP_FILE="$BACKUP_DIR/deploy_$TIMESTAMP.tar.gz"
    echo "[INFO] Creating backup at $BACKUP_FILE"
    tar -czf "$BACKUP_FILE" -C "$DEPLOY_DIR" .
fi

echo "[INFO] Copying new build to $DEPLOY_DIR"
rm -rf "$DEPLOY_DIR/*"
cp -r "$PUBLISH_DIR/"* "$DEPLOY_DIR/"

echo "[INFO] Deployment completed successfully."
