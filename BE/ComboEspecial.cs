using System.Collections.Generic;

namespace BE
{
    public class ComboEspecial : Combo, IPedidoComponent
    {
        public ComboEspecial()
        {
            Id = 3;
            Nombre = "Combo Especial";
            Precio = 8000m;
            Descripcion = "Hamburguesa premium, papas medianas, gaseosa, postre";
            Tipo = TipoCombo.Especial;
        }

        public string ObtenerDescripcion()
        {
            return Nombre;
        }

        public List<string> ObtenerIngredientes()
        {
            return new List<string> { "Hamburguesa premium", "Papas medianas", "Gaseosa", "Postre" };
        }

        public TipoCombo ObtenerTipoComboBase()
        {
            return Tipo;
        }
    }
}