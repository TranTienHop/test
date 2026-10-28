namespace GUI
{
    partial class FormQuanLyTheLoai
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaTL = new Label();
            txtMaTL = new TextBox();
            lblTenTheLoai = new Label();
            txtTenTheLoai = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            lblNgayTao = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvTheLoai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new Point(20, 20);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(75, 15);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại";
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(120, 17);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.PlaceholderText = "ReadOnly";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(220, 23);
            txtMaTL.TabIndex = 1;
            // 
            // lblTenTheLoai
            // 
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Location = new Point(20, 55);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(80, 15);
            lblTenTheLoai.TabIndex = 2;
            lblTenTheLoai.Text = "Tên thể loại";
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(120, 52);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(220, 23);
            txtTenTheLoai.TabIndex = 3;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 90);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(37, 15);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(120, 87);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(220, 60);
            txtMoTa.TabIndex = 5;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(120, 155);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(90, 15);
            lblNgayTao.TabIndex = 6;
            lblNgayTao.Text = "Ngày tạo: —";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(380, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 30);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(480, 17);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 30);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(580, 17);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 30);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(680, 17);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 30);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(20, 190);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại...";
            txtTimKiem.Size = new Size(320, 23);
            txtTimKiem.TabIndex = 11;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(350, 188);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 27);
            btnTimKiem.TabIndex = 12;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new Point(20, 230);
            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowTemplate.Height = 25;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.Size = new Size(750, 260);
            dgvTheLoai.TabIndex = 13;
            dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
            // 
            // FormQuanLyTheLoai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(dgvTheLoai);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblNgayTao);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblTenTheLoai);
            Controls.Add(txtMaTL);
            Controls.Add(lblMaTL);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormQuanLyTheLoai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            Load += FormQuanLyTheLoai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private TextBox txtMaTL;
        private Label lblTenTheLoai;
        private TextBox txtTenTheLoai;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Label lblNgayTao;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvTheLoai;
    }
}
