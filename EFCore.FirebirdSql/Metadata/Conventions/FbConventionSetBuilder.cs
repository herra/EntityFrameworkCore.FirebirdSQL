/*
 *          Copyright (c) 2017-2018 Rafael Almeida (ralms@ralms.net)
 *
 *                    EntityFrameworkCore.FirebirdSql
 *
 * THIS MATERIAL IS PROVIDED AS IS, WITH ABSOLUTELY NO WARRANTY EXPRESSED
 * OR IMPLIED.  ANY USE IS AT YOUR OWN RISK.
 * 
 * Permission is hereby granted to use or copy this program
 * for any purpose,  provided the above notices are retained on all copies.
 * Permission to modify the code and to distribute modified code is granted,
 * provided the above notices are retained, and a notice that the code was
 * modified is included with the above copyright notice.
 *
 */

using EntityFrameworkCore.FirebirdSql.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.FirebirdSql.Metadata.Conventions
{
    public class FbConventionSetBuilder : RelationalConventionSetBuilder
    {
        public FbConventionSetBuilder(RelationalConventionSetBuilderDependencies dependencies)
            : base(dependencies)
        { }

        public override ConventionSet AddConventions(ConventionSet conventionSet)
        {
            base.AddConventions(conventionSet);

            var valueGenerationStrategyConvention = new FbValueGenerationStrategyConvention();
            conventionSet.ModelInitializedConventions.Add(valueGenerationStrategyConvention);
            // ReplaceConvention(conventionSet.PropertyAddedConventions, (DatabaseGeneratedAttributeConvention)valueGenerationStrategyConvention);
            // ReplaceConvention(conventionSet.PropertyFieldChangedConventions, (DatabaseGeneratedAttributeConvention)valueGenerationStrategyConvention);
            return conventionSet;
        }

        public static ConventionSet Build()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkFirebird()
                .AddDbContext<DbContext>(o => o.UseFirebird("DataSource=."))
                .BuildServiceProvider();

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
                {
                    return ConventionSet.CreateConventionSet(context);
                }
            }
        }
    }
}
