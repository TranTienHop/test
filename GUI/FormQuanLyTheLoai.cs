using BULs;
using DTOs;

namespace GUI
{
    public partial class FormQuanLyTheLoai : Form
    {
        private TheLoaiSachBUL _bul = new TheLoaiSachBUL();

        public FormQuanLyTheLoai()
        {
            InitializeComponent();
        }

        // Khi mở form
        // Sự kiện chạy khi Form được mở.
        private void FormQuanLyTheLoai_Load(object sender, EventArgs e)
        {
            LoadDanhSach(); // Nạp DataGridView.
            LamMoiONhap(); // Xóa ô nhập + set Enable/Disable nút.
        }

        // Trạng thái mặc định: chỉ cho Thêm, khóa Sửa/Xóa
        void SetNutMacDinh()
        {
            btnThem.Enabled = true; // Cho phép bấm nút Thêm.
            btnSua.Enabled = false; // Không cho phép bấm nút Sửa.
            btnXoa.Enabled = false; // Không cho phép bấm nút Xóa.
            btnLamMoi.Enabled = true; // Cho phép bấm nút Làm mới.
            btnTimKiem.Enabled = true; // Cho phép bấm nút Tìm kiếm.
        }

        // Khi đã chọn 1 dòng trên lưới: cho Sửa/Xóa
        void SetNutKhiChonDong()
        {
            btnThem.Enabled = false; // Không cho Thêm khi đang chọn bản ghi cũ.
            btnSua.Enabled = true; // Cho phép bấm nút Sửa.
            btnXoa.Enabled = true; // Cho phép bấm nút Xóa.
            btnLamMoi.Enabled = true; // Cho phép bấm nút Làm mới.
            btnTimKiem.Enabled = true; // Cho phép bấm nút Tìm kiếm.
        }

        // Nạp / làm mới DataGridView (không reload cả Form)
        void LoadDanhSach(List<TheLoaiSach>? ds = null)
        {
            ds ??= _bul.LayDanhSach();
            dgvTheLoai.DataSource = null;
            dgvTheLoai.DataSource = ds;

            if (dgvTheLoai.Columns["MaTL"] != null)
                dgvTheLoai.Columns["MaTL"].HeaderText = "Mã TL";
            if (dgvTheLoai.Columns["TenTheLoai"] != null)
                dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
            if (dgvTheLoai.Columns["MoTa"] != null)
                dgvTheLoai.Columns["MoTa"].HeaderText = "Mô tả";
            if (dgvTheLoai.Columns["SoLuongSach"] != null)
                dgvTheLoai.Columns["SoLuongSach"].HeaderText = "Số lượng sách";
            if (dgvTheLoai.Columns["NgayTao"] != null)
                dgvTheLoai.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }

        // Xóa nội dung ô nhập (Làm mới)
        void LamMoiONhap()
        {
            txtMaTL.Text = ""; // Mã để trống (ReadOnly).
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            lblNgayTao.Text = "Ngày tạo: —";
            SetNutMacDinh(); // Về trạng thái chỉ Thêm.
            txtTenTheLoai.Focus();
        }

        // SelectionChanged — click dòng → đổ lên TextBox
        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow == null || dgvTheLoai.CurrentRow.Index < 0)
                return;
            if (dgvTheLoai.CurrentRow.DataBoundItem is not TheLoaiSach tl)
                return;

            txtMaTL.Text = tl.MaTL.ToString(); // Đổ mã.
            txtTenTheLoai.Text = tl.TenTheLoai; // Đổ tên.
            txtMoTa.Text = tl.MoTa ?? ""; // Đổ mô tả.
            lblNgayTao.Text = "Ngày tạo: " + tl.NgayTao.ToString("yyyy/MM/dd HH:mm:ss"); // Hiện ngày tạo.
            SetNutKhiChonDong(); // Bật Sửa/Xóa khi đã chọn dòng.
        }

        // Nút Thêm
        private async void btnThem_Click(object sender, EventArgs e)
        {
            TheLoaiSach tl = new TheLoaiSach
            {
                TenTheLoai = txtTenTheLoai.Text,
                MoTa = txtMoTa.Text
            };

            var (ok, thongBao) = await _bul.ThemAsync(tl);
            MessageBox.Show(thongBao, "Thông báo",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (ok)
            {
                LoadDanhSach(); // Refresh lưới ngay.
                LamMoiONhap(); // Xóa ô + Enable/Disable lại mặc định.
            }
        }

        // Nút Sửa
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TheLoaiSach tl = new TheLoaiSach
            {
                MaTL = maTL,
                TenTheLoai = txtTenTheLoai.Text,
                MoTa = txtMoTa.Text
            };

            var (ok, thongBao) = await _bul.SuaAsync(tl);
            MessageBox.Show(thongBao, "Thông báo",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (ok)
            {
                LoadDanhSach(); // Refresh lưới ngay.
                LamMoiONhap(); // Về trạng thái mặc định.
            }
        }

        // Nút Xóa — hỏi Yes/No
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có chắc muốn xóa thể loại này?", "Chú ý",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (hoi != DialogResult.Yes)
                return;

            var (ok, thongBao) = await _bul.XoaAsync(maTL);
            MessageBox.Show(thongBao, "Thông báo",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok)
            {
                LoadDanhSach();
                LamMoiONhap(); // Về trạng thái mặc định.
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiONhap(); // Xóa ô + Enable Thêm, Disable Sửa/Xóa.
            LoadDanhSach();
            txtTimKiem.Clear();
        }

        // Nút Tìm kiếm — LINQ Where + Contains
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSach(_bul.TimKiem(txtTimKiem.Text));
            LamMoiONhap(); // Tìm xong về trạng thái mặc định.
        }
    }
}
