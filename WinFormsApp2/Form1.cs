using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WinFormsApp1;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDataFromDB();
        }

        private void ImportData_Click(object sender, EventArgs e)
        {
            LoadExcelFile();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            SaveChangedData();
            LoadDataFromDB();
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        private void LoadExcelFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var dataTable = ReadExcelFile(openFileDialog.FileName);

                        dataGridView1.DataSource = dataTable;

                        SaveToDatabase(dataTable);

                        MessageBox.Show("Данные успешно загружены и сохранены в базу данных!",
                            "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private DataTable ReadExcelFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    return reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    }).Tables[0];
                }
            }
        }

        private void SaveToDatabase(DataTable dataTable)
        {
            using (var context = new DataBaseContext())
            {
                context.Database.EnsureCreated();

                var users = new List<DataBaseModel>();
                var cardCount = new Dictionary<double, int>();

                foreach (DataRow row in dataTable.Rows)
                {
                    var original = Convert.ToDouble(row["CardCode"]);

                    if (cardCount.ContainsKey(original))
                    {
                        cardCount[original]++;
                        original += cardCount[original];
                    }
                    else
                    {
                        cardCount[original] = 0;
                    }
                    users.Add(new DataBaseModel
                    {
                        CardCode = original,
                        LastName = row.IsNull("LastName") ? null : Convert.ToString(row["LastName"]),
                        FirstName = row.IsNull("FirstName") ? null : Convert.ToString(row["FirstName"]),
                        SurName = row.IsNull("SurName") ? null : Convert.ToString(row["SurName"]),
                        PhoneMobile = row.IsNull("PhoneMobile") ? null : Convert.ToString(row["PhoneMobile"]),
                        Email = row.IsNull("Email") ? null : Convert.ToString(row["Email"]),
                        GenderId = row.IsNull("GenderId") ? null : Convert.ToString(row["GenderId"]),
                        Birthday = row.IsNull("Birthday") ? null : Convert.ToString(row["Birthday"]),
                        City = row.IsNull("City") ? null : Convert.ToString(row["City"]),
                        Pincode = row.IsNull("Pincode") ? 0 : Convert.ToDouble(row["Pincode"]),
                        Bonus = row.IsNull("Bonus") ? 0 : Convert.ToDouble(row["Bonus"]),
                        Turnover = row.IsNull("Turnover") ? 0 : Convert.ToDouble(row["Turnover"]),
                    });
                }
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        private void LoadDataFromDB()
        {
            try
            {
                using (var context = new DataBaseContext())
                {
                    var data = context.Users.ToList();
                    dataGridView1.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }
        private void SaveChangedData()
        {
            try
            {
                using (var context = new DataBaseContext())
                {
                    var changedData = (List<DataBaseModel>)dataGridView1.DataSource;

                    foreach (var item in changedData)
                    {
                        if (item.CardCode == 0)
                            context.Users.Add(item);
                        else
                            context.Entry(item).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}