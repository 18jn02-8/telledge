using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;
using System.Data;
using System.IO;

namespace telledge.Controllers.Teachers
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult mypage()
        {
			if (Teacher.currentUser() == null) return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
            return View("/Views/Teachers/Homes/mypage.cshtml", Teacher.currentUser());

		}

		[HttpPost]
		public ActionResult update(String imagePath ,String mailaddress ,String name, String nationality, int sex, String intoroduction)
		{
			Teacher teacher = Teacher.currentUser();
			if (teacher != null)
			{
				if (mailaddress != "") teacher.mailaddress = mailaddress;
				if (name != "") teacher.name = name;
				if (nationality != "") teacher.nationality = nationality;
				if (intoroduction != "") teacher.intoroduction = intoroduction;
				teacher.sex = sex;

				if (teacher.Update())
				{
					//正常系
					return RedirectToRoute("teacher", new { controller = "homes", action = "mypage" });
				}
				else
				{
					//異常系
					return RedirectToRoute("teacher", new { controller = "homes", action = "mypage" });
				}
			}
			//ログインしていない場合にする処理
			return RedirectToRoute("teacher", new { controller = "sessions", action = "create" });

		}

		public ActionResult edit()
		{
			return View("/Views/Teachers/Homes/edit.cshtml");
		}

		// アップロード処理を行うUpload/DbUploadアクション
		// （HTTP POSTによる実行）
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult DbUpload(HttpPostedFileBase imagePath)
		{

			// コンテンツ・タイプが「image/*」であるか（画像ファイルか）
			// をチェック
			if (imagePath.ContentType.StartsWith("image/"))
			{

				// EDMのコンテキスト・オブジェクトを生成
				var _db = new MyMvcEntities();

				// エンティティにアップロード・ファイルの情報をセット
				var ph = new Teacher();
				ph.profileImage = Path.GetFileName(imagePath.FileName);  // ファイル名
				ph.uploadedProfileImage = imagePath.ContentType;  // コンテンツ・タイプ

				// エンティティを追加＆データソースに反映
				_db.AddObject("Teacher", ph);
				_db.SaveChanges();
				ViewData["msg"] = String.Format(
				  "画像アップロード完了しました", imagePath.FileName);
			}
			else
			{
				// 画像ファイルでない場合はエラー
				ViewData["msg"] = "画像以外はアップロードできません。";
			}
			// 入力元のフォームに結果を表示
			return View("/Views/Teachers/Registrations/create.cshtml");
		}
	}
}