using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public  class Messages
    {
        public static string UserAdded = "Kullanıcı Eklenme Başarılı";
        public static string UserDeleted = "Kullanıcı Silme Başarılı";
        public static string UserUpdated = "Kullanıcı Güncelleme Başarılı";
        public static string UserFollowed = "Kullanıcı Takip Edildi";
        public static string UserUnfollowed = "Kullanıcı Takibi Bırakıldı";
        public static string FollowUpdated = "Takip Güncellendi";
        public static string MessageSended = "Mesaj Gönderildi";
        public static string MessageDeleted = "Mesaj Silindi";
        public static string MessageUpdated = "Mesaj Güncellendi";
        public static string PostAdded = "Gönderi Eklendi";
        public static string PostDeleted = "Gönderi Silindi";
        public static string PostUpdated = "Gönderi Güncellendi";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı kayıt edildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string LoginSuccess = "Giriş Başarılı";
        public static string TokenCreated = "Token Oluşturuldu";
        public static string UserAlreadyReported = "Kullanıcı mevcut sebepten zaten bildirilmiştir.";
        public static string UserBanned = "Kullanıcı Yasaklı";
        public static string ProfileImageUpdated = "Profil resmi güncellendi";
        public static string BackgroundImageUpdated = "Arkaplan resmi güncellendi";
        public static string UserHasNotLabel = "Kullancının bir etiketi bulunmuyor";
    }
}
