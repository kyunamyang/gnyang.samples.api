using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.infrastructure
{
    public static class DbHelper
    {
        public static string GetQueryForInsert(string[] columns, bool forParameter = false)
        {
            if (forParameter)
            {
                return "@" + string.Join(", @", columns);
            }

            return string.Join(", ", columns);
        }

        public static string GetQueryForInsert(bool forParameter = false)
        {
            if (forParameter)
            {
                return "@Created, @CreatedBy, @Deleted, @DeletedBy";
            }
            return "Created, CreatedBy, Deleted, DeletedBy";
        }

        public static string GetQueryForUpdate(string[] columns)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < columns.Length; i++)
                builder.AppendFormat("{0} = @{0}", columns[i]);

            string result = builder.ToString();
            builder.Clear();

            return result;
        }

        public static string GetQueryForUpdate()
        {
            return "Created = @Created, CreatedBy = @CreatedBy, Deleted = @Deleted, DeletedBy = @DeletedBy";
        }
    }
}
