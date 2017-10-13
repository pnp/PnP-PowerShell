# Set-PnPContext

## SYNOPSIS
Sets the Client Context to use by the cmdlets

## SYNTAX 

```powershell
Set-PnPContext -Context <ClientContext>
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPOnline -Url $siteAurl -Credentials $credentials
PS:> $ctx = Get-PnPContext
PS:> Get-PnPList # returns the lists from site specified with $siteAurl
PS:> Connect-PnPOnline -Url $siteBurl -Credentials $credentials
PS:> Get-PnPList # returns the lists from the site specified with $siteBurl
PS:> Set-PnPContext -Context $ctx # switch back to site A
PS:> Get-PnPList # returns the lists from site A
```



## PARAMETERS

### -Context
The ClientContext to set

```yaml
Type: ClientContext
Parameter Sets: (All)

Required: True
Position: 1
Accept pipeline input: True
```

# RELATED LINKS

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)