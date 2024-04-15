using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ClothingShop shop = new ClothingShop();
        public BindingList<Style> StyleBindingList = new BindingList<Style>();

        public Form1()
        {
            InitializeComponent();
            shop.LoadFromFile();
            StyleBindingList = new BindingList<Style>(shop.GetStyles());
            StyleBindingList.RaiseListChangedEvents = false;
            StylesDataGridView.AutoGenerateColumns = false;
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", ReadOnly = true });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Type" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cut", HeaderText = "Cut" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Color", HeaderText = "Color" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fabric", HeaderText = "Fabric" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Brand", HeaderText = "Brand" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BasePrice", HeaderText = "Base Price" });
            StylesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SizePriceAdjustmentsDisplay", HeaderText = "Size Price Adjustments" });
            StylesDataGridView.DataSource = StyleBindingList;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (SortOptionsComboBox.SelectedItem == null || SortDirectionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select a sort option and direction.");
                return;
            }
            string sortBy = SortOptionsComboBox.SelectedItem.ToString();
            bool ascending = SortDirectionComboBox.SelectedItem.ToString() == "Ascending";

            var sortedList = shop.SortStyles(sortBy, ascending);
            StyleBindingList = new BindingList<Style>(sortedList);
            StylesDataGridView.DataSource = null;
            StylesDataGridView.DataSource = StyleBindingList;
        }

        private void RefreshStyles()
        {
            shop.LoadFromFile();
            StyleBindingList = new BindingList<Style>(shop.GetStyles());
            StylesDataGridView.DataSource = null;
            StylesDataGridView.DataSource = StyleBindingList;
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            if (StyleBindingList.Any(s => s.Id == int.Parse(IDBox.Text)))
            {
                MessageBox.Show("ID should be unique.");
                return;
            }
            StyleBindingList.Add(new Style
            {
                Id = int.Parse(IDBox.Text),
                Type = "Type",
                Cut = "Cut",
                Color = "Color",
                Fabric = "Fabric",
                Brand = "Brand",
                BasePrice = 0,
                SizePriceAdjustments = new Dictionary<string, decimal>(),
                SizePriceAdjustmentsDisplay = ""
            });
            shop.SaveToFile();
            RefreshStyles();
        }

        private void StylesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            shop.SaveToFile();
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StylesDataGridView.SelectedRows)
            {
                if (row.Index < StylesDataGridView.Rows.Count - 1) {
                    StyleBindingList.RemoveAt(row.Index); 
                }
                
            }
            shop.SaveToFile();
            RefreshStyles();
        }

        private void CalculatePriceButton_Click(object sender, EventArgs e)
        {
            string size = SizeBox.Text.ToUpper();
            int total_price = 0;

            if (string.IsNullOrWhiteSpace(size))
            {
                size = "none";
            }

            foreach (DataGridViewRow row in StylesDataGridView.SelectedRows)
            {
                if (row.Index < StylesDataGridView.Rows.Count - 1)
                {
                    int styleId = (int)row.Cells[0].Value;
                    
                    decimal price = shop.CalculatePrice(styleId, size);
                    total_price += (int)price;
                }
            }
            MessageBox.Show($"Total price: {total_price}");
        }
    }

    public class Style
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Cut { get; set; }
        public string Color { get; set; }
        public string Fabric { get; set; }
        public string Brand { get; set; }
        public decimal BasePrice { get; set; }
        public Dictionary<string, decimal> SizePriceAdjustments { get; set; } = new Dictionary<string, decimal>();
        public string SizePriceAdjustmentsDisplay { get; set; }
    }

    public class ClothingShop
    {
        private List<Style> styles = new List<Style>();
        public List<Style> GetStyles()
        {
            return styles;
        }

        private const string FilePath = "clothing_data.txt";

        public decimal CalculatePrice(int styleId, string size)
        {
            Style style = styles.Find(s => s.Id == styleId);
            if (style != null)
            {
                string upperSize = size.ToUpper();
                if (style.SizePriceAdjustments.TryGetValue(upperSize, out decimal adjustment))
                {
                    return style.BasePrice + adjustment;
                }
            }
            return style?.BasePrice ?? 0M;
        }


        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var style in styles)
                {
                    writer.WriteLine($"{style.Id}|{style.Type}|{style.Cut}|{style.Color}|{style.Fabric}|{style.Brand}|{style.BasePrice}|{style.SizePriceAdjustmentsDisplay}");
                }
            }
        }

        public void LoadFromFile()
        {
            styles.Clear();
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        var parts = line.Split('|');
                        var sizeAdjustmentsParts = parts[7].Split(',');
                        var sizeAdjustments = new Dictionary<string, decimal>();
                        foreach (var part in sizeAdjustmentsParts)
                        {
                            var sizePrice = part.Split(':');
                            if (sizePrice.Length == 2 && decimal.TryParse(sizePrice[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal priceAdjustment))
                            {
                                sizeAdjustments.Add(sizePrice[0].Trim(), priceAdjustment);
                            }
                        }

                        styles.Add(new Style
                        {
                            Id = int.Parse(parts[0]),
                            Type = parts[1],
                            Cut = parts[2],
                            Color = parts[3],
                            Fabric = parts[4],
                            Brand = parts[5],
                            BasePrice = decimal.Parse(parts[6]),
                            SizePriceAdjustments = sizeAdjustments,
                            SizePriceAdjustmentsDisplay = string.Join(",", sizeAdjustments.Select(kvp => $"{kvp.Key}:{kvp.Value}"))
                        });
                    }
                }
            }
            else
            {
                File.Create(FilePath).Dispose();
            }
        }
        public List<Style> SortStyles(string sortBy, bool ascending)
        {
            switch (sortBy)
            {
                case "Type":
                    return ascending ? styles.OrderBy(s => s.Type).ToList() : styles.OrderByDescending(s => s.Type).ToList();
                case "Color":
                    return ascending ? styles.OrderBy(s => s.Color).ToList() : styles.OrderByDescending(s => s.Color).ToList();
                case "Price":
                    return ascending ? styles.OrderBy(s => s.BasePrice).ToList() : styles.OrderByDescending(s => s.BasePrice).ToList();
                case "ID":
                    return ascending ? styles.OrderBy(s => s.Id).ToList() : styles.OrderByDescending(s => s.Id).ToList();
                case "Brand":
                    return ascending ? styles.OrderBy(s => s.Brand).ToList() : styles.OrderByDescending(s => s.Brand).ToList();
                case "Size":
                    return ascending ? styles.OrderBy(s => s.SizePriceAdjustmentsDisplay).ToList() : styles.OrderByDescending(s => s.SizePriceAdjustmentsDisplay).ToList();
                default:
                    return styles;
            }
        }
    }
}
