using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using Newtonsoft.Json;
using HttpApp.Models;
using HttpApp.Models.Data;
using Newtonsoft.Json.Linq;
using HttpApp.Models.Utilities;

namespace HttpApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Get data from API
            string getReponse = await HTTP.Get("https://webapibasicsstudenttracker.azurewebsites.net/api/Students", "");
            //Console.WriteLine(getReponse);

            //Word
            HttpApp.Models.Utilities.CreateWord.CreateWordprocessingDocument(@"d:\00.Bigdata\DataEncoding\info.docx");

            string document = @"d:\00.Bigdata\DataEncoding\info.docx";
            string fileName = @"d:\00.Bigdata\DataEncoding\myimage.jpg";
            HttpApp.Models.Utilities.CreateWord.InsertAPicture(document, fileName);
            HttpApp.Models.Utilities.CreateWord.OpenAndAddTextToWordDocument(document, getReponse);

            //Excel
            HttpApp.Models.Utilities.CreateExcel.CreateSpreadsheetWorkbook(@"D:\00.Bigdata\DataEncoding\info.xlsx");
            HttpApp.Models.Utilities.CreateExcel.InsertText(@"D:\00.Bigdata\DataEncoding\info.xlsx", "Hello, my name is Jiyoung");
            HttpApp.Models.Utilities.CreateExcel.InsertText(@"D:\00.Bigdata\DataEncoding\info.xlsx", "Hello, my name is Jiyoung");

            //Presentation
            string filepath = @"d:\00.Bigdata\DataEncoding\info.pptx";
            HttpApp.Models.Utilities.CreatePre.CreatePresentation(filepath);
            //HttpApp.Models.Utilities.CreatePre.InsertNewSlide(@"d:\00.Bigdata\DataEncoding\info.pptx", 1, "My new slide");


            //FPT
            List<string> directories = FTP.GetDirectory(Constants.FTP.BaseUrl);
            string localUploadFilePath = @"d:\00.Bigdata\DataEncoding\info.docx";
            string remoteUploadFileDestination = "/StudentId FirstName LastName/info.docx";

            Console.WriteLine(FTP.UploadFile(localUploadFilePath, Constants.FTP.BaseUrl + remoteUploadFileDestination));
     
        }
    }
}
