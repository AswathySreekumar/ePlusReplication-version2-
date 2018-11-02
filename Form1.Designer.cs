namespace ePlusReplication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgview = new System.Windows.Forms.DataGridView();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastReplication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FetchedQuery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerifiedQuery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppliedQuery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextReplication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.btnError = new System.Windows.Forms.Button();
            this.updTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.SuspendLayout();
            // 
            // dgview
            // 
            this.dgview.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Branch,
            this.LastReplication,
            this.FetchedQuery,
            this.VerifiedQuery,
            this.AppliedQuery,
            this.NextReplication,
            this.Status,
            this.button});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgview.GridColor = System.Drawing.Color.DarkGray;
            this.dgview.Location = new System.Drawing.Point(3, 6);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.ShowEditingIcon = false;
            this.dgview.Size = new System.Drawing.Size(919, 124);
            this.dgview.TabIndex = 0;
            this.dgview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgview_CellMouseClick);
            this.dgview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgview_DataBindingComplete);
            this.dgview.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgview_DefaultValuesNeeded);
            this.dgview.BindingContextChanged += new System.EventHandler(this.Form1_Load);
            // 
            // Branch
            // 
            this.Branch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Branch.DataPropertyName = "Branch";
            this.Branch.HeaderText = "Branch";
            this.Branch.MinimumWidth = 20;
            this.Branch.Name = "Branch";
            // 
            // LastReplication
            // 
            this.LastReplication.DataPropertyName = "LastReplication";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.LastReplication.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastReplication.HeaderText = "Last Replication";
            this.LastReplication.Name = "LastReplication";
            this.LastReplication.Width = 120;
            // 
            // FetchedQuery
            // 
            this.FetchedQuery.DataPropertyName = "FETCHEDQUERY";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.FetchedQuery.DefaultCellStyle = dataGridViewCellStyle2;
            this.FetchedQuery.HeaderText = "Fetched Query";
            this.FetchedQuery.Name = "FetchedQuery";
            this.FetchedQuery.Width = 140;
            // 
            // VerifiedQuery
            // 
            this.VerifiedQuery.DataPropertyName = "VERIFIEDQUERY";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.VerifiedQuery.DefaultCellStyle = dataGridViewCellStyle3;
            this.VerifiedQuery.HeaderText = "Pending for Verification";
            this.VerifiedQuery.Name = "VerifiedQuery";
            this.VerifiedQuery.Width = 140;
            // 
            // AppliedQuery
            // 
            this.AppliedQuery.DataPropertyName = "APPLIEDQUERY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = null;
            this.AppliedQuery.DefaultCellStyle = dataGridViewCellStyle4;
            this.AppliedQuery.HeaderText = "Pending for Updation";
            this.AppliedQuery.Name = "AppliedQuery";
            this.AppliedQuery.Width = 140;
            // 
            // NextReplication
            // 
            this.NextReplication.DataPropertyName = "NextReplication";
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = null;
            this.NextReplication.DefaultCellStyle = dataGridViewCellStyle5;
            this.NextReplication.HeaderText = "NextReplication";
            this.NextReplication.Name = "NextReplication";
            this.NextReplication.Width = 120;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            dataGridViewCellStyle6.NullValue = null;
            this.Status.DefaultCellStyle = dataGridViewCellStyle6;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // button
            // 
            this.button.HeaderText = "";
            this.button.Name = "button";
            this.button.Width = 25;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtStatus.Location = new System.Drawing.Point(3, 136);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(463, 310);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.UseWaitCursor = true;
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.SystemColors.Window;
            this.txtDetails.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtDetails.Location = new System.Drawing.Point(472, 136);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.Size = new System.Drawing.Size(450, 310);
            this.txtDetails.TabIndex = 4;
            this.txtDetails.UseWaitCursor = true;
            // 
            // btnError
            // 
            this.btnError.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnError.Enabled = false;
            this.btnError.Font = new System.Drawing.Font("Rockwell Extra Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnError.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnError.Location = new System.Drawing.Point(896, 29);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(26, 20);
            this.btnError.TabIndex = 8;
            this.btnError.Text = ":";
            this.btnError.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnError.UseVisualStyleBackColor = false;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // updTimer
            // 
            this.updTimer.Enabled = true;
            this.updTimer.Interval = 30000;
            this.updTimer.Tick += new System.EventHandler(this.updTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ePlus";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(924, 448);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.dgview);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "ePlus Replication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgview;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Timer updTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastReplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn FetchedQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn VerifiedQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppliedQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextReplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn button;
    }
}