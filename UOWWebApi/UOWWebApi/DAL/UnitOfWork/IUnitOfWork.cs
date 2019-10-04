using System;
using UOWWebApi.DAL.Repository;

namespace UOWWebApi.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ITestRepository Test { get; }

        int Complete();
    }
}
