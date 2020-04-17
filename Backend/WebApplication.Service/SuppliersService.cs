using System.Collections.Generic;
using System.Linq;
using DailyReports.Contracts.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DailyReports.Contracts.Models;
using DailyReports.Repositories;
using DailyReports.Service.Helpers;
using Dapper;

namespace DailyReports.Service
{
   public class SuppliersService : ISuppliers
   {
       private readonly SuppliersRepository _suppliersRepository;
        public SuppliersService(SuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

       
        public List<Supplier> GetSuppliers(int stationId, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }
            var result = _suppliersRepository.GetSuppliersList(stationId, validationMessages);
            return result;
        }

        public int? UpsertSupplier(Supplier supplier, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }
            var result = _suppliersRepository.AddSupplier(supplier, validationMessages);
            return result;
        }

        public bool? DeleteSupplier(int suplierId, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }
         return  _suppliersRepository.DeleteSupplier(suplierId, validationMessages);
          
        }
    }
}
