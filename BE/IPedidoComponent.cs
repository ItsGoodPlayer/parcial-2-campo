using System.Collections.Generic;

namespace BE
{
    public interface IPedidoComponent
    {
        decimal CalcularPrecio();
        string ObtenerDescripcion();
        List<string> ObtenerIngredientes();
        TipoCombo ObtenerTipoComboBase();
    }
}