using System.Collections.Generic;

namespace BE
{
    public class ComboBasico : Combo, IPedidoComponent
    {
        public ComboBasico()
        {
            Id = 1;
            Nombre = "Combo Básico";
            Precio = 5000m;
            Descripcion = "Hamburguesa simple, papas chicas, gaseosa";
            Tipo = TipoCombo.Basico;
        }

        public string ObtenerDescripcion()
        {
            return Nombre;
        }

        public List<string> ObtenerIngredientes()
        {
            return new List<string> { "Hamburguesa simple", "Papas chicas", "Gaseosa" };
        }

        public TipoCombo ObtenerTipoComboBase()
        {
            return Tipo;
        }
    }
}