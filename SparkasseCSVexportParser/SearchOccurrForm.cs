using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparkasseCSVexportParser {
    public partial class SearchOccurrForm : Form {
        List<SparkasseEntry> list;
        string[] header;

        public SearchOccurrForm (List<SparkasseEntry> list, string[] header) {
            InitializeComponent();
            this.list = list;
            lvResult.View = View.Details;
            this.header = header;

            foreach (var item in header) {
                cbFilter.Items.Add(item);
            }

            cbFilter.SelectedItem = "Verwendungszweck";

        }

        private void btnSearch_Click (object sender, EventArgs e) {
            if (txtSearchBox.Text == string.Empty) {
                return;
            }

            lvResult.Clear();

            string choice = (string) cbFilter.SelectedItem;
            string searchTerm = txtSearchBox.Text;

            AddColumns(choice);

            Search(searchTerm, choice);
        }

        private void Search (string searchTerm, string choice) {
            ListViewItem lvi;
            float total = 0f;
            int counter = 0;

            switch (choice) {
                case "Verwendungszweck":
                    foreach (var item in list) {
                        if (item.Verwendungszweck.Contains(searchTerm)) {
                            lvi = new ListViewItem(new string[] {
                                item.Auftragskonto.ToString(),
                                item.Buchungstag,
                                item.Valutadatum,
                                item.Buchungstext,
                                item.Beguenstigter_Zahlungspflichtiger,
                                item.Kontonummer,
                                item.Bankleitzahl,
                                item.Betrag.ToString(),
                                item.Waehrung,
                                item.Information
                            });
                            lvResult.Items.Add(lvi);
                            total += item.Betrag;
                            counter++;
                        }
                    }

                    txtTotalAmount.Text = total.ToString() + " EUR";
                    txtTotalOccurrence.Text = counter.ToString();
                    break;
                case "Beguenstigter/Zahlungspflichtiger":
                    foreach (var item in list) {
                        if (item.Beguenstigter_Zahlungspflichtiger.Contains(searchTerm)) {
                            lvi = new ListViewItem(new string[] {
                                item.Auftragskonto.ToString(),
                                item.Buchungstag,
                                item.Valutadatum,
                                item.Buchungstext,
                                item.Verwendungszweck,
                                item.Kontonummer,
                                item.Bankleitzahl,
                                item.Betrag.ToString(),
                                item.Waehrung,
                                item.Information
                            });
                            lvResult.Items.Add(lvi);
                            total += item.Betrag;
                            counter++;
                        }
                    }

                    txtTotalAmount.Text = total.ToString() + " EUR";
                    txtTotalOccurrence.Text = counter.ToString();

                    break;
                case "Kontonummer":

                    break;
                case "Info":

                    break;
                case "Waehrung":

                    break;
                case "BLZ":

                    break;
                case "Buchugstext":

                    break;
                default:
                    break;
            }

            for (int i = 0; i < lvResult.Columns.Count; i++) {
                lvResult.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

        }

        private void AddColumns (string exludeHeader) {

            foreach (var item in cbFilter.Items) {
                if (exludeHeader != item.ToString()) {
                    lvResult.Columns.Add(item.ToString(), -2);
                }
            }
        }



    }
}
