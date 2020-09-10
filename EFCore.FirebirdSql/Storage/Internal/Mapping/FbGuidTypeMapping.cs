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
  
using FirebirdSql.Data.FirebirdClient;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkCore.FirebirdSql.Storage.Internal.Mapping
{ 
    public class FbGuidTypeMapping : GuidTypeMapping
    {
        public FbGuidTypeMapping()
            : base("CHAR(16) CHARACTER SET OCTETS")
        { }

        protected override void ConfigureParameter(DbParameter parameter)
            => ((FbParameter)parameter).FbDbType = FbDbType.Guid;
    }
}
