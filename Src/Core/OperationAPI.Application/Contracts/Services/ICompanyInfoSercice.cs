using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
    public interface ICompanyInfoSercice : IGenericService<CompanyInfoDomain>
    {
        Task<bool> IsActive(CompanyInfoDomain model);
    }
}
