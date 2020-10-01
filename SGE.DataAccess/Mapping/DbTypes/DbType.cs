using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Mapping.DbTypes
{
    public static class DbType
    {
        public const string Varchar = "character varying";
        public const string Jsonb = "jsonb";
        public static string Decimal(int precision1, int precision2) => $"decimal({precision1}, {precision2})";
    }
}
