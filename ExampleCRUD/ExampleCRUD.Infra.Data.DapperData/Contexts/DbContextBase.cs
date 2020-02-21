using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace ExampleCRUD.Infra.Data.DapperData.Contexts
{
    public class DbContextBase: Domain.IDbContexts.IDbContextBase
    {
        private IDbConnection _connection;
        private IConfiguration _configuration;
        public DbContextBase(IConfiguration configuration, DbProviderFactory dbProviderFactory, params Type[] mappers)
        {
            _configuration = configuration;
            DbProviderFactory = dbProviderFactory;
            _configurationContext = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>),
            new List<Assembly>(),
            new SqlServerDialect());
        }

        protected string ConnectionString => _configuration.GetConnectionString("DefaultConnection");

        protected DbProviderFactory DbProviderFactory { get; private set; }

        private DapperExtensionsConfiguration _configurationContext;

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    var factory = DbProviderFactory;
                    _connection = factory.CreateConnection();
                    _connection.ConnectionString = ConnectionString;

                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection.Dispose();
                _connection = null;
                GC.SuppressFinalize(this);
            }
        }

        public T GetConfigurationContext<T>() where T : class
        {
            return this._configurationContext as T;
        }
    }
}
