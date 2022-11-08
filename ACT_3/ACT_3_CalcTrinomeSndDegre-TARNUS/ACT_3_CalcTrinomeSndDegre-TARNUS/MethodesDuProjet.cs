using System;
using System.Collections.Generic;
using System.Text;

namespace ACT_3_CalcTrinomeSndDegre_TARNUS
{
    class MethodesDuProjet
    {
        public void Resolution(double a, double b, double c, out string message)
        {
            double delta = Math.Pow(b, 2) - 4 * a * c;

            if(delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / 2 * a;
                
                double x2 = (-b - Math.Sqrt(delta)) / 2 * a;

                message = "Les solutions de l'équations sont: " + x1 + " et " + x2;
            }
            else if(delta == 0)
            {
                double x = -b / 2 * a;

                message = "La solution est : " + x;
            }
            else
            {
                message = "Il n'y a pas de solutions à cette équation";
            }
        }
    }
}
