rm -rf linux-publish/
dotnet publish --configuration Release -r ubuntu.16.04-x64 -o linux-publish
