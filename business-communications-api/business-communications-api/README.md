# Business Communications API - C#

RCS for Business uses the [Business Communications API](https://developers.google.com/business-communications/rcs-business-messaging/reference/business-communications/rest) for two
separate sets of operations:

-   For developers: to create RCS for Business agents, manage assets and
    submit agents for approval. These are known as [RBM Management API](https://developers.google.com/business-communications/rcs-business-messaging/guides/management-api/overview) functions.
-   For carriers: to approve, reject and suspend RCS for Business agents
    submitted to their network. These are know as [RBM Operations API](https://developers.google.com/business-communications/rcs-business-messaging/carriers/operations-api/get-started) features.

## Prerequisites

This library builds with the Dotnet 8.0 SDK. Follow installation instructions at
https://dotnet.microsoft.com/en-us/download.

## Building locally

You can build and install a local version with:

```
dotnet build
```

## Work still to do

We aim to publish builds to nuget.org shortly.

## Change log

1.0.6

-   Regenerated to include Business Communications API definitions as of Jan
    8 2026.
-   Renaming from RBM to RCS for Business.
-   Includes new
    [Tester API](https://developers.google.com/business-communications/rcs-business-messaging/reference/business-communications/rest/v1/testers).
-   Principal entity required for launching in India to comply with local
    regulations.

1.0.5

-   Regenerated to include Business Communications API definitions as of Sept
    5 2025.
-   Product renaming to RCS for Business.
-   New tester API support to add and delete testers, list testers and retrieve
    the status of a tester invite.
