# **Kullanılan Teknolojiler**
## *Backend (.NET)*
-	.NET 8.0 
-	Entity Framework Core: Veritabanı işlemleri için ORM katmanı.
-	MSSQL: Veritabanı yönetimi.
-	JWT (JSON Web Token): Güvenli kimlik doğrulama.
-	SHA256 Hashing: Kullanıcı şifrelerinin veritabanında güvenli bir şekilde saklanması.
## *Frontend (MVC)*
-Razor View ile arayüz yönetimi yapıldı.
## *Mimari Yaklaşım*
Proje, kodun sürdürülebilirliği için N-Tier architecture mimarisi il 6 ana katmandan oluşmaktadır:
1.	Core (Domain) Layer: Generic Repository Pattern ile veri erişim mantığının soyutlandığı katman.
2.	Entity Layer: Veritabanı varlıklarının (Entity) bulunduğu katman.
3.	DataAccess Layer: Veritabanı konfigürasyonu, Context yapısı.
4.	Business (Service) Layer: İş mantığının (Business Logic) yürütüldüğü katman.
5.	Web API : API configurasyonlarının yapıldığı katman.
6.	UI Layer: Kullanıcı ile etkileşime geçen, arayüz yönetiminin yapıldığı son katman.
## *Projede Eksik ve Geliştirilecekler: *
-	Angular ile geliştirmeye çalışacağım, 
-	Validation işlemi yapılabilir,
-	Veritabanında ilişkili tablolar kullanılabilir,
-	User ekleme, silme ve güncelleme işlemleri geliştirilebilir,
-	Categori, comment ve image gibi veritabanı tabloları eklenebilir ve dah birçok yenilikler eklenebilir.
Projenin arayüz yönetimini Angular ile geliştirmeye çalıştım ama projede yapmak istediklerimi Angular ile geliştiremedim. İlerleyen süreçte Angular ile geliştirmeler yaparak kendimi geliştireceğim. 

Anasayfa
<img width="1422" height="438" alt="proje1" src="https://github.com/user-attachments/assets/cc9daaab-04a3-4660-92e0-94c650d4b799" />
Ürün Yönetim Sayfası
<img width="1432" height="681" alt="proje" src="https://github.com/user-attachments/assets/3b9bbb71-1ce1-4ed8-9af1-e2200dac98d0" />
Sipariş Yönetim Sayfası
<img width="1414" height="617" alt="proje2" src="https://github.com/user-attachments/assets/2bbcb261-e147-45c8-b4c6-1ec7c9cf708e" />
Kullanıcı Login Sayfası
<img width="1424" height="413" alt="proje3" src="https://github.com/user-attachments/assets/3584728f-f639-4f3e-a4aa-aba3c88c7f4e" />
