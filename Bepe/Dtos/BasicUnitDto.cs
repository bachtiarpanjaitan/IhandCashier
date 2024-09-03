using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Bepe.Dtos;

public class BasicUnitDto
{
    public int id { get; set; }
    public string nama { get; set; }

    public BasicUnit ToEntity()
    {
        return new BasicUnit()
        {
            id = this.id,
            nama = this.nama
        };
    }

    public BasicUnitViewModel ToViewModel()
    {
        return new BasicUnitViewModel()
        {
            Id = this.id,
            Nama = this.nama
        };
    }
}