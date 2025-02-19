﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar
{
    public class OracleUpdateable<T> : UpdateableProvider<T> where T : class, new()
    {
        protected override List<string> GetIdentityKeys()
        {
            return this.EntityInfo.Columns.Where(it => it.OracleSequenceName.HasValue()).Select(it => it.DbColumnName).ToList();
        }
        public override int ExecuteCommand()
        {
            if (base.UpdateObjs.Count() == 1)
            {
                return base.ExecuteCommand();
            }
            else if (base.UpdateObjs.Count() == 0)
            {
                return 0;
            }
            else
            {
                base.ExecuteCommand();
                return base.UpdateObjs.Count();
            }
        }
        public async override  Task<int> ExecuteCommandAsync()
        {
            if (base.UpdateObjs.Count() == 1)
            {
                return await base.ExecuteCommandAsync();
            }
            else if (base.UpdateObjs.Count() == 0)
            {
                return 0;
            }
            else
            {
                await base.ExecuteCommandAsync();
                return base.UpdateObjs.Count();
            }
        }
    }
}
