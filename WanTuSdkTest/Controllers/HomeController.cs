/*
*2016.3.27
*开发者请注意，这里我提供了我自己使用的阿里云空间，流量有限，请合理使用
*别搞我啊,这边会定期清理文件
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WanTuNetSdk.common;

namespace WanTuSdkTest.Controllers
{
    public class HomeController : Controller
    {
        private const string Accesskey = "23277645";
        private const string Secretkey = "b826d40de2db00c39e5b60364a56599a";
        private const string Myspace = "wantueleven";
        // GET: Home
        public ActionResult Index()
        {
            var token = utils.GetPicTokenDefault(Accesskey,Secretkey,Myspace);
            ViewBag.token = token;
            return View();
        }
        /// <summary>
        /// 没有写自定义的例子，有时间再弄吧，心累
        /// </summary>
        /// <returns></returns>
        public ActionResult SelfDifine()
        {
            var policy = new PhotoPolicy();
            policy.NameSpace = Myspace;
            policy.detectMime = "0";
            policy.dir = "selfdefine";

            DateTime d1 = DateTime.Now.AddHours(2);//两小时后过期
            DateTime d2 = new DateTime(1970, 1, 1);
            double d = d1.Subtract(d2).TotalMilliseconds;
            long expiration = Convert.ToInt64(d);

            policy.expiration = expiration.ToString();
            policy.sizeLimit = 20 * 1024 * 1024;//20M
            //使用阿里提供的占位符，自动生成唯一文件名，
            //开发者可以根据自己需要自己生成，但要保证多个文件上传的时候文件名的差异
            policy.name = "${uuid}";
            policy.insertOnly = 0;

            //用作返回参数的设置，参数设置是默认值都为空，
            //由于这些都是占位符，所以只要设置随意字符，由原始代码生成
            var rb = new ReturnBody();
            rb.dir = "use";
            rb.uuid = "use";

            policy.returnBody = rb;
            var uploadPlocy = utils.BulidUploadPolicy(policy);
            ViewBag.uploadpolicy = uploadPlocy;
            var token = utils.GetPicTokenByPolicy(Accesskey, Secretkey, uploadPlocy);
            return View(token);
        }
    }
}