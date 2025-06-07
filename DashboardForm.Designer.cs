

namespace MasterMic
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            panelSideMenu = new Panel();
            buttonCredits = new Button();
            buttonSoundboard = new Button();
            buttonHome = new Button();
            panelLogo = new Panel();
            logoText = new Label();
            panelContent = new Panel();
            panelSideMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.AutoScroll = true;
            panelSideMenu.BackColor = Color.FromArgb(11, 7, 17);
            panelSideMenu.Controls.Add(buttonCredits);
            panelSideMenu.Controls.Add(buttonSoundboard);
            panelSideMenu.Controls.Add(buttonHome);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(250, 561);
            panelSideMenu.TabIndex = 0;
            // 
            // buttonCredits
            // 
            buttonCredits.Dock = DockStyle.Bottom;
            buttonCredits.FlatAppearance.BorderSize = 0;
            buttonCredits.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 27, 37);
            buttonCredits.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 17, 27);
            buttonCredits.FlatStyle = FlatStyle.Flat;
            buttonCredits.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCredits.ForeColor = Color.Gainsboro;
            buttonCredits.Image = (Image)resources.GetObject("buttonCredits.Image");
            buttonCredits.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCredits.Location = new Point(0, 527);
            buttonCredits.Name = "buttonCredits";
            buttonCredits.Padding = new Padding(10, 0, 0, 0);
            buttonCredits.Size = new Size(250, 34);
            buttonCredits.TabIndex = 3;
            buttonCredits.Text = "Credits";
            buttonCredits.UseVisualStyleBackColor = true;
            buttonCredits.Click += buttonCredits_Click;
            // 
            // buttonSoundboard
            // 
            buttonSoundboard.Dock = DockStyle.Top;
            buttonSoundboard.FlatAppearance.BorderSize = 0;
            buttonSoundboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 27, 37);
            buttonSoundboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 17, 27);
            buttonSoundboard.FlatStyle = FlatStyle.Flat;
            buttonSoundboard.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSoundboard.ForeColor = Color.Gainsboro;
            buttonSoundboard.Image = (Image)resources.GetObject("buttonSoundboard.Image");
            buttonSoundboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSoundboard.Location = new Point(0, 134);
            buttonSoundboard.Name = "buttonSoundboard";
            buttonSoundboard.Padding = new Padding(10, 0, 0, 0);
            buttonSoundboard.Size = new Size(250, 34);
            buttonSoundboard.TabIndex = 2;
            buttonSoundboard.Text = "Soundboard";
            buttonSoundboard.UseVisualStyleBackColor = true;
            buttonSoundboard.Click += buttonSoundboard_Click;
            // 
            // buttonHome
            // 
            buttonHome.Dock = DockStyle.Top;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 27, 37);
            buttonHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 17, 27);
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHome.ForeColor = Color.Gainsboro;
            buttonHome.Image = (Image)resources.GetObject("buttonHome.Image");
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(0, 100);
            buttonHome.Name = "buttonHome";
            buttonHome.Padding = new Padding(10, 0, 0, 0);
            buttonHome.Size = new Size(250, 34);
            buttonHome.TabIndex = 1;
            buttonHome.Text = "Home";
            buttonHome.UseVisualStyleBackColor = true;
            buttonHome.Click += buttonHome_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(8, 4, 14);
            panelLogo.Controls.Add(logoText);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(250, 100);
            panelLogo.TabIndex = 0;
            // 
            // logoText
            // 
            logoText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoText.AutoSize = true;
            logoText.Font = new Font("Monotype Corsiva", 32.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            logoText.ForeColor = Color.Gainsboro;
            logoText.Location = new Point(24, 25);
            logoText.Name = "logoText";
            logoText.Size = new Size(202, 52);
            logoText.TabIndex = 0;
            logoText.Text = "Master Mic";
            logoText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(17, 14, 24);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(250, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(684, 561);
            panelContent.TabIndex = 1;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 561);
            Controls.Add(panelContent);
            Controls.Add(panelSideMenu);
            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "DashboardForm";
            Text = "Master Mic";
            panelSideMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private Button buttonHome;
        private Button buttonSoundboard;
        private Panel panelLogo;
        private Label logoText;
        private Panel panelContent;
        private Button buttonCredits;
    }
}