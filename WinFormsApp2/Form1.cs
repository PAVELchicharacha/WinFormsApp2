using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WinFormsApp1;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += async (sender, e) => await LoadDataFromDBAsync();
        }

        private async void ImportData_Click(object sender, EventArgs e)
        {
            await LoadExcelFileAsync();
        }

        private async void SaveData_Click(object sender, EventArgs e)
        {
            await SaveChangedDataAsync();
            await LoadDataFromDBAsync();
        }

        private async void LoadData_Click(object sender, EventArgs e)
        {
            await LoadDataFromDBAsync();
        }

        private async Task LoadExcelFileAsync()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var dataTable = await Task.Run(() => ReadExcelFile(openFileDialog.FileName));

                        dataGridView1.Invoke((Action)(() => dataGridView1.DataSource = dataTable));

                        await SaveToDatabaseAsync(dataTable);

                        MessageBox.Show("������ ������� ��������� � ��������� � ���� ������!",
                            "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async Task SaveToDatabaseAsync(DataTable dataTable)
        {
            await using (var context = new DataBaseContext())
            {
                await context.Database.EnsureCreatedAsync();

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
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }
        }

        private async Task LoadDataFromDBAsync()
        {
            try
            {
                await using (var context = new DataBaseContext())
                {
                    var data = await context.Users.ToListAsync();
                    dataGridView1.Invoke(() => dataGridView1.DataSource = data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��������: {ex.Message}");
            }
        }
        private async Task SaveChangedDataAsync()
        {
            await using (var context = new DataBaseContext())
            {
                var changedData = (List<DataBaseModel>)dataGridView1.DataSource;
                dataGridView1.Invoke(() => changedData = (List<DataBaseModel>)dataGridView1.DataSource);

                foreach (var item in changedData)
                {
                    if (item.CardCode == 0)
                        context.Users.Add(item);
                    else
                        context.Entry(item).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
                MessageBox.Show("������ ������� ���������!");
            }
        }
    }
}