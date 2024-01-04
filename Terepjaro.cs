using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA240104
{
    internal class Terepjaro
    {
        public string MarkaModell { get; set; }
        public int Evjarat { get; set; }
        public string UzemanyagTipus { get; set; }
        public int Tomeg { get; set; }
        public string Hajtas { get; set; }
        public string KepessegekString { get; set; }
        public List<string> Kepessegek { get; set; }
        public double TomegFontba { get; set; }

        public Terepjaro(string sor)
        {
            var atmeneti = sor.Split(';');
            this.MarkaModell = atmeneti[0];
            this.Evjarat = Convert.ToInt32(atmeneti[1]);
            this.UzemanyagTipus = atmeneti[2];
            this.Tomeg = Convert.ToInt32(atmeneti[3]);
            this.Hajtas = atmeneti[4];
            this.KepessegekString = atmeneti[5];
            this.Kepessegek = new();
            var atmeneti2 = atmeneti[5].Split(',');
            for (int i = 0; i < atmeneti2.Length; i++) this.Kepessegek.Add(atmeneti2[i]);
            this.TomegFontba = this.Tomeg * 2.20462;
        }

        public override string ToString()
        {
            return $"Márka és modell: {this.MarkaModell}\nÉvjárat: {this.Evjarat}\nÜzemanyag típus: {this.UzemanyagTipus}\nTömege: {this.Tomeg}\nHajtása: {this.Hajtas}\nKépességek: {this.KepessegekString}\n";
        }
    }
}
