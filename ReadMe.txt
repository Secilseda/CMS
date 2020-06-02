
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