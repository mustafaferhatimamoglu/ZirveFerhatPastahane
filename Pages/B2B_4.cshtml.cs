using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZirveFerhatPastahane.Pages
{
    public class B2B_4Model : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnGetAdaGoreBul(string KalemAd)
        {
            string sql = "select ITEMS1.LOGICALREF,ITEMS1.CODE,ITEMS1.[NAME],ITEMS1.SPECODE,ITEMS3.LOGICALREF as item3lref,ITEMS3.NAME as item3name \n" +
"--,(select DEFINITION_ from " + Request.Cookies["S_ANA"] + "_SPECODES where LG_002_SPECODES.SPECODE = ITEMS1.SPECODE and SPETYP1 = 1) as SPECODEname \n" +
"from " + Request.Cookies["S_ANA"] + "_ITEMS as ITEMS1 ," + Request.Cookies["S_ANA"] + "_ITMUNITA as ITEMS2 , " + Request.Cookies["S_ANA"] + "_UNITSETL as ITEMS3 \n" +
" where ITEMS1.NAME != '' \n" +
"and ITEMS1.LOGICALREF = ITEMS2.ITEMREF and ITEMS2.UNITLINEREF = ITEMS3.LOGICALREF \n";
            sql += "and ITEMS1.[NAME] = '" + KalemAd + "'";
            var sql_cevap = Islemler.DB_op.Instance.selectToTiger_DT(sql);

            string cevap = "";
            for (int i = 0; i < sql_cevap.Rows.Count; i++)
            {
                cevap += sql_cevap.Rows[i]["item3name"]+"~~"+ sql_cevap.Rows[i]["item3lref"] + "-~-";
            }
            return Content(cevap);
        }

        public IActionResult OnGetProjeOlustur(string gelen)
        {
            var Data = gelen.Split("-~-");
            var DataCount = Data.Length - 1;

            string UserID = Request.Cookies["ID"];
            string ClientRef = Islemler.DB_op.Instance.selectToZP("select L_SQL from USERS where ID = " + UserID);
            //string ITEM_BREF = Request.Cookies["ITEM_BREF"];

            string SQL = "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from " + Request.Cookies["S_ALT"] + "_ORFICHE where FICHENO like 'B2B%'),'B2B0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            SQL += "declare @F_TIME varchar(10) set @F_TIME = FORMAT(GETDATE(),'HH:mm:ss') \n";
            SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256  \n";

            SQL += "insert into " + Request.Cookies["S_ALT"] + "_ORFICHE (TRCODE,FICHENO,STATUS,DATE_,TIME_" +
                ",CLIENTREF) VALUES (1,@Seed3,1,CAST(GETDATE() AS DATE),@F_TIME4" +
                ","+ClientRef+")  \n";
            SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_ORFICHE where FICHENO = @Seed3 \n";
            var FisRef = Islemler.DB_op.Instance.selectToTiger(SQL);

            for (int i = 0; i < DataCount; i++)
            {
                var DataAlt = Data[i].Split("~~");
                var UrunId = DataAlt[0];
                var UrunMik = DataAlt[1];
                var UrunBirim = DataAlt[2];

                var SQL3 = "";
                SQL3 += "declare @F_TIME varchar(10) set @F_TIME = FORMAT(GETDATE(),'HH:mm:ss') \n";
                SQL3 += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256  \n";
                SQL3 += "INSERT INTO " + Request.Cookies["S_ALT"] + "_ORFLINE ([STOCKREF],[ORDFICHEREF],[TRCODE],[AMOUNT],[UOMREF],[LINENO_],[DATE_],[TIME_],[CLIENTREF],[LINETYPE],[CLOSED],[SHIPPEDAMOUNT],DETLINE \n";
                SQL3 += ") VALUES \n";
                SQL3 += "( " + UrunId + "," + FisRef + ",1," + UrunMik + "," + UrunBirim + "," + (i+1).ToString() + ",CAST(GETDATE() AS DATE),@F_TIME4," + ClientRef+",0,0,0,0) \n";
                Islemler.DB_op.Instance.selectToTiger(SQL3);
            }
            return Content("/Siparis_Alinmistir");



            //var SQL2 = "select * from SEPET where UserID = " + UserID;
            //var Aratablo = Islemler.DB_op.Instance.selectToZP_DT(SQL2);
            //for (int i = 0; i < Aratablo.Rows.Count; i++)
            //{
                
            //    var SQL3 = "INSERT INTO " + Request.Cookies["S_ALT"] + "_ORFLINE ([STOCKREF],[ORDFICHEREF],[TRCODE],[AMOUNT],[UOMREF] \n";
            //    SQL3 += ") VALUES \n";
            //    SQL3 += "( " + Aratablo.Rows[i]["UrunID"] + "," + FisRef + ",1," + Aratablo.Rows[i]["UrunMik"] + "," + Aratablo.Rows[i]["UrunBirim"] + ") \n";
            //    Islemler.DB_op.Instance.selectToTiger(SQL3);
            //}
            //Islemler.DB_op.Instance.selectToZP("DELETE SEPET where UserID = " + UserID);


            //return Content("/B2B_4");
        }
        public IActionResult SayfayiYukle(string KalemAd)
        {
            string sql = "select ITEMS1.LOGICALREF,ITEMS1.CODE,ITEMS1.[NAME],ITEMS1.SPECODE,ITEMS3.LOGICALREF as item3lref,ITEMS3.NAME as item3name \n" +
"--,(select DEFINITION_ from " + Request.Cookies["S_ANA"] + "_SPECODES where LG_002_SPECODES.SPECODE = ITEMS1.SPECODE and SPETYP1 = 1) as SPECODEname \n" +
"from " + Request.Cookies["S_ANA"] + "_ITEMS as ITEMS1 ," + Request.Cookies["S_ANA"] + "_ITMUNITA as ITEMS2 , " + Request.Cookies["S_ANA"] + "_UNITSETL as ITEMS3 \n" +
" where ITEMS1.NAME != '' \n" +
"and ITEMS1.LOGICALREF = ITEMS2.ITEMREF and ITEMS2.UNITLINEREF = ITEMS3.LOGICALREF \n";
            sql += "and ITEMS1.[NAME] = '" + KalemAd + "'";
            var sql_cevap = Islemler.DB_op.Instance.selectToTiger_DT(sql);

            string cevap = "";
            for (int i = 0; i < sql_cevap.Rows.Count; i++)
            {
                cevap += sql_cevap.Rows[i]["item3name"] + "~~" + sql_cevap.Rows[i]["item3lref"] + "-~-";
            }
            return Content(cevap);
        }

    }
}
