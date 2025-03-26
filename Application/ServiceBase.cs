using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public abstract class ServiceBase<T>(IRepositoryBase<T> _repo) where T : class
    {
        protected IRepositoryBase<T> _currentRepo { get; set; } = _repo;
    }
}
