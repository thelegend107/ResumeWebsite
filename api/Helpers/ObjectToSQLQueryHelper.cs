using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ResumeAPI.Helpers
{
    public static class ObjectToSQLQueryHelper<T> where T : new()
    {
        private static readonly object obj = new T();

        public static StringBuilder GenerateQuery()
        {
            StringBuilder sb = new StringBuilder();

            List<string> properties = new List<string>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties().Where(p => !p.GetGetMethod().IsVirtual))
                properties.Add(prop.Name);

            sb.AppendLine("SELECT ");
            sb.AppendLine("\t" + string.Join("," + Environment.NewLine + "\t", properties));
            sb.AppendLine($"FROM [dbo].[{obj.GetType().Name}]");

            return sb;
        }
    }
}
