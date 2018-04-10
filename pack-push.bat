del /F /Q .\artifacts\*.*
dotnet pack RandomGen.sln -o ..\..\artifacts
dotnet nuget push "artifacts\*.nupkg" -s nuget.org