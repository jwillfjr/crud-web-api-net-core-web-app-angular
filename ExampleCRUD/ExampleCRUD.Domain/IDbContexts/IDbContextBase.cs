using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExampleCRUD.Domain.IDbContexts
{
	public interface IDbContextBase : IDisposable
	{
		IDbConnection Connection { get; }
		T GetConfigurationContext<T>() where T : class;
	}
}
