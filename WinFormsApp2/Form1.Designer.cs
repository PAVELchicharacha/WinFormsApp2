namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ImportData = new Button();
            SaveData = new Button();
            LoadData = new Button();
            dataGridView1 = new DataGridView();
            dataBaseModelBindingSource = new BindingSource(components);
            cardCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            surNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneMobileDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            genderIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            birthdayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pincodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bonusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            turnoverDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataBaseModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ImportData
            // 
            ImportData.Location = new Point(681, 12);
            ImportData.Name = "ImportData";
            ImportData.Size = new Size(110, 45);
            ImportData.TabIndex = 0;
            ImportData.Text = "импортировать данные из exel";
            ImportData.UseVisualStyleBackColor = true;
            ImportData.Click += ImportData_Click;
            // 
            // SaveData
            // 
            SaveData.Location = new Point(681, 63);
            SaveData.Name = "SaveData";
            SaveData.Size = new Size(107, 45);
            SaveData.TabIndex = 1;
            SaveData.Text = "сохранить данные ";
            SaveData.UseVisualStyleBackColor = true;
            SaveData.Click += SaveData_Click;
            // 
            // LoadData
            // 
            LoadData.Location = new Point(681, 114);
            LoadData.Name = "LoadData";
            LoadData.Size = new Size(107, 45);
            LoadData.TabIndex = 2;
            LoadData.Text = "загрузить данные";
            LoadData.UseVisualStyleBackColor = true;
            LoadData.Click += LoadData_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cardCodeDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, surNameDataGridViewTextBoxColumn, phoneMobileDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, genderIdDataGridViewTextBoxColumn, birthdayDataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn, pincodeDataGridViewTextBoxColumn, bonusDataGridViewTextBoxColumn, turnoverDataGridViewTextBoxColumn });
            dataGridView1.DataSource = dataBaseModelBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(663, 426);
            dataGridView1.TabIndex = 3;
            // 
            // dataBaseModelBindingSource
            // 
            dataBaseModelBindingSource.DataSource = typeof(WinFormsApp1.DataBaseModel);
            // 
            // cardCodeDataGridViewTextBoxColumn
            // 
            cardCodeDataGridViewTextBoxColumn.DataPropertyName = "CardCode";
            cardCodeDataGridViewTextBoxColumn.HeaderText = "CardCode";
            cardCodeDataGridViewTextBoxColumn.Name = "cardCodeDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // surNameDataGridViewTextBoxColumn
            // 
            surNameDataGridViewTextBoxColumn.DataPropertyName = "SurName";
            surNameDataGridViewTextBoxColumn.HeaderText = "SurName";
            surNameDataGridViewTextBoxColumn.Name = "surNameDataGridViewTextBoxColumn";
            // 
            // phoneMobileDataGridViewTextBoxColumn
            // 
            phoneMobileDataGridViewTextBoxColumn.DataPropertyName = "PhoneMobile";
            phoneMobileDataGridViewTextBoxColumn.HeaderText = "PhoneMobile";
            phoneMobileDataGridViewTextBoxColumn.Name = "phoneMobileDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // genderIdDataGridViewTextBoxColumn
            // 
            genderIdDataGridViewTextBoxColumn.DataPropertyName = "GenderId";
            genderIdDataGridViewTextBoxColumn.HeaderText = "GenderId";
            genderIdDataGridViewTextBoxColumn.Name = "genderIdDataGridViewTextBoxColumn";
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.HeaderText = "City";
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            // 
            // pincodeDataGridViewTextBoxColumn
            // 
            pincodeDataGridViewTextBoxColumn.DataPropertyName = "Pincode";
            pincodeDataGridViewTextBoxColumn.HeaderText = "Pincode";
            pincodeDataGridViewTextBoxColumn.Name = "pincodeDataGridViewTextBoxColumn";
            // 
            // bonusDataGridViewTextBoxColumn
            // 
            bonusDataGridViewTextBoxColumn.DataPropertyName = "Bonus";
            bonusDataGridViewTextBoxColumn.HeaderText = "Bonus";
            bonusDataGridViewTextBoxColumn.Name = "bonusDataGridViewTextBoxColumn";
            // 
            // turnoverDataGridViewTextBoxColumn
            // 
            turnoverDataGridViewTextBoxColumn.DataPropertyName = "Turnover";
            turnoverDataGridViewTextBoxColumn.HeaderText = "Turnover";
            turnoverDataGridViewTextBoxColumn.Name = "turnoverDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(LoadData);
            Controls.Add(SaveData);
            Controls.Add(ImportData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataBaseModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ImportData;
        private Button SaveData;
        private Button LoadData;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cardCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneMobileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pincodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bonusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn turnoverDataGridViewTextBoxColumn;
        private BindingSource dataBaseModelBindingSource;
    }
}
