using System;

namespace Tangentengleichung
{
    class InOut
    {
        public InOut(String ausgabe)
        {
            headline(ausgabe);
        }

        public InOut()
        {
            
        }

        public void headline(String message)
        {
            var width = Console.WindowWidth;
            var messageLength = message.Length;
            var markLength = (width - messageLength) / 2;
            for(double i = 0; i < markLength; i++)
            {
                Console.Write("-");
            }
            Console.Write(message);
            for (double i = 0; i < markLength; i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }

        public double[] funktionEingeben()
        {
            int grad;
            double[] funktion;

            Console.Write("Grad der Funktion: ");
            var eingabe = Console.ReadLine();
            try
            {
                grad = Int32.Parse(eingabe);

                if (grad < 0)
                    throw new Exception("Die Funktionen können nur einen positiven Grad haben!");
            } catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
            funktion = new double[grad+1];

            for (int i = grad; i >= 0; i--)
            {
                Console.Write("x^" + i + " * ");
                var funkEingabe = Console.ReadLine();
                try
                {
                    funktion[i] = Double.Parse(funkEingabe);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                    return null;
                }
                //Console.Write("\n");
            }
            Console.Clear();
            return funktion;
        } 

        public void funktionAusgeben(double[] funktion)
        {
            if (funktion == null || funktion.Length == 0)
                return;

            var lenthM = funktion.Length - 1;
            Console.Write(funktion[lenthM] + "x^" + lenthM);
            for (int i = funktion.Length-2; i >= 0; i--)
            {
                Console.Write(" + " + funktion[i] + "x^" + i);
            }
            Console.Write("\n");
        }

        public void funktionAusgeben(double[] funktion, string pre)
        {
            if (funktion == null || funktion.Length == 0)
                return;

            var lenthM = funktion.Length - 1;
            Console.Write(pre);
            Console.Write(funktion[lenthM] + "x^" + lenthM);
            for (int i = funktion.Length - 2; i >= 0; i--)
            {
                Console.Write(" + " + funktion[i] + "x^" + i);
            }
            Console.Write("\n");
        }

        public (double, double) punktEingeben(string bez)
        {
            double koord1;
            double koord2;
            Console.Write("Punkt " + bez + " eingeben: ");
            var eingabe = Console.ReadLine();
            try
            {
                int i = eingabe.IndexOf('(');
                int i2 = eingabe.IndexOf('|');
                int i3 = eingabe.IndexOf(')');
                if ((i < 0 || i2 < 0 || i3 < 0) || (i2 < i || (i3 < i2 || i3 < i)))
                    throw new Exception("Eingabefehler! Überprüfe deine Eingabe und versuche es erneut.");

                string k1 = eingabe.Substring(i+1, i2 - i - 1);
                string k2 = eingabe.Substring(i2+1, i3 - i2 - 1);
                koord1 = Double.Parse(k1);
                koord2 = Double.Parse(k2);
            } catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return punktEingeben(bez);
            }
            return (koord1,koord2);
        }

        public string genereicEingeben(string message)
        {
            Console.Write(message);
            string eingabe = Console.ReadLine();
            Console.Write("\n");
            return eingabe;
        }

        public void error(Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message);
        }
    }
}
