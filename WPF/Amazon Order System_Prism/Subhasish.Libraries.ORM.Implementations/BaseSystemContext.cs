using Subhasish.Libraries.ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.ORM.Implementations
{
    public class BaseSystemContext:DbContext,ISystemContext
    {
        private const string CONNECTION_STRING_KEY = "SubhasishPracticeDB";
        private static string CONNECTION_STRING = 
            ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString;


        public BaseSystemContext() : base(CONNECTION_STRING) { }

        public void Commit()
        {
            this.SaveChanges();
        }

        public IEnumerable<T> ExecuteRoutine<T>(string routineName, IDictionary<string, object> parameter = null)
        {
            var tList = default(IEnumerable<T>);

            var validationStatus = !string.IsNullOrEmpty(routineName);

            if (validationStatus)
            {
                var sqlParameter = new List<SqlParameter>();
                if (parameter!=default(IDictionary<string,object>) && parameter.Count> default(int))
                {
                    foreach (var parameterKey in parameter.Keys)
                    {
                        sqlParameter.Add(new SqlParameter(parameterKey, parameter[parameterKey]));
                    }
                }

                tList = Database.SqlQuery<T>(routineName, sqlParameter.ToArray()).ToList();
            }

            return tList;
        }
    }
}
