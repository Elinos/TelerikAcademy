using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.SQLite;

namespace FilesShelf.Models.Database
{
    public class DbCommon : FilesShelfDbObject
    {
        public static string ConvertListOfObjectsToString(object[] objs)
        {
            string result = "";
            bool isFirst = true;
            foreach (object obj in objs)
            {
                result += ((isFirst) ? "" : ", ") + SQLiteDatabase.EscapeSpecialChars(obj.ToString());
                if (isFirst)
                {
                    isFirst = false;
                }
            }
            return result;
        }
    }
}
