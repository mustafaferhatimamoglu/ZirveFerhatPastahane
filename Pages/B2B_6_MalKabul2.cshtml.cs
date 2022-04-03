using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZirveFerhatPastahane.Pages
{
    public class B2B_6_MalKabul2 : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnGetBarkodBilgileriniGetir(string gelen)
        {
            var sql = "use  KL_TPOSMERKEZ" +
                "SELECT IT.ITEMCODE AS KODU,IT.ITEMNAME AS ADI,  SUM(NETAMOUNT) AS MIKTAR,STL.UNITCODE AS BIRIM,SUM(STL.TOTAL) AS TUTAR \n" +
"FROM CLNT_STLINE AS STL,CLNT_STFICHE AS STF,CLNT_ITEMS AS IT \n" +

"WHERE STL.STFICHEREF=STF.LOGICALREF \n" +
"AND STL.ITEMREF=IT.ITEMREF AND STF.FICHEBARCODE='2349002764081150' \n" +
"GROUP BY IT.ITEMCODE,IT.ITEMNAME,STL.UNITCODE ";

            var sql_cevap = Islemler.DB_op.Instance.selectToTiger_DT(sql);

            return Content("/B2B_6_MalKabul2?gelen="+gelen);
        }
        public static string docode_gelen = null;
        public IActionResult OnGetProjeOlustur(string gelen)
        {
            var Data = gelen.Split("-~-");
            var DataCount = Data.Length - 1;

            string UserID = Request.Cookies["ID"];
            string ClientRef = Islemler.DB_op.Instance.selectToZP("select L_SQL from USERS where ID = " + UserID);
            //string ITEM_BREF = Request.Cookies["ITEM_BREF"];

            //string SQL = "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from " + Request.Cookies["S_ALT"] + "_ORFICHE where FICHENO like 'B3B%'),'B3B0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            //SQL += "declare @F_TIME varchar(10) set @F_TIME = FORMAT(GETDATE(),'HH:mm:ss') \n";
            //SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256  \n";

            //SQL += "insert into " + Request.Cookies["S_ALT"] + "_ORFICHE (TRCODE,FICHENO,STATUS,DATE_,TIME_" +
            //    ",CLIENTREF) VALUES (1,@Seed3,1,CAST(GETDATE() AS DATE),@F_TIME4" +
            //    "," + ClientRef + ")  \n";
            //SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_ORFICHE where FICHENO = @Seed3 \n";
            //var gelendocode = Request.QueryString.ToString();
            //gelendocode = Request.Q

            string SQL = "DECLARE @Seed2 VARCHAR(16) =  isnull ((select MAX(FICHENO) from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO like 'B3B%'),'B3B0000000000000') DECLARE @IncrementedValue2 BIGINT = CONVERT(BIGINT,CONVERT(BIGINT, substring(@Seed2,4,LEN(@Seed2)-1)))+ 1 DECLARE @Seed3 VARCHAR(16) =  CONVERT(varchar, substring(@Seed2,1,3)) + SUBSTRING('0000000000000',1, 13 - LEN(convert(varchar,@IncrementedValue2))) + Convert(varchar,@IncrementedValue2) \n";
            SQL += "declare @F_TIME varchar(10) set @F_TIME = FORMAT(GETDATE(),'HH:mm:ss') \n";
            SQL += "declare @F_TIME4 int set @F_TIME4 = CAST(SUBSTRING(@F_TIME,1,2) as INT)*16777216 + CAST(SUBSTRING(@F_TIME,4,2) as INT)*65536 + CAST(SUBSTRING(@F_TIME,7,2) as INT)*256  \n";

            SQL += "INSERT INTO " + Request.Cookies["S_ALT"] + "_STFICHE (GRPCODE,TRCODE,IOCODE,FICHENO,DATE_,FTIME,DOCODE,SOURCEINDEX,SOURCECOSTGRP,BRANCH, \n" +
                "GENEXCTYP,RECSTATUS,INVOICEREF,CLIENTREF,RECVREF,ACCOUNTREF,CENTERREF,PRODORDERREF,PORDERFICHENO,SOURCETYPE, \n" +
                "SOURCEWSREF,SOURCEPOLNREF,DESTTYPE,DESTINDEX,DESTWSREF,DESTPOLNREF,DESTCOSTGRP,FACTORYNR,DEPARTMENT,COMPBRANCH,COMPDEPARTMENT, \n" +
                "COMPFACTORY,PRODSTAT,DEVIR,CANCELLED,BILLED,ACCOUNTED,UPDCURR,INUSE,INVKIND,ADDDISCOUNTS, \n" +
                "TOTALDISCOUNTS,TOTALDISCOUNTED,ADDEXPENSES,TOTALEXPENSES,TOTALDEPOZITO,TOTALPROMOTIONS,TOTALVAT,GROSSTOTAL,NETTOTAL,REPORTRATE, \n" +
                "DOCDATE,DOCTIME,SHIPDATE,SHIPTIME) \n" +
                "VALUES (3,15,1,@Seed3,CAST(GETDATE() AS DATE),@F_TIME4,'"+ docode_gelen + "','" + Request.Cookies["ISYERI"] + "','" + Request.Cookies["ISYERI"] + "','" + Request.Cookies["ISYERI"] + "', \n" +
                "3,1,0,0,0,0,0,0,0,0, \n" +
                "0,0,0,0,0,0,0,0,0,0,0, \n" +
                "0,0,0,0,0,0,0,0,0,0, \n" +
                "0,0,0,0,0,0,0,0,0,1, \n" +
                "CAST(GETDATE() AS DATE),@F_TIME4,CAST(GETDATE() AS DATE),@F_TIME4) \n";
            SQL += "select LOGICALREF from " + Request.Cookies["S_ALT"] + "_STFICHE where FICHENO = @Seed3 \n";
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
                SQL3 += "INSERT INTO " + Request.Cookies["S_ALT"] + "_STLINE ([STOCKREF],[STFICHEREF],[TRCODE],[AMOUNT],[UOMREF],[DATE_],[CLIENTREF],[LINETYPE],DETLINE,FTIME,SOURCEINDEX,SOURCECOSTGRP,IOCODE, \n" +
                    "PREVLINEREF,PREVLINENO,GLOBTRANS,CALCTYPE,PRODORDERREF,SOURCETYPE,SOURCEWSREF,SOURCEPOLNREF,DESTTYPE,DESTINDEX,DESTCOSTGRP,DESTWSREF,DESTPOLNREF,FACTORYNR,STFICHELNNO,INVOICEREF,INVOICELNNO, \n" +
                    "ORDTRANSREF,ORDFICHEREF,CENTERREF,ACCOUNTREF,VATACCREF,VATCENTERREF,PRACCREF,PRCENTERREF,PRVATACCREF,PRVATCENREF,PROMREF,PAYDEFREF,PRICE,TOTAL,PRCURR,PRPRICE,TRCURR,TRRATE,REPORTRATE,DISTCOST,DISTDISC,DISTEXP,DISTPROM,DISCPER, \n" +
                    "PLNAMOUNT,VATINC,VAT,VATAMNT,VATMATRAH,BILLEDITEM,BILLED,CPSTFLAG,RETCOSTTYPE,SOURCELINK,RETCOST,RETCOSTCURR,OUTCOST,OUTCOSTCURR,RETAMOUNT,FAREGREF,FAATTRIB,CANCELLED,LINENET,DISTADDEXP,FADACCREF,FADCENTERREF,FARACCREF,FARCENTERREF,DIFFPRICE,DIFFPRCOST,DECPRDIFF,LPRODSTAT,PRDEXPTOTAL,DIFFREPPRICE,DIFFPRCRCOST,SALESMANREF,FAPLACCREF,FAPLCENTERREF, \n" +
                    "DREF,COSTRATE,XPRICEUPD,XPRICE,XREPRATE,DISTCOEF,TRANSQCOK,SITEID,RECSTATUS \n";
                SQL3 += ") VALUES \n";
                SQL3 += "( " + UrunId + "," + FisRef + ",25," + UrunMik + "," + UrunBirim + ",CAST(GETDATE() AS DATE)," + ClientRef + ",0,0,@F_TIME4,'" + Request.Cookies["ISYERI"] + "','" + Request.Cookies["ISYERI"] + "',2, \n" +
                    "0,0,0,0,0,0,0,0,0,0,0,0,0,0,"+ (i + 1).ToString() + ",0,0, \n" +
                    "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0, \n" +
                    "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, \n" +
                    "0,0,0,0,0,0,0,0,1) \n";

                //SQL3 += "INSERT INTO " + Request.Cookies["S_ALT"] + "_STLINE ([STOCKREF],[STFICHEREF],[TRCODE],[AMOUNT],[UOMREF],[DATE_],[CLIENTREF],[LINETYPE],DETLINE,FTIME,SOURCEINDEX,SOURCECOSTGRP,IOCODE \n";
                //SQL3 += ") VALUES \n";
                //SQL3 += "( " + UrunId + "," + FisRef + ",25," + UrunMik + "," + UrunBirim + ",CAST(GETDATE() AS DATE)," + ClientRef + ",0,0,@F_TIME4,'" + Request.Cookies["ISYERI"] + "','" + Request.Cookies["ISYERI"] + "',2) \n";
                Islemler.DB_op.Instance.selectToTiger(SQL3);
            }
            return Content("/MalKabulTamamla");



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
    }
}
