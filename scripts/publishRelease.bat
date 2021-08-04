ECHO ON
cd /d ..\src\Api.ConfTerm.Application
dotnet publish -c Release .
heroku container:login
heroku container:push web -a conf-term
heroku container:release web -a conf-term
PAUSE