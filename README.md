*Simple leaderboard server with profanity filtering.*

[![Deploy to DO](https://www.deploytodo.com/do-btn-blue.svg)](https://marketplace.digitalocean.com/apps/docker)

## Anonymous names
The API is designed for leaderboards with anonymous players (i.e. players won't need an account to appear on the leaderboard). In order to mitigate abuse, usernames are processed as follows:
* Usernames are sanitized of profanity (see [PurgoMalum](https://www.purgomalum.com))
* Usernames are removed of whitespace characters
* Usernames are removed of digit characters

# Setup
## Docker
* Choose an `AUTH_KEY` in docker-compose.yml.

# See Also
[![Open in Gitpod](https://gitpod.io/button/open-in-gitpod.svg)](https://gitpod.io#https://github.com/andtechstudios/trophy)
