﻿using HRIS.Model.Sys;
using System.Collections.Generic;
using System.Linq;

namespace HRIS.Service.Sys
{
    public interface ICompanyService
    {
        void UpdateCurrentCompany(CompanyModel model);

        IEnumerable<ValueText> GetList();

        IQueryable<CompanyModel> GetQuery();

        bool IsMoreThanOneCompany();

        CompanyModel GetCurrentCompany();
    }
}