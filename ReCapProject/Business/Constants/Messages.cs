﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameAtLeastTwoCharacter = "Araba ismi en az iki karakter olmalıdır.";
        public static string DailyPriceGreaterThanZero = "Araba günlük fiyatı 0'dan yüksek olmalıdır.";
        public static string SuccessfullyUpdated = "Başarıyla Güncellendi.";
        public static string SuccessfullyDeleted = "Başarıyla Silindi.";
        public static string SuccessfullyAdded = "Başarıyla Eklendi.";
        public static string SuccessfullyListedObjects = "Başarıyla gelen objeler listelendi.";
        public static string SuccessfullyGotObject = "Uygulanan filtre sonucu başarıyla obje getirildi.";
        public static string RentedCarIsNotExistReturnedDate = "Aracın kiralanabilmesi için öncelikle teslim tarihi de belirtilmelidir.";
        public static string CarByIdNotFoundError = "Filtrelenen Araca ait bilgi bulunamadı.";
        public static string CarAlreadyExist = "Eklemeye çalışılan araç daha önceden eklenmiş.";
        public static string CarImageIdNotFoundError = "İlgili araba resmi bulunamadı.";
        public static string CarIsNotExistError = "Resim eklemek istediğin arac bulunamadı.";
        public static string CarImageLimitExceed = "Resim eklemek istediğin aracın sınırına ulaştın. Daha fazla resim ekleyemezsin.";
    }
}
