using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SharePointPnP.PowerShell.ModuleFilesGenerator
{
    internal class MarkDownGenerator
    {
        private List<Model.CmdletInfo> _cmdlets;
        private string _solutionDir;
        private const string extension = "md";
        internal MarkDownGenerator(List<Model.CmdletInfo> cmdlets, string solutionDir)
        {
            _cmdlets = cmdlets;
            _solutionDir = solutionDir;
        }

        internal void Generate()
        {
            GenerateCmdletDocs();
            GenerateTOC();

            DirectoryInfo di = new DirectoryInfo($"{_solutionDir}\\Documentation");
            var mdFiles = di.GetFiles("*.md");

            // Clean up old MD files
            foreach (var mdFile in mdFiles)
            {
                if (mdFile.Name.ToLowerInvariant() != $"readme.{extension}")
                {
                    var index = _cmdlets.FindIndex(t => $"{t.Verb}{t.Noun}.{extension}" == mdFile.Name);
                    if (index == -1)
                    {
                        mdFile.Delete();
                    }
                }
            }
        }

        private void GenerateCmdletDocs()
        {

            foreach (var cmdletInfo in _cmdlets)
            {
                var originalMd = string.Empty;
                var newMd = string.Empty;


                if (!string.IsNullOrEmpty(cmdletInfo.Verb) && !string.IsNullOrEmpty(cmdletInfo.Noun))
                {
                    string mdFilePath = $"{_solutionDir}\\Documentation\\{cmdletInfo.Verb}{cmdletInfo.Noun}.{extension}";

                    if (System.IO.File.Exists(mdFilePath))
                    {
                        originalMd = System.IO.File.ReadAllText(mdFilePath);

                    }
                    var docBuilder = new StringBuilder();

                    // Header

                    docBuilder.AppendFormat("#{0}{1}", cmdletInfo.FullCommand, Environment.NewLine);

                    // Body 

                    docBuilder.AppendFormat("{0}{1}", cmdletInfo.Description, Environment.NewLine);

                    if (cmdletInfo.Syntaxes.Any())
                    {
                        docBuilder.AppendFormat("##Syntax{0}", Environment.NewLine);
                        foreach (var cmdletSyntax in cmdletInfo.Syntaxes.OrderBy(s => s.Parameters.Count(p => p.Required)))
                        {
                            var syntaxText = new StringBuilder();
                            syntaxText.AppendFormat("```powershell\r\n{0} ", cmdletInfo.FullCommand);
                            var cmdletLength = cmdletInfo.FullCommand.Length;
                            var first = true;
                            foreach (var par in cmdletSyntax.Parameters.Distinct(new ParameterComparer()).OrderBy(p => !p.Required).ThenBy(p => p.Position))
                            {
                                if (first)
                                {
                                    first = false;
                                }
                                else
                                {
                                    syntaxText.Append(new string(' ', cmdletLength + 1));
                                }
                                if (!par.Required)
                                {
                                    syntaxText.Append("[");
                                }
                                if (par.Type.StartsWith("Int"))
                                {
                                    par.Type = "Int";
                                }
                                if (par.Type == "SwitchParameter")
                                {
                                    syntaxText.AppendFormat("-{0} [<{1}>]", par.Name, par.Type);
                                }
                                else
                                {
                                    syntaxText.AppendFormat("-{0} <{1}>", par.Name, par.Type);
                                }
                                if (!par.Required)
                                {
                                    syntaxText.Append("]");
                                }
                                syntaxText.Append("\r\n");
                            }
                            // Add All ParameterSet ones
                            docBuilder.Append(syntaxText);
                            docBuilder.AppendFormat("```\n\n\n");
                        }
                    }
                    if (!string.IsNullOrEmpty(cmdletInfo.DetailedDescription))
                    {
                        docBuilder.Append("##Detailed Description\n");
                        docBuilder.AppendFormat("{0}\n\n", cmdletInfo.DetailedDescription);
                    }

                    if (cmdletInfo.OutputType != null)
                    {
                        docBuilder.Append("##Returns\n");
                        if (!string.IsNullOrEmpty(cmdletInfo.OutputTypeLink))
                        {
                            docBuilder.Append($">[{cmdletInfo.OutputType}]({cmdletInfo.OutputTypeLink})");
                        }
                        else
                        {
                            docBuilder.Append($">{cmdletInfo.OutputType}");
                        }
                        if (!string.IsNullOrEmpty(cmdletInfo.OutputTypeDescription))
                        {
                            docBuilder.Append($"\n\n{cmdletInfo.OutputTypeDescription}");
                        }
                        docBuilder.Append("\n\n");
                    }
                    if (cmdletInfo.Parameters.Any())
                    {
                        docBuilder.Append("##Parameters\n");
                        docBuilder.Append("Parameter|Type|Required|Description\n");
                        docBuilder.Append("---------|----|--------|-----------\n");
                        foreach (var par in cmdletInfo.Parameters.OrderBy(x => x.Name).Distinct(new ParameterComparer()).OrderBy(p => !p.Required))
                        {
                            if (par.Type.StartsWith("Int"))
                            {
                                par.Type = "Int";
                            }
                            docBuilder.AppendFormat("|{0}|{1}|{2}|{3}|\n", par.Name, par.Type, par.Required ? "True" : "False", par.Description);
                        }
                    }
                    if (cmdletInfo.Examples.Any())
                        docBuilder.Append("##Examples\n");
                    var examplesCount = 1;
                    foreach (var example in cmdletInfo.Examples.OrderBy(e => e.SortOrder))
                    {
                        docBuilder.AppendFormat("{0}\n", example.Introduction);
                        docBuilder.AppendFormat("###Example {0}\n", examplesCount);
                        docBuilder.AppendFormat("```powershell\n{0}\n```\n", example.Code);
                        docBuilder.AppendFormat("{0}\n", example.Remarks);
                        examplesCount++;
                    }

                    newMd = docBuilder.ToString();

                    var dmp = new DiffMatchPatch.diff_match_patch();

                    var diffResults = dmp.diff_main(newMd, originalMd);

                    foreach (var result in diffResults)
                    {
                        if (result.operation != DiffMatchPatch.Operation.EQUAL)
                        {
                            System.IO.File.WriteAllText(mdFilePath, docBuilder.ToString());
                            break;
                        }
                    }
                }
            }
        }

        private void GenerateTOC()
        {
            var originalMd = string.Empty;
            var newMd = string.Empty;

            // Create the readme.md
            var readmePath = $"{_solutionDir}\\Documentation\\readme.{extension}";
            if (System.IO.File.Exists(readmePath))
            {
                originalMd = System.IO.File.ReadAllText(readmePath);
            }
            var docBuilder = new StringBuilder();


            docBuilder.AppendFormat("# Cmdlet Documentation #{0}", Environment.NewLine);
            docBuilder.AppendFormat("Below you can find a list of all the available cmdlets. Many commands provide built-in help and examples. Retrieve the detailed help with {0}", Environment.NewLine);
            docBuilder.AppendFormat("{0}```powershell{0}Get-Help Connect-PnPOnline -Detailed{0}```{0}{0}", Environment.NewLine);

            // Get all unique categories
            var categories = _cmdlets.Where(c => !string.IsNullOrEmpty(c.Category)).Select(c => c.Category).Distinct();

            foreach (var category in categories.OrderBy(c => c))
            {
                docBuilder.AppendFormat("##{0}{1}", category, Environment.NewLine);

                docBuilder.AppendFormat("Cmdlet|Description{0}", Environment.NewLine);
                docBuilder.AppendFormat(":-----|:----------{0}", Environment.NewLine);
                foreach (var cmdletInfo in _cmdlets.Where(c => c.Category == category).OrderBy(c => c.Noun))
                {
                    var description = cmdletInfo.Description != null ? cmdletInfo.Description.Replace("\r\n", " ") : "";
                    docBuilder.AppendFormat("**[{0}]({1}{2}.md)** |{3}{4}", cmdletInfo.FullCommand.Replace("-", "&#8209;"), cmdletInfo.Verb, cmdletInfo.Noun, description, Environment.NewLine);
                }
            }

            newMd = docBuilder.ToString();
            DiffMatchPatch.diff_match_patch dmp = new DiffMatchPatch.diff_match_patch();

            var diffResults = dmp.diff_main(newMd, originalMd);

            foreach (var result in diffResults)
            {
                if (result.operation != DiffMatchPatch.Operation.EQUAL)
                {
                    System.IO.File.WriteAllText(readmePath, docBuilder.ToString());
                }
            }
        }
    }
}
