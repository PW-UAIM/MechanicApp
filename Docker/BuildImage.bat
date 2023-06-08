docker login -u majumi -p uaimrzadzi

docker rmi majumi/mechanicapp:application

docker build -f ../majumi.MechanicApp.BlazorServer/Dockerfile.prod -t majumi/mechanicapp:application ..

docker logout

pause
