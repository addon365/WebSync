using Microsoft.EntityFrameworkCore;
using Addon365.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync.DAL
{
    public interface IAppContext : IDisposable
    {
        DbSet<Report> Reports { get; }
        int SaveChanges();
        void MarkAsModified(Report item);
    }
}
