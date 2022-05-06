namespace AbstractShipyardView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelWT = new System.Windows.Forms.Label();
            this.textBoxWT = new System.Windows.Forms.TextBox();
            this.labelPT = new System.Windows.Forms.Label();
            this.textBoxPT = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(33, 44);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(112, 15);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО исполнителя:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(185, 41);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(222, 23);
            this.textBoxFIO.TabIndex = 1;
            // 
            // labelWT
            // 
            this.labelWT.AutoSize = true;
            this.labelWT.Location = new System.Drawing.Point(33, 90);
            this.labelWT.Name = "labelWT";
            this.labelWT.Size = new System.Drawing.Size(89, 15);
            this.labelWT.TabIndex = 2;
            this.labelWT.Text = "Время работы:";
            // 
            // textBoxWT
            // 
            this.textBoxWT.Location = new System.Drawing.Point(185, 87);
            this.textBoxWT.Name = "textBoxWT";
            this.textBoxWT.Size = new System.Drawing.Size(222, 23);
            this.textBoxWT.TabIndex = 3;
            // 
            // labelPT
            // 
            this.labelPT.AutoSize = true;
            this.labelPT.Location = new System.Drawing.Point(33, 133);
            this.labelPT.Name = "labelPT";
            this.labelPT.Size = new System.Drawing.Size(87, 15);
            this.labelPT.TabIndex = 4;
            this.labelPT.Text = "Время отдыха:";
            // 
            // textBoxPT
            // 
            this.textBoxPT.Location = new System.Drawing.Point(185, 130);
            this.textBoxPT.Name = "textBoxPT";
            this.textBoxPT.Size = new System.Drawing.Size(222, 23);
            this.textBoxPT.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(230, 187);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(358, 187);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 237);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPT);
            this.Controls.Add(this.labelPT);
            this.Controls.Add(this.textBoxWT);
            this.Controls.Add(this.labelWT);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelWT;
        private System.Windows.Forms.TextBox textBoxWT;
        private System.Windows.Forms.Label labelPT;
        private System.Windows.Forms.TextBox textBoxPT;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}