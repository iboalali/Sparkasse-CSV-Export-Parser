﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkasseCSVexportParser {
    public class SparkasseEntry {

        public SparkasseEntry (string line) {
            string[] c = line.Split( new char[] {';'}, StringSplitOptions.RemoveEmptyEntries );
            for ( int j = 0; j < c.Length; j++ ) {
                c[j] = c[j].Remove(0, 1);
                c[j] = c[j].Remove(c[j].Length - 1);
            }

            Auftragskonto = int.Parse(c[0]);

            if ( c[1] != string.Empty ) {
                buchungstag = Convert.ToDateTime(c[1]);
            } else {
                buchungstag = null;
            }

            if ( c[2] != string.Empty ) {
                valutadatum = Convert.ToDateTime(c[2]);
            } else {
                valutadatum = null;
            }

            Buchungstext = c[3];
            verwendungszweck = c[4];
            Beguenstigter_Zahlungspflichtiger = c[5];
            Kontonummer = c[6];
            Bankleitzahl = c[7];
            Betrag = float.Parse(c[8], new System.Globalization.CultureInfo("de-DE"));
            Waehrung = c[9];
            Information = c[10];

        }

        private string verwendungszweck;
        // Nullable Datetime. Equivalent to: Nullable<DateTime> buchungstag;
        private DateTime? buchungstag;
        private DateTime? valutadatum;

        public int Auftragskonto { get; private set; }
        public string Buchungstag
        {
            get
            {
                if ( buchungstag != null ) {
                    return buchungstag.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }
        public string Valutadatum
        {
            get
            {
                if ( valutadatum != null ) {
                    return valutadatum.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }
        public string Buchungstext { get; private set; }
        public string Verwendungszweck
        {
            get
            {
                string t = verwendungszweck;

                if ( verwendungszweck.StartsWith("SVWZ") || verwendungszweck.StartsWith("EREF") ) {
                    t = verwendungszweck.Substring(5);
                }

                if ( Buchungstext == "KARTENZAHLUNG" || Buchungstext == "SEPA-ELV-LASTSCHRIFT" ) {
                    if ( verwendungszweck.LastIndexOf("//") != -1 ) {
                        return t.Remove(t.LastIndexOf("//"));
                    }
                } else if ( Buchungstext == "ONLINE-UEBERWEISUNG" || Buchungstext == "ONLINE-UEBERWEISUNG TERM." ) {
                    return t.Remove(t.LastIndexOf("UHR1.TAN"));
                }

                if ( Buchungstext == "SONSTIGER EINZUNG" || Buchungstext == "ENTGELTABSCHLUSS" || Buchungstext == "GELDAUTOMAT" ) {
                    return verwendungszweck;
                }

                return t;
            }
        }
        public string Beguenstigter_Zahlungspflichtiger { get; private set; }
        public string Kontonummer { get; private set; }
        public string Bankleitzahl { get; private set; }
        public float Betrag { get; private set; }
        public string Waehrung { get; private set; }
        public string Information { get; private set; }
        public string Stadt
        {
            get
            {
                if ( Buchungstext == "KARTENZAHLUNG" || Buchungstext == "SEPA-ELV-LASTSCHRIFT" ) {
                    if ( verwendungszweck.LastIndexOf("//") != -1 ) {
                        return verwendungszweck.Substring(
                            verwendungszweck.LastIndexOf("//") + 2,
                            verwendungszweck.LastIndexOf('/') - ( verwendungszweck.LastIndexOf("//") + 2 )
                            );
                    }
                }

                return string.Empty;
            }
        }

        public string Land
        {
            get
            {
                if ( Buchungstext == "KARTENZAHLUNG" ) {
                    return verwendungszweck.Substring(verwendungszweck.LastIndexOf('/') + 1);
                }

                if ( Buchungstext == "GELDAUTOMAT" ) {
                    return verwendungszweck.Substring(verwendungszweck.LastIndexOf("UHR") + 4);
                }

                return string.Empty;
            }
        }

        public string TAN
        {
            get
            {
                if ( Buchungstext == "ONLINE-UEBERWEISUNG" ) {
                    return verwendungszweck.Substring(verwendungszweck.LastIndexOf("UHR1.TAN") + "UHR1.TAN".Length + 1);
                }

                return string.Empty;

            }
        }

    }
}
