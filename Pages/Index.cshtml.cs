using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZirveFerhatPastahane.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnGetGiris(string Username, string Pass)
        {
            string sorgu = "DECLARE @RC int , @UserName nvarchar(50) ,@password nvarchar(50) \n";
            sorgu += "set @UserName = N'"+Username+"' set @password = N'"+Pass+"' \n";
            sorgu += "EXECUTE @RC = [dbo].[SP_Login] @UserName ,@password  \n";
            var sql_cevap = Islemler.DB_op.Instance.selectToZP_DT(sorgu);
            //string sql_cevap1 = sql_cevap.Rows[0][0].ToString() + "-----" + sql_cevap.Rows[0][1].ToString();
            //return Content(sql_cevap1);
            string sql_cevap1 =
                sql_cevap.Rows[0][0].ToString() + "-----" +
                sql_cevap.Rows[0][1].ToString() + "-----" +
                sql_cevap.Rows[0][2].ToString() + "-----" +
                sql_cevap.Rows[0][3].ToString() + "-----" +
                sql_cevap.Rows[0][4].ToString() + "-----" +
                sql_cevap.Rows[0][5].ToString() + "-----" +
                //sql_cevap.Rows[0][6].ToString() + "-----" +
                sql_cevap.Rows[0][6].ToString() + "-----" +
                sql_cevap.Rows[0][7].ToString().Replace(" ", "*~") + "-----" +//.replace(' ', '*~');
                sql_cevap.Rows[0][8].ToString();
            return Content(sql_cevap1);
            /////////////return Content(ID);
            //ZP_USERS ZP_USERS_obj = JsonSerializer.Deserialize<ZP_USERS>(gelen);
            //string RoleLink = "/";
            //switch (ZP_USERS_obj.Rol)
            //{
            //    case 1:
            //        //öğrenci
            //        RoleLink = "/UGF";
            //        break;
            //    //case "2":
            //    //    //öğrenci
            //    //    RoleLink = "/StajKomiyonUyesi";
            //    //    break;
            //    //case "3":
            //    //    //öğrenci
            //    //    RoleLink = "/StajDegerlendirici";
            //    //    break;
            //    default:
            //        //case 2:
            //        // hatalı birşey
            //        //Response.Redirect("Login");
            //        throw new Exception("Kullanıcı adı veya şifre yanlış.!");
            //}
            //Response.Cookies.Append("ID", ZP_USERS_obj.ID.ToString());
            //Response.Cookies.Append("Rol", ZP_USERS_obj.Rol.ToString());
            //Response.Cookies.Append("ISYERI", ZP_USERS_obj.ISYERI);
            //Response.Cookies.Append("BOLUM", ZP_USERS_obj.BOLUM);
            //Response.Cookies.Append("FABRIKA", ZP_USERS_obj.FABRIKA);
            //Response.Cookies.Append("AMBAR", ZP_USERS_obj.AMBAR);
            //return Content(gelen);
        }
    }
    public class ZP_USERS
    {
        public int ID { get; set; }
        public int Rol { get; set; }
        public string ISYERI { get; set; }
        public string BOLUM { get; set; }
        public string FABRIKA { get; set; }
        public string AMBAR { get; set; }
    }
}
