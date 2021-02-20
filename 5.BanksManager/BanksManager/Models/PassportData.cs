using System;
using System.Timers;

namespace BanksManager.Models
{
    public class PassportData
    {
        public DateTime IssueDate { get; }
        public string Series { get; }
        public string Number { get; }

        public PassportData()
        {
            IssueDate = new DateTime();
            Series = "0000";
            Number = "000000";
        }

        public PassportData (DateTime issueDate, string series, string number)
        {
            IssueDate = issueDate;
            Series = series;
            Number = number;
        }

    }
}