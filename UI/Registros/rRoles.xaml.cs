using System;
using System.Collections.Generic;
using System.Windows;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.BLL;
using Tarea_5_CrearUnRegistroConDetalleEnWpf.Entidades;

namespace Tarea_5_CrearUnRegistroConDetalleEnWpf.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles rol = new Roles();

        public rRoles()
        {
            InitializeComponent();
            DataContext = rol;
            RolIdTextBox.Text = "0";

            PermisoComboBox.ItemsSource = PermisosBLL.GetPermisos();
            PermisoComboBox.SelectedValuePath = "PermisoId";
            PermisoComboBox.DisplayMemberPath = "Nombre";

            DescripcionComboBox.ItemsSource = PermisosBLL.GetPermisos();
            DescripcionComboBox.SelectedValuePath = "PermisoId";
            DescripcionComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Actualizar()
        {
            DataContext = null;
            DataContext = rol;
        }
		
        private void Limpiar()
        {
            RolIdTextBox.Text = "0";
            DetalleDataGrid.ItemsSource = new List<RolesDetalle>();
            Actualizar();
        }

        private bool ExisteBD()
        {
            Roles rol = RolesBLL.Buscar(Utilidades.ToInt(RolIdTextBox.Text));
            return rol != null;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(DescripcionComboBox.Text))
            {
                MessageBox.Show("No Debe Agregar la Descripción.", "Validacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }
            return esValido;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            rol.Detalle.Add(new RolesDetalle
            {
                RolId = rol.RolId,
                PermisoId = (int)PermisoComboBox.SelectedValue,
                EsAsignado = (bool)EsAsignadoCheckBox.IsChecked
            });
            Actualizar();
        }
		
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                Limpiar();
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Encontrado = RolesBLL.Buscar(Convert.ToInt32(RolIdTextBox.Text));

            if (Encontrado != null)
            {
                this.rol = Encontrado;
                MessageBox.Show("EL Rol Fue Creado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("El Rol No Esta Creado.", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
                this.rol = new Roles();
            }
            this.DataContext = this.rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!string.IsNullOrWhiteSpace(RolIdTextBox.Text = "0"))
            {
                paso = RolesBLL.Guardar(rol);
            }
            else
            {
                if (ExisteBD())
                {
                    MessageBox.Show("No se puede Modificar porque no existe.", "Fallo",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
                paso = RolesBLL.Modificar(rol);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Convert.ToInt32(RolIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Regitro Eliminado!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Eliminación Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
