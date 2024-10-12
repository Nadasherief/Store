using Microsoft.Extensions.Logging;
using Store.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async  Task SeedAsync(StoreDbContext StoreDbContext, ILoggerFactory loggerFactory )
        {
            try
            {
                if (StoreDbContext.productBrands != null && !StoreDbContext.productBrands.Any()) 
                {
                    //var brandData=
                }
                else { }
            }
            catch (Exception ex) {
            }
        } 
    }
}
