
namespace TallerCarroceria {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation2 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation3 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation1 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation4 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuTransition1 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.bunifuPanel4 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuPanel3 = new Bunifu.UI.WinForms.BunifuPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuTileButton2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuTransition2 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.bunifuTransition3 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.bunifuTransition4 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.login1 = new TallerCarroceria.Login();
            this.vehiculos1 = new TallerCarroceria.Vehiculos();
            this.clientesVista1 = new TallerCarroceria.ClientesVista();
            this.home1 = new TallerCarroceria.Home();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuPanel4.SuspendLayout();
            this.bunifuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.HorizSlide;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            // 
            // bunifuPanel4
            // 
            this.bunifuPanel4.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel4.BackgroundImage")));
            this.bunifuPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel4.BorderRadius = 3;
            this.bunifuPanel4.BorderThickness = 1;
            this.bunifuPanel4.Controls.Add(this.login1);
            this.bunifuPanel4.Controls.Add(this.vehiculos1);
            this.bunifuPanel4.Controls.Add(this.clientesVista1);
            this.bunifuPanel4.Controls.Add(this.home1);
            this.bunifuTransition4.SetDecoration(this.bunifuPanel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuPanel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPanel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuPanel4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuPanel4.Location = new System.Drawing.Point(149, 60);
            this.bunifuPanel4.Name = "bunifuPanel4";
            this.bunifuPanel4.ShowBorders = true;
            this.bunifuPanel4.Size = new System.Drawing.Size(1051, 310);
            this.bunifuPanel4.TabIndex = 4;
            // 
            // bunifuPanel3
            // 
            this.bunifuPanel3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.bunifuPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel3.BackgroundImage")));
            this.bunifuPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.bunifuPanel3.BorderRadius = 0;
            this.bunifuPanel3.BorderThickness = 0;
            this.bunifuPanel3.Controls.Add(this.pictureBox6);
            this.bunifuPanel3.Controls.Add(this.pictureBox5);
            this.bunifuTransition4.SetDecoration(this.bunifuPanel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuPanel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPanel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuPanel3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuPanel3.Location = new System.Drawing.Point(0, 60);
            this.bunifuPanel3.Name = "bunifuPanel3";
            this.bunifuPanel3.ShowBorders = false;
            this.bunifuPanel3.Size = new System.Drawing.Size(65, 310);
            this.bunifuPanel3.TabIndex = 3;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox6, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(5, 185);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(55, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            this.pictureBox6.MouseEnter += new System.EventHandler(this.mEnter);
            this.pictureBox6.MouseLeave += new System.EventHandler(this.mExit);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox5, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(5, 50);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(55, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            this.pictureBox5.MouseEnter += new System.EventHandler(this.mEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.mExit);
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.bunifuPanel2.BorderRadius = 0;
            this.bunifuPanel2.BorderThickness = 0;
            this.bunifuPanel2.Controls.Add(this.bunifuTileButton2);
            this.bunifuPanel2.Controls.Add(this.bunifuTileButton1);
            this.bunifuTransition4.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuPanel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 60);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = false;
            this.bunifuPanel2.Size = new System.Drawing.Size(150, 310);
            this.bunifuPanel2.TabIndex = 2;
            // 
            // bunifuTileButton2
            // 
            this.bunifuTileButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(13)))), ((int)(((byte)(24)))));
            this.bunifuTileButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuTileButton2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuTileButton2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.bunifuTileButton2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuTileButton2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTileButton2.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton2.Image")));
            this.bunifuTileButton2.ImagePosition = 20;
            this.bunifuTileButton2.ImageZoom = 50;
            this.bunifuTileButton2.LabelPosition = 41;
            this.bunifuTileButton2.LabelText = "Vehiculos";
            this.bunifuTileButton2.Location = new System.Drawing.Point(10, 160);
            this.bunifuTileButton2.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton2.Name = "bunifuTileButton2";
            this.bunifuTileButton2.Size = new System.Drawing.Size(130, 120);
            this.bunifuTileButton2.TabIndex = 1;
            this.bunifuTileButton2.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            // 
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(13)))), ((int)(((byte)(24)))));
            this.bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.bunifuTileButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuTileButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.bunifuTileButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuTileButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTileButton1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton1.Image")));
            this.bunifuTileButton1.ImagePosition = 20;
            this.bunifuTileButton1.ImageZoom = 50;
            this.bunifuTileButton1.LabelPosition = 41;
            this.bunifuTileButton1.LabelText = "Clientes";
            this.bunifuTileButton1.Location = new System.Drawing.Point(10, 20);
            this.bunifuTileButton1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(130, 120);
            this.bunifuTileButton1.TabIndex = 0;
            this.bunifuTileButton1.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 0;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Controls.Add(this.pictureBox4);
            this.bunifuPanel1.Controls.Add(this.pictureBox3);
            this.bunifuPanel1.Controls.Add(this.pictureBox2);
            this.bunifuPanel1.Controls.Add(this.pictureBox1);
            this.bunifuTransition4.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this.bunifuPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = false;
            this.bunifuPanel1.Size = new System.Drawing.Size(1200, 60);
            this.bunifuPanel1.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1080, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(10, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1140, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition3.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(70, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.HorizSlide;
            this.bunifuTransition2.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.bunifuTransition2.DefaultAnimation = animation3;
            // 
            // bunifuTransition3
            // 
            this.bunifuTransition3.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition3.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.bunifuTransition3.DefaultAnimation = animation1;
            // 
            // bunifuTransition4
            // 
            this.bunifuTransition4.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition4.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 1F;
            this.bunifuTransition4.DefaultAnimation = animation4;
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.login1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.login1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.login1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.login1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(1050, 310);
            this.login1.TabIndex = 3;
            // 
            // vehiculos1
            // 
            this.vehiculos1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(211)))), ((int)(((byte)(186)))));
            this.bunifuTransition3.SetDecoration(this.vehiculos1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.vehiculos1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.vehiculos1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.vehiculos1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.vehiculos1.Location = new System.Drawing.Point(0, 0);
            this.vehiculos1.Name = "vehiculos1";
            this.vehiculos1.Size = new System.Drawing.Size(1050, 310);
            this.vehiculos1.TabIndex = 2;
            // 
            // clientesVista1
            // 
            this.clientesVista1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(211)))), ((int)(((byte)(186)))));
            this.bunifuTransition3.SetDecoration(this.clientesVista1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.clientesVista1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.clientesVista1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.clientesVista1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.clientesVista1.Location = new System.Drawing.Point(0, 0);
            this.clientesVista1.Name = "clientesVista1";
            this.clientesVista1.Size = new System.Drawing.Size(1050, 310);
            this.clientesVista1.TabIndex = 1;
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition3.SetDecoration(this.home1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.home1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.home1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this.home1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.home1.Location = new System.Drawing.Point(0, 0);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(1050, 310);
            this.home1.TabIndex = 0;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.bunifuPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(211)))), ((int)(((byte)(186)))));
            this.ClientSize = new System.Drawing.Size(1200, 370);
            this.Controls.Add(this.bunifuPanel4);
            this.Controls.Add(this.bunifuPanel3);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.bunifuTransition2.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition4.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuTransition3.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taller Carroceria";
            this.Load += new System.EventHandler(this.form2_Load);
            this.bunifuPanel4.ResumeLayout(false);
            this.bunifuPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton2;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel3;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel4;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition2;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Home home1;
        private ClientesVista clientesVista1;
        private Vehiculos vehiculos1;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition4;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition3;
        private Login login1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}