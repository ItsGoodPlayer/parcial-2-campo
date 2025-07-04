using System.Collections.Generic;

namespace BE
{
    public class ComboFamiliar : Combo
    {
        public ComboFamiliar()
        {
            Id = 2;
            Nombre = "Combo Familiar";
            Precio = 12000m;
            Descripcion = "Hamburguesas x2, papas grandes, gaseosas x2, nuggets";
            Tipo = TipoCombo.Familiar;
        }

        public override List<string> ObtenerIngredientes()
        {
            return new List<string> { "Hamburguesas x2", "Papas grandes", "Gaseosas x2", "Nuggets" };
        }
    }
}