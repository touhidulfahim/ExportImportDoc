using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExportImportApp.Models
{
    public class CountryModel:BaseModel
    {
        public string ShortName { get; set; }
        public string CountryNameEn { get; set; }
        public string CountryNameBn { get; set; }
        public string LanguageEn { get; set; }
        public string LanguageBn { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyEn { get; set; }
        public string CurrencyBn { get; set; }
    }
}
