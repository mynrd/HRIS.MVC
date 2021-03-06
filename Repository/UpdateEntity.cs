﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UpdateEntity<TModelSource, TModelDestination>
        where TModelDestination : EntityBase
    {
        public TModelSource DataSource { get; set; }
        public TModelDestination DataDestination { get; set; }
        public IRepository<TModelDestination> Repository { get; set; }
        private bool _ignoreErrorInSetValue = false;

        public UpdateEntity(TModelSource source, TModelDestination destination, IRepository<TModelDestination> repository)
        {
            this.DataSource = source;
            this.DataDestination = destination;
            this.Repository = repository;
        }

        public UpdateEntity<TModelSource, TModelDestination> Update()
        {
            this.Repository.Update(this.DataDestination);
            return this;
        }

        public TModelDestination GetEntity()
        {
            return this.DataDestination;
        }

        public UpdateEntity<TModelSource, TModelDestination> Insert()
        {
            this.Repository.Insert(this.DataDestination);
            return this;
        }

        public UpdateEntity<TModelSource, TModelDestination> IgnoreErrorSetValue()
        {
            this._ignoreErrorInSetValue = true;
            return this;
        }

        public void Delete()
        {
            this.Repository.Delete(this.DataDestination);
        }

        public UpdateEntity<TModelSource, TModelDestination> SetValue<TProperty>(
            Expression<Func<TModelDestination, TProperty>> destination,
            Expression<Func<TModelSource, TProperty>> source)
        {
            var pi_source = GetPropertyInfo(source);
            var pi_destination = GetPropertyInfo(destination);

            pi_destination.SetValue(this.DataDestination, pi_source.GetValue(this.DataSource));

            return this;
        }

        public UpdateEntity<TModelSource, TModelDestination> SetValue(string destinationField, object value)
        {
            var pi_destination = typeof(TModelDestination).GetProperty(destinationField);
            pi_destination.SetValue(this.DataDestination, value);
            return this;
        }

        public UpdateEntity<TModelSource, TModelDestination> MatchAllDataField()
        {
            var allowedFields = new[] {
                typeof(string),
                typeof(byte),typeof(byte?),
                typeof(Guid),typeof(Guid?),
                typeof(int),typeof(int?),
                typeof(long),typeof(long?),
                typeof(decimal),typeof(decimal?),
                typeof(double),typeof(double?),
                typeof(DateTime),typeof(DateTime?),
                typeof(bool),typeof(bool?),
            };

            var props = this.DataDestination.GetType().GetProperties().Where(x => allowedFields.Contains(x.PropertyType));

            foreach (var propDestination in props)
            {
                var propSource = this.DataSource.GetType().GetProperties().FirstOrDefault(x => x.Name == propDestination.Name);
                if (propSource != null)
                {
                    if (!propSource.GetCustomAttributes<PrimaryKeyAttribute>().Any())
                    {
                        if (!propSource.GetCustomAttributes<ExcludeToUpdateAttribute>().Any())
                        {
                            bool isTheSame = false;
                            object value = propSource.GetValue(this.DataSource);
                            try
                            {
                                isTheSame = value == propDestination.GetValue(this.DataDestination);
                            }
                            catch { }

                            if (!isTheSame)
                            {
                                try
                                {
                                    propDestination.SetValue(this.DataDestination, value);
                                }
                                catch
                                {
                                    if (this._ignoreErrorInSetValue) continue;
                                }
                            }
                        }
                    }
                }
            }

            return this;
        }

        //public UpdateEntity<TModelSource, TModelDestination> SetValue<TProperty>(
        //   Expression<Func<TModelDestination, TProperty>> destination)
        //{
        //    var pi_destination = GetPropertyInfo(destination);

        //    if (!this.DataSource.GetType().GetProperties().Any(x => x.Name == pi_destination.Name))
        //    {
        //        throw new Exception("Unable to find column " + pi_destination.Name + " in DataSource.");
        //    }

        //    var pi_source = this.DataSource.GetType().GetProperty(pi_destination.Name);

        //    pi_destination.SetValue(this.DataDestination, pi_source.GetValue(this.DataSource));

        //    return this;
        //}

        public UpdateEntity<TModelSource, TModelDestination> SetValue<TProperty>(Expression<Func<TModelDestination, TProperty>> destination, object data)
        {
            var pi_destination = GetPropertyInfo(destination);

            pi_destination.SetValue(this.DataDestination, Util.ConvertValue(data, pi_destination.PropertyType));

            return this;
        }

        private PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }
    }
}