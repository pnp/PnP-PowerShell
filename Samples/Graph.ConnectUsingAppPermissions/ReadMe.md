# Connect to the Microsoft Graph using Application Permissions

This PowerShell sample demonstrates how to use the Office Dev PnP PowerShell to connect to the Microsoft Graph
using Application Permissions. Using application permissions is useful for automated tasks
and service scenarios where you don't have an end-user logging in.

Applies to


- Office 365 Multi-Tenant (MT)

## Prerequisites ##
	Register an Application
	Consent to the application
	PnP PowerShell Commands

## GETTING STARTED ##
The PnP commandlets are using the Microsoft Authentication Library (MSAL) to connect with the Microsoft Graph on the v2 endpoint. Compared to ADAL
which connects using the v1 endpoint, MSAL allows connection to the Microsoft Graph with Microsoft Accounts, Azure AD and Azure AD B2C. This

### Register your application
To use application permissions against the Microsoft Graph you first have to register your application.
You do this at [https://apps.dev.microsoft.com](https://apps.dev.microsoft.com). Once logged in click
add a new Converged application, by clicking *Add an app*

![alt text][Screen1]

Give your application a name and hit *Create application*.

In the application configuration screen configure the following:
* Generate a password and make a note of it together with the application id
* Click 'Add Platform' and select *Mobile application* as the platform target as the application does not have a landing page
* Add the neccessary Application Permission. In this sample app we have added the right to read and write to all Office 365 Groups, as well as the ability to read users which is needed in PnP when adding owners and members.
* Make sure to uncheck 'Live SDK support'

Once configured save your changes.

![alt text][Screen2]

[Screen1]: CreateApp-1.png "Add an app"
[Screen2]: CreateApp-2.png "Configure app"

### Consent to the application

In this sample the Group.ReadWrite.All application permission require admin consent in a tenant
before it can be used. Create a consent URL like the following:

```
https://login.microsoftonline.com/<tenant>/adminconsent?client_id=<clientid>&state=<something>
```

Using the client id from the app registered and consenting to the app from my tenant *techmikael.onmicrosoft.com*,
the URL looks like this:

```
https://login.microsoftonline.com/techmikael.onmicrosoft.com/adminconsent?client_id=2994aca5-7ef4-4179-89ff-c1ce18fa052f&state=12345
```

Browsing to the created URL and log in as a tenant admin, and consent to the application. You
can see the consent screen show the name of your application as well as the permission scopes
you configured.

![alt text][Consent]

[Consent]: Consent.png "Consent application in tenant"

### Test the application using PnP
Using the application id and application password from the application registration you can
connect to the Microsoft Graph.

```PowerShell
> Connect-PnPMicrosoftGraph -AppId '2994aca5-7ef4-4179-89ff-c1ce18fa052f' -AppSecret 'NvgASDFS4564fas' -AADDomain 'techmikael.onmicrosoft.com'
```

If all went as expected you should now be able to list all Office 365 Groups in the tenant.

```PowerShell
> Get-PnPUnifiedGroup

DisplayName                    Group Id                               Site URL
-----------                    --------                               --------
Public Group                   b2ad65af-cff8-20ac-8084-6c2fe4bb7764   https://techmikael.sharepoint.com/s...
Private Group                  ab846f52-c193-42f3-9a3f-d008bf3c1d79   https://techmikael.sharepoint.com/s...
```


## Solution ##
Author(s)</br>
Mikael Svenson (Puzzlepart)

## Version history ##
Version  | Date | Comments
---------| -----| --------
1.0  | Feb 17 2017 | Initial release

## Resources ##
* [How to use Application Permission with v2 endpoint and Microsoft Graph][1]
* [Microsoft Graph app authentication using Azure AD][2]

[1]: https://blogs.msdn.microsoft.com/tsmatsuz/2016/10/07/application-permission-with-v2-endpoint-and-microsoft-graph/
[2]: https://graph.microsoft.io/en-us/docs/authorization/app_authorization

## **Disclaimer** 
THIS CODE IS PROVIDED AS IS WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
________________________________________

