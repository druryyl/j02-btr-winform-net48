namespace btr.winform48
{
    partial class SalesPersonForm
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
            this.ListGrid = new System.Windows.Forms.DataGridView();
            this.SalesPersonNameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SalesPersonIdLabel = new System.Windows.Forms.Label();
            this.SalesPersonIdTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // ListGrid
            // 
            this.ListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListGrid.Location = new System.Drawing.Point(12, 12);
            this.ListGrid.Name = "ListGrid";
            this.ListGrid.Size = new System.Drawing.Size(201, 244);
            this.ListGrid.TabIndex = 0;
            // 
            // SalesPersonNameLabel
            // 
            this.SalesPersonNameLabel.AutoSize = true;
            this.SalesPersonNameLabel.Location = new System.Drawing.Point(9, 50);
            this.SalesPersonNameLabel.Name = "SalesPersonNameLabel";
            this.SalesPersonNameLabel.Size = new System.Drawing.Size(36, 13);
            this.SalesPersonNameLabel.TabIndex = 2;
            this.SalesPersonNameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 66);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(237, 22);
            this.NameTextBox.TabIndex = 3;
            // 
            // SalesPersonIdLabel
            // 
            this.SalesPersonIdLabel.AutoSize = true;
            this.SalesPersonIdLabel.Location = new System.Drawing.Point(9, 9);
            this.SalesPersonIdLabel.Name = "SalesPersonIdLabel";
            this.SalesPersonIdLabel.Size = new System.Drawing.Size(85, 13);
            this.SalesPersonIdLabel.TabIndex = 1;
            this.SalesPersonIdLabel.Text = "Sales Person ID";
            // 
            // SalesPersonIdTextBox
            // 
            this.SalesPersonIdTextBox.Location = new System.Drawing.Point(12, 25);
            this.SalesPersonIdTextBox.Name = "SalesPersonIdTextBox";
            this.SalesPersonIdTextBox.ReadOnly = true;
            this.SalesPersonIdTextBox.Size = new System.Drawing.Size(237, 22);
            this.SalesPersonIdTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SalesPersonIdLabel);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.SalesPersonIdTextBox);
            this.panel1.Controls.Add(this.SalesPersonNameLabel);
            this.panel1.Location = new System.Drawing.Point(219, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 244);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(407, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SalesPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ListGrid);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SalesPersonForm";
            this.Text = "Sales Person";
            ((System.ComponentModel.ISupportInitialize)(this.ListGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ListGrid;
        private System.Windows.Forms.BindingSource ListBinding;
        private System.Windows.Forms.Label SalesPersonNameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label SalesPersonIdLabel;
        private System.Windows.Forms.TextBox SalesPersonIdTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

