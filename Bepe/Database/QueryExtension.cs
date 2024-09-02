using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database;

public static class QueryExtension
{
    public static IQueryable<TEntity> WithNavigation<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
        // Tambahkan Include untuk setiap properti navigasi yang diperlukan
        return query;
    }
}