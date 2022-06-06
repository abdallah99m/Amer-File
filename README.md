## Amer app: 

## build environment instructions:
### for mssql db
- make sure docker is installed
- git clone <repo>
- docker-compose -f docker-compose.yml up -d --build

### rebuild docker-compose file after changes
- docker-compose -f docker-compose.yml up -d --build

### stop containers (only stops containers)
- docker-compose -f docker-compose.yml stop

### destroy containers (will remove containers)
- docker-compose -f docker-compose.yml down
