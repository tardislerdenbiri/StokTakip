# Stok Takip Sistemi
.Net Core 5.0 ile yaptığım ilk projedir. Bu proje bir firmaya özel yapılmıştır. Stok bilgilerini, Satış yaptığı firmaları ve geçmişe dönük işlemleri görüntülemek amacıyla yapıldı. Ürünlerin yanında bulunan barkod ile sisteme ürün eklenebilmektedir. Proje geliştirilmeye açıktır. Çalışan ekleme, Şifremi unuttum ve yetkilendirme işlemleri yapılmamıştır. Asp.net Core 5.0 Kurumsal Mimari düzeyinde yapılmıştır.


## Installation
Öncelikle projeyi clonelayın.

```bash
git clone https://github.com/tardislerdenbiri/StokTakipCoreV3.git
```

## Usage
Projeyi cloneladıktan sonra Visual Studio programını açınız.
<br>
Not: Database'yi oluşturmak için DataAccessLayer/Concrete/Context.cs içindeki UseSqlServer Kısmını düzenleyip Migrations içerisindeki migrationsları silip Package Manager Console üzerinden default project'i DataAccessLayer seçip
 ```
add-migration mig_firstmig
update-database
```
komutlarını yazın

---

## Benimle iletişime geçmek için [mail](mailto:zulkuf.yalcin@tardisyazilim.com) gönderebilirsiniz
