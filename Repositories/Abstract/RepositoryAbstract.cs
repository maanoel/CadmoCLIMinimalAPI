using Contracts;
using Entities.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public class RepositoryAbstract<Model>
        where Model : class, new()
    {
        private readonly ILoggerManager _Logger;
        /// <summary>
        /// 
        /// Collection name in DataBase
        /// </summary>

        /// <summary>
        /// Context
        /// </summary>
        /// <summary>
        /// Name's database 
        /// </summary>
        /// <summary>
        /// Schema's database
        /// </summary>
#region Construtor
        public RepositoryAbstract(ApiDbContext context, ILoggerManager Logger, IConfiguration configuration)
        {
            _context = context;
            _Logger = Logger;
            DataBaseName = configuration.GetValue<string>("dataBaseName");
            SchemaDataBase = configuration.GetValue<string>("schemaDataBase");
        }

#endregion
#region Get
        /// <summary>
        /// Recover all records with (Deleted = false)
        /// </summary>
        /// <returns></returns>
        {
            return _context.Set<Model>().AsEnumerable();
        }

        /// <summary>
        /// Return record by Id
        /// </summary>
        /// <param name = "id"></param>
        /// <returns></returns>
        {
            return _context.Set<Model>().Find(id)!;
        }

        /// <summary>
        /// Query with filters predicate
        /// </summary>
        /// <param name = "predicate"></param>
        /// <returns></returns>
        {
            var dbSet = _context.Set<Model>();
            var query = dbSet.Where(predicate);
            return query;
        }

#endregion
#region CRUD
        /// <summary>
        /// Insert New Record
        /// </summary>
        /// <param name = "record"></param>
        /// <returns></returns>
        {
            _context.Set<Model>().Add(record);
            _context.SaveChanges();
            var jsonModel = JsonConvert.SerializeObject(record);
            LogTable("insert", jsonModel);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "record"></param>
        /// <returns></returns>
        {
            _context.Set<Model>().Add(record);
            await _context.SaveChangesAsync();
            var jsonModel = JsonConvert.SerializeObject(record);
            LogTable("insert", jsonModel);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "record"></param>
        /// <returns></returns>
        {
            _context.Set<Model>().Update(record);
            _context.SaveChanges();
            var jsonModel = JsonConvert.SerializeObject(record);
            LogTable("update", jsonModel);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "record"></param>
        /// <returns></returns>
        {
            SetUpdateDate(record);
            _context.Set<Model>().Update(record);
            await _context.SaveChangesAsync();
            var jsonModel = JsonConvert.SerializeObject(record);
            LogTable("update", jsonModel);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "Id"></param>
        /// <returns></returns>
        {
            var model = this.SelectById(Id);
            _context.Set<Model>().Remove(model);
            _context.SaveChanges();
            var jsonModel = JsonConvert.SerializeObject(model);
            LogTable("delete", jsonModel);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(int Id)
        {
            var model = this.SelectById(Id);
            _context.Set<Model>().Remove(model);
            await _context.SaveChangesAsync();
            var jsonModel = JsonConvert.SerializeObject(model);
            LogTable("delete", jsonModel);
            return true;
        }

#endregion
#region Helper methods 
        private static void SetUpdateDate(Model record)
        {
            var propertyUpdateDate = record.GetType().GetProperty("UpdateDate");
            if (propertyUpdateDate != null)
            {
                record.GetType().GetProperty("UpdateDate")!.SetValue(record, DateTime.Now);
            }
        }

        private void LogTable(string crud, string message)
        {
            try
            {
                _Logger.LogInfo(string.Format("{0}: {1} ", crud, message));
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name = "T"></typeparam>
        /// <param name = "Name"></param>
        /// <param name = "Obj"></param>
        /// <returns></returns>
        {
            T result = (T)Obj.GetType().GetProperty(Name)!.GetValue(Obj)!;
            return result;
        }

        protected static void SetValue(object inputObject, string propertyName, object propertyVal)
        {
            Type type = inputObject.GetType();
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName)!;
            if (propertyInfo != null)
            {
                var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                propertyVal = Convert.ChangeType(propertyVal, targetType!);
                propertyInfo.SetValue(inputObject, propertyVal, null);
            }
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
#endregion
    }
}