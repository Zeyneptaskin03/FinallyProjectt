using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static  string MaintenanceTime="sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 15 ürün olabilir";
        public static string ProductNameAlreadyExists="bu isimde zaten bir ürün var ";
        public static string CategoryLimitExceded="kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string AccessTokenCreated="erişim işareti (Token) oluştu ";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string PasswordError="Parola hatası";  //userdı strıng yaptım
        public static string UserNotFound="kullanıcı bulunamadı"; //userdı strıng yaptım
        public static string UserRegistered="kayıt oldu";
        public static string ProductUpdated="Ürün güncellendi.";
    }
}
