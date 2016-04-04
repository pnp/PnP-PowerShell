using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using OfficeDevPnP.PowerShell.Commands.Extensions;

namespace OfficeDevPnP.PowerShell.Commands.InvokeAction
{
    internal class InvokeAction
    {
        protected Cmdlet _cmdlet;

        public InvokeAction(Cmdlet cmdlet)
        {
            _cmdlet = cmdlet;
        }

        public InvokeActionResult StartProcessAction(IEnumerable<Web> webs, 
            bool subWebs,
            InvokeActionParameter<Web> webActions, 
            InvokeActionParameter<List> listActions, 
            InvokeActionParameter<ListItem> listItemActions)
        {
            Stopwatch totalExecutionTimeStopWatch = Stopwatch.StartNew();

            InvokeActionResult result = new InvokeActionResult();

            int currentWebsProcessed = 0;
            int currentListsProcessed = 0;
            int currentListItemsProcessed = 0;

            double averageWebTime = 0;
            double averageListTime = 0;
            double arverageListItemTime = 0;

            bool processAction;

            if (subWebs)
                webs = webs.Select(item => item.GetAllWebsRecursive().Concat(new[] { item })).SelectMany(item => item).ToList();

            webActions.Properties = AddProperties(webActions.Properties, "Title", "Url");

            if (listActions.HasAnyAction || listItemActions.HasAnyAction)
            {
                webActions.Properties = AddProperties(webActions.Properties, "Lists");
                listActions.Properties = AddProperties(listActions.Properties, "Title", "ItemCount");
                listItemActions.Properties = AddProperties(listItemActions.Properties, "Id");


                //Counting

                foreach (var currentWeb in webs)
                {
                    currentWeb.LoadProperties(webActions.Properties);

                    if (!webActions.ShouldProcessAnyAction(currentWeb))
                        continue;
                    
                    foreach (var currentList in currentWeb.Lists)
                    {
                        if (!listActions.ShouldProcessAnyAction(currentList))
                            continue;

                        result.TotalListItemCount += currentList.ItemCount;
                        result.TotalListCount++;
                    }

                    result.TotalWebCount++;
                }
            }

            int webCount = webs.Count();
            result.TotalWebCount = webCount;
            int webIndex = 0;
            foreach (var currentWeb in webs)
            {
                Stopwatch webStopWatch = Stopwatch.StartNew();

                currentWeb.LoadProperties(webActions.Properties);
                if (!webActions.ShouldProcessAnyAction(currentWeb))
                    continue;

                int itemCount;
                int itemProccesedCount;
                double averageTime;

                if (!listActions.HasAnyAction && !listItemActions.HasAnyAction)
                {
                    itemCount = result.TotalWebCount;
                    itemProccesedCount = currentWebsProcessed;
                    averageTime = averageWebTime;
                }
                else if (listItemActions.HasAnyAction)
                {
                    itemCount = result.TotalListCount;
                    itemProccesedCount = currentListsProcessed;
                    averageTime = averageListTime;
                }
                else
                {
                    itemCount = result.TotalListItemCount;
                    itemProccesedCount = currentListItemsProcessed;
                    averageTime = arverageListItemTime;
                }

                processAction = ProccessAction(1, "Iterating Webs", webIndex, result.TotalWebCount, currentWeb, GetTitle, webActions.Properties, webActions.ShouldProcessAction, webActions.Action, ref itemProccesedCount, itemProccesedCount, ref averageTime);
                if (!processAction)
                    continue;

                if(listActions.HasAnyAction || listItemActions.HasAnyAction)
                {
                    ListCollection lists = currentWeb.Lists;
                    int listCount = lists.Count;
                    int listIndex = 0;

                    foreach (List currentList in lists)
                    {
                        Stopwatch listStopWatch = Stopwatch.StartNew();

                        WriteIterationProgress(1, "Iterating webs", GetTitle(currentWeb), webIndex, result.TotalWebCount, itemCount, itemProccesedCount, averageWebTime, totalExecutionTimeStopWatch);

                        processAction = ProccessAction(2, "Iterating lists", listIndex, listCount, currentList, GetTitle, listActions.Properties, listActions.ShouldProcessAction, listActions.Action, ref listIndex, listCount, ref averageListTime);
                        if (!processAction)
                            continue;

                        if (listItemActions.HasAction)
                        {
                            ListItemCollection listItems = currentList.GetItems(CamlQuery.CreateAllItemsQuery());
                            currentList.Context.Load(listItems);
                            currentList.Context.ExecuteQueryRetry();

                            int listItemCount = listItems.Count;
                            int listItemIndex = 0;

                            foreach (ListItem currentListItem in listItems)
                            {
                                ProccessAction(3, "Iterating list items", listItemIndex, listItemCount, currentListItem, GetTitle, listItemActions.Properties, listItemActions.ShouldProcessAction, listItemActions.Action, ref listItemIndex, listItemCount, ref arverageListItemTime);
                            }
                        }
                    }
                }
            }
            
            return result;
        }

