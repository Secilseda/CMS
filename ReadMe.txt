
Project D�k�mantasyonu.

1.Package Manager arac�l��� ile a�a��daki paketler y�klenir.
	1.1 Microsoft.EntityFrameworkCore.SqlServer
	1.2 Microsoft.EntityFrameworkCore.Tools
2.Infrastructure klas�r� olu�turulur.
	2.1. Context klas�r� olu�turulur.
		2.1.1 ProjectContext.cs file eklenir.
3.Model klas�r� alt�nda "Page.cs"eklenir.
4.Page entitsi DbSet edilir.
6.Infrastructure klas�r� alt�na "Seeding"klas�r� a��l�r.
	6.1. Seed.cs eklenir.
	6.2. Program.cs s�n�f�n� d�zenleyin.
7.Proje aya�� kald�r�l�r ve database kontrol edilir.
8.Areas klas�r� eklenir.
	8.1. Admin area eklenir.
	8.2. Admin are roting i�lemi ger�ekle�tirilir.(Not: Scaffolding ile gelen readme'deki routing Asp .Net Core 2.1 aittit. Asp .Net Core 3.1'de end point mant���na ge�ilmi�tir.
	L�tfen Startup.cs alt�ndaki "Configure"metodunu kontrol edin.)
	8.3. Global alandaki Views alt�nda bulunan "Shared"+"ViewImports"+"ViewStart"yap�lar�n� kopyalay�p Admin area alt�ndaki Views  i�erisinde yap��t�rd�k.(Not: viewImports.cshtml dosyas�na ihtiyac�m�z olan, yada projede s�kl�kla kullanaca��m�z yollar� ekleyebiliriz.B�ylelikle model ekledi�imizde yolunu klasik .Net 'teki gibi uzun uzunday� yazm�yoruz.)
	8.4. Page kontroller eklendi.
	8.5. Page CRUD operasyonlar� halledildi.(Delete Operasyonu i�in yaz�ld�.)
	8.6. CK edit�r implemtation yap�ld�.
		8.6.1. Client side library �zerinden CK edit�r y�klenir.
		8.6.2. 
		8.6.3. Ckedit�r.js _Layout page eklenir.
	8.7. Dinamic sorting i�lemi
		8.7.1. Client side library'den jqueryui.js eklenir.
		8.7.2. _LayoutPage page jqueryui.js eklenir.
		8.7.3. Index sayfas�na script yaz�l�r. HTML elementleri uygun �ekilde yakalan�r.
		(Projenin di�er index sayfalar�nda, �rne�in category index vb. yerlerde kullanmak istersek, harici bir js file'sine yaz�p d��ar�ya alabiliriz. Sonra ihtiya� olan sayfalarda bu js file eklenir.)
		8.7.4. Page controller i�erisinde ReOrder action'u yaz�l�r.
	8.8. Category model olu�turulur ve db'ye g�� ettirilir.
	8.9.Category controller a��l�r ve crud operasyonlar� y�r�t�l�r.
	8.10.Product controller a��l�r ve crud operasyonlar� y�r�t�l�r.
9.Main Controller klas�r�n�n alt�na
	9.1.Page Controller eklenir.
	9.1.1.Index Methodu yaz�l�r. (Index metodunu yazmam��zn nedeni, top navbar'da sayfalar� listeleyerek, dinamik bir �ekilde, eklenen sayfalar� listelemekti)
	9.1.2.Infrastructure klas�r� alt�nda "Component"klas�r� a��l�r.
	9.1.3. "MainMenuComponent.cs"a��l�r.
	9.1.4. Views=>Shared alt�nda "Components"klas�r� a��l�r.
	9.1.5. Components klas�r�n�n alt�nda "MainMenu"Klas�r� a��l�r.
	9.1.6. MainMenu i�eriisnde "Default.cshtml"dosyas� eklenir. 
	9.1.7. _Layout.cshtml i�erisinde temada uygun yerde haz�rlanan component asekron olarak �a��r�l�r.
  9.2.ProductController eklenir.
	9.2.1. Index metodu yaz�l�r.
	9.2.2. ProductByCategory metodu yaz�l�r. View sayfas� haz�rlan�r.
	9.2.3.Roting i�lemleri i�in gerekli altyap� yani "endpoints"eklenir.
10.Infrastructure=> Component alt�na "CategoryViewComponent.cs"eklenir.
	10.1. Views=Shared=>Components alt�na "Category" klas�r� eklenir.
	10.2.Views=Shared=>Components => Category alt�nda "Default.cshtml"eklenir. 
	10.2._Layout.cshtml i�erisinde temada uygun yerde haz�rlanan component asekron olarak �a��r�l�r. 
11.CartController eklenir ve CRUD operasyonlar� ger�ekle�tirilir.
12. Asp .net Identity i�in gerekli i�lemler y�r�t�l�r.
	12.1. Infrastructure=>Context.cs �zerinde de�i�ikler yap�l�r.
	12.2. Microsoft.AspNetCore.Identity.EntityFreamworkCore paketi y�klenir.
	12.3.Models klas�r� alt�na AppUser.cs eklenir.(AspNet Identity yap�s� bizlere user ile ilgili bir�ok haz�r yap� temin etmektedir. Lakin i�ermedi�i property'lerride a�t����m�z AppUser.cs i�erisinde yazabiliriz.A�t���m�z bu dosyaysa muhakkak "IdentityUSer"s�n�f� ile extend edilmelidir.)
	12.4.Models klas�r� alt�na "USer.cs"a��l�r. Bu dosya data transferinde kullan�lmak �zere haz�rlan�r.
	12.5.M�gration yap�l�r.
13.Areas=>Admin=> Controllers alt�nda "RoleController.cs"a��l�r Crud operasyonlar� y�r�t�l�r.
14.Kullan�c�lara yetkiler atand�ktan sonra her bir controller tepesine hangi yetkideki ki�inin eri�ip i�lem yapaca��n� belirten attribute'ler yaz�l�r.(Not bu i�lem RoleController.cs alt�nda bulunan "Edit"metodunda handle edilir.)
	14.1.Infrastructure=>alt�na"Helpers"klas�r� a��l�r.
	14.2.1.HElpers klas�r� alt�na"TagHelper.cs" haz�rlan�r.
	14.2.2._V�ewsImporta i�erisine haz�rlanan TagHelper yolu eklenir.
15.Controller alt�na "AccountController.cs"a��l�r.
	15.1.Register ve Login i�lemleri yap�l�r.