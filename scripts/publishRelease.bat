ECHO ON
cd ../../../../../
cmd /c "heroku container:login"
cmd /c "heroku container:push web -a conf-term"
cmd /c "heroku container:release web -a conf-term"
ECHO "PUSHOU"
PAUSE