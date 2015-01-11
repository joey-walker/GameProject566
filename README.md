#Roleplaying Game
##Project Members: Joey, Mentu, Sarthak, Deep

##Title: Work in Progress

#Rules:

1. Please do not complete your own pull requests.  All pull requests should be reviewed by a second group member.

2. Commit and push often.

#Git Setup:

1. Download and install git: http://git-scm.com/

2. Fork the joey-walker/GameProject on github.

3. Create an empty directory on your computer where you will store this project.

4. Clone your fork.

`` 
Grab the link of your fork on the side on github. Enter empty new directory.
cmd> git clone https://github.com/"usernamehere"/GameProject566.git
cmd> cd GameProject566
cmd> git checkout development.
``

5. Create a remote to our upstream project.

``cmd> git remote add dev https://github.com/joey-walker/GameProject566.git ``

6. Configure credentials so you don't have to keep inputting username and password.

``git config --global credential.helper wincred``

##Git usage/cycle:

``
cmd> git status # See current changes

cmd> git diff # Review changes and clean up

cmd> git add . # Add all modified files

cmd> git status # check what has been added

cmd> git commit -m "This has been changed" #Commit the code

cmd> git status # no working changes now

cmd> git fetch dev #Grab all changes from upstream

cmd> git merge dev #merge changes in

 CLEAN UP ALL MERGE CONFLICTS... edit...add..commit..

 Build project in your IDE to ensure tests run

cmd> git push origin #push changes

cmd> git status #See if branch is up to date
``
____________________________

##Pull Requests

1. Go to https://github.com/joey-walker/GameProject566.git
2. Create pull request
3. Make title and comment on your changes.
4. Submit pull request
5. Nobody create a merge conflict......
