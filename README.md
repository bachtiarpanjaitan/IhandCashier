## Local Database
> Local ConnectionString = "`{Document Path}/IhandCashier/ihandcashier.db3`"
## Catatan Kebutuhan Development
- Net Framework 8.0
- Entity Framework v8.0.8
- Syncfusion v26.2.9
- MAUI Framework v8.0.71
- Workload berdasarkan platform development <code>dotnet workload install</code>
## Panduan Instalasi dan Development
  - Mengatur penyimpanan database
    1. Set **SAVE_DB_IN_APPDATA** = true apabila anda ingin menyimpan database di folder appdata aplikasi dan set False jika ingin menyimpan database di folder **Documents** komputer anda
    2. Migrasi dilakukan secara manual, dengan mengeksekusi schema database ada di **Resources/Datas/sqlite_schema.sql** atau **Resources/Datas/mysql_schema.sql**.
    3. Update selalu schema ini apabila ada perubahan pada schema database dan jangan lupa untuk memodifikasi entity dan dbconfig
    4. Eksekusi data dummy biar gak capek bikin data contoh

> Ikuti style code yang sudah dibuat biar gak nyampah, karena sudah ada contoh dibuat berdasarkan case yang dibutuhkan
