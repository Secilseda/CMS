
Project Dökümantasyonu.

1.Package Manager aracýlýðý ile aþaðýdaki paketler yüklenir.
	1.1 Microsoft.EntityFrameworkCore.SqlServer
	1.2 Microsoft.EntityFrameworkCore.Tools
2.Infrastructure klasörü oluþturulur.
	2.1. Context klasörü oluþturulur.
		2.1.1 ProjectContext.cs file eklenir.
3.Model klasörü altýnda "Page.cs"eklenir.
4.Page entitsi DbSet edilir.
6.Infrastructure klasörü altýna "Seeding"klasörü açýlýr.
	6.1. Seed.cs eklenir.
	6.2. Program.cs sýnýfýný düzenleyin.
7.Proje ayaðý kaldýrýlýr ve database kontrol edilir.
8.Areas klasörü eklenir.
	8.1. Admin area eklenir.
	8.2. Admin are roting iþlemi gerçekleþtirilir.(Not: Scaffolding ile gelen readme'deki routing Asp .Net Core 2.1 aittit. Asp .Net Core 3.1'de end point mantýðýna geçilmiþtir.
	Lütfen Startup.cs altýndaki "Configure"metodunu kontrol edin.)
	8.3. Global alandaki Views altýnda bulunan "Shared"+"ViewImports"+"ViewStart"yapýlarýný kopyalayýp Admin area altýndaki Views  içerisinde yapýþtýrdýk.(Not: viewImports.cshtml dosyasýna ihtiyacýmýz olan, yada projede sýklýkla kullanacaðýmýz yollarý ekleyebiliriz.Böylelikle model eklediðimizde yolunu klasik .Net 'teki gibi uzun uzundayý yazmýyoruz.)
	8.4. Page kontroller eklendi.
	8.5. Page CRUD operasyonlarý halledildi.(Delete Operasyonu için yazýldý.)
	8.6. CK editör implemtation yapýldý.
		8.6.1. Client side library üzerinden CK editör yüklenir.
		8.6.2. 
		8.6.3. Ckeditör.js _Layout page eklenir.
	8.7. Dinamic sorting iþlemi
		8.7.1. Client side library'den jqueryui.js eklenir.
		8.7.2. _LayoutPage page jqueryui.js eklenir.
		8.7.3. Index sayfasýna script yazýlýr. HTML elementleri uygun þekilde yakalanýr.
		(Projenin diðer index sayfalarýnda, örneðin category index vb. yerlerde kullanmak istersek, harici bir js file'sine yazýp dýþarýya alabiliriz. Sonra ihtiyaç olan sayfalarda bu js file eklenir.)
		8.7.4. Page controller içerisinde ReOrder action'u yazýlýr.
	8.8. Category model oluþturulur ve db'ye göç ettirilir.
	8.9.Category controller açýlýr ve crud operasyonlarý yürütülür.