using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkasseCSVexportParser {
    class SparkasseEntry {
        public int Auftragskonto { get; set; }
        public DateTime Buchungstag { get; set; }
        public DateTime Valutadatum { get; set; }
        public string Buchungstext { get; set; }
        public string Verwendungszweck { get; set; }
        public string Beguenstigter_Zahlungspflichtiger { get; set; }
        public string Kontonummer { get; set; }
        public string Bankleitzahl { get; set; }
        public float Betrag { get; set; }
        public string Waehrung { get; set; }
        public string Information { get; set; }
        public string Stadt {
            get
            {
                if ( Buchungstext == "KARTENZAHLUNG" ) {
                    return Verwendungszweck.Substring(
                        Verwendungszweck.LastIndexOf( "//" ),
                        Verwendungszweck.LastIndexOf( '/' ) - Verwendungszweck.LastIndexOf( "//" )
                        );
                }

                return string.Empty;
            }
        }

        public string Land {
            get
            {
                if ( Buchungstext == "KARTENZAHLUNG" ) {
                    return Verwendungszweck.Substring( Verwendungszweck.LastIndexOf( '/' ) );
                }

                return string.Empty;
            }
        }

    }
}
