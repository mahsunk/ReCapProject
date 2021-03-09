using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string SuccessVoid = "Başarıyla tamamlandı";
        public static string ErrorVoid = "İşlem Sırasında Hata Meydana Geldi";
        public static string CarNameControl = "Lütfen araç adı en az 2 karekter ve DealyPrice 0'dan büyük olmalıdır.";
        public static string RentalControl = "Araç Geri Gelmemiştir";
        public static string CarImagesMaxLimitError = "Bir arabanın en fazla 5 resmi olabilir.";
        public static string ImageAdded = "Resim başarıyla eklendi";
        public static string ImageNotFound = "Resim bulunamadı";
        public static string ImageDeleted = "Resim başarıyla silindi";
        public static string ImageIdNotFound = "Resim Id kontrol edin";
        public static string CarIdNoting = "Seçtiğiniz aracı kontrol ediniz";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı Kayıtlı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token başarıyla oluşturuldu";
    }
}
