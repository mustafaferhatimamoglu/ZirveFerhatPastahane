using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZirveFerhatPastahane.Pages
{
    public class B2BModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnGetKalemMikDuzenle(string KalemID, string KalemMik)
        {
            string sql = "INSERT INTO [dbo].[Sepet] ([UserID],[UrunID],[UrunMik],[UrunBirim])" +
                " VALUES ("+ Request.Cookies["ID"] + ","+KalemID+","+KalemMik+",11) ";
              //  "UPDATE [dbo].[ARA_STLINE] set [ITEM_MIKTAR] = " + KalemMik + " WHERE ID = " + KalemID;
            Islemler.DB_op.Instance.selectToZP(sql);
            return Content("/B2B");
        }
    }
}
