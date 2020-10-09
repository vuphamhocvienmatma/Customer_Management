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
        public ActionResult ListOfCustomerType()
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

        public ActionResult UpdateCustomerType(int Id)
        {
            //Hiển thị loại khách hàng

            Customer objcustomerType = DataProvider.Entities.customers.Where(c => c.Id == Id).Single<Customer>();

            return View(objcustomerType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomerType(int Id, Customer objCustomer, HttpPostedFileBase fUpload)
        {
            var objOld_Customer = DataProvider.Entities.customers.Find(Id);
            string img_Name = "";
            //Xử lý upload file
            if (fUpload != null &&
                fUpload.ContentLength > 0)
            {
                //Upload
                fUpload.SaveAs(Server.MapPath("~/Content/img/" + fUpload.FileName));
                //Lưu vào db
                objCustomer.PictureId = fUpload.FileName;
                img_Name = fUpload.FileName;
            }
            if (objOld_Customer != null)
            {
                if (string.IsNullOrEmpty(img_Name))
                {
                    objCustomer.PictureId = objOld_Customer.PictureId;
                }
                DataProvider.Entities.Entry(objOld_Customer).CurrentValues.SetValues(objCustomer);
                //Lưu thay đổi
                DataProvider.Entities.SaveChanges();
            }
            return RedirectToAction("ListOfCustomer");
        }
    }
}