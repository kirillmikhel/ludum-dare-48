echo "⬆️  Uploading all the builds to itch.io"

~/bin/butler push "$(dirname "$0")/Builds/StandaloneOSX" agrdev/darkest-forest:mac-build
~/bin/butler push "$(dirname "$0")/Builds/StandaloneWindows64" agrdev/darkest-forest:windows-build
~/bin/butler push "$(dirname "$0")/Builds/WebGL" agrdev/darkest-forest:webgl-build

echo "✅  Build uploaded"