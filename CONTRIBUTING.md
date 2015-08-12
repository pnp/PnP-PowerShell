# Contribution guidance



*work in progress*



All PnP repositories are following up on the standard PnP process on getting started and contribute. 


See following PnP wiki page from the main repository for additional details. 



- For getting started guidance, see [Setting up your environment](https://github.com/OfficeDev/PnP/wiki/Setting-up-your-environment). 



*Notice that you'll need to update the URLs based on used repository. All community contributions are also more than welcome. 
Please see following page for additional insights on the model.



- For contributing to PnP, see [Contributing to Office 365 developer patterns and practices](https://github.com/OfficeDev/PnP/wiki/contributing-to-Office-365-developer-patterns-and-practices)



---


##Documentation contributions
If you want to contribute to cmdlet documentation, please do not make a pull request to modify the actual files in the Documentation folder itself. Those files
are automatically generated based upon comments in the actual classes. So if you want to modify documentation and or add an example of a cmdlet, navigate to the
corresponding class where the cmdlet is being implemented and add the comments there. An example can for instance be found in

https://github.com/OfficeDev/PnP-PowerShell/blob/dev/Commands/Fields/AddField.cs

Notice the [CmdletHelp("")] and [CmdletExample()] class attributes that describe the cmdlet.

##Cmdlet contributions

A few notes:
* Every new cmdlet should provide help and examples. 
* Most cmdlets will extend SPOWebCmdlet which provides a few helper objects for you to use. 
* Cmdlets will have to work both on-premises and in the cloud. You can use preprocessor variables ("CLIENTSDKV15" and "CLIENTSDKV16") to build different cmdlets for the different targets.
* The verb of a cmdlet (get-, add-, etc.) should follow acceptable cmdlet standards and should be part of one of the built in verbs classes (VerbsCommon, VerbsData, etc.)
 