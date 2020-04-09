using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Framework.Infra.Extensions
{
    public static class EFCoreModelBuilderExtensions
    {
        public static void RegisterAllEntities(this ModelBuilder modelBuilder,Type EntitiyType ,params Assembly[] assemblies)
        {

            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && EntitiyType.IsAssignableFrom(c));

            foreach (Type type in types)
                modelBuilder.Entity(type);
        }
    }
}
