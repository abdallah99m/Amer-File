using Microsoft.AspNetCore.Mvc;
using AmerPay.Models.Models;
using System.Collections.Generic;
using AmerPay.DataAccess.Data;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;

namespace AmerPay.Controllers
{
    public class RequestController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private const string EncryptionKey = "z3$#jh687";
        private readonly ApplicationDbContext _db ;
        public RequestController(IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            
            _hostEnvironment = hostEnvironment;
            _db = db;
        }
       
        public IActionResult Encrypt( IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Files\");
                    var extension = Path.GetExtension(file.FileName);
                   
                    using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {

                        file.CopyTo(fileStreams);
                    }
                    string FileForward = @"wwwroot\Files\" + filename + extension;


                    ///////////////////////

                    
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (FileStream fsOutput = new FileStream(Path.Combine(uploads, filename + "abdallah" + extension), FileMode.Create))
                        {
                            using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                using (FileStream fsInput = new FileStream(FileForward, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsInput.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }

                    var fileen = Path.Combine(uploads, filename + "abdallah" + extension);

                    /////////////
                    //////////////
                    if (FileForward != null)
                    {
                      
                        if (System.IO.File.Exists(FileForward))
                        { 
                            System.IO.File.Delete(FileForward); 
                        }
                    }
                    //if (fileen != null)
                    //{

                    //    if (System.IO.File.Exists(fileen))
                    //    {
                    //        System.IO.File.Delete(fileen);
                    //    }
                    //}
                    byte[] fileBytes = GetFile(Path.Combine(uploads, filename + "abdallah" + extension));
               
                    return File(
                        
                        fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.Combine(uploads, filename + "abdallah" + extension));
                    ///

                    




                    FileForward = @"wwwroot\Files\" + filename + "abdallah" + extension;






                   
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Decrypt(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Files\");
                    var extension = Path.GetExtension(file.FileName);
                    using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {

                        file.CopyTo(fileStreams);
                    }
                    string FileForward = @"wwwroot\Files\" + filename + extension;

                    
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x69, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (FileStream fsInput = new FileStream(FileForward, FileMode.Open))
                        {
                            using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                            {
                                using (FileStream fsOutput = new FileStream(Path.Combine(uploads, filename + "abdallah15" + extension), FileMode.Create))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOutput.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                    if (FileForward != null)
                    {

                        if (System.IO.File.Exists(FileForward))
                        {
                            System.IO.File.Delete(FileForward);
                        }
                    }
                    byte[] fileBytes = GetFile(Path.Combine(uploads, filename + "abdallah15" + extension));

                    return File(

                        fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.Combine(uploads, filename + "abdallah15" + extension));

                }
            }
            return View();
        }
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }


    }
}

