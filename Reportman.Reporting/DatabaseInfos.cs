﻿using System;
using System.Data;

namespace Reportman.Reporting
{
    public class DatabaseInfos : System.Collections.Generic.List<DatabaseInfo>, ICloneable
    {
        public DataSet MemoryDataSet;
        public DatabaseInfos()
        {
            MemoryDataSet = new DataSet();
        }
        /// <summary>
        /// Get item by name
        /// </summary>
        /// <param name="dbname">Database info name or alias</param>
        /// <returns></returns>
        public DatabaseInfo this[string dbname]
        {
            get
            {
                int index = IndexOf(dbname);
                if (index >= 0)
                    return this[index];
                else
                    return null;
            }
        }
        /// <summary>
        /// Returns index by name (alias)
        /// </summary>
        /// <param name="avalue">Alias to search for</param>
        /// <returns>Index or -1 when not found</returns>
        public int IndexOf(string avalue)
        {
            int aresult = -1;
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Alias == avalue)
                {
                    aresult = i;
                    break;
                }
            }
            return aresult;
        }
        /// <summary>
        /// Clone the DatabaseInfos collection
        /// </summary>
        /// <returns>A new DatabaseInfos collection</returns>
        public object Clone()
        {
            DatabaseInfos ninfo = new DatabaseInfos();
            foreach (DatabaseInfo ainfo in this)
            {
                ninfo.Add((DatabaseInfo)ainfo.Clone());
            }
            return ninfo;
        }
        /// <summary>
        /// Clone the DatabaseInfos collection
        /// </summary>
        /// <param name="areport">New owner</param>
        /// <returns>A new DatabaseInfos collection</returns>
        public DatabaseInfos Clone(Report areport)
        {
            DatabaseInfos ninfo = new DatabaseInfos();
            foreach (DatabaseInfo ainfo in this)
            {
                ninfo.Add(ainfo.Clone(areport));
            }
            return ninfo;
        }
    }

}
