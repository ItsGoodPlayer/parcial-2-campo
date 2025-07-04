using System.Collections.Generic;

namespace BE
{
    public class ComboBasico : Combo
    {
        public ComboBasico()
        {
            Id = 1;
            Nombre = "Combo Básico";
            Precio = 5000m;
            Descripcion = "Hamburguesa simple, papas chicas, gaseosa";
            Tipo = TipoCombo.Basico;
        }

        public override List<string> ObtenerIngredientes()
        {
            return new List<string> { "Hamburguesa simple", "Papas chicas", "Gaseosa" };
        }
    }
}