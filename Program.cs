using System;
using System.Collections.Generic;
using System.Text;

struct MatHang
{
    public int MaMH;
    public string TenMH;
    public int SoLuong;
    public double DonGia;

    public MatHang(int maMH, string tenMH, int soLuong, double donGia)
    {
        MaMH = maMH;
        TenMH = tenMH;
        SoLuong = soLuong;
        DonGia = donGia;
    }

    public double ThanhTien()
    {
        return SoLuong * DonGia;
    }
}

class Program
{
    static bool ThemMatHang(List<MatHang> ds, MatHang mh)
    {
        if (TimMatHang(ds, mh.MaMH))
            return false;
        ds.Add(mh);
        return true;
    }

    static bool TimMatHang(List<MatHang> ds, int maMH)
    {
        foreach (MatHang mh in ds)
        {
            if (mh.MaMH == maMH)
                return true;
        }
        return false;
    }

    static void XuatDanhSach(List<MatHang> ds)
    {
        if (ds.Count == 0)
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }

        Console.WriteLine("{0,-8}{1,-20}{2,-10}{3,-12}{4,-12}",
            "MaMH", "TenMH", "SoLuong", "DonGia", "ThanhTien");
        foreach (MatHang mh in ds)
        {
            Console.WriteLine("{0,-8}{1,-20}{2,-10}{3,-12:0.##}{4,-12:0.##}",
                mh.MaMH, mh.TenMH, mh.SoLuong, mh.DonGia, mh.ThanhTien());
        }
    }

    static bool XoaMatHang(List<MatHang> ds, int maMH)
    {
        return ds.RemoveAll(mh => mh.MaMH == maMH) > 0;
    }

    static int NhapSoNguyen(string loiNhac)
    {
        int so;
        while (true)
        {
            Console.Write(loiNhac);
            if (int.TryParse(Console.ReadLine(), out so))
                return so;
            Console.WriteLine("Phải nhập số nguyên, nhập lại.");
        }
    }

    static double NhapSoThuc(string loiNhac)
    {
        double so;
        while (true)
        {
            Console.Write(loiNhac);
            if (double.TryParse(Console.ReadLine(), out so))
                return so;
            Console.WriteLine("Phải nhập số, nhập lại.");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<MatHang> ds = new List<MatHang>();

        string tiepTuc;
        do
        {
            Console.WriteLine("--- Nhập mặt hàng ---");
            int ma = NhapSoNguyen("Mã mặt hàng: ");
            Console.Write("Tên mặt hàng: ");
            string ten = Console.ReadLine();
            int sl = NhapSoNguyen("Số lượng: ");
            double gia = NhapSoThuc("Đơn giá: ");

            if (ThemMatHang(ds, new MatHang(ma, ten, sl, gia)))
                Console.WriteLine("Đã thêm mặt hàng.");
            else
                Console.WriteLine("Mã mặt hàng đã tồn tại, không thêm.");

            Console.Write("Tiếp tục nhập? (c/k): ");
            tiepTuc = Console.ReadLine().Trim().ToLower();
        } while (tiepTuc == "c");

        Console.WriteLine();
        Console.WriteLine("=== DANH SÁCH MẶT HÀNG ===");
        XuatDanhSach(ds);

        Console.WriteLine();
        int maCanXoa = NhapSoNguyen("Nhập mã mặt hàng cần tìm: ");
        if (TimMatHang(ds, maCanXoa))
        {
            XoaMatHang(ds, maCanXoa);
            Console.WriteLine("Đã xóa mặt hàng có mã " + maCanXoa + ".");
            Console.WriteLine("=== DANH SÁCH SAU KHI XÓA ===");
            XuatDanhSach(ds);
        }
        else
        {
            Console.WriteLine("Không tìm thấy mặt hàng có mã " + maCanXoa + ".");
        }

        Console.ReadKey();
    }
}