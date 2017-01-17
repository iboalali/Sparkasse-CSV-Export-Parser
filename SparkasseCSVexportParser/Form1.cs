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
        public Form1 () {
            InitializeComponent();
            lvData.View = View.Details;
        }

        private void btnOpenFile_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV File|*.csv";
            if ( ofd.ShowDialog() == DialogResult.OK ) {
                txtFileName.Text = ofd.FileName;
                parseCSVFile( ofd.FileName );
            }
        }


        private void parseCSVFile ( string path ) {
            string[] lines = File.ReadAllLines( path );



            lvData.Clear();
            setListViewHeader( lines[0] );
            setListData( lines );
        }

        private void setListData ( string[] lines ) {
            ListViewItem lvi;
            for ( int i = 1; i < lines.Length; i++ ) {
                string[] c = lines[i].Split( new char[] {';'}, StringSplitOptions.RemoveEmptyEntries );
                for ( int j = 0; j < c.Length; j++ ) {
                    c[j] = c[j].Remove( 0, 1 );
                    c[j] = c[j].Remove( c[j].Length - 1 );
                }
                lvi = new ListViewItem(c);
                lvData.Items.Add( lvi );
            }
        }

        private void setListViewHeader ( string line ) {
            string[] columns = line.Split( new char[] {';', '\"'}, StringSplitOptions.RemoveEmptyEntries );

            foreach ( var item in columns ) {
                lvData.Columns.Add( item, -2 );
            }
        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );
        }
    }
}
