using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.Models;

namespace WorkForceManagement.Services
{
    public interface ISoftlockService
    {
        Task<IEnumerable<SoftLock>> SaveAsync(string locationJson);

    }

    public class SoftlockService : ISoftlockService
    {
        private readonly SQLiteDBContext _context;

        public Task<IEnumerable<SoftLock>> SaveAsync(string locationJson)
        {
            throw new NotImplementedException();
        }
    }
}
