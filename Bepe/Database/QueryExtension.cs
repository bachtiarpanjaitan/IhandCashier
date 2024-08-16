using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database;

public static class QueryExtension
{
    public static IQueryable<TEntity> WithNavigation<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
        // Tambahkan Include untuk setiap properti navigasi yang diperlukan
        // Misalnya, jika ada entitas Unit yang memiliki BasicUnit
        return query
            .Include("BasicUnit");
    }
}