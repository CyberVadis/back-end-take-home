# User Capability Service

## Context

Our complex software ecosystem requires a way to manage features that depend on one another, for which users hold specific permissions. We would appreciate help building a service that determines user capabilities.

## Task

Your assignment is to design and implement a service that resolves feature flags and user permissions into a complete set of capabilities.

### Business Rules

- A feature flag is identified by a globally unique, alphanumeric name. Any flag can be active or inactive.
  - (Optional) A flag can be active for a period of time. Outside this period, it will automatically become inactive.
- To handle cases where features depend on each other, a feature flag can be dependent on one or more other flags. A feature flag is _enabled_ under these conditions:
  - If a master flag is inactive, all dependent flags must also be inactive.
  - If a master flag is active, dependent flags can be either active or inactive based on their individual states.
  - Flag dependencies must be defined explicitly, and circular dependencies should be disallowed.
- A user can be granted permission to any feature flag.
- If a user is granted permission for a flag, and that flag is enabled, it becomes a capability for the user.

### User Stories

The core functionality can be described through the following user stories:

1. **As an administrator**, I want to define feature flags for the system so that I can establish the set of all available features and their interdependencies.
2. **As a System**, I want to grant a user permission for any of the feature flags so that their access rights are recorded and can be used to calculate their capabilities.
3. **As a Client Application**, I want to get the complete set of capabilities for a specific user so that I can tailor the user experience accordingly.

### Technical Requirements

- .NET with code in F# or C#.
- RESTful API.
- Data persistence (e.g., in-memory, files, or a database).
- Test framework of your choice, if you plan to write tests.
- Git for change tracking.

## Solution

- Try not to spend more than 4 hours on this task.
- In case you don't implement everything, please document what's left and what you would do next.
- If you use AI, highlight AI-aided parts, including the prompts and models you used.
- For unspecified rules or behaviors, apply common sense and industry best practices.
- Deliver a working solution and include instructions on how to run it.

### Submission

Provide a link to a GitHub repository with your solution to the recruitment team.
