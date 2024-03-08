namespace GalleNewApp
{
    partial class Form1
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            this.lblVisible = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(482, 104);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(113, 37);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 20);
            this.textBox1.TabIndex = 68;
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.BackColor = System.Drawing.Color.Orange;
            this.btnSaveDB.FlatAppearance.BorderSize = 0;
            this.btnSaveDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDB.Location = new System.Drawing.Point(162, 148);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(433, 37);
            this.btnSaveDB.TabIndex = 69;
            this.btnSaveDB.Text = "Save Database";
            this.btnSaveDB.UseVisualStyleBackColor = false;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResult.BackgroundColor = System.Drawing.Color.White;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResult.Location = new System.Drawing.Point(44, 228);
            this.gridResult.Name = "gridResult";
            this.gridResult.RowHeadersVisible = false;
            this.gridResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResult.Size = new System.Drawing.Size(662, 158);
            this.gridResult.TabIndex = 70;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(41, 404);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 71;
            // 
            // lblVisible
            // 
            this.lblVisible.AutoSize = true;
            this.lblVisible.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblVisible.Location = new System.Drawing.Point(218, 201);
            this.lblVisible.Name = "lblVisible";
            this.lblVisible.Size = new System.Drawing.Size(0, 19);
            this.lblVisible.TabIndex = 72;
            this.lblVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(570, 404);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(109, 30);
            this.btnUpdate.TabIndex = 73;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            //this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 458);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblVisible);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.btnSaveDB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblVisible;
        private System.Windows.Forms.Button btnUpdate;
    }
}

