using ExampleCRUD.Domain.IDbContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExampleCRUD.Infra.Data.DapperData.UnitOfWords
{
	public class UnitOfWork : Domain.IUnitOfWords.IUnitOfWord, IDisposable
	{
		public UnitOfWork(IDbContextBase dbContext)
		{
			DbContext = dbContext;
		}

		public IDbTransaction Transaction { get; private set; }

		public IDbContextBase DbContext { get; private set; }

		public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
		{
			if (Transaction == null)
			{
				Transaction = DbContext.Connection.BeginTransaction(isolationLevel);
			}

			return Transaction;
		}

		public void Commit()
		{
			if (Transaction != null)
			{
				Transaction.Commit();
				Transaction.Dispose();
				Transaction = null;
			}

		}

		public void Rollback()
		{
			if (Transaction != null)
			{
				Transaction.Rollback();
				Transaction.Dispose();
			}
			Transaction = null;
		}

		public void Dispose()
		{
			if (Transaction != null)
			{
				Transaction.Dispose();
			}
			if (DbContext != null)
			{
				DbContext.Dispose();
			}
		}
	}
}
