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

            /*
            switch (choice) {
                #region Auftragskonto
                case "Auftragskonto":
                    int r;
                    bool succ = int.TryParse( searchTerm, out r );
                    if (succ) {

                        lvResult.Columns.Add("Buchungstag", -2);
                        lvResult.Columns.Add("Valutadatum", -2);
                        lvResult.Columns.Add("Buchungstext", -2);
                        lvResult.Columns.Add("Verwendungszweck", -2);
                        lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                        lvResult.Columns.Add("Kontonummer", -2);
                        lvResult.Columns.Add("Bankleitzahl", -2);
                        lvResult.Columns.Add("Betrag", -2);
                        lvResult.Columns.Add("Währung", -2);
                        lvResult.Columns.Add("Information", -2);
                        lvResult.Columns.Add("Stadt", -2);
                        lvResult.Columns.Add("Land", -2);
                        lvResult.Columns.Add("TAN", -2);

                        foreach (var item in list) {
                            ListViewItem lvi;

                            if (item.Auftragskonto == r) {
                                lvi = new ListViewItem(new string[] {
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                                );
                                lvResult.Items.Add(lvi);
                            }
                        }
                    } else {
                        MessageBox.Show("Der Wert muss eine gültige Zahl sein");
                        return;
                    }
                    break;
                #endregion
                #region Buchungstag
                case "Buchungstag":
                    DateTime d;
                    succ = DateTime.TryParse(searchTerm, out d);

                    if (succ) {
                        lvResult.Columns.Add("Auftragskonto", 90);
                        lvResult.Columns.Add("Valutadatum", -2);
                        lvResult.Columns.Add("Buchungstext", -2);
                        lvResult.Columns.Add("Verwendungszweck", -2);
                        lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                        lvResult.Columns.Add("Kontonummer", -2);
                        lvResult.Columns.Add("Bankleitzahl", -2);
                        lvResult.Columns.Add("Betrag", -2);
                        lvResult.Columns.Add("Währung", -2);
                        lvResult.Columns.Add("Information", -2);
                        lvResult.Columns.Add("Stadt", -2);
                        lvResult.Columns.Add("Land", -2);
                        lvResult.Columns.Add("TAN", -2);

                        foreach (var item in list) {
                            ListViewItem lvi;

                            if (item.Buchungstag == d.ToString("dd.MM.yyyy")) {
                                lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                                );
                                lvResult.Items.Add(lvi);
                            }
                        }
                    } else {
                        MessageBox.Show("Der Wert muss eine gültiges Datum sein");
                        return;
                    }
                    break;
                #endregion
                #region Valutadatum
                case "Valutadatum":
                    succ = DateTime.TryParse(searchTerm, out d);
                    if (succ) {
                        lvResult.Columns.Add("Auftragskonto", 90);
                        lvResult.Columns.Add("Buchungstag", -2);
                        lvResult.Columns.Add("Buchungstext", -2);
                        lvResult.Columns.Add("Verwendungszweck", -2);
                        lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                        lvResult.Columns.Add("Kontonummer", -2);
                        lvResult.Columns.Add("Bankleitzahl", -2);
                        lvResult.Columns.Add("Betrag", -2);
                        lvResult.Columns.Add("Währung", -2);
                        lvResult.Columns.Add("Information", -2);
                        lvResult.Columns.Add("Stadt", -2);
                        lvResult.Columns.Add("Land", -2);
                        lvResult.Columns.Add("TAN", -2);

                        foreach (var item in list) {
                            ListViewItem lvi;

                            if (item.Valutadatum == d.ToString("dd.MM.yyyy")) {
                                lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                                );
                                lvResult.Items.Add(lvi);
                            }
                        }
                    } else {
                        MessageBox.Show("Der Wert muss eine gültiges Datum sein");
                        return;
                    }
                    break;
                #endregion
                #region Buchungstext
                case "Buchungstext":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Buchungstext == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }

                    break;
                #endregion
                #region Verwendungszweck
                case "Verwendungszweck":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Verwendungszweck == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }
                    break;
                #endregion
                #region Begünstigter/Zahlungspflichtiger
                case "Begünstigter/Zahlungspflichtiger":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Beguenstigter_Zahlungspflichtiger == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }

                    break;
                #endregion
                #region Kontonummer
                case "Kontonummer":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Kontonummer == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }

                    break;
                #endregion
                #region Bankleitzahl
                case "Bankleitzahl":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Bankleitzahl == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }

                    break;
                #endregion
                #region Betrag
                case "Betrag":
                    float f;
                    succ = float.TryParse(searchTerm, out f);

                    if (succ) {
                        lvResult.Columns.Add("Auftragskonto", 90);
                        lvResult.Columns.Add("Buchungstag", -2);
                        lvResult.Columns.Add("Valutadatum", -2);
                        lvResult.Columns.Add("Buchungstext", -2);
                        lvResult.Columns.Add("Verwendungszweck", -2);
                        lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                        lvResult.Columns.Add("Kontonummer", -2);
                        lvResult.Columns.Add("Bankleitzahl", -2);
                        lvResult.Columns.Add("Währung", -2);
                        lvResult.Columns.Add("Information", -2);
                        lvResult.Columns.Add("Stadt", -2);
                        lvResult.Columns.Add("Land", -2);
                        lvResult.Columns.Add("TAN", -2);

                        foreach (var item in list) {
                            ListViewItem lvi;

                            if (item.Betrag == f) {
                                lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Waehrung,
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                                );
                                lvResult.Items.Add(lvi);
                            }
                        }
                    }

                    break;
                #endregion
                #region Währung
                case "Währung":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    foreach (var item in list) {
                        ListViewItem lvi;

                        if (item.Waehrung == searchTerm) {
                            lvi = new ListViewItem(new string[] {
                                        item.Auftragskonto.ToString(),
                                        item.Buchungstag,
                                        item.Valutadatum,
                                        item.Buchungstext,
                                        item.Verwendungszweck,
                                        item.Beguenstigter_Zahlungspflichtiger,
                                        item.Kontonummer,
                                        item.Bankleitzahl,
                                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                                        item.Information,
                                        item.Stadt,
                                        item.Land,
                                        item.TAN
                                    }
                            );
                            lvResult.Items.Add(lvi);
                        }
                    }

                    break;
                #endregion
                #region Information
                case "Information":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    break;
                #endregion
                #region Stadt
                case "Stadt":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    break;
                #endregion
                #region Land
                case "Land":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("TAN", -2);

                    break;
                #endregion
                #region TAN
                case "TAN":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);

                    break;
                #endregion
                #region All
                case "All":
                    lvResult.Columns.Add("Auftragskonto", 90);
                    lvResult.Columns.Add("Buchungstag", -2);
                    lvResult.Columns.Add("Valutadatum", -2);
                    lvResult.Columns.Add("Buchungstext", -2);
                    lvResult.Columns.Add("Verwendungszweck", -2);
                    lvResult.Columns.Add("Begünstigter/Zahlungspflichtiger", -2);
                    lvResult.Columns.Add("Kontonummer", -2);
                    lvResult.Columns.Add("Bankleitzahl", -2);
                    lvResult.Columns.Add("Betrag", -2);
                    lvResult.Columns.Add("Währung", -2);
                    lvResult.Columns.Add("Information", -2);
                    lvResult.Columns.Add("Stadt", -2);
                    lvResult.Columns.Add("Land", -2);
                    lvResult.Columns.Add("TAN", -2);

                    break;
                #endregion
                default:
                    break;
            }

            */
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
