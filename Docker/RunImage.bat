docker login -u majumi -p uaimrzadzi

docker stop mechanicapp

docker pull majumi/mechanicapp:application

docker run --name mechanicapp -p 5100:5100 -it majumi/mechanicapp:application

pause

docker stop mechanicapp

docker rm mechanicapp

pause
