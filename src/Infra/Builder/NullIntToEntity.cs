using System;
using Omu.ValueInjecter;
using Core.Model;
using Core.Repository;

namespace Infra.Builder
{
    public class NullIntToEntity : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(int?) && targetType.IsSubclassOf(typeof(DelEntity));
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            if (sourcePropertyValue == null) return null;
            var id = ((int?)sourcePropertyValue).Value;

            dynamic repo = IoC.Resolve(typeof(IRepo<>).MakeGenericType(TargetPropType));

            return repo.Get(id);
        }
    }
}