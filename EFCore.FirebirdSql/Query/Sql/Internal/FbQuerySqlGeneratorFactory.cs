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

using EntityFrameworkCore.FirebirdSql.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.Sql;

namespace EntityFrameworkCore.FirebirdSql.Query.Sql.Internal
{
    public class FbQuerySqlGeneratorFactory : QuerySqlGeneratorFactoryBase
    {
        private IFbOptions _fBOptions;
        public FbQuerySqlGeneratorFactory(
            QuerySqlGeneratorDependencies dependencies,
            IFbOptions fBOptions)
            : base(dependencies) => _fBOptions = fBOptions;

        public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression)
            => new FbQuerySqlGenerator(Dependencies, selectExpression, _fBOptions);
    }
}
