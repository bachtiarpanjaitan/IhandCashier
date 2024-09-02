using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.Dtos;

public class BasicUnitDto
{
    public int id { get; set; }
    public string nama { get; set; }

    public BasicUnit ToBasicUnit()
    {
        return new BasicUnit()
        {
            id = id,
            nama = nama
        };
    }
}