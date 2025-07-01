namespace BE
{
    public class ComboFactory
    {
        public static Combo CrearCombo(TipoCombo tipo)
        {
            switch (tipo)
            {
                case TipoCombo.Basico:
                    return new ComboBasico();
                case TipoCombo.Familiar:
                    return new ComboFamiliar();
                case TipoCombo.Especial:
                    return new ComboEspecial();
                default:
                    return new ComboBasico();
            }
        }

        public static Combo CrearCombo(string tipoString)
        {
            switch (tipoString.ToLower())
            {
                case "basico":
                    return new ComboBasico();
                case "familiar":
                    return new ComboFamiliar();
                case "especial":
                    return new ComboEspecial();
                default:
                    return new ComboBasico();
            }
        }
    }
}