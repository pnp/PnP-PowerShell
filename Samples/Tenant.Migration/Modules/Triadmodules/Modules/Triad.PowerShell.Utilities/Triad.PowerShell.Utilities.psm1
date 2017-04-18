
function Get-TMCredential
<#
.SYNOPSIS
Collect password form the configuration file or ask user for password

.DESCRIPTION
The password is read from the configuration file. If no paassword is found then a login window will be presented to the user.

.EXAMPLE
./Get-TMCredential -Environment $environment

.PARAMETER Environment
Supply the environment xml form the config file


#>
{
	param(
		 [string]$Environment  
	)

	begin
	{
		[xml]$environmentXml = $Environment


		$password = $environmentXml.Environment.Password
		$username = $environmentXml.Environment.Username
	}

	process
	{
		if ($password -eq "" -or $password -eq $null)
		{
			$cred = Get-Credential -UserName $username -Message "Please enter password for $username"
		}
		else
		{
			$encpassword = convertto-securestring -String $password -AsPlainText -Force
    		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $encpassword
		}
	}


	end
	{
		return $cred
	}
}


