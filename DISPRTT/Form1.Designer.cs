﻿namespace DISPRTT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.подключитьсяКСерверуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяКСерверуToolStripMenuItem,
            this.предметыToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.ShowItemToolTips = true;
            this.menuStrip.Size = new System.Drawing.Size(457, 30);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // подключитьсяКСерверуToolStripMenuItem
            // 
            this.подключитьсяКСерверуToolStripMenuItem.Image = global::DISPRTT.Properties.Resources.database;
            this.подключитьсяКСерверуToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.подключитьсяКСерверуToolStripMenuItem.Name = "подключитьсяКСерверуToolStripMenuItem";
            this.подключитьсяКСерверуToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            this.подключитьсяКСерверуToolStripMenuItem.Click += new System.EventHandler(this.ShowConnectToDB);
            // 
            // предметыToolStripMenuItem
            // 
            this.предметыToolStripMenuItem.Enabled = false;
            this.предметыToolStripMenuItem.Image = global::DISPRTT.Properties.Resources.book_bookmark_1;
            this.предметыToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.предметыToolStripMenuItem.Name = "предметыToolStripMenuItem";
            this.предметыToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            this.предметыToolStripMenuItem.Click += new System.EventHandler(this.ShowSubjects);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.Enabled = false;
            this.справочникиToolStripMenuItem.Image = global::DISPRTT.Properties.Resources.paper_clip_2;
            this.справочникиToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            this.справочникиToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(457, 303);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяКСерверуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предметыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
    }
}

