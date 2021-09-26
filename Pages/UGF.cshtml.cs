using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZirveFerhatPastahane.Pages
{
    public class UGFModel : PageModel
    {
        public void OnGet()
        {
        }
        //public IActionResult OnGetSayfaYukle()
        //{
        //    //var sql_cevap = Islemler.DB_op.Instance.selectToTiger(" select TOP 20 LOGICALREF,CODE,NAME from " + Request.Cookies["S_ANA"] + "_ITEMS where NAME != '' for json auto ");
        //    var sql_cevap = Islemler.DB_op.Instance.selectToTiger_DT(" select TOP 20 LOGICALREF,CODE,NAME from " + Request.Cookies["S_ANA"] + "_ITEMS where NAME != '' ");
        //    //return Content(sql_cevap);

        //    return Content("asd");
        //}
        //public IActionResult OnGetKalemUrunleriGetir()
        //{

        //    string UserID = Request.Cookies["ID"];
        //    string SQL = "SELECT TOP (1000) [ID],[Users_ID],[ITEM_LREF],[ITEM_NAME],[ITEM_BREF],[ITEM_BNAME],[ITEM_MIKTAR] FROM ARA_STLINE";
        //    SQL += " where Users_ID = N'" + UserID + "' order by ID desc FOR JSON AUTO , INCLUDE_NULL_VALUES";
        //    string sql_cevap = Islemler.DB_op.Instance.selectToZP(SQL);
        //    return Content(sql_cevap);
        //}
        public IActionResult OnGetUrunSecildi(string LOGICALREF)
        {
            //string sql = "select ITEMS3.CODE ,ITEMS3.LOGICALREF from " + Request.Cookies["S_ANA"] + "_ITEMS as ITEMS1 ," + Request.Cookies["S_ANA"] + "_ITMUNITA as ITEMS2 , " + Request.Cookies["S_ANA"] + "_UNITSETL as ITEMS3 \n";
            //sql += " where  ITEMS1.LOGICALREF = ITEMS2.ITEMREF and ITEMS2.UNITLINEREF  = ITEMS3.LOGICALREF \n";
            //sql += " and ITEMS1.LOGICALREF = " + LOGICALREF + "  \n";
            //sql += " FOR JSON AUTO \n";
            //var sql_cevap = Islemler.DB_op.Instance.selectToTiger(sql);
            //return Content(sql_cevap);
            string sql = "select ITEMS3.CODE ,ITEMS3.LOGICALREF from " + Request.Cookies["S_ANA"] + "_ITEMS as ITEMS1 ," + Request.Cookies["S_ANA"] + "_ITMUNITA as ITEMS2 , " + Request.Cookies["S_ANA"] + "_UNITSETL as ITEMS3 \n";
            sql += " where  ITEMS1.LOGICALREF = ITEMS2.ITEMREF and ITEMS2.UNITLINEREF  = ITEMS3.LOGICALREF \n";
            sql += " and ITEMS1.LOGICALREF = " + LOGICALREF + "  \n";
            var sql_cevap = Islemler.DB_op.Instance.selectToTiger_DT(sql);

            //var sql_cevap = Islemler.DB_op.Instance.selectToZP_DT(sql);
            string sql_cevap1 = sql_cevap.Rows[0][0].ToString() + "-----" + sql_cevap.Rows[0][1].ToString();
            //return Content(sql_cevap1);
            return Content(sql_cevap1);
        }
        public IActionResult OnGetKalemSil(string KalemID)
        {
            string sql = "DELETE FROM [dbo].[ARA_STLINE] where ID = " + KalemID;
            Islemler.DB_op.Instance.selectToZP(sql);
            return Content("/UGF");
        }
        public IActionResult OnGetKalemMikDuzenle(string KalemID,string KalemMik)
        {
            string sql = "UPDATE [dbo].[ARA_STLINE] set [ITEM_MIKTAR] = " + KalemMik + " WHERE ID = " + KalemID;
            Islemler.DB_op.Instance.selectToZP(sql);
            return Content("/UGF");
        }
        public IActionResult OnGetProjeOlustur(string ITEM_LREF, string ITEM_NAME, string ITEM_BNAME, string ITEM_MIKTAR)
        {
            string UserID = Request.Cookies["ID"];
            string ITEM_BREF = Request.Cookies["ITEM_BREF"];

            string SQL = "INSERT INTO [dbo].[ARA_STLINE] ([Users_ID] ,[ITEM_LREF] ,[ITEM_NAME],[ITEM_BREF],[ITEM_BNAME],[ITEM_MIKTAR]) VALUES \n";
            SQL += "(" + UserID + "," + ITEM_LREF + ",(select NAME from "+Islemler.Configs.SQLServerDBName_Tiger+".." + Request.Cookies["S_ANA"] + "_ITEMS where LOGICALREF = " + ITEM_LREF+")," + ITEM_BREF + ",N'" + ITEM_BNAME + "'," + ITEM_MIKTAR + ")";
            Islemler.DB_op.Instance.selectToZP(SQL);

            return Content("/UGF");
            //string UserID = Request.Cookies["ID"];
            //string SQL = "INSERT INTO [dbo].[Project] ([UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime]) VALUES";
            //SQL += " (N'" + UserID + "',N'" + PN + "',N'" + PE + "',N'" + PT + "',GETDATE())";
            //DB_op.Instance.selectTo(SQL, "");
            ////var Komisyon = DB_op.Instance.selectTo("select ID from Users where Rol = 2 ", "");
            ////string kom = "---";
            ////for (int i = 0; i < Komisyon.Rows.Count; i++)
            ////{
            ////    kom += Komisyon.Rows[i][0] + "---";
            ////}
            ////return Content(kom);
            //return Content("/Student");
        }
        public IActionResult OnGetLogoya_Aktar()
        {
            string UserID = Request.Cookies["ID"];
            //string ITEM_BREF = Request.Cookies["ITEM_BREF"];

            string SQL = "declare @F_TIME varchar(10) set @F_TIME = FORMAT(GETDATE(),'HH:mm:ss') \n";
            SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256 \n";
            SQL += "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from "+Request.Cookies["S_ALT"]+"_STFICHE where FICHENO like 'UGF%'),'UGF0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            SQL += "INSERT INTO [dbo].[" + Request.Cookies["S_ALT"] + "_STFICHE] ([GRPCODE],[TRCODE],[IOCODE],[FICHENO]\n,[DATE_],[FTIME],[SOURCEINDEX],[SOURCECOSTGRP],[CAPIBLOCK_CREADEDDATE],[CAPIBLOCK_CREATEDHOUR],[CAPIBLOCK_CREATEDMIN],[CAPIBLOCK_CREATEDSEC],[DOCDATE],[DOCTIME])\n VALUES (3,13,1,@Seed3,\n";
            SQL += "CAST(GETDATE() AS DATE) , @F_TIME4 , \n";
            SQL += "cast('" + Request.Cookies["AMBAR"] + "' as int) , \n";
            SQL += "(select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int) )   \n";
            SQL += ",GETDATE(),CAST(SUBSTRING(@F_TIME,1,2) as INT),CAST(SUBSTRING(@F_TIME,4,2) as INT),CAST(SUBSTRING(@F_TIME,7,2) as INT),CAST(GETDATE() AS DATE) , @F_TIME4  )\n";
            SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO = @Seed3 ";
            var FisRef = Islemler.DB_op.Instance.selectToTiger(SQL);


            var SQL2 = "select * from ARA_STLINE where Users_ID = " + UserID;
            var Aratablo = Islemler.DB_op.Instance.selectToZP_DT(SQL2);
            for (int i = 0; i < Aratablo.Rows.Count; i++)
            {
                var a1 = Aratablo.Rows[i]["ITEM_LREF"];
                var SQL3 = "declare @F_TIME2 varchar(10) set @F_TIME2 = FORMAT(GETDATE(),'HH:mm:ss') \n";
                SQL3 += "declare @F_TIME3 int set @F_TIME3 = CAST(SUBSTRING(@F_TIME2,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME2,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME2,7,2) as INT)*256 \n";
                SQL3 += "INSERT INTO " + Request.Cookies["S_ALT"] + "_STLINE ([STOCKREF],[LINETYPE],[PREVLINEREF],[PREVLINENO],[DETLINE],[TRCODE],[DATE_],[FTIME],[SOURCETYPE],[SOURCEINDEX],[SOURCECOSTGRP],[IOCODE],[STFICHEREF],[STFICHELNNO],[AMOUNT],[UOMREF],[USREF],[UINFO1],[UINFO2],[MONTH_],[YEAR_]\n";
                SQL3 +=    ") VALUES \n";
                SQL3 += "( " + Aratablo.Rows[i]["ITEM_LREF"] + ",0,0,0,0,13,CAST(GETDATE() AS DATE),@F_TIME3,0 \n";
                SQL3 += " ,cast('" + Request.Cookies["AMBAR"] + "' as int), (select COSTGRP from L_CAPIWHOUSE where FIRMNR = cast('" + Request.Cookies["S_FIRMNR"] + "' as int) and NR = cast('" + Request.Cookies["AMBAR"] + "' as int)) \n";
                SQL3 += ",1," + FisRef + "," + i.ToString() + "," + Aratablo.Rows[i]["ITEM_MIKTAR"].ToString().Replace(",", ".") + "," + Aratablo.Rows[i]["ITEM_BREF"] + ",(select UNITSETREF from " + Request.Cookies["S_ANA"] + "_UNITSETL where LOGICALREF =" + Aratablo.Rows[i]["ITEM_BREF"] + "),1,1,MONTH(GETDATE()),YEAR(GETDATE()) )";
                Islemler.DB_op.Instance.selectToTiger(SQL3);
            }
            Islemler.DB_op.Instance.selectToZP("DELETE ARA_STLINE where Users_ID = " + UserID);


            return Content("/UGF");
            //string UserID = Request.Cookies["ID"];
            //string SQL = "INSERT INTO [dbo].[Project] ([UserID],[ProjectName],[ProjectEx],[ProjectTalepEdilenHocaID],[ProjectDatetime]) VALUES";
            //SQL += " (N'" + UserID + "',N'" + PN + "',N'" + PE + "',N'" + PT + "',GETDATE())";
            //DB_op.Instance.selectTo(SQL, "");
            ////var Komisyon = DB_op.Instance.selectTo("select ID from Users where Rol = 2 ", "");
            ////string kom = "---";
            ////for (int i = 0; i < Komisyon.Rows.Count; i++)
            ////{
            ////    kom += Komisyon.Rows[i][0] + "---";
            ////}
            ////return Content(kom);
            //return Content("/Student");
        }
    }
}
