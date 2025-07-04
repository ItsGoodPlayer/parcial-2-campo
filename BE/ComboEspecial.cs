using System.Collections.Generic;

namespace BE
{
    public class ComboEspecial : Combo
    {
        public ComboEspecial()
        {
            Id = 3;
            Nombre = "Combo Especial";
            Precio = 8000m;
            Descripcion = "Hamburguesa premium, papas medianas, gaseosa, postre";
            Tipo = TipoCombo.Especial;
        }

        public override List<string> ObtenerIngredientes()
        {
            return new List<string> { "Hamburguesa premium", "Papas medianas", "Gaseosa", "Postre" };
        }
    }
}