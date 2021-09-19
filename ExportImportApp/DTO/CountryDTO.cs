using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExportImportApp.DTO
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryEn { get; set; }
        public string CountryBn { get; set; }
        public string LanguageEn { get; set; }
        public string LanguageBn { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyEn { get; set; }
        public string CurrencyBn { get; set; }
    }
}
