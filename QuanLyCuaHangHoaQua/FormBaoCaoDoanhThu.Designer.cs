namespace QuanLyCuaHangHoaQua
{
    partial class FormBaoCaoDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            label2 = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnThongKe = new Button();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 26);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(380, 26);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 1;
            label2.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpTuNgay.Location = new Point(43, 59);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(269, 29);
            dtpTuNgay.TabIndex = 2;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDenNgay.Location = new Point(380, 59);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(269, 29);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongKe.Location = new Point(273, 415);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(147, 53);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Xem thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(43, 100);
            chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(606, 308);
            chartDoanhThu.TabIndex = 5;
            chartDoanhThu.Text = "chart1";
            // 
            // FormBaoCaoDoanhThu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 480);
            Controls.Add(chartDoanhThu);
            Controls.Add(btnThongKe);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormBaoCaoDoanhThu";
            Text = "FormBaoCaoDoanhThu";
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}