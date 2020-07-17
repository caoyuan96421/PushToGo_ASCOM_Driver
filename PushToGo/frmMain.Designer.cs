using System;

namespace ASCOM.PushToGo
{
    partial class FrmMain
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
            util.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAlt = new System.Windows.Forms.Label();
            this.labelAz = new System.Windows.Forms.Label();
            this.labelDec = new System.Windows.Forms.Label();
            this.labelRa = new System.Windows.Forms.Label();
            this.labelLst = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxPierSideWest = new System.Windows.Forms.PictureBox();
            this.buttonSlewUp = new System.Windows.Forms.Button();
            this.buttonSlewRight = new System.Windows.Forms.Button();
            this.buttonSlewLeft = new System.Windows.Forms.Button();
            this.buttonSlewDown = new System.Windows.Forms.Button();
            this.buttonSlewStop = new System.Windows.Forms.Button();
            this.pictureBoxPierSideEast = new System.Windows.Forms.PictureBox();
            this.ledPierEast = new ASCOM.Controls.LedIndicator();
            this.ledPierWest = new ASCOM.Controls.LedIndicator();
            this.checkBoxTrack = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTraffic = new System.Windows.Forms.Button();
            this.buttonSetup = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonPark = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHOME = new System.Windows.Forms.Label();
            this.lblPARK = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSlew = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonPulseGuide = new System.Windows.Forms.RadioButton();
            this.radioButtonMoveAxis = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPierSideWest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPierSideEast)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "RA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Az";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.8125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.1875F));
            this.tableLayoutPanel1.Controls.Add(this.labelAlt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAz, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelDec, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRa, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLst, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 154);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(174, 154);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelAlt
            // 
            this.labelAlt.AutoSize = true;
            this.labelAlt.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelAlt.ForeColor = System.Drawing.Color.Red;
            this.labelAlt.Location = new System.Drawing.Point(77, 122);
            this.labelAlt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlt.Name = "labelAlt";
            this.labelAlt.Size = new System.Drawing.Size(93, 32);
            this.labelAlt.TabIndex = 9;
            this.labelAlt.Text = "00:00:00:00";
            // 
            // labelAz
            // 
            this.labelAz.AutoSize = true;
            this.labelAz.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelAz.ForeColor = System.Drawing.Color.Red;
            this.labelAz.Location = new System.Drawing.Point(68, 91);
            this.labelAz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAz.Name = "labelAz";
            this.labelAz.Size = new System.Drawing.Size(102, 31);
            this.labelAz.TabIndex = 7;
            this.labelAz.Text = "000:00:00:00";
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelDec.ForeColor = System.Drawing.Color.Red;
            this.labelDec.Location = new System.Drawing.Point(68, 60);
            this.labelDec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(102, 31);
            this.labelDec.TabIndex = 5;
            this.labelDec.Text = "+00:00:00:00";
            // 
            // labelRa
            // 
            this.labelRa.AutoSize = true;
            this.labelRa.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelRa.ForeColor = System.Drawing.Color.Red;
            this.labelRa.Location = new System.Drawing.Point(77, 30);
            this.labelRa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRa.Name = "labelRa";
            this.labelRa.Size = new System.Drawing.Size(93, 30);
            this.labelRa.TabIndex = 3;
            this.labelRa.Text = "00:00:00:00";
            // 
            // labelLst
            // 
            this.labelLst.AutoSize = true;
            this.labelLst.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelLst.ForeColor = System.Drawing.Color.Red;
            this.labelLst.Location = new System.Drawing.Point(77, 0);
            this.labelLst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLst.Name = "labelLst";
            this.labelLst.Size = new System.Drawing.Size(93, 30);
            this.labelLst.TabIndex = 1;
            this.labelLst.Text = "00:00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Alt";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxPierSideWest, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSlewUp, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSlewRight, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSlewLeft, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSlewDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonSlewStop, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxPierSideEast, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ledPierEast, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.ledPierWest, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 385);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 171);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // pictureBoxPierSideWest
            // 
            this.pictureBoxPierSideWest.Location = new System.Drawing.Point(4, 5);
            this.pictureBoxPierSideWest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxPierSideWest.Name = "pictureBoxPierSideWest";
            this.pictureBoxPierSideWest.Size = new System.Drawing.Size(48, 47);
            this.pictureBoxPierSideWest.TabIndex = 6;
            this.pictureBoxPierSideWest.TabStop = false;
            // 
            // buttonSlewUp
            // 
            this.buttonSlewUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSlewUp.Location = new System.Drawing.Point(61, 5);
            this.buttonSlewUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSlewUp.Name = "buttonSlewUp";
            this.buttonSlewUp.Size = new System.Drawing.Size(49, 47);
            this.buttonSlewUp.TabIndex = 0;
            this.buttonSlewUp.Text = "N";
            this.buttonSlewUp.UseVisualStyleBackColor = true;
            this.buttonSlewUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewUp_MouseDown);
            this.buttonSlewUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewUp_MouseUp);
            // 
            // buttonSlewRight
            // 
            this.buttonSlewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSlewRight.Location = new System.Drawing.Point(118, 62);
            this.buttonSlewRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSlewRight.Name = "buttonSlewRight";
            this.buttonSlewRight.Size = new System.Drawing.Size(50, 47);
            this.buttonSlewRight.TabIndex = 3;
            this.buttonSlewRight.Text = "E";
            this.buttonSlewRight.UseVisualStyleBackColor = true;
            this.buttonSlewRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewRight_MouseDown);
            this.buttonSlewRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewRight_MouseUp);
            // 
            // buttonSlewLeft
            // 
            this.buttonSlewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSlewLeft.Location = new System.Drawing.Point(4, 62);
            this.buttonSlewLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSlewLeft.Name = "buttonSlewLeft";
            this.buttonSlewLeft.Size = new System.Drawing.Size(49, 47);
            this.buttonSlewLeft.TabIndex = 1;
            this.buttonSlewLeft.Text = "W";
            this.buttonSlewLeft.UseVisualStyleBackColor = true;
            this.buttonSlewLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewLeft_MouseDown);
            this.buttonSlewLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewLeft_MouseUp);
            // 
            // buttonSlewDown
            // 
            this.buttonSlewDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSlewDown.Location = new System.Drawing.Point(61, 119);
            this.buttonSlewDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSlewDown.Name = "buttonSlewDown";
            this.buttonSlewDown.Size = new System.Drawing.Size(49, 47);
            this.buttonSlewDown.TabIndex = 4;
            this.buttonSlewDown.Text = "S";
            this.buttonSlewDown.UseVisualStyleBackColor = true;
            this.buttonSlewDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewDown_MouseDown);
            this.buttonSlewDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonSlewDown_MouseUp);
            // 
            // buttonSlewStop
            // 
            this.buttonSlewStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSlewStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSlewStop.Location = new System.Drawing.Point(61, 62);
            this.buttonSlewStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSlewStop.Name = "buttonSlewStop";
            this.buttonSlewStop.Size = new System.Drawing.Size(49, 47);
            this.buttonSlewStop.TabIndex = 2;
            this.buttonSlewStop.Text = "STOP";
            this.buttonSlewStop.UseVisualStyleBackColor = true;
            this.buttonSlewStop.Click += new System.EventHandler(this.ButtonSlewStop_Click);
            // 
            // pictureBoxPierSideEast
            // 
            this.pictureBoxPierSideEast.Location = new System.Drawing.Point(118, 5);
            this.pictureBoxPierSideEast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxPierSideEast.Name = "pictureBoxPierSideEast";
            this.pictureBoxPierSideEast.Size = new System.Drawing.Size(50, 47);
            this.pictureBoxPierSideEast.TabIndex = 5;
            this.pictureBoxPierSideEast.TabStop = false;
            // 
            // ledPierEast
            // 
            this.ledPierEast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ledPierEast.LabelText = "";
            this.ledPierEast.Location = new System.Drawing.Point(130, 130);
            this.ledPierEast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledPierEast.Name = "ledPierEast";
            this.ledPierEast.Size = new System.Drawing.Size(26, 25);
            this.ledPierEast.TabIndex = 6;
            this.ledPierEast.TabStop = false;
            this.toolTip1.SetToolTip(this.ledPierEast, "Normal pointing state, scope on East side of Pier, looking West");
            // 
            // ledPierWest
            // 
            this.ledPierWest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ledPierWest.LabelText = "";
            this.ledPierWest.Location = new System.Drawing.Point(16, 130);
            this.ledPierWest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledPierWest.Name = "ledPierWest";
            this.ledPierWest.Size = new System.Drawing.Size(24, 25);
            this.ledPierWest.TabIndex = 5;
            this.ledPierWest.TabStop = false;
            this.toolTip1.SetToolTip(this.ledPierWest, "Through the pole pointing State, scope on West Side of Pier, looking East");
            // 
            // checkBoxTrack
            // 
            this.checkBoxTrack.AutoSize = true;
            this.checkBoxTrack.ForeColor = System.Drawing.Color.White;
            this.checkBoxTrack.Location = new System.Drawing.Point(26, 565);
            this.checkBoxTrack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxTrack.Name = "checkBoxTrack";
            this.checkBoxTrack.Size = new System.Drawing.Size(74, 24);
            this.checkBoxTrack.TabIndex = 4;
            this.checkBoxTrack.Text = "Track";
            this.checkBoxTrack.UseVisualStyleBackColor = true;
            this.checkBoxTrack.CheckedChanged += new System.EventHandler(this.CheckBoxTrack_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonTraffic, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonSetup, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonConnect, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonPark, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 600);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(198, 100);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // buttonTraffic
            // 
            this.buttonTraffic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTraffic.Location = new System.Drawing.Point(103, 55);
            this.buttonTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTraffic.Name = "buttonTraffic";
            this.buttonTraffic.Size = new System.Drawing.Size(91, 40);
            this.buttonTraffic.TabIndex = 3;
            this.buttonTraffic.Text = "Traffic";
            this.buttonTraffic.UseVisualStyleBackColor = true;
            this.buttonTraffic.Click += new System.EventHandler(this.ButtonTraffic_Click);
            // 
            // buttonSetup
            // 
            this.buttonSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetup.Location = new System.Drawing.Point(4, 55);
            this.buttonSetup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSetup.Name = "buttonSetup";
            this.buttonSetup.Size = new System.Drawing.Size(91, 40);
            this.buttonSetup.TabIndex = 2;
            this.buttonSetup.Text = "Setup";
            this.buttonSetup.UseVisualStyleBackColor = true;
            this.buttonSetup.Click += new System.EventHandler(this.ButtonSetup_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnect.Location = new System.Drawing.Point(103, 5);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(91, 40);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // buttonPark
            // 
            this.buttonPark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPark.Location = new System.Drawing.Point(4, 5);
            this.buttonPark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPark.Name = "buttonPark";
            this.buttonPark.Size = new System.Drawing.Size(91, 40);
            this.buttonPark.TabIndex = 0;
            this.buttonPark.Text = "Park";
            this.buttonPark.UseVisualStyleBackColor = true;
            this.buttonPark.Click += new System.EventHandler(this.ButtonPark_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.lblHOME, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblPARK, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(18, 114);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(172, 31);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblHOME
            // 
            this.lblHOME.AutoSize = true;
            this.lblHOME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHOME.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHOME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHOME.Location = new System.Drawing.Point(4, 0);
            this.lblHOME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHOME.Name = "lblHOME";
            this.lblHOME.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.lblHOME.Size = new System.Drawing.Size(61, 31);
            this.lblHOME.TabIndex = 0;
            this.lblHOME.Text = "HOME";
            this.toolTip1.SetToolTip(this.lblHOME, "Scope is at the home position");
            // 
            // lblPARK
            // 
            this.lblPARK.AutoSize = true;
            this.lblPARK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPARK.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPARK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPARK.Location = new System.Drawing.Point(112, 0);
            this.lblPARK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPARK.Name = "lblPARK";
            this.lblPARK.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.lblPARK.Size = new System.Drawing.Size(56, 31);
            this.lblPARK.TabIndex = 1;
            this.lblPARK.Text = "PARK";
            this.toolTip1.SetToolTip(this.lblPARK, "Scope is parked");
            // 
            // picASCOM
            // 
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.PushToGo.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(118, 15);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 4;
            this.picASCOM.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.labelSlew, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(117, 560);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(74, 31);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // labelSlew
            // 
            this.labelSlew.AutoSize = true;
            this.labelSlew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSlew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSlew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSlew.Location = new System.Drawing.Point(4, 0);
            this.labelSlew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSlew.Name = "labelSlew";
            this.labelSlew.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.labelSlew.Size = new System.Drawing.Size(66, 31);
            this.labelSlew.TabIndex = 0;
            this.labelSlew.Text = "SLEW";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.radioButtonPulseGuide, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.radioButtonMoveAxis, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(18, 312);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(172, 66);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // radioButtonPulseGuide
            // 
            this.radioButtonPulseGuide.AutoSize = true;
            this.radioButtonPulseGuide.ForeColor = System.Drawing.Color.White;
            this.radioButtonPulseGuide.Location = new System.Drawing.Point(4, 38);
            this.radioButtonPulseGuide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonPulseGuide.Name = "radioButtonPulseGuide";
            this.radioButtonPulseGuide.Size = new System.Drawing.Size(120, 23);
            this.radioButtonPulseGuide.TabIndex = 1;
            this.radioButtonPulseGuide.Text = "Pulse Guide";
            this.radioButtonPulseGuide.UseVisualStyleBackColor = true;
            // 
            // radioButtonMoveAxis
            // 
            this.radioButtonMoveAxis.AutoSize = true;
            this.radioButtonMoveAxis.Checked = true;
            this.radioButtonMoveAxis.ForeColor = System.Drawing.Color.White;
            this.radioButtonMoveAxis.Location = new System.Drawing.Point(4, 5);
            this.radioButtonMoveAxis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonMoveAxis.Name = "radioButtonMoveAxis";
            this.radioButtonMoveAxis.Size = new System.Drawing.Size(105, 23);
            this.radioButtonMoveAxis.TabIndex = 0;
            this.radioButtonMoveAxis.TabStop = true;
            this.radioButtonMoveAxis.Text = "Move Axis";
            this.radioButtonMoveAxis.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "V0.1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(207, 712);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.checkBoxTrack);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.picASCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "PushToGo";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPierSideWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPierSideEast)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLst;
        private System.Windows.Forms.Label labelAlt;
        private System.Windows.Forms.Label labelAz;
        private System.Windows.Forms.Label labelDec;
        private System.Windows.Forms.Label labelRa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSlewUp;
        private System.Windows.Forms.Button buttonSlewRight;
        private System.Windows.Forms.Button buttonSlewLeft;
        private System.Windows.Forms.Button buttonSlewDown;
        private System.Windows.Forms.Button buttonSlewStop;
        private System.Windows.Forms.CheckBox checkBoxTrack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonTraffic;
        private System.Windows.Forms.Button buttonSetup;
        private System.Windows.Forms.Button buttonPark;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal System.Windows.Forms.Label lblPARK;
        internal System.Windows.Forms.Label lblHOME;
        private System.Windows.Forms.PictureBox pictureBoxPierSideWest;
        private System.Windows.Forms.PictureBox pictureBoxPierSideEast;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        internal System.Windows.Forms.Label labelSlew;
        private Controls.LedIndicator ledPierEast;
        private Controls.LedIndicator ledPierWest;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.RadioButton radioButtonPulseGuide;
		private System.Windows.Forms.RadioButton radioButtonMoveAxis;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button buttonConnect;
    }
}

