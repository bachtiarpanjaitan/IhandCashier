###### Local Database
Local ConnectionString = "/Users/bachtiarpanjaitan/Documents/IhandCashier/ihandcashier.db3"
###### Database Scaffolding 
dbcontect scaffold = dotnet ef dbcontext scaffold "Data Source=/Users/bachtiarpanjaitan/Documents/IhandCashier/ihandcashier.db3" Microsoft.EntityFrameworkCore.Sqlite --output-dir Bepe/Entities --context-dir Bepe/Migrations --context AppDbContext
###### Perhatian
- Jangan gunakan .net8 karena belum support MenuBarItems di MacOS
- Gunakan Syncfusion MAUI v23.1.44/v23.2.5
