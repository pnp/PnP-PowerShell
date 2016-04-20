using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands.InvokeAction
{
    public class InvokeWebActionResult
    {
        public int TotalWebCount { get; internal set; }
        public int ProcessedWebCount { get; internal set; }
        public int ProcessedPostWebCount { get; internal set; }

        public int TotalListCount { get; internal set; }
        public int ProcessedListCount { get; internal set; }
        public int ProcessedPostListCount { get; internal set; }

        public int TotalListItemCount { get; internal set; }
        public int ProcessedListItemCount { get; internal set; }

        public bool IsListNameSpecified { get; internal set; }

        public double AverageWebTime { get; internal set; }
        public double AverageListTime { get; internal set; }
        public double AverageListItemTime { get; internal set; }

        public double AveragePostWebTime { get; internal set; }
        public double AveragePostListTime { get; internal set; }

        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }

        public TimeSpan TotalExecutionTime => EndDate - StartDate;

        public DataTable ToDataTable()
        {
            DataTable resultTable = new DataTable("InvokeWebActionResult");
            DataColumn titleColumn = new DataColumn("Title", typeof(string));
            DataColumn valueColumn = new DataColumn("Value", typeof(string));

            resultTable.Columns.Add(titleColumn);
            resultTable.Columns.Add(valueColumn);

            if (!IsListNameSpecified)
            {
                AddTableRow(resultTable, "Number of webs", TotalWebCount);

                if (ProcessedWebCount != 0)
                    AddTableRow(resultTable, "Number of webs proccessed", ProcessedWebCount);

                if (ProcessedWebCount != 0)
                    AddTableRow(resultTable, "Number of webs post proccessed", ProcessedWebCount);


                if (ProcessedListCount != 0 || ProcessedListItemCount != 0 || ProcessedPostListCount != 0 || ProcessedListItemCount != 0)
                {
                    AddTableRow(resultTable, "Number of lists", TotalListCount);

                    if (ProcessedListCount != 0)
                        AddTableRow(resultTable, "Number of lists proccessed", ProcessedListCount);

                    if(ProcessedPostListCount != 0)
                        AddTableRow(resultTable, "Number of lists post proccessed", ProcessedPostListCount);
                }
            }

            if (ProcessedListItemCount != 0 || ProcessedPostListCount != 0)
            {
                AddTableRow(resultTable, "Number of list items", TotalListItemCount);

                if (ProcessedListItemCount != 0)
                    AddTableRow(resultTable, "Number of list items proccessed", ProcessedListItemCount);
            }

            if (!IsListNameSpecified)
            {
                if (AverageWebTime != 0)
                {
                    TimeSpan averageWebTimeSpan = new TimeSpan(0, 0, (int)AverageWebTime);
                    AddTableRow(resultTable, "Average web action time", averageWebTimeSpan.ToString("dd\\.hh\\:mm\\:ss"));
                }

                if (AveragePostWebTime != 0)
                {
                    TimeSpan averagePostWebTimeSpan = new TimeSpan(0, 0, (int)AveragePostWebTime);
                    AddTableRow(resultTable, "Average web post action time", averagePostWebTimeSpan.ToString("dd\\.hh\\:mm\\:ss"));
                }
            }

            if (ProcessedListCount != 0 || ProcessedListItemCount != 0)
            {
                if (AverageListTime != 0)
                {
                    TimeSpan averageListTimeSpan = new TimeSpan(0, 0, (int)AverageListTime);
                    AddTableRow(resultTable, "Average list action time", averageListTimeSpan.ToString("dd\\.hh\\:mm\\:ss"));
                }

                if (AveragePostListTime != 0)
                {
                    TimeSpan averagePostListTimeSpan = new TimeSpan(0, 0, (int)AveragePostListTime);
                    AddTableRow(resultTable, "Average list action time", averagePostListTimeSpan.ToString("dd\\.hh\\:mm\\:ss"));
                }
            }

            if (AverageListItemTime != 0)
            {
                TimeSpan averageListItemTimeSpan = new TimeSpan(0, 0, (int)AverageListItemTime);
                AddTableRow(resultTable, "Average list item action time", averageListItemTimeSpan.ToString("dd\\.hh\\:mm\\:ss"));
            }

            AddTableRow(resultTable, "Start date", StartDate);
            AddTableRow(resultTable, "End date", EndDate);

            AddTableRow(resultTable, "Total execution time", TotalExecutionTime.ToString("dd\\.hh\\:mm\\:ss"));

            return resultTable;
        }

        private void AddTableRow(DataTable table, string title, object value)
        {
            System.Data.DataRow row = table.NewRow();

            row["Title"] = title;
            row["Value"] = value?.ToString();

            table.Rows.Add(row);
        }
    }
}
