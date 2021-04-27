VERSION=$1

echo "⬆️  Uploading the build to itch.io"

~/bin/butler push "$(dirname "$0")/Builds/$VERSION" agrdev/darkest-forest:WebGL --userversion $VERSION

echo "✅  Build uploaded"