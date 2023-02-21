  public ActionResult TaoMoi(SanPham sp, HttpPostedFileBase[] HinhAnh)
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            if (HinhAnh[0].ContentLength > 0)
            {
                //Lấy tên hình ảnh
                var filename = Path.GetFileName(HinhAnh[0].FileName);
                //Lấy hình ảnh chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Content/ProductImages"), filename);
                //Nếu thư mục chứa hình ảnh đó rồi thì xuất ra thông báo
                if (System.IO.File.Exists(path))
                {
                    ViewBag.HinhAnh = "Hình đã tồn tài";
                    return View();
                }
                else
                {
                    HinhAnh[0].SaveAs(path);
                    sp.HinhAnh = HinhAnh[0].FileName;
                }
            }
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }