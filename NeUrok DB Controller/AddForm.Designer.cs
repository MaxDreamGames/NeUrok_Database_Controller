﻿namespace NeUrok_DB_Controller
{
    partial class AddForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.IdText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.mouText = new System.Windows.Forms.ComboBox();
            this.commentsText = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.ComboBox();
            this.dopTelText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.telText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FIO2Text = new System.Windows.Forms.ComboBox();
            this.coursesText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.classText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yearText = new System.Windows.Forms.TextBox();
            this.monthText = new System.Windows.Forms.TextBox();
            this.dayText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FIOComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.minMaxButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.addButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(828, 218);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 32);
            this.addButton.TabIndex = 48;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(177, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 26);
            this.label11.TabIndex = 90;
            this.label11.Text = "ID";
            // 
            // IdText
            // 
            this.IdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdText.Location = new System.Drawing.Point(167, 47);
            this.IdText.Name = "IdText";
            this.IdText.Size = new System.Drawing.Size(53, 29);
            this.IdText.TabIndex = 62;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 257);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1148, 376);
            this.dataGridView1.TabIndex = 91;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(249, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 26);
            this.label10.TabIndex = 113;
            this.label10.Text = "Месяцы";
            // 
            // mouText
            // 
            this.mouText.AutoCompleteCustomSource.AddRange(new string[] {
            "Июнь",
            "Июль",
            "Август",
            "Июнь, июль",
            "Июнь, август",
            "Июль, август",
            "Июнь, июль, август"});
            this.mouText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.mouText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.mouText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mouText.FormattingEnabled = true;
            this.mouText.Items.AddRange(new object[] {
            "Июнь",
            "Июль",
            "Август",
            "Июнь, июль",
            "Июнь, август",
            "Июль, август",
            "Июнь, июль, август"});
            this.mouText.Location = new System.Drawing.Point(249, 155);
            this.mouText.Name = "mouText";
            this.mouText.Size = new System.Drawing.Size(115, 32);
            this.mouText.TabIndex = 112;
            // 
            // commentsText
            // 
            this.commentsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.commentsText.Location = new System.Drawing.Point(384, 156);
            this.commentsText.Name = "commentsText";
            this.commentsText.Size = new System.Drawing.Size(216, 95);
            this.commentsText.TabIndex = 111;
            this.commentsText.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(383, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 26);
            this.label9.TabIndex = 110;
            this.label9.Text = "Коментарии";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(265, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 26);
            this.label8.TabIndex = 109;
            this.label8.Text = "Время";
            // 
            // timeText
            // 
            this.timeText.AutoCompleteCustomSource.AddRange(new string[] {
            "Утро",
            "Вечер",
            "Утро, вечер"});
            this.timeText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.timeText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.timeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeText.FormattingEnabled = true;
            this.timeText.Items.AddRange(new object[] {
            "Утро",
            "Вечер",
            "Утро, вечер"});
            this.timeText.Location = new System.Drawing.Point(251, 218);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(113, 32);
            this.timeText.TabIndex = 108;
            // 
            // dopTelText
            // 
            this.dopTelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dopTelText.Location = new System.Drawing.Point(14, 218);
            this.dopTelText.Name = "dopTelText";
            this.dopTelText.Size = new System.Drawing.Size(217, 29);
            this.dopTelText.TabIndex = 107;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 26);
            this.label7.TabIndex = 106;
            this.label7.Text = "Дополнительный телефон";
            // 
            // telText
            // 
            this.telText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.telText.Location = new System.Drawing.Point(13, 156);
            this.telText.Name = "telText";
            this.telText.Size = new System.Drawing.Size(217, 29);
            this.telText.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 26);
            this.label6.TabIndex = 104;
            this.label6.Text = "Телефон";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(520, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 26);
            this.label5.TabIndex = 103;
            this.label5.Text = "ФИО родителя";
            // 
            // FIO2Text
            // 
            this.FIO2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIO2Text.FormattingEnabled = true;
            this.FIO2Text.Location = new System.Drawing.Point(524, 101);
            this.FIO2Text.Name = "FIO2Text";
            this.FIO2Text.Size = new System.Drawing.Size(267, 32);
            this.FIO2Text.TabIndex = 102;
            // 
            // coursesText
            // 
            this.coursesText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.coursesText.Location = new System.Drawing.Point(606, 154);
            this.coursesText.Name = "coursesText";
            this.coursesText.Size = new System.Drawing.Size(216, 96);
            this.coursesText.TabIndex = 101;
            this.coursesText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(607, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 26);
            this.label4.TabIndex = 100;
            this.label4.Text = "Направления";
            // 
            // classText
            // 
            this.classText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.classText.Location = new System.Drawing.Point(456, 97);
            this.classText.Name = "classText";
            this.classText.Size = new System.Drawing.Size(31, 29);
            this.classText.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(452, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 26);
            this.label3.TabIndex = 98;
            this.label3.Text = "Класс";
            // 
            // yearText
            // 
            this.yearText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearText.Location = new System.Drawing.Point(303, 98);
            this.yearText.Name = "yearText";
            this.yearText.Size = new System.Drawing.Size(61, 29);
            this.yearText.TabIndex = 97;
            // 
            // monthText
            // 
            this.monthText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthText.Location = new System.Drawing.Point(370, 97);
            this.monthText.Name = "monthText";
            this.monthText.Size = new System.Drawing.Size(30, 29);
            this.monthText.TabIndex = 96;
            // 
            // dayText
            // 
            this.dayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayText.Location = new System.Drawing.Point(406, 97);
            this.dayText.Name = "dayText";
            this.dayText.Size = new System.Drawing.Size(30, 29);
            this.dayText.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(297, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 26);
            this.label2.TabIndex = 94;
            this.label2.Text = "Дата рождения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 26);
            this.label1.TabIndex = 93;
            this.label1.Text = "ФИО ученика";
            // 
            // FIOComboBox
            // 
            this.FIOComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIOComboBox.FormattingEnabled = true;
            this.FIOComboBox.Location = new System.Drawing.Point(10, 97);
            this.FIOComboBox.Name = "FIOComboBox";
            this.FIOComboBox.Size = new System.Drawing.Size(277, 32);
            this.FIOComboBox.TabIndex = 92;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(4, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 43);
            this.button1.TabIndex = 114;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // minMaxButton
            // 
            this.minMaxButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(127)))));
            this.minMaxButton.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.minMaxButton.Location = new System.Drawing.Point(1107, 20);
            this.minMaxButton.Name = "minMaxButton";
            this.minMaxButton.Size = new System.Drawing.Size(65, 32);
            this.minMaxButton.TabIndex = 115;
            this.minMaxButton.Text = "Min/Max";
            this.minMaxButton.UseVisualStyleBackColor = false;
            this.minMaxButton.Click += new System.EventHandler(this.minMaxButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.minMaxButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mouText);
            this.Controls.Add(this.commentsText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.dopTelText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.telText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FIO2Text);
            this.Controls.Add(this.coursesText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.classText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearText);
            this.Controls.Add(this.monthText);
            this.Controls.Add(this.dayText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FIOComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.IdText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.addButton);
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox IdText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox mouText;
        private System.Windows.Forms.RichTextBox commentsText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox timeText;
        private System.Windows.Forms.TextBox dopTelText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox telText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox FIO2Text;
        private System.Windows.Forms.RichTextBox coursesText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox classText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yearText;
        private System.Windows.Forms.TextBox monthText;
        private System.Windows.Forms.TextBox dayText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FIOComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button minMaxButton;
    }
}