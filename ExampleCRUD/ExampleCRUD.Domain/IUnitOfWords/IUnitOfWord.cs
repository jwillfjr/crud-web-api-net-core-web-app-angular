using ExampleCRUD.Domain.IDbContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExampleCRUD.Domain.IUnitOfWords
{
   
	public interface IUnitOfWord
	{
		IDbContextBase DbContext { get; }
		IDbTransaction Transaction { get; }
		IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
		void Commit();
		void Rollback();
	}

}
