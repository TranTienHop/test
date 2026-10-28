using DALs;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace BULs
{
    // Tầng BULs — nghiệp vụ + kiểm tra hợp lệ
    public class TheLoaiSachBUL
    {
        private TheLoaiSachDAL _dal = new TheLoaiSachDAL();

        public List<TheLoaiSach> LayDanhSach() => _dal.LayDanhSach();

        public List<TheLoaiSach> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return _dal.LayDanhSach(); // Rỗng thì lấy hết.
            return _dal.TimKiem(tuKhoa.Trim());
        }

        // Thêm — TenTheLoai không rỗng, không trùng
        public async Task<(bool ok, string thongBao)> ThemAsync(TheLoaiSach tl)
        {
            if (string.IsNullOrWhiteSpace(tl.TenTheLoai))
                return (false, "Tên thể loại không được để trống!");

            if (_dal.TonTaiTen(tl.TenTheLoai.Trim()))
                return (false, "Tên thể loại đã tồn tại!");

            tl.TenTheLoai = tl.TenTheLoai.Trim();
            await _dal.ThemAsync(tl);
            return (true, "Thêm thể loại thành công!");
        }

        // Sửa
        public async Task<(bool ok, string thongBao)> SuaAsync(TheLoaiSach tl)
        {
            if (tl.MaTL <= 0)
                return (false, "Vui lòng chọn thể loại cần sửa!");

            if (string.IsNullOrWhiteSpace(tl.TenTheLoai))
                return (false, "Tên thể loại không được để trống!");

            if (_dal.TonTaiTen(tl.TenTheLoai.Trim(), tl.MaTL))
                return (false, "Tên thể loại đã tồn tại!");

            tl.TenTheLoai = tl.TenTheLoai.Trim();
            await _dal.SuaAsync(tl);
            return (true, "Cập nhật thể loại thành công!");
        }

        // Xóa — bắt DbUpdateException nếu đang được sách tham chiếu
        public async Task<(bool ok, string thongBao)> XoaAsync(int maTL)
        {
            if (maTL <= 0)
                return (false, "Vui lòng chọn thể loại cần xóa!");

            try
            {
                await _dal.XoaAsync(maTL);
                return (true, "Xóa thể loại thành công!");
            }
            catch (DbUpdateException)
            {
                return (false, "Không thể xóa! Thể loại đang được sách tham chiếu.");
            }
        }
    }
}
