// Nombre del espacio de nombres
using Microsoft.UI.Composition.Interactions;

namespace UD5T1
{
    // Clase parcial MainPage que hereda de ContentPage
    public partial class MainPage : ContentPage
    {

        decimal cuenta = 0;
        int propina = 0;
        int personas = 1;

        /// <summary>
        /// Constructor de la clase MainPage.
        /// </summary>
        public MainPage()
        {
            // Inicialización de la interfaz de usuario
            InitializeComponent();
        }

        /// <summary>
        /// Método para calcular el total de la cuenta.
        /// </summary>
        private void CalcularTotal()
        {
            // Cálculo de la propina total
            var propinaTotal = cuenta * propina / 100;

            // Cálculo de la propina por persona
            var propinaPorPersona = propinaTotal / personas;
            lblPropinaPorPersona.Text = $"{propinaPorPersona:C}";

            // Cálculo del subtotal por persona
            var subtotal = cuenta / personas;
            lblSubtotal.Text = $"{subtotal:C}";

            // Cálculo del total por persona (cuenta + propina) / personas
            var totalPorPersona = (cuenta + propinaTotal) / personas;
            lblTotal.Text = $"{totalPorPersona:C}";
        }

        /// <summary>
        /// Evento cuando se completa la entrada de la cuenta.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void TxtCuenta_Completed(object sender, EventArgs e)
        {
            // Actualización del valor de la cuenta y cálculo del total
            cuenta = decimal.Parse(txtCuenta.Text);
            CalcularTotal();
        }

        /// <summary>
        /// Evento cuando se cambia el valor del deslizador de propina.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void SldPropina_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Actualización del valor de la propina y cálculo del total
            propina = (int)sldPropina.Value;
            lblPropina.Text = $"Propina: {propina}%";
            CalcularTotal();
        }

        /// <summary>
        /// Evento cuando se hace clic en un botón de propina específico.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Verificación de que el remitente sea un botón
            if (sender is Button)
            {
                // Conversión del remitente a un objeto Button
                var btn = (Button)sender;
                // Extracción del porcentaje del texto del botón
                var porcentaje = int.Parse(btn.Text.Replace("%", string.Empty));
                // Actualización del valor del deslizador de propina
                sldPropina.Value = porcentaje;
            }
        }

        /// <summary>
        /// Evento cuando se hace clic en el botón de disminuir personas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnMenos_Clicked(object sender, EventArgs e)
        {
            // Verificación de que hay más de una persona
            if (personas > 1)
            {
                // Reducción del número de personas y actualización de la interfaz
                personas--;
                lblPersonas.Text = personas.ToString();
                CalcularTotal();
            }
        }

        /// <summary>
        /// Evento cuando se hace clic en el botón de aumentar personas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnMas_Clicked(object sender, EventArgs e)
        {
            // Aumento del número de personas y actualización de la interfaz
            personas++;
            lblPersonas.Text = personas.ToString();
            CalcularTotal();
        }
    }
}
