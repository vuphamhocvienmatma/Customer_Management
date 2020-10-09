using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer_Management.Models;

namespace Customer_Management.Controllers
{
    public class CustomerController : Controller
    {
        /// <summary>
        /// Hàm hiển thị danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult ListOfCustomer()
        {
            ListOfCustomerType();
            //Hiển thị danh sách khách hàng, chưa có chức năng tìm kiếm
            List<Customer> lstCustomer = DataProvider.Entities.customers.ToList();
            return View(lstCustomer);
        }

        /// <summary>
        /// Hàm hiển thị danh sách loại khách hàng
        /// </summary>
        /// <param name="IdOftype"></param>
        public void ListOfCustomerType(int? IdOftype = null)
        {
            List<TypeOfCustomer> lsttypeOfCustomers = DataProvider.Entities.typeofcustomer.ToList();
            ViewBag.TypeOfCustomer = new SelectList(lsttypeOfCustomers, "IdOftype", "Type", IdOftype.HasValue ? IdOftype.Value : 0);
        }

        public ActionResult AddCustomer()
        {
            //hiển thị danh sách loại khách hàng
            ListOfCustomerType();
            return View(new Customer());
        }

        /// <summary>
        /// Hàm thêm mới khách hàng
        /// </summary>
        /// <param name="objCustomer">Đối tượng được thêm</param>
        /// <param name="fUpload">Phụ trách đưa hình ảnh lên</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(Customer objCustomer, HttpPostedFileBase fUpload)
        {
            //hiển thị danh sách loại khách hàng
            ListOfCustomerType();
            if (ModelState.IsValid)
            {
                //Xử lý upload file
                if (fUpload != null &&
                    fUpload.ContentLength > 0)
                {
                    //Upload
                    fUpload.SaveAs(Server.MapPath("~/Content/img/" + fUpload.FileName));
                    //Lưu vào db
                    objCustomer.PictureId = fUpload.FileName;
                }
                //thêm vào database
                DataProvider.Entities.customers.Add(objCustomer);
                //Lưu thay đổi
                DataProvider.Entities.SaveChanges();
            }
            return RedirectToAction("ListOfCustomer");
        }

        public ActionResult UpdateCustomer(int Id)
        {
            //Hiển thị loại khách hàng
            ListOfCustomerType();

            Customer objcustomer = DataProvider.Entities.customers.Where(c => c.Id == Id).Single<Customer>();

            return View(objcustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(int Id, Customer objCustomer, HttpPostedFileBase fUpload)
        {
            ListOfCustomerType();

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

        /// <summary>
        /// Hàm xóa khách hàng
        /// </summary>
        /// <param name="idKhachHang"></param>
        /// <returns></returns>
        public ActionResult DeleteCustomer(int Id)
        {
            //Lấy đối tượng khách hàng
            Customer objcustomer = DataProvider.Entities.customers.Where(c => c.Id == Id).First();
            if (objcustomer != null)
            {
                //Xóa
                DataProvider.Entities.customers.Remove(objcustomer);
                //Lưu thay đổi
                DataProvider.Entities.SaveChanges();
            }
            return RedirectToAction("ListOfCustomer");
        }
    }
}