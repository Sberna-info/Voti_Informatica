using System;

namespace Calcoli
{
    public class Gestione
    {
        public static double Incidenza(double voto, double tot)
        {
            return Math.Round((voto / tot) * 100,2);
        }
    }
}
