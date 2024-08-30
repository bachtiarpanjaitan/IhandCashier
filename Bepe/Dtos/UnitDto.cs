using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Bepe.Dtos;

public class UnitDto
{
    public int id { get; set; }
    public int basic_unit_id { get; set; }
    public string kode_satuan { get; set; }
    public string nama { get; set; }
    public decimal konversi { get; set; } 
    
    public BasicUnit BasicUnit { get; set; }
    
    public Unit ToUnit()
    {
        return new Unit
        {
            id = this.id,
            basic_unit_id = this.basic_unit_id,
            kode_satuan = this.kode_satuan,
            nama = this.nama,
            konversi = this.konversi,
            BasicUnit = this.BasicUnit
        };
    }
    
    public UnitViewModel ToUnitViewModel()
    {
        return new UnitViewModel()
        {
            Id = this.id,
            BasicUnitId = this.basic_unit_id,
            KodeSatuan = this.kode_satuan,
            Nama = this.nama,
            Konversi = this.konversi
        };
    }
}