# RCS for Business: Management API - Csharp

These code samples demonstrate how to use the RBM Management API C# SDK to manage agents, agent launches and brands.

## Prerequisites

This library builds with the Dotnet 8.0 SDK. Follow installation instructions at
https://dotnet.microsoft.com/en-us/download.

## Setup: Obtaining your Service Account Key

1.  Open the RBM Developer Console
    (https://business-communications.cloud.google.com/console/) with your RBM
    Platform Google account and proceed to Partner settings.

2.  Choose an RBM-enabled Partner Account in the top dropdown (pre-registered or
    created via self-registration).

3.  In the left navigation, click **Service account**.

4.  Click **Create key**, then click **Create**. Your browser downloads a
    service account key for your RBM Partner account. You need this key to make
    RBM Messaging and Management API calls as your agent(s).

5.  Add the service account key JSON to
    `rbm-developer-service-account-credentials.json`.

## Running the code samples

1.  In a terminal, navigate to this sample's root directory.

2.  Compile the samples:

```
dotnet build
```

### Creating a tester

```
dotnet run add_test_device=true msisdn=<Tester MSISDN with + and country code> agent_id=<agent id without '@rbm.goog'>
```

### Checking tester status

```
dotnet run get_tester=true tester_id=<Tester id returned from create or list> agent_id=<agent id without '@rbm.goog'>
```

### Listing testers

```
dotnet run list_testers=true agent_id=<agent id without '@rbm.goog'>
```