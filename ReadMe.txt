
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
	8.10.Product controller açýlýr ve crud operasyonlarý yürütülür.
9.Main Controller klasörünün altýna
	9.1.Page Controller eklenir.
	9.1.1.Index Methodu yazýlýr. (Index metodunu yazmamýýzn nedeni, top navbar'da sayfalarý listeleyerek, dinamik bir þekilde, eklenen sayfalarý listelemekti)
	9.1.2.Infrastructure klasörü altýnda "Component"klasörü açýlýr.
	9.1.3. "MainMenuComponent.cs"açýlýr.
	9.1.4. Views=>Shared altýnda "Components"klasörü açýlýr.
	9.1.5. Components klasörünün altýnda "MainMenu"Klasörü açýlýr.
	9.1.6. MainMenu içeriisnde "Default.cshtml"dosyasý eklenir. 
	9.1.7. _Layout.cshtml içerisinde temada uygun yerde hazýrlanan component asekron olarak çaðýrýlýr.
  9.2.ProductController eklenir.
	9.2.1. Index metodu yazýlýr.
	9.2.2. ProductByCategory metodu yazýlýr. View sayfasý hazýrlanýr.
	9.2.3.Roting iþlemleri için gerekli altyapý yani "endpoints"eklenir.
10.Infrastructure=> Component altýna "CategoryViewComponent.cs"eklenir.
	10.1. Views=Shared=>Components altýna "Category" klasörü eklenir.
	10.2.Views=Shared=>Components => Category altýnda "Default.cshtml"eklenir. 
	10.2._Layout.cshtml içerisinde temada uygun yerde hazýrlanan component asekron olarak çaðýrýlýr. 
11.CartController eklenir ve CRUD operasyonlarý gerçekleþtirilir.
12. Asp .net Identity için gerekli iþlemler yürütülür.
	12.1. Infrastructure=>Context.cs üzerinde deðiþikler yapýlýr.
	12.2. Microsoft.AspNetCore.Identity.EntityFreamworkCore paketi yüklenir.
	12.3.Models klasörü altýna AppUser.cs eklenir.(AspNet Identity yapýsý bizlere user ile ilgili birçok hazýr yapý temin etmektedir. Lakin içermediði property'lerride açtýðýðmýz AppUser.cs içerisinde yazabiliriz.Açtýðýmýz bu dosyaysa muhakkak "IdentityUSer"sýnýfý ile extend edilmelidir.)
	12.4.Models klasörü altýna "USer.cs"açýlýr. Bu dosya data transferinde kullanýlmak üzere hazýrlanýr.
	12.5.MÝgration yapýlýr.
13.Areas=>Admin=> Controllers altýnda "RoleController.cs"açýlýr Crud operasyonlarý yürütülür.
14.Kullanýcýlara yetkiler atandýktan sonra her bir controller tepesine hangi yetkideki kiþinin eriþip iþlem yapacaðýný belirten attribute'ler yazýlýr.(Not bu iþlem RoleController.cs altýnda bulunan "Edit"metodunda handle edilir.)
	14.1.Infrastructure=>altýna"Helpers"klasörü açýlýr.
	14.2.1.HElpers klasörü altýna"TagHelper.cs" hazýrlanýr.
	14.2.2._VÝewsImporta içerisine hazýrlanan TagHelper yolu eklenir.
15.Controller altýna "AccountController.cs"açýlýr.
	15.1.Register ve Login iþlemleri yapýlýr.