using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameAtLeastTwoCharacter = "Araba ismi en az iki karakter olmalıdır.";
        public static string DailyPriceGreaterThanZero = "Araba günlük fiyatı 0'dan yüksek olmalıdır.";
        internal static string SuccessfullyUpdated;
        internal static string SuccessfullyDeleted;
        internal static string SuccessfullyAdded;
        internal static string SuccessfullyListedObjects;
        internal static string SuccessfullyGotObject;
    }
}
