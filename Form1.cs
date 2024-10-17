using System;
using System.Windows.Forms;

namespace VinoTanquesForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento del botón Calcular
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura los valores ingresados
                string nombreVino = textBoxNombreVino.Text;
                double radio = Convert.ToDouble(textBoxRadio.Text);
                double altura = Convert.ToDouble(textBoxAltura.Text);
                string material = comboBoxMaterial.SelectedItem?.ToString();

                // Validación de los datos ingresados
                if (string.IsNullOrWhiteSpace(nombreVino))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del vino.", "Entrada Inválida");
                    return;
                }
                if (radio <= 0 || altura <= 0)
                {
                    MessageBox.Show("Radio y altura deben ser mayores que 0.", "Entrada Inválida");
                    return;
                }
                if (material == "-")
                {
                    MessageBox.Show("Por favor, selecciona un material válido.", "Entrada Inválida");
                    return;
                }

                // Calcula el volumen del tanque (en metros cúbicos)
                double volumenMetrosCubicos = Math.PI * Math.Pow(radio, 2) * altura;
                double volumenLitros = volumenMetrosCubicos * 1000; // Conversión a litros

                // Muestra el resultado en el Label
                labelResultado.Text = $"Hay {volumenLitros:F2} litros del {nombreVino} vino en un depósito de {material}.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos para el radio y la altura.", "Error de Formato");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        // Eventos adicionales para evitar errores
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}

