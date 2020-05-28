
Project Dökümantasyonu.

1.Package Manager aracýlýðý ile aþaðýdaki paketler yüklenir.
	1.1 Microsoft.EntityFrameworkCore.SqlServer
	1.2 Microsoft.EntityFrameworkCore.Tools
2.Infrastructure klasçrü oluþturulur.
	2.1. Context klasörü oluþturulur.
		2.1.1 ProjectContext.cs file eklenir.
3.Model klasörü altýnda "Page.cs"eklenir.
4.Page entitsi DbSet edilir.
6.Infrastructure klasörü altýna "Seeding"klasörü açýlýr.
	6.1. Seed.cs eklenir.
	6.2. Program.cs sýnýfýný düzenleyin.
7.Proje ayaðý kaldýrýlýr ve database kontrol edilir.