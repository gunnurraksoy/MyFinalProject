using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Siatem bakımda!!!";
        public static string ProductListed = "Ürünler listelendi!!";

        public static string ProductCountOfCategoryError = "Kategoride en fazla 15 ürün olabilir.";
        public static string ProductAlreadyExist = "Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
