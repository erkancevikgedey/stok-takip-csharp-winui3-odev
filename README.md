# C# WinUI3 Stok Takip Uygulaması

![Resim 1](https://github.com/erkancevikgedey/stok-takip-csharp-winui3-odev/raw/main/urun-ekleme.png)
 
Projemizde code-first entity framework yapısı, LINQ ve WinUI3
kullanılmıştır.
Bağlantı dosyamız DbContext.cs dosyasında bulunmaktadır. Sayfalar
"Pages" klasöründe class yapıları "Models" klasöründe, servislerimiz ise
"Services" klasöründe yer almaktadır. Veritabanın da yapılan her türlü
işlem öncelikle servislerimizde kontrol edildikten sonra yapılmaktadır.
Servislerde kalıtım kullanılmıştır.
İlk olarak giriş ekranında kullanıcı adı ve şifre bilgileri istenmektedir.
Kullanıcı ad ve şifre bilgilerini girdikten sonra ana sayfa ekranı
gelmektedir. Ana sayfa da uygulama ismi ve duyurular bölümü
bulunmaktadır. Ekranın sol kısmında ise menüler bulunmaktadır.
Ürünleri listeleme menüsünde ürün bilgileri; ürün adı, ürün miktarı ve
işlemler(sil-düzenle-stok ekle- stok azalt butonları bulunmakta) bilgileri
verilmiştir. Ekranın üstünde ise aranacak ürün bölümü ile ismi girilen ürün
listelenebilecektir. Bu bölümde daha önceden eklenmiş bir ürünü silebilir,
stoğunu azaltıp çoğaltabilir veya düzenleyebilirsiniz. Eğer ürün silinmek
istendiğinde butona basıldığı zaman ekrana kullanıcı için işlemi onaylaması
için bir mesaj verilmektedir(evet-hayır butonu). Düzenlenmek istendiğinde
ürün adı ve ürün adedinde değişiklik yapabileceğimiz bir ekran
gelmektedir. Düzenleme işlemi yapıldıktan sonra düzenle butonu
değişikliği tamamlamış oluruz.
Ürün ekleme sayfasında eklenmek istenen ürünün adı ve stok adedi bilgisi
istenmektedir. Bilgiler girildikten sonra ekle butonuna basıldığı zaman
ürün eklenmektedir ve ürünleri listele sayfasından da ürün
görülebilmektedir.
Durum raporu menüsünde ürün isimleri ve ürünlerin stok durumu
verilmiştir. Bu bilgiler kopyala butonu yardımı ile kolayca
kopyalanabilmektedir.
İşlem geçmişi menüsü açıldığında ekrana kullanıcının hangi tarih ve saat
de ürün ekleme, ürün silme ve stok değişikliği gibi bilgileri vermektedir. Bu
bilgilerde sayfanın altında bulunan kopyala butonu ile
kopyalanabilmektedir.
Şifre değiştirme menüsünde kullanıcı adı ve yeni şifrenin girilmesi
istenilmiştir. Kullanıcı bilgileri girdikten sonra değiştir butonuna basması
yeterlidir.
Random ürün ekle menüsünde sadece ürün adedi bilgisi istenmektedir. Bu
işlem sonucunda rastgele oluşturulmuş isimli ürünü ürünleri listele veya
durum raporu sayfasından görebiliriz.
Ve son olarak çıkış yapılmak istendiği zaman menüden çıkış yap seçilir ve
ekrana ilk başta olduğu gibi kullanıcı adı ve şifre bilgisi istenen giriş ekranı
gelmektedir. 
