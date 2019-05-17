namespace ArmorSearchForm
{
    partial class ArmorSearchForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.skillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.PlusButton = new System.Windows.Forms.Button();
            this.MinusButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.ASearchButton = new System.Windows.Forms.Button();
            this.QSearchButton = new System.Windows.Forms.Button();
            this.ReturnTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.skillBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.skillBindingSource;
            this.comboBox1.DisplayMember = "SkillName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "SkillID";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // skillBindingSource
            // 
            this.skillBindingSource.DataSource = typeof(ArmorDBModel.Skill);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(222, 157);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(37, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // PlusButton
            // 
            this.PlusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlusButton.Location = new System.Drawing.Point(79, 131);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(24, 22);
            this.PlusButton.TabIndex = 2;
            this.PlusButton.Text = "+";
            this.PlusButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.PlusButton_Click);
            // 
            // MinusButton
            // 
            this.MinusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinusButton.Location = new System.Drawing.Point(107, 131);
            this.MinusButton.Name = "MinusButton";
            this.MinusButton.Size = new System.Drawing.Size(24, 22);
            this.MinusButton.TabIndex = 3;
            this.MinusButton.Text = "-";
            this.MinusButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinusButton.UseVisualStyleBackColor = true;
            this.MinusButton.Click += new System.EventHandler(this.MinusButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(136, 131);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(81, 22);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear All";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CancButton
            // 
            this.CancButton.Location = new System.Drawing.Point(820, 587);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(80, 29);
            this.CancButton.TabIndex = 5;
            this.CancButton.Text = "Cancel";
            this.CancButton.UseVisualStyleBackColor = true;
            // 
            // ASearchButton
            // 
            this.ASearchButton.Location = new System.Drawing.Point(695, 587);
            this.ASearchButton.Name = "ASearchButton";
            this.ASearchButton.Size = new System.Drawing.Size(119, 29);
            this.ASearchButton.TabIndex = 6;
            this.ASearchButton.Text = "Advanced Search";
            this.ASearchButton.UseVisualStyleBackColor = true;
            // 
            // QSearchButton
            // 
            this.QSearchButton.Location = new System.Drawing.Point(570, 587);
            this.QSearchButton.Name = "QSearchButton";
            this.QSearchButton.Size = new System.Drawing.Size(119, 29);
            this.QSearchButton.TabIndex = 7;
            this.QSearchButton.Text = "Quick Search";
            this.QSearchButton.UseVisualStyleBackColor = true;
            this.QSearchButton.Click += new System.EventHandler(this.QSearchButton_Click);
            // 
            // ReturnTextBox
            // 
            this.ReturnTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ReturnTextBox.Location = new System.Drawing.Point(570, 12);
            this.ReturnTextBox.Name = "ReturnTextBox";
            this.ReturnTextBox.ReadOnly = true;
            this.ReturnTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ReturnTextBox.Size = new System.Drawing.Size(330, 569);
            this.ReturnTextBox.TabIndex = 9;
            this.ReturnTextBox.Text = "";
            // 
            // ArmorSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(912, 628);
            this.Controls.Add(this.ReturnTextBox);
            this.Controls.Add(this.QSearchButton);
            this.Controls.Add(this.ASearchButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.MinusButton);
            this.Controls.Add(this.PlusButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "ArmorSearchForm";
            this.Text = "Armor Search Form";
            this.Load += new System.EventHandler(this.ArmorSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skillBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource skillBindingSource;
        private System.Windows.Forms.Button PlusButton;
        private System.Windows.Forms.Button MinusButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button ASearchButton;
        private System.Windows.Forms.Button QSearchButton;
        private System.Windows.Forms.RichTextBox ReturnTextBox;
    }
}

