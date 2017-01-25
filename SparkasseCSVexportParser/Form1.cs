using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparkasseCSVexportParser {
    public partial class Form1 : Form {

        List<SparkasseEntry> list;
        string[] header;

        public Form1 () {
            InitializeComponent();
            lvData.View = View.Details;
            list = new List<SparkasseEntry>();
        }

        private void btnOpenFile_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV File|*.csv|All Files|*.*";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                txtFileName.Text = ofd.FileName;
                parseCSVFile( ofd.FileName );
            }
        }


        private void parseCSVFile ( string path ) {
            string[] lines = File.ReadAllLines( path );

            for ( int i = 1; i < lines.Length; i++ ) {
                list.Add( new SparkasseEntry( lines[i] ) );
            }

            lvData.Clear();
            setListViewHeader( lines[0] );
            setListData( list );
        }

        private void setListData ( string[] lines ) {
            ListViewItem lvi;
            for ( int i = 1; i < lines.Length; i++ ) {
                string[] c = lines[i].Split( new char[] {';'}, StringSplitOptions.RemoveEmptyEntries );
                for ( int j = 0; j < c.Length; j++ ) {
                    c[j] = c[j].Remove( 0, 1 );
                    c[j] = c[j].Remove( c[j].Length - 1 );
                }
                lvi = new ListViewItem( c );
                lvData.Items.Add( lvi );
            }
        }

        private void setListData ( List<SparkasseEntry> sparkasseEntryList ) {
            ListViewItem lvi;
            foreach ( var item in sparkasseEntryList ) {
                lvi = new ListViewItem( new string[] {
                        item.Auftragskonto.ToString(),
                        item.Buchungstag,
                        item.Valutadatum,
                        item.Buchungstext,
                        item.Verwendungszweck,
                        item.Beguenstigter_Zahlungspflichtiger,
                        item.Kontonummer,
                        item.Bankleitzahl,
                        item.Betrag.ToString( "0.00", new System.Globalization.CultureInfo( "de-DE" )),
                        item.Waehrung,
                        item.Information
                    }
                );

                lvData.Items.Add( lvi );
            }
        }

        private void setListViewHeader ( string line ) {
            header = line.Split( new char[] {';', '\"'}, StringSplitOptions.RemoveEmptyEntries );

            foreach ( var item in header ) {
                lvData.Columns.Add( item, -2 );
            }

            lvData.Columns[0].Width = 90;
        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );
        }

        private void btnSearchOccurrences_Click ( object sender, EventArgs e ) {
            if ( txtFileName.Text != string.Empty ) {
                new SearchOccurrForm( list, header ).Show();
            } else {
                MessageBox.Show( "Öffne erst eine Datei" );
            }
        }


    }
}
