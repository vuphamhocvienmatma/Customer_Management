using Customer_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_Management.Controllers
{
    public class TypeOfCustomerController : Controller
    {
        public ActionResult ListOfCustomerType(string tuKhoa, int? TypeOfCustomer)
        {
            List<TypeOfCustomer> lstCustomer = DataProvider.Entities.typeofcustomer.ToList();
            return View(lstCustomer);
        }

        public ActionResult DeleteCustomerType(int Id)
        {
            //Lấy đối tượng loại khách hàng
            TypeOfCustomer objcustomerType = DataProvider.Entities.typeofcustomer.Where(c => c.IdOftype == Id).First();
            if (objcustomerType != null)
            {
                //Xóa
                DataProvider.Entities.typeofcustomer.Remove(objcustomerType);
                //Lưu thay đổi
                DataProvider.Entities.SaveChanges();
            }
            return RedirectToAction("ListOfCustomerType");
        }

        public ActionResult AddCustomerType()
        {
            //hiển thị danh sách loại khách hàng
            return View(new TypeOfCustomer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomerType(TypeOfCustomer objcustomerType, HttpPostedFileBase fUpload)
        {
            //hiển thị danh sách loại khách hàng
            if (ModelState.IsValid)
            {
                //Xử lý upload file
                if (fUpload != null &&
                    fUpload.ContentLength > 0)
                {
                    //Upload
                    fUpload.SaveAs(Server.MapPath("~/Content/img/" + fUpload.FileName));
                    //Lưu vào db
                    objcustomerType.PictureId = fUpload.FileName;
                }
                //thêm vào database
                DataProvider.Entities.typeofcustomer.Add(objcustomerType);
                //Lưu thay đổi
                DataProvider.Entities.SaveChanges();
            }
            return RedirectToAction("ListOfCustomerType");
        }
    }
}