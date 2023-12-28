dotnet test WdbReader.sln --collect:"XPlat Code Coverage" --results-directory "TestResults"
dotnet tool install --global dotnet-reportgenerator-globaltool
reportgenerator -reports:TestResults/**/coverage.cobertura.xml -targetdir:TestResults/CoverageReport -reporttypes:html
start TestResults/CoverageReport/index.html
pause