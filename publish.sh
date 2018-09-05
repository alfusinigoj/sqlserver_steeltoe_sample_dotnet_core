echo "dotnet publish"

rm -r _publish 
dotnet publish -o _publish
cp manifest.yml ... _publish