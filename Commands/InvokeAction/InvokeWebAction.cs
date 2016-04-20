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
	internal class InvokeWebAction
	{
		protected const int WebProgressBarId = 1;
		protected const int ListProgressBarId = 2;
		protected const int ListItemProgressBarId = 3;

		protected readonly Cmdlet _cmdlet;

		protected InvokeWebActionResult _result;
		protected int _currentWebsProcessed = 0;
		protected int _currentListsProcessed = 0;
		protected int _currentListItemsProcessed = 0;

		protected int _currentPostWebsProcessed = 0;
		protected int _currentPostListsProcessed = 0;

		protected double _averageWebTime = 0;
		protected double _averageListTime = 0;
		protected double _averageListItemTime = 0;

		protected double _averagePostWebTime = 0;
		protected double _averagePostListTime = 0;

		protected readonly IEnumerable<Web> _webs;
		protected readonly bool _subWebs;
		protected readonly string _listName;
		protected readonly bool _isListNameSpecified;
		protected readonly InvokeActionParameter<Web> _webActions;
		protected readonly InvokeActionParameter<List> _listActions;
		protected readonly InvokeActionParameter<ListItem> _listItemActions;

		protected readonly bool _skipCounting;

		protected Stopwatch _totalExecutionTimeStopWatch;

		private InvokeWebAction(Cmdlet cmdlet, bool subWebs, InvokeActionParameter<Web> webActions, InvokeActionParameter<List> listActions, InvokeActionParameter<ListItem> listItemActions, bool skipCounting)
		{
			_cmdlet = cmdlet;
			_subWebs = subWebs;

			//We will update the InvokeActionParameter parameters, thats why we create a copies.
			_webActions = webActions.ShallowCopy();
			_listActions = listActions.ShallowCopy();
			_listItemActions = listItemActions.ShallowCopy();

			_skipCounting = skipCounting;
		}

		public InvokeWebAction(Cmdlet cmdlet, IEnumerable<Web> webs, bool subWebs, InvokeActionParameter<Web> webActions, InvokeActionParameter<List> listActions, InvokeActionParameter<ListItem> listItemActions, bool skipCounting) : 
			this(cmdlet, subWebs, webActions, listActions, listItemActions, skipCounting)
		{
			_webs = webs;

			_isListNameSpecified = false;           
		}

		public InvokeWebAction(Cmdlet cmdlet, Web web, string listName, InvokeActionParameter<Web> webActions, InvokeActionParameter<List> listActions, InvokeActionParameter<ListItem> listItemActions, bool skipCounting) :
			this(cmdlet, false, webActions, listActions, listItemActions, skipCounting)
		{
			_listName = listName;
			_webs = new List<Web>() { web };

			_isListNameSpecified = true;
		}

		public InvokeWebActionResult StartProcessAction()
		{
			_totalExecutionTimeStopWatch = Stopwatch.StartNew();

			_result = new InvokeWebActionResult();
			_result.StartDate = DateTime.Now;

			UpdatePropertiesToLoad();

			List<Web> webs;
			if (_subWebs)
				webs = GetSubWebs(_webs.ToList());
			else
				webs = _webs.ToList();

			if (!_skipCounting)
				CountItems(webs);

			ProcessAction(webs);

			UpdateResult();
			
			return _result;
		}

		private void UpdatePropertiesToLoad()
		{
			_webActions.Properties = AddProperties(_webActions.Properties, "Title", "Url");

			if (_listActions.HasAnyAction || _listItemActions.HasAnyAction)
			{
				_webActions.Properties = AddProperties(_webActions.Properties, "Lists");
				_listActions.Properties = AddProperties(_listActions.Properties, "Title", "ItemCount");
				_listItemActions.Properties = AddProperties(_listItemActions.Properties, "Id");
			}
		}

		private List<Web> GetSubWebs(List<Web> webs)
		{
			List<Web> allWebs = new List<Web>();
			int webCount = webs.Count;
			for (int webIndex = 0; webIndex < webCount; webIndex++)
			{
				Web currentWeb = webs[webIndex];
				currentWeb.LoadProperties(_webActions.Properties);

				WriteIterationProgress(WebProgressBarId, null, "Fetching sub webs", GetTitle(currentWeb), webIndex, webCount);

				allWebs.AddRange(currentWeb.GetAllWebsRecursive());
				allWebs.Add(currentWeb);
			}

			webs = allWebs;

			CompleteProgressBar(WebProgressBarId);

			return allWebs;
		}

		private void CountItems(List<Web> webs)
		{
			_result.TotalWebCount = webs.Count;

			if (_listActions.HasAnyAction || _listItemActions.HasAnyAction)
			{
				//Counting
				int webCount = webs.Count;
				for (int webIndex = 0; webIndex < webCount; webIndex++)
				{
					Web currentWeb = webs[webIndex];
					currentWeb.LoadProperties(_webActions.Properties);

					WriteIterationProgress(WebProgressBarId, null, "Couting webs", GetTitle(currentWeb), webIndex, webCount, null, _totalExecutionTimeStopWatch);

					_result.TotalListCount = currentWeb.Lists.Count;
					_result.TotalListItemCount = currentWeb.Lists.Sum(item => item.ItemCount);

					bool processWeb = _webActions.ShouldProcessAnyAction(currentWeb);

					if (!processWeb)
						continue;

					_result.ProcessedWebCount++;

					if (!_listActions.HasAnyAction && !_listItemActions.HasAnyAction)
						continue;

					ListCollection lists = currentWeb.Lists;
					int listCount = lists.Count;

					for (int listIndex = 0; listIndex < listCount; listIndex++)
					{
						List currentList = lists[listIndex];
                        WriteIterationProgress(ListProgressBarId, WebProgressBarId, "Counting list", GetTitle(currentList), listIndex, listCount);

                        if ((_isListNameSpecified && currentList.Title.Equals(_listName, StringComparison.CurrentCultureIgnoreCase)) || _listActions.ShouldProcessAnyAction(currentList))
						{
							_result.ProcessedListCount++;
							_result.ProcessedListItemCount += currentList.ItemCount;
						}
					}

					CompleteProgressBar(ListProgressBarId);
				}

				CompleteProgressBar(WebProgressBarId);
			}
		}

		private void ProcessAction(List<Web> webs)
		{
			bool processAction;
			int webCount = webs.Count;
			for (int webIndex = 0; webIndex < webCount; webIndex++)
			{
				Web currentWeb = webs[webIndex];

				currentWeb.LoadProperties(_webActions.Properties);
				if (!_webActions.ShouldProcessAnyAction(currentWeb))
					continue;

				UpdateWebProgressBar(webs, webIndex, webCount, 0, _totalExecutionTimeStopWatch);

				processAction = ProccessAction(currentWeb, GetTitle, _webActions.Properties, _webActions.ShouldProcessAction, _webActions.Action, ref _currentWebsProcessed, ref _averageWebTime);

				if (!processAction)
					continue;

				if (_listActions.HasAnyAction || _listItemActions.HasAnyAction)
				{
					ListCollection lists = currentWeb.Lists;
					int listCount = lists.Count;

					for (int listIndex = 0; listIndex < listCount; listIndex++)
					{
						List currentList = lists[listIndex];

						if (_isListNameSpecified && !currentList.Title.Equals(_listName, StringComparison.CurrentCultureIgnoreCase))
							continue;

						//Update web progress bar
						UpdateWebProgressBar(webs, webIndex, webCount, listIndex, _totalExecutionTimeStopWatch);

						//Update list progress bar
						UpdateListProgressBar(lists, listIndex, listCount);

						processAction = ProccessAction(currentList, GetTitle, _listActions.Properties, _listActions.ShouldProcessAction, _listActions.Action, ref _currentListsProcessed, ref _averageListTime);

						if (!processAction)
							continue;

						if (_listItemActions.HasAnyAction)
						{
							ListItemCollection listItems = currentList.GetItems(CamlQuery.CreateAllItemsQuery());
							currentList.Context.Load(listItems);
							currentList.Context.ExecuteQueryRetry();

							int listItemCount = listItems.Count;

							for (int listItemIndex = 0; listItemIndex < listItemCount; listItemIndex++)
							{
								ListItem currentListItem = listItems[listItemIndex];

								//Update list item progress bar
								WriteIterationProgress(ListItemProgressBarId, ListProgressBarId, "Iterating list items", GetTitle(currentListItem), listItemIndex, listItemCount, CalculateRemainingTimeForListItems(listItemCount, listItemIndex));

								ProccessAction(currentListItem, GetTitle, _listItemActions.Properties, _listItemActions.ShouldProcessAction, _listItemActions.Action, ref _currentListItemsProcessed, ref _averageListItemTime);
							}

							CompleteProgressBar(ListItemProgressBarId);
						}

						processAction = ProccessAction(currentList, GetTitle, _listActions.Properties, _listActions.ShouldProcessPostAction, _listActions.PostAction, ref _currentPostListsProcessed, ref _averagePostListTime);
					}

					CompleteProgressBar(ListProgressBarId);
				}

				processAction = ProccessAction(currentWeb, GetTitle, _webActions.Properties, _webActions.ShouldProcessPost, _webActions.PostAction, ref _currentPostWebsProcessed, ref _averagePostWebTime);
			}

			CompleteProgressBar(WebProgressBarId);
		}

		private void UpdateResult()
		{
			_result.ProcessedWebCount = _currentWebsProcessed;
			_result.ProcessedListCount = _currentListsProcessed;
			_result.ProcessedListItemCount = _currentListItemsProcessed;

			_result.ProcessedPostWebCount = _currentPostWebsProcessed;
			_result.ProcessedPostListCount = _currentPostListsProcessed;

			_result.AverageWebTime = _averageWebTime;
			_result.AverageListTime = _averageListTime;
			_result.AverageListItemTime = _averageListItemTime;

			_result.AveragePostWebTime = _averagePostWebTime;
			_result.AveragePostListTime = _averagePostListTime;

			_result.EndDate = DateTime.Now;
		}

		private void UpdateWebProgressBar(List<Web> webs, int index, int count, int listProcessedOnCurrentWeb, Stopwatch totalExecutionTimeStopWatch)
		{
			WriteIterationProgress(WebProgressBarId, null, "Iterating webs", GetTitle(webs[index]), index, count, CalculateRemainingTimeForWeb(webs, index, listProcessedOnCurrentWeb), totalExecutionTimeStopWatch);
		}

		private void UpdateListProgressBar(ListCollection lists, int index, int count)
		{
			WriteIterationProgress(ListProgressBarId, WebProgressBarId, "Iterating lists", GetTitle(lists[index]), index, count, CalculateRemainingTimeForList(lists, index));
		}

		private bool ProccessAction<T>(T item, Func<T, string> getTitle, string[] properties, Func<T, bool> shouldProcessAction, Action<T> action, ref int itemsProcessed, ref double averageTime) where T : SecurableObject
		{
			Stopwatch actionStopWatch = Stopwatch.StartNew();
			item.LoadProperties(properties);

			string title = getTitle(item);

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

		private double CalculateRemainingTimeForWeb(List<Web> webs, int websProcessed = 0, int listProcessedOnCurrentWeb = 0)
		{
			if (_skipCounting)
				return -1;

			double timeRemaining = (_averageWebTime + _averagePostWebTime) * (webs.Count - websProcessed);

			//We have already processed the WebAction on current web, this will make the WebProgressBar and ListProgressBar in sync when iteration one web.
			if (listProcessedOnCurrentWeb > 0)
				timeRemaining -= _averageWebTime;

			if (_listActions.HasAnyAction || _listItemActions.HasAnyAction)
			{
				timeRemaining += CalculateRemainingTimeForList(webs[websProcessed].Lists, listProcessedOnCurrentWeb);
				timeRemaining += webs.Skip(websProcessed + 1).Sum(item => CalculateRemainingTimeForList(item.Lists));
			}

			return timeRemaining;
		}

		private double CalculateRemainingTimeForList(ListCollection lists, int itemsProcessed = 0)
		{
			if (_skipCounting)
				return -1;

			double timeRemaining = (_averageWebTime + _averagePostListTime) * (lists.Count - itemsProcessed);
			int remainingListItems = lists.Cast<List>().Skip(itemsProcessed).Sum(item => item.ItemCount);

			if(_listItemActions.HasAnyAction)
				timeRemaining += CalculateRemainingTimeForListItems(remainingListItems);

			return timeRemaining; 
		}

		private double CalculateRemainingTimeForListItems(int listItemsCount, int itemsProcessed = 0)
		{
			if (_skipCounting)
				return -1;

			return _averageListItemTime * (listItemsCount - itemsProcessed);
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

		private void WriteIterationProgress(int id, int? parentId, string activity, string status, int currentIndex, int itemCount, double? secondsRemaining = null, Stopwatch stopwatch = null)
		{
			string activityText = $"{activity}, {currentIndex + 1}/{itemCount}";

			if (stopwatch != null)
				activityText += ", " + stopwatch.Elapsed.ToString("dd\\.hh\\:mm\\:ss");

			string statusText = status;

			if (string.IsNullOrEmpty(statusText))
				statusText = " ";

			int procentComplete = (int) (((double)currentIndex / itemCount) * 100);

			ProgressRecord progressRecord = new ProgressRecord(id, activityText, statusText)
			{
				PercentComplete = procentComplete
			};

			if (parentId.HasValue)
				progressRecord.ParentActivityId = parentId.Value;

			if(secondsRemaining.HasValue && !_skipCounting)
				progressRecord.SecondsRemaining = (int) secondsRemaining.Value;

			_cmdlet.WriteProgress(progressRecord);
		}

		private void CompleteProgressBar(int id)
		{
            //Since you need the Activity name to close the progress bar we write an empty temporary activity first.
            _cmdlet.WriteProgress(new ProgressRecord(id, " ", " ")
            {
                PercentComplete = 100
            });

            _cmdlet.WriteProgress(new ProgressRecord(id, " ", " ")
			{
				RecordType = ProgressRecordType.Completed
			});
		}

		protected string[] AddProperties(string[] properties, params string[] propertiesToAdd)
		{
			if (properties == null)
				return propertiesToAdd;

			return properties.Union(propertiesToAdd).ToArray();
		}
	}
}
