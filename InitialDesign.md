# Feature Flag Service

## Stack

Using dotnet 9 with C#
RESTful API
DataBase to be defined

## Project

FeatureFLag.API
FeatureFLag.API.Tests
FeatureFLag.Services
FeatureFLag.Services.Tests
FeatureFLag.Repository
FeatureFLag.Repository.Tests

## Out of Scope
Front-end app to interact with the APIs

## Endpoints
(toggle)


### PUT  api/FeatureFlags
#### User Stories 1: Create Feature flags

Request 
```json
{
    "flagname"="{flag-name}"
}
```
Response 200,400,500

### GET  api/FeatureFlags
#### User Stories 2: Get all Feature flags

Request  {}
Response 
```json
{
    {
        "flaId"="1",
        "flagname"="filterTable"
    },
    {
        "flaId"="2",
        "flagname"="orderTable"
    }
}
```

### GET  api/FeatureFlags/{flag-name}
#### User Stories 3: Get view the complete configuration of a single flag

Request  {}
Response 
```json
{
    "flaId"="1",
    "flagname"="{flag-name}",
    "Enviroments": [
        {"Name" = "test", "Value" = "true", "created" = "today", "userLastChange" = "Admin"},
        {"Name" = "prod", "Value" = "false", "created" = "today", "userLastChange" = "Admin"}
    ]
}
```

### POST api/FeatureFlags/
#### User Stories 4: Activate or deactivate a feature flag for a specific environment
Request 
```json
{
    "flagname"="{flag-name}",
    "Enviroment" = "test",
    "Value" = "true"
}
```

Response 200,400,500


### GET api/Audit/{flag-name}
#### User Stories 5: History of state changes for a flag

Request  {}
Response 
```json
{
    "flaId"="1",
    "flagname"="{flag-name}",
    "History": [
        {
            "Action" = "create", 
            "Detail" = "flagName={name}, Value=false", 
            "dateTime" = "today", 
            "byUser" = "Developer"
        },
        {
            "Action" = "update", 
            "Detail" = "flagName={name}, value =true", 
            "dateTime" = "today", 
            "byUser" = "Admin"
        }
    ]
}
```

### DELETE api/FeatureFlags/{flag-name}
#### User Stories 6: Remove a feature flag from the system entirely once the feature has been fully released and the code has been cleaned up.
##### I prefer change deleted flag to true, in the future should be a background tasks to delete all marked as deleted to delete history. But since is a development tests will implemented as requested.
Request {}
Response: 200,400,500

### GET api/FeatureFlags/{flag-name}/{user}/{enviroment}
#### User Stories 7: Check if a feature flag is currently active for my specific environment

Request  {}
Response 
```json
{
    "enviroment"="prod",
    "flagname"="{flag-name}",
    "user" = "username",
    "isActive" = "false"
}
```


### GET api/Checkflags/{flag-name}/{user}/{enviroment}
#### User Stories 8: Configure a flag to be active for a certain percentage of users in an environment. a/b testing



## Commands
### Git
git flow init
git flow feature start scaffolding-and-configuration
...
git flow feature finish scaffolding-and-configuration