        private bool ProccessAction<T>(int id, string activity, int index, int itemCount, T item, Func<T, string> getTitle, string[] properties, Func<T, bool> shouldProcessAction, Action<T> action, ref int itemsProcessed, int totalCount, ref double averageTime) where T : SecurableObject
        {
            Stopwatch actionStopWatch = Stopwatch.StartNew();
            item.LoadProperties(properties);

            string title = getTitle(item);

            WriteIterationProgress(id, activity, title, index, itemCount, totalCount, itemsProcessed, averageTime);

            bool processAction = ProcessAction(item, title, shouldProcessAction, action);

            if (processAction)
            {
                itemsProcessed++;
                averageTime = CalculateAverage(averageTime, actionStopWatch.Elapsed.TotalSeconds, itemsProcessed);
            }

            return processAction;
        }

        private string GetTitle(Web web) => $"{web.Title} - {web.Url}";

        private string GetTitle(List list) => $"{list.Title}";

        private string GetTitle(ListItem listItem)
        {
            string statusText = "";

            if (!string.IsNullOrEmpty(listItem["Title"]?.ToString()) &&
                listItem.File != null &&
                listItem.File.IsObjectPropertyInstantiated(item => item.Name) &&
                string.IsNullOrEmpty(listItem.File.Name))
            {
                statusText = $"{listItem["Title"]} - {listItem.File.Name}";
            }
            else if (!string.IsNullOrEmpty(listItem["Title"]?.ToString()))
                statusText = listItem["Title"].ToString();
            else
                statusText = listItem.Id.ToString();
            
            return statusText;
        }

        private double CalculateAverage(double averageTime, double totalSeconds, int currentItemsProcessed) => averageTime + ((totalSeconds - averageTime) / currentItemsProcessed);

        private bool ProcessAction<T>(T target, string targetTitle, Func<T, bool> shouldProcessAction, Action<T> action)
        {
            bool processAction = false;

            if (shouldProcessAction == null)
            {
                processAction = true;
               _cmdlet.WriteDebug("No should process script block, will process action");
            }
            else
            {
                _cmdlet.WriteVerbose("Invoking should process function");
                processAction = shouldProcessAction(target);
            }

            _cmdlet.WriteVerbose("ShouldProcessAction: " + processAction);

            if(processAction && action != null)
            {
                _cmdlet.WriteVerbose("Invoking action function");

                if(_cmdlet.ShouldProcess(targetTitle, "Process action"))
                {
                    action(target);
                }
            }

            return processAction;
        } 

        private void WriteIterationProgress(int id, string activity, string status, int currentIndex, int itemCount, int totalItemCount = 0, int itemsProcessed = 0, double? averageTime = null, Stopwatch stopwatch = null)
        {
            string activityText = $"{activity}, {currentIndex + 1}/{itemCount}";

            if (stopwatch != null)
                activity += ", " + stopwatch.Elapsed.ToString("hh\\:mm\\:ss");

            string statusText = status;

            if (string.IsNullOrEmpty(statusText))
                statusText = " ";

            int procentComplete = (currentIndex / itemCount) * 100;

            ProgressRecord progressRecord = new ProgressRecord(id, activityText, statusText)
            {
                PercentComplete = procentComplete
            };

            if (averageTime.HasValue)
            {
                int secondsRemaining = (int)(averageTime * (totalItemCount - itemsProcessed));
                progressRecord.SecondsRemaining = secondsRemaining;
            }

            _cmdlet.WriteProgress(progressRecord);
        }

        protected string[] AddProperties(string[] properties, params string[] propertiesToAdd)
        {
            if (properties == null)
                return propertiesToAdd;

            return properties.Union(propertiesToAdd).ToArray();
        }
    }
}
