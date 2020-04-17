using System;
using System.Collections.Generic;

namespace DailyReports.Contracts.Interfaces
{
    public interface IDailyReports
    {
        List<Models.DailyReports> GetDailyReports(DateTime date);
        void AddReport(Contracts.Models.DailyReports report);
    }
}
