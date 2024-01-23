using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Common
{
    public class Constants
    {
        private const string DbFileName = "ProjectMobilne.db3";
        public const string ApiUrl = "";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite
            | SQLiteOpenFlags.Create
            | SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DbFileName);

    }
}
