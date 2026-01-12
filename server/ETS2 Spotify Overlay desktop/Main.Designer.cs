namespace ETS2_Spotify_Overlay
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.keyTimeout = new System.Windows.Forms.Timer(this.components);
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.MBCustoms = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameInfo = new System.Windows.Forms.Label();
            this.gameLabel = new System.Windows.Forms.Label();
            this.statusInfo = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.spotifyStatusInfo = new System.Windows.Forms.Label();
            this.spotifyStatusLabel = new System.Windows.Forms.Label();
            this.spotifyTrackInfo = new System.Windows.Forms.Label();
            this.spotifyTrackLabel = new System.Windows.Forms.Label();
            this.spotifyArtistInfo = new System.Windows.Forms.Label();
            this.spotifyArtistLabel = new System.Windows.Forms.Label();
            this.spotifyConnectButton = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.joystickTimer = new System.Windows.Forms.Timer(this.components);
            this.currentGameTimer = new System.Windows.Forms.Timer(this.components);
            this.groupInstall = new System.Windows.Forms.GroupBox();
            this.removePluginButton = new System.Windows.Forms.Button();
            this.installEts2Button = new System.Windows.Forms.Button();
            this.installAtsButton = new System.Windows.Forms.Button();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MBCustoms)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupInstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyTimeout
            // 
            this.keyTimeout.Interval = 10;
            this.keyTimeout.Tick += new System.EventHandler(this.keyTimeout_Tick);
            // 
            // groupInfo
            // 
            this.groupInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInfo.Controls.Add(this.MBCustoms);
            this.groupInfo.Controls.Add(this.tableLayoutPanel1);
            this.groupInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.groupInfo.Location = new System.Drawing.Point(12, 12);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(413, 151);
            this.groupInfo.TabIndex = 5;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Info";
            // 
            // MBCustoms
            // 
            this.MBCustoms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MBCustoms.Image = global::ETS2_Spotify_Overlay.Properties.Resources.MBCustoms;
            this.MBCustoms.Location = new System.Drawing.Point(254, 9);
            this.MBCustoms.Name = "MBCustoms";
            this.MBCustoms.Size = new System.Drawing.Size(156, 48);
            this.MBCustoms.TabIndex = 6;
            this.MBCustoms.TabStop = false;
            this.MBCustoms.Click += new System.EventHandler(this.MBCustoms_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel1.Controls.Add(this.gameInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.spotifyStatusInfo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.spotifyStatusLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.spotifyTrackInfo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.spotifyTrackLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.spotifyArtistInfo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.spotifyArtistLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.spotifyConnectButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 130);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // gameInfo
            // 
            this.gameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gameInfo.Location = new System.Drawing.Point(3, 0);
            this.gameInfo.Name = "gameInfo";
            this.gameInfo.Size = new System.Drawing.Size(94, 17);
            this.gameInfo.TabIndex = 13;
            this.gameInfo.Text = "Game:";
            this.gameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameLabel
            // 
            this.gameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gameLabel.Location = new System.Drawing.Point(103, 0);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(301, 17);
            this.gameLabel.TabIndex = 12;
            this.gameLabel.Text = "Euro Truck Simulator 2";
            this.gameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusInfo
            // 
            this.statusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusInfo.Location = new System.Drawing.Point(3, 17);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(94, 17);
            this.statusInfo.TabIndex = 8;
            this.statusInfo.Text = "Status:";
            this.statusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusLabel.Location = new System.Drawing.Point(103, 17);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(301, 17);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spotifyStatusInfo
            // 
            this.spotifyStatusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyStatusInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyStatusInfo.Location = new System.Drawing.Point(3, 34);
            this.spotifyStatusInfo.Name = "spotifyStatusInfo";
            this.spotifyStatusInfo.Size = new System.Drawing.Size(94, 20);
            this.spotifyStatusInfo.TabIndex = 14;
            this.spotifyStatusInfo.Text = "Spotify:";
            this.spotifyStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spotifyStatusLabel
            // 
            this.spotifyStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyStatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.spotifyStatusLabel.Location = new System.Drawing.Point(103, 34);
            this.spotifyStatusLabel.Name = "spotifyStatusLabel";
            this.spotifyStatusLabel.Size = new System.Drawing.Size(301, 20);
            this.spotifyStatusLabel.TabIndex = 15;
            this.spotifyStatusLabel.Text = "Not Connected";
            this.spotifyStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spotifyTrackInfo
            // 
            this.spotifyTrackInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyTrackInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyTrackInfo.Location = new System.Drawing.Point(3, 54);
            this.spotifyTrackInfo.Name = "spotifyTrackInfo";
            this.spotifyTrackInfo.Size = new System.Drawing.Size(94, 20);
            this.spotifyTrackInfo.TabIndex = 16;
            this.spotifyTrackInfo.Text = "Track:";
            this.spotifyTrackInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spotifyTrackLabel
            // 
            this.spotifyTrackLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyTrackLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyTrackLabel.Location = new System.Drawing.Point(103, 54);
            this.spotifyTrackLabel.Name = "spotifyTrackLabel";
            this.spotifyTrackLabel.Size = new System.Drawing.Size(301, 20);
            this.spotifyTrackLabel.TabIndex = 17;
            this.spotifyTrackLabel.Text = "-";
            this.spotifyTrackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spotifyArtistInfo
            // 
            this.spotifyArtistInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyArtistInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyArtistInfo.Location = new System.Drawing.Point(3, 74);
            this.spotifyArtistInfo.Name = "spotifyArtistInfo";
            this.spotifyArtistInfo.Size = new System.Drawing.Size(94, 20);
            this.spotifyArtistInfo.TabIndex = 18;
            this.spotifyArtistInfo.Text = "Artist:";
            this.spotifyArtistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spotifyArtistLabel
            // 
            this.spotifyArtistLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyArtistLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyArtistLabel.Location = new System.Drawing.Point(103, 74);
            this.spotifyArtistLabel.Name = "spotifyArtistLabel";
            this.spotifyArtistLabel.Size = new System.Drawing.Size(301, 20);
            this.spotifyArtistLabel.TabIndex = 19;
            this.spotifyArtistLabel.Text = "-";
            this.spotifyArtistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spotifyConnectButton
            // 
            this.spotifyConnectButton.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.spotifyConnectButton, 2);
            this.spotifyConnectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyConnectButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.spotifyConnectButton.Location = new System.Drawing.Point(3, 97);
            this.spotifyConnectButton.Name = "spotifyConnectButton";
            this.spotifyConnectButton.Size = new System.Drawing.Size(401, 30);
            this.spotifyConnectButton.TabIndex = 22;
            this.spotifyConnectButton.Text = "Connect to Spotify";
            this.spotifyConnectButton.UseVisualStyleBackColor = false;
            this.spotifyConnectButton.Click += new System.EventHandler(this.spotifyConnectButton_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Please select the Euro Truck Simulator 2 installation folder, usually found in C:" +
    "\\Program Files (x86)\\Steam\\SteamApps\\common\\Euro Truck Simulator 2";
            this.folderDialog.ShowNewFolderButton = false;
            this.folderDialog.HelpRequest += new System.EventHandler(this.folderDialog_HelpRequest);
            // 
            // joystickTimer
            // 
            this.joystickTimer.Interval = 10;
            // 
            // currentGameTimer
            // 
            this.currentGameTimer.Interval = 3000;
            this.currentGameTimer.Tick += new System.EventHandler(this.currentGameTimer_Tick);
            // 
            // groupInstall
            // 
            this.groupInstall.Controls.Add(this.removePluginButton);
            this.groupInstall.Controls.Add(this.installEts2Button);
            this.groupInstall.Controls.Add(this.installAtsButton);
            this.groupInstall.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupInstall.ForeColor = System.Drawing.Color.LimeGreen;
            this.groupInstall.Location = new System.Drawing.Point(12, 166);
            this.groupInstall.Name = "groupInstall";
            this.groupInstall.Size = new System.Drawing.Size(413, 103);
            this.groupInstall.TabIndex = 9;
            this.groupInstall.TabStop = false;
            this.groupInstall.Text = "Install plugin";
            // 
            // removePluginButton
            // 
            this.removePluginButton.AutoSize = true;
            this.removePluginButton.Location = new System.Drawing.Point(10, 72);
            this.removePluginButton.Name = "removePluginButton";
            this.removePluginButton.Size = new System.Drawing.Size(393, 23);
            this.removePluginButton.TabIndex = 1;
            this.removePluginButton.Text = "Remove plugin";
            this.removePluginButton.Click += new System.EventHandler(this.removePluginButton_Click);
            // 
            // installEts2Button
            // 
            this.installEts2Button.BackColor = System.Drawing.Color.Black;
            this.installEts2Button.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.installEts2Button.ForeColor = System.Drawing.Color.LimeGreen;
            this.installEts2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.installEts2Button.Location = new System.Drawing.Point(213, 23);
            this.installEts2Button.Name = "installEts2Button";
            this.installEts2Button.Size = new System.Drawing.Size(190, 44);
            this.installEts2Button.TabIndex = 1;
            this.installEts2Button.Text = "Install plugin for \r\nEuro Truck Simulator 2";
            this.installEts2Button.UseVisualStyleBackColor = false;
            this.installEts2Button.Click += new System.EventHandler(this.installEts2Button_Click);
            // 
            // installAtsButton
            // 
            this.installAtsButton.BackColor = System.Drawing.Color.Black;
            this.installAtsButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.installAtsButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.installAtsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.installAtsButton.Location = new System.Drawing.Point(10, 23);
            this.installAtsButton.Name = "installAtsButton";
            this.installAtsButton.Size = new System.Drawing.Size(190, 44);
            this.installAtsButton.TabIndex = 0;
            this.installAtsButton.Text = "Install plugin for \r\nAmerican Truck Simulator";
            this.installAtsButton.UseVisualStyleBackColor = false;
            this.installAtsButton.Click += new System.EventHandler(this.installAtsButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(437, 279);
            this.Controls.Add(this.groupInstall);
            this.Controls.Add(this.groupInfo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "ETS2/ATS Spotify Overlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MBCustoms)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupInstall.ResumeLayout(false);
            this.groupInstall.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer keyTimeout;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.LinkLabel URLLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusInfo;
        private System.Windows.Forms.PictureBox MBCustoms;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Timer joystickTimer;
        private System.Windows.Forms.Timer currentGameTimer;
        private System.Windows.Forms.Label gameInfo;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.GroupBox groupInstall;
        private System.Windows.Forms.Button installEts2Button;
        private System.Windows.Forms.Button installAtsButton;
        private System.Windows.Forms.Button removePluginButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label spotifyStatusInfo;
        private System.Windows.Forms.Label spotifyStatusLabel;
        private System.Windows.Forms.Label spotifyTrackInfo;
        private System.Windows.Forms.Label spotifyTrackLabel;
        private System.Windows.Forms.Label spotifyArtistInfo;
        private System.Windows.Forms.Label spotifyArtistLabel;
        private System.Windows.Forms.Button spotifyConnectButton;
    }
}