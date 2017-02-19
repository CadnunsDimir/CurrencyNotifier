using CadnunsDev.CurrencyNotifier.Core.DB.Types;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadnunsDev.CurrencyNotifier.Core.DB
{
    public class DbQueries
    {
        private SQLiteConnection conn;
        public string DbName { get; private set; }
        public string ConnectionString { get { return "Data Source=" + DbName; } }
        public DbQueries(string dbName = "SimpleDb.sqlite")
        {
            DbName = dbName;
            //DbName = dbName ?? AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\SimpleDb.sqlite";
            if (!File.Exists(DbName))
            {
                SQLiteConnection.CreateFile(DbName);
                

                Dapper.SqlMapper.AddTypeHandler(typeof(decimal), new DecimalTypeHadler());

                UsingConnection(conn =>
                {
                    conn.Execute(Constantes.CurrencyTable);
                    conn.Execute(Constantes.CurrencyLogTable);
                });
            }
            SqlMapper.AddTypeHandler(new DecimalTypeHadler());
            //UsingConnection(conn =>
            //{                
            //    conn.Execute(Constantes.CurrencyLogTable);
            //});

            //ValidacaoBancoDeDados.Validar(this);
        }
        protected IDbConnection GetConnection()
        {
            conn = new SQLiteConnection(ConnectionString);
            
            conn.Open();
            return conn;
        }

        protected void UsingConnection(Action<IDbConnection> action)
        {
            using (var conn = GetConnection())
            {
                action(conn);
                conn.Close();
            }
        }
    }
}
