using System;

namespace Tangentengleichung
{
    class Funktion
    {
        public double[] FunktionsGleichung
        {
            get; set;
        }
        public int Grad
        {
            get; set;
        }

        public string Bezeichner
        {
            get; set;
        }

        public Funktion()
        {

        }

        public Funktion(double[] funktion)
        {
            this.FunktionsGleichung = funktion ?? new double[1];
            this.Grad = funktion == null ? 0 : funktion.Length-1;
            Bezeichner = "f";
        }

        public Funktion(double[] funktion, string bezeichner)
        {

            this.FunktionsGleichung = funktion ?? new double[1];
            this.Grad = funktion == null ? 0 : funktion.Length - 1;
            this.Bezeichner = bezeichner;
        }

        public void ausgeben()
        {
            InOut.funktionAusgeben(FunktionsGleichung, Bezeichner);
        }

        public Funktion ableitenToFunc()
        {
            return new Funktion(ableiten(), Bezeichner + "\'");
        }

        private double[] ableiten()
        {
            double[] ableitung = new double[Grad];
            for (int i = Grad; i >= 0; i--)
            {
                int j = i - 1;
                if(i!=0)
                    ableitung[j] = FunktionsGleichung[i] * i;
            }
            return ableitung;
        }

        //NUR FÜR STELLEN (x-component)
        private double einsetzen(double punkt)
        {
            double sum = 0;
            for (int i = Grad; i >= 0; i--)
            {
                sum += FunktionsGleichung[i] * Math.Pow(punkt, i);
            }
            return sum;
        }

        private Funktion getTangenteAn((double, double) koord)
        {
            //Get y=mx+b
            Funktion ableitung = new Funktion(ableiten());
            //Change from koord to koord.Item1
            double m = ableitung.einsetzen(koord.Item1);
            double b = koord.Item2 - ( m * koord.Item1);
            double[] rawTangente = { b, m };

            Funktion tangente = new Funktion(rawTangente, "t");

            return tangente;
        }

        private Funktion getTangenteAnX(double x)
        {
            //insert x in f(x)
            (double, double) koord = (x, einsetzen(x));
            return getTangenteAn(koord);
        }

        public Funktion getTangenteAnX()
        {
            double x = 0;
            String eingabe = InOut.genereicEingeben("Gib die Stelle, durch die die Tangente verlaufen soll, an: ");
            try
            {
                x = Double.Parse(eingabe);
            } catch (Exception e)
            {
                throw new FormatException("An invalid character has been entered! Onyl doubles allowed!", e);
            }
            return getTangenteAnX(x);
        }

        public static void getTangete()
        {
            double[] rawFunktion = new double[0];
            try
            {
                rawFunktion = InOut.funktionEingeben();
            } catch(Exception e)
            {
                InOut.error(e);
                return;
            }
            

            Funktion funktion = new Funktion(rawFunktion);
            Funktion ableitung = funktion.ableitenToFunc();
            Funktion tangente = new Funktion();
            try
            {
                tangente = funktion.getTangenteAnX();
            } catch(Exception e)
            {
                InOut.error(e);
                return;
            }
             
            
            
            InOut.funktionAusgeben(funktion);
            InOut.funktionAusgeben(ableitung);
            InOut.funktionAusgeben(tangente);
        }
    }
}
