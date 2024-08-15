###### Local Database
Local ConnectionString = "`{Document Path}/IhandCashier/ihandcashier.db3`"
## Catatan Kebutuhan Development
- Sudah bisa menggunakan .net8
- Gunakan Syncfusion MAUI v26
- Pastikan [Basapadi NuGet](https://www.nuget.org/packages/Basapadi/0.0.1-alpha) Package selalu versi yang terbaru.
## Panduan Instalasi dan Development
  - Mengatur penyimpanan database
    1. Set **SAVE_DB_IN_APPDATA** = true apabila anda ingin menyimpan database di folder appdata aplikasi dan set False jika ingin menyimpan database di folder **Documents** komputer anda
    2. Set **ALWAYS_BUILD_TABLES** = true apabila anda ingin mengatur migrasi secara otomatis apabila aplikasi dijalankan.
  - Membuat Migrasi Data *(tidak ada panduan di internet karena bikinan sendiri)*
    1. Tambah Entity baru di folder **Entities**
    2. Tambah Migrasi baru folder **Migrations** dengan format penamaan {urutan_eksekusi}_{nama_tabel}.cs.
    3. Pastikan urutan eksekusi sesuai requirement Entity karena table yang direlasikan harus di eksekusi terlebih dahulu.
    4. Tambah DbSet baru di **AppDbContext** seperti contoh berikut <code> public DbSet<`User`> User { get; set; }</code> dimana *Produk* adalah Type Entity.
    5. Tambah ModelBuilder di method **ModelCreating** di *AppDbContext.cs* seperti contoh berikut : <code>modelBuilder.Entity<`User`>().ToTable("users");</code>
    6. Pastikan **ALWAYS_BUILD_TABLES** = true
    7. Jalankan aplikasi untuk migrasi
