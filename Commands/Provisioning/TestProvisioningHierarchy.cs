using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsDiagnostic.Test, "PnPProvisioningHierarchy", SupportsShouldProcess = true)]
    [CmdletHelp("Tests a provisioning hierarchy for invalid references",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Test-PnPProvisioningHierarchy -Hierarchy $myhierarchy",
       Remarks = "Checks for valid template references",
       SortOrder = 1)]
    public class TestProvisioningHierarchy : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The hierarchy to add the sequence to", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ProvisioningHierarchy Hierarchy;

        protected override void ExecuteCmdlet()
        {
            List<string> issues = new List<string>();
            foreach(var sequence in Hierarchy.Sequences)
            {
                foreach (var site in sequence.SiteCollections)
                {
                    foreach (var template in site.Templates)
                    {
                        if(Hierarchy.Templates.FirstOrDefault(t => t.Id == template) == null)
                        {
                            issues.Add($"Template {template} referenced in site {site.Id} is not present in hierarchy.");
                        }
                    }
                    foreach(var subsite in site.Sites.Cast<TeamNoGroupSubSite>())
                    {
                        foreach (var template in subsite.Templates)
                        {
                            if (Hierarchy.Templates.FirstOrDefault(t => t.Id == template) == null)
                            {
                                issues.Add($"Template {template} referenced in subsite with url {subsite.Url} in site {site.Id} is not present in hierarchy");
                            }
                        }
                    }
                }
            }
            foreach(var template in Hierarchy.Templates)
            {
                var used = false;
                foreach(var sequence in Hierarchy.Sequences)
                {
                    foreach(var site in sequence.SiteCollections)
                    {
                        if(site.Templates.Contains(template.Id))
                        {
                            used = true;
                            break;
                        }

                        foreach(var subsite in site.Sites)
                        {
                            if(subsite.Templates.Contains(template.Id))
                            {
                                used = true;
                                break;
                            }
                        }
                        if (used)
                        {
                            break;
                        }
                    }
                    if(used)
                    {
                        break;
                    }
                }
                if(!used)
                {
                    issues.Add($"Template {template.Id} is not used by any site in the hierarchy.");
                }
            }
            if(issues.Any())
            {
                WriteObject(issues, true);
            }

        }
    }
}
