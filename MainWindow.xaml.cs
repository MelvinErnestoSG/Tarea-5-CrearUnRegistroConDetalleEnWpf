using System.Windows;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.UI.Ayuda;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.UI.Registros;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroRolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rol = new rRoles();
            rol.Show();
        }

        private void AyudaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var ayudas = new Ayudas();
            ayudas.Show();
        }
    }
}
