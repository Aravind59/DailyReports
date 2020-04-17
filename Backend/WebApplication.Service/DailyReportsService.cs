using System;
using System.Collections.Generic;
using DailyReports.Contracts.Interfaces;
using DailyReports.Repositories;

namespace DailyReports.Service
{
   public class DailyReportsService : IDailyReports
   {
     
       private readonly DailyreportsRepository _dailyReportsRepository;

       public DailyReportsService(DailyreportsRepository dailyReportsRepository)
       {
           _dailyReportsRepository = dailyReportsRepository;
       }

        public List<Contracts.Models.DailyReports> GetDailyReports(DateTime date)
        {
            return _dailyReportsRepository.GetDailyReports(date);
        }

        public void AddReport(Contracts.Models.DailyReports report)
        {
            _dailyReportsRepository.AddReport(report);
          
        }

    }

}
