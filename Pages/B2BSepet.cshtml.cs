using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZirveFerhatPastahane.Pages
{
    public class B2BSepetModel : PageModel
    {
        public void OnGet()
        {
           // login();
        }

        //public IActionResult OnGetLogoya_Aktar()
        //{
        //    string UserID = Request.Cookies["ID"];
        //    //string ITEM_BREF = Request.Cookies["ITEM_BREF"];

        //    string SQL = "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from LG_002_01_ORFICHE where FICHENO like 'B2B%'),'B2B0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
        //    //SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256 \n";
        //   // SQL += "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO like 'UGF%'),'UGF0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
        //   // SQL += "INSERT INTO [dbo].[" + Request.Cookies["S_ALT"] + "_STFICHE] ([GRPCODE],[TRCODE],[IOCODE],[FICHENO]\n,[DATE_],[FTIME],[SOURCEINDEX],[SOURCECOSTGRP],[CAPIBLOCK_CREADEDDATE],[CAPIBLOCK_CREATEDHOUR],[CAPIBLOCK_CREATEDMIN],[CAPIBLOCK_CREATEDSEC],[DOCDATE],[DOCTIME])\n VALUES (3,13,1,@Seed3,\n";
        //    SQL += "insert into LG_002_01_ORFICHE (TRCODE,FICHENO) VALUES (1,@Seed3)  \n";
        //    SQL += "select LOGICALREF from LG_002_01_ORFICHE where FICHENO = @Seed3 \n";
        //    //SQL += "(select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int) )   \n";
        //    //SQL += ",GETDATE(),CAST(SUBSTRING(@F_TIME,1,2) as INT),CAST(SUBSTRING(@F_TIME,4,2) as INT),CAST(SUBSTRING(@F_TIME,7,2) as INT),CAST(GETDATE() AS DATE) , @F_TIME4  )\n";
        //    //SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO = @Seed3 ";
        //    var FisRef = Islemler.DB_op.Instance.selectToTiger(SQL);


        //    var SQL2 = "select * from SEPET where UserID = " + UserID;
        //    var Aratablo = Islemler.DB_op.Instance.selectToZP_DT(SQL2);
        //    for (int i = 0; i < Aratablo.Rows.Count; i++)
        //    {
        //        var a1 = Aratablo.Rows[i]["ITEM_LREF"];
        //        //var SQL3 = "declare @F_TIME2 varchar(10) set @F_TIME2 = FORMAT(GETDATE(),'HH:mm:ss') \n";
        //        //SQL3 += "declare @F_TIME3 int set @F_TIME3 = CAST(SUBSTRING(@F_TIME2,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME2,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME2,7,2) as INT)*256 \n";
        //        var SQL3 = "INSERT INTO " + Request.Cookies["S_ALT"] + "_ORFLINE ([STOCKREF],[ORDFICHEREF],[TRCODE],[AMOUNT],[UOMREF] \n";
        //        SQL3 += ") VALUES \n";
        //        SQL3 += "( " + Aratablo.Rows[i]["UrunID"] + ","+FisRef + ",1," + Aratablo.Rows[i]["UrunMik"] + "," + Aratablo.Rows[i]["UrunBirim"] + ") \n";
        //        //SQL3 += " ,cast('" + Request.Cookies["AMBAR"] + "' as int), (select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int)) \n";
        //        //SQL3 += ",1," + FisRef + "," + i.ToString() + "," + Aratablo.Rows[i]["ITEM_MIKTAR"].ToString().Replace(",", ".") + "," + Aratablo.Rows[i]["ITEM_BREF"] + ",(select UNITSETREF from " + Request.Cookies["S_ANA"] + "_UNITSETL where LOGICALREF =" + Aratablo.Rows[i]["ITEM_BREF"] + "),1,1,MONTH(GETDATE()),YEAR(GETDATE()) )";
        //        Islemler.DB_op.Instance.selectToTiger(SQL3);
        //    }
        //    Islemler.DB_op.Instance.selectToZP("DELETE SEPET where UserID = " + UserID);


        //    return Content("/B2BSepet");
        //}
        public IActionResult OnGetProjeOlustur()
        {
            string UserID = Request.Cookies["ID"];
            //string ITEM_BREF = Request.Cookies["ITEM_BREF"];

            string SQL = "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from LG_002_01_ORFICHE where FICHENO like 'B2B%'),'B2B0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            //SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256 \n";
            // SQL += "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO like 'UGF%'),'UGF0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            // SQL += "INSERT INTO [dbo].[" + Request.Cookies["S_ALT"] + "_STFICHE] ([GRPCODE],[TRCODE],[IOCODE],[FICHENO]\n,[DATE_],[FTIME],[SOURCEINDEX],[SOURCECOSTGRP],[CAPIBLOCK_CREADEDDATE],[CAPIBLOCK_CREATEDHOUR],[CAPIBLOCK_CREATEDMIN],[CAPIBLOCK_CREATEDSEC],[DOCDATE],[DOCTIME])\n VALUES (3,13,1,@Seed3,\n";
            SQL += "insert into LG_002_01_ORFICHE (TRCODE,FICHENO,STATUS) VALUES (1,@Seed3,1)  \n";
            SQL += "select LOGICALREF from LG_002_01_ORFICHE where FICHENO = @Seed3 \n";
            //SQL += "(select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int) )   \n";
            //SQL += ",GETDATE(),CAST(SUBSTRING(@F_TIME,1,2) as INT),CAST(SUBSTRING(@F_TIME,4,2) as INT),CAST(SUBSTRING(@F_TIME,7,2) as INT),CAST(GETDATE() AS DATE) , @F_TIME4  )\n";
            //SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO = @Seed3 ";
            var FisRef = Islemler.DB_op.Instance.selectToTiger(SQL);


            var SQL2 = "select * from SEPET where UserID = " + UserID;
            var Aratablo = Islemler.DB_op.Instance.selectToZP_DT(SQL2);
            for (int i = 0; i < Aratablo.Rows.Count; i++)
            {
                //var a1 = Aratablo.Rows[i]["ITEM_LREF"];
                //var SQL3 = "declare @F_TIME2 varchar(10) set @F_TIME2 = FORMAT(GETDATE(),'HH:mm:ss') \n";
                //SQL3 += "declare @F_TIME3 int set @F_TIME3 = CAST(SUBSTRING(@F_TIME2,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME2,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME2,7,2) as INT)*256 \n";
                var SQL3 = "INSERT INTO " + Request.Cookies["S_ALT"] + "_ORFLINE ([STOCKREF],[ORDFICHEREF],[TRCODE],[AMOUNT],[UOMREF] \n";
                SQL3 += ") VALUES \n";
                SQL3 += "( " + Aratablo.Rows[i]["UrunID"] + "," + FisRef + ",1," + Aratablo.Rows[i]["UrunMik"] + "," + Aratablo.Rows[i]["UrunBirim"] + ") \n";
                //SQL3 += " ,cast('" + Request.Cookies["AMBAR"] + "' as int), (select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int)) \n";
                //SQL3 += ",1," + FisRef + "," + i.ToString() + "," + Aratablo.Rows[i]["ITEM_MIKTAR"].ToString().Replace(",", ".") + "," + Aratablo.Rows[i]["ITEM_BREF"] + ",(select UNITSETREF from " + Request.Cookies["S_ANA"] + "_UNITSETL where LOGICALREF =" + Aratablo.Rows[i]["ITEM_BREF"] + "),1,1,MONTH(GETDATE()),YEAR(GETDATE()) )";
                Islemler.DB_op.Instance.selectToTiger(SQL3);
            }
            Islemler.DB_op.Instance.selectToZP("DELETE SEPET where UserID = " + UserID);


            return Content("/B2BSepet");
        }


        //public void login()
        //{
        //    if (LogoTiger.Login("LOGO", "LOGO", 2, 1) == true)
        //    {
        //        //sonuc = true;
        //        //txtMesaj.Text += “LogoTigera Login ol… ” +r;
        //        ////logout olunca Logoya connect olun,yeni þirkete login olun, yeni kullanýcýya login olun
        //        //txtMesaj.Text += ” kullanýcýAdý:” +userName + ” þifre:” + “123456 ” + ” þirketNo:” +sirketNo.ToString() + ” çalýþmaDönemi:” +calismaDonemi.ToString() + r;
        //        //txtMesaj.Text += “LogoTiger.Login(userName, userPassword, sirketNo, calismaDonemi) == true ” +r;
        //        //txtMesaj.Text += “Logoya baðlanýldý. OK. ” +r + r;
        //    }
        //    //return son

        //    UnityApplication giris = new UnityApplication();
        //    if (giris.Connect())
        //    {
        //        if (giris.UserLogin("LOGO", "LOGO"))
        //        {
        //            if (giris.CompanyLogin(2)) //Logo þirket numarasý
        //            {

        //                //Logoya baðlanýldý                        

        //                giris.CompanyLogout();
        //            }

        //            giris.UserLogout();
        //        }

        //        giris.Disconnect();
        //    }
        //}
    }
}
