using DTOs;
using Microsoft.EntityFrameworkCore;

namespace DALs
{
    // Tầng DALs — CRUD với EF Core
    public class TheLoaiSachDAL
    {
        // Lấy toàn bộ thể loại
        public List<TheLoaiSach> LayDanhSach()
        {
            using var ctx = new TriThucBooksContext();
            return ctx.TheLoaiSaches.OrderBy(x => x.MaTL).ToList();
        }

        // Tìm theo tên (LINQ Contains)
        public List<TheLoaiSach> TimKiem(string tuKhoa)
        {
            using var ctx = new TriThucBooksContext();
            return ctx.TheLoaiSaches
                .Where(x => x.TenTheLoai.Contains(tuKhoa))
                .OrderBy(x => x.MaTL)
                .ToList();
        }

        // Kiểm tra tên đã tồn tại (khi thêm mới)
        public bool TonTaiTen(string tenTheLoai, int? maTLBoQua = null)
        {
            using var ctx = new TriThucBooksContext();
            return ctx.TheLoaiSaches.Any(x =>
                x.TenTheLoai == tenTheLoai &&
                (maTLBoQua == null || x.MaTL != maTLBoQua));
        }

        // Thêm thể loại
        public async Task ThemAsync(TheLoaiSach tl)
        {
            using var ctx = new TriThucBooksContext();
            tl.NgayTao = DateTime.Now;
            tl.SoLuongSach = 0;
            ctx.TheLoaiSaches.Add(tl); // context.Add()
            await ctx.SaveChangesAsync();
        }

        // Sửa thể loại
        public async Task SuaAsync(TheLoaiSach tl)
        {
            using var ctx = new TriThucBooksContext();
            var entity = await ctx.TheLoaiSaches.FindAsync(tl.MaTL);
            if (entity == null) return;

            entity.TenTheLoai = tl.TenTheLoai;
            entity.MoTa = tl.MoTa;
            await ctx.SaveChangesAsync();
        }

        // Xóa thể loại — ném DbUpdateException nếu bị ràng buộc
        public async Task XoaAsync(int maTL)
        {
            using var ctx = new TriThucBooksContext();
            var entity = await ctx.TheLoaiSaches.FindAsync(maTL);
            if (entity == null) return;

            ctx.TheLoaiSaches.Remove(entity);
            await ctx.SaveChangesAsync();
        }
    }
}
