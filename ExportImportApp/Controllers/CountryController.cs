using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImportApp.DTO;
using ExportImportApp.Gateway;
using ExportImportApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;


namespace ExportImportApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ExportImportDbContext _context;
        private IHostingEnvironment _environment;

        public CountryController(ExportImportDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public IFormFile UploadedExcelFile { get; set; }


        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CountryEntity.ToListAsync());
        //}


        public IActionResult Import()
        {
            return View();
        }

        //public async Task<IActionResult> Import(IFormFile formFile)
        //{
        //    if (formFile == null || formFile.Length <= 0)
        //    {
        //        Message = "This is not a valid file.";
        //        return Page();
        //    }

        //    if (formFile.Length > 500000)
        //    {
        //        Message = "File should be less then 0.5 Mb";
        //        return Page();
        //    }

        //    if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
        //    {
        //        Message = "Wrong file format. Should be xlsx.";
        //        return Page();
        //    }

        //    var newList = new List<InvoiceModel>();

        //    try
        //    {
        //        using (var stream = new MemoryStream())
        //        {
        //            await formFile.CopyToAsync(stream);

        //            using (var package = new ExcelPackage(stream))
        //            {
        //                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //                var rowCount = worksheet.Dimension.Rows;

        //                for (int row = 2; row <= rowCount; row++)
        //                {
        //                    newList.Add(new InvoiceModel
        //                    {
        //                        //ID = row - 1,
        //                        InvoiceNumber = int.Parse(worksheet.Cells[row, 1].Value.ToString().Trim()),
        //                        Amount = float.Parse(worksheet.Cells[row, 2].Value.ToString().Trim()),
        //                        CostCategory = worksheet.Cells[row, 3].Value.ToString().Trim(),
        //                        Period = worksheet.Cells[row, 4].Value.ToString().Trim(),
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = "Error while parsing the file. Check the column order and format.";
        //        return Page();
        //    }


        //    List<InvoiceModel> oldInvoiceList = _context.InvoiceTable.ToList();
        //    _context.InvoiceTable.RemoveRange(oldInvoiceList);
        //    _context.InvoiceTable.AddRange(newList);
        //    _context.SaveChanges();

        //    return RedirectToPage("./Index");
        //}





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile file)
        {

            if (file == null || file.Length <= 0)
            {
                TempData["Message"] = "This is not a valid file.";
                return View();
            }
            if (file.Length > 500000)
            {
                TempData["Message"] = "File should be less then 0.5 Mb";
                return View();
            }
            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Message"] = "Wrong file format. Should be xlsx.";
                return View();
            }
            var list = new List<CountryDTO>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            list.Add(new CountryDTO
                            {
                                CountryId = int.Parse(worksheet.Cells[row, 1].Value.ToString().Trim()),
                                CountryCode = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                CountryEn = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                CurrencyCode = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                CurrencyEn = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                LanguageEn = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                CountryBn = worksheet.Cells[row, 7].Value?.ToString().Trim(),
                                CurrencyBn = worksheet.Cells[row, 8].Value?.ToString().Trim(),
                                LanguageBn = worksheet.Cells[row, 9].Value?.ToString().Trim()
                            });
                        }
                    }
                    foreach (var cou in list)
                    {
                        var country = new CountryModel
                        {
                            SysId = cou.CountryId,
                            ShortName = cou.CountryCode,
                            CountryNameBn = cou.CountryBn,
                            CountryNameEn = cou.CountryEn,
                            CurrencyCode = cou.CurrencyCode,
                            CurrencyBn = cou.CurrencyBn,
                            CurrencyEn = cou.CurrencyEn,
                            LanguageBn = cou.LanguageBn,
                            LanguageEn = cou.LanguageEn
                        };
                        _context.CountryEntity.Add(country);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View();
        }
    }
}
