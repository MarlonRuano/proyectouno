using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoProgra
{
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataRowView selectedRowUsuario;
        private DataRowView selectedRowCurso;
        private DataRowView selectedRowEvaluacion;
        private DataRowView selectedRowMaterial;
        private DataRowView selectedRowForo;
        private DataRowView selectedRowCalificacion;
        private DataRowView selectedRowGrupo;
        private DataRowView selectedRowReporte;

        public MainWindow()
        {
            InitializeComponent();
            TestDatabaseConnection();
            LoadUsuarios();
            LoadCursos();
            LoadEvaluaciones();
            LoadMateriales();
            LoadForos();
            LoadCalificaciones();
            LoadGrupos();
            LoadReportes();
        }

        private void TestDatabaseConnection()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (connectionStringSettings == null)
            {
                MessageBox.Show("La cadena de conexión no se encuentra en el archivo de configuración.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string connectionString = connectionStringSettings.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("La cadena de conexión está vacía o no está configurada correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión a la base de datos exitosa.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadUsuarios()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Nombre, Email, FechaRegistro, Foto FROM CredencialesUsuario";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable usuariosTable = new DataTable();
                    adapter.Fill(usuariosTable);

                    UsuariosGrid.ItemsSource = usuariosTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadCursos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Titulo, Descripcion, FechaInicio, FechaFin FROM Cursos";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable cursosTable = new DataTable();
                    adapter.Fill(cursosTable);

                    CursosGrid.ItemsSource = cursosTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los cursos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadEvaluaciones()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Titulo, Descripcion, Fecha, CursoID FROM Evaluaciones";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable evaluacionesTable = new DataTable();
                    adapter.Fill(evaluacionesTable);

                    EvaluacionesGrid.ItemsSource = evaluacionesTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las evaluaciones: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadMateriales()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Titulo, Descripcion, Tipo, CursoID FROM Materiales";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable materialesTable = new DataTable();
                    adapter.Fill(materialesTable);

                    MaterialesGrid.ItemsSource = materialesTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los materiales: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadForos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Titulo, Descripcion, Fecha, CursoID FROM Foros";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable forosTable = new DataTable();
                    adapter.Fill(forosTable);

                    ForosGrid.ItemsSource = forosTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los foros: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadCalificaciones()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, UsuarioID, CursoID, Calificacion, Comentarios FROM Calificaciones";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable calificacionesTable = new DataTable();
                    adapter.Fill(calificacionesTable);

                    CalificacionesGrid.ItemsSource = calificacionesTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las calificaciones: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadGrupos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Nombre, Descripcion, CursoID FROM Grupos";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable gruposTable = new DataTable();
                    adapter.Fill(gruposTable);

                    GruposGrid.ItemsSource = gruposTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los grupos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadReportes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Titulo, Descripcion, Fecha, CursoID FROM Reportes";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable reportesTable = new DataTable();
                    adapter.Fill(reportesTable);

                    ReportesGrid.ItemsSource = reportesTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UsuariosGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsuariosGrid.SelectedItem != null)
            {
                selectedRowUsuario = (DataRowView)UsuariosGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void CursosGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CursosGrid.SelectedItem != null)
            {
                selectedRowCurso = (DataRowView)CursosGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void EvaluacionesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EvaluacionesGrid.SelectedItem != null)
            {
                selectedRowEvaluacion = (DataRowView)EvaluacionesGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void MaterialesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MaterialesGrid.SelectedItem != null)
            {
                selectedRowMaterial = (DataRowView)MaterialesGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void ForosGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ForosGrid.SelectedItem != null)
            {
                selectedRowForo = (DataRowView)ForosGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void CalificacionesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalificacionesGrid.SelectedItem != null)
            {
                selectedRowCalificacion = (DataRowView)CalificacionesGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void GruposGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GruposGrid.SelectedItem != null)
            {
                selectedRowGrupo = (DataRowView)GruposGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void ReportesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReportesGrid.SelectedItem != null)
            {
                selectedRowReporte = (DataRowView)ReportesGrid.SelectedItem;
                // Aquí puedes rellenar los campos de texto si los tienes
            }
        }

        private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO CredencialesUsuario (Nombre, Email, FechaRegistro, Foto) VALUES (@nombre, @Email, @FechaRegistro, @Foto)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", "NuevoNombre"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@Email", "NuevoEmail"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                    command.Parameters.AddWithValue("@Foto", "NuevaFoto"); // Reemplaza con el valor del campo de texto

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowUsuario != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE CredencialesUsuario SET Nombre = @nombre, Email = @Email, FechaRegistro = @FechaRegistro, Foto = @Foto WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@nombre", "NuevoNombre"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@Email", "NuevoEmail"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                        command.Parameters.AddWithValue("@Foto", "NuevaFoto"); // Reemplaza con el valor del campo de texto

                        command.Parameters.AddWithValue("@id", (int)selectedRowUsuario["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadUsuarios();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún usuario.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowUsuario != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM CredencialesUsuario WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowUsuario["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadUsuarios();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún usuario.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Cursos (Titulo, Descripcion, FechaInicio, FechaFin) VALUES (@titulo, @descripcion, @fechaInicio, @fechaFin)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@fechaInicio", DateTime.Now);
                    command.Parameters.AddWithValue("@fechaFin", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadCursos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el curso: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowCurso != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Cursos SET Titulo = @titulo, Descripcion = @descripcion, FechaInicio = @fechaInicio, FechaFin = @fechaFin WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@fechaInicio", DateTime.Now);
                        command.Parameters.AddWithValue("@fechaFin", DateTime.Now);

                        command.Parameters.AddWithValue("@id", (int)selectedRowCurso["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadCursos();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún curso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowCurso != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este curso?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Cursos WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowCurso["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadCursos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún curso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el curso: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Evaluaciones (Titulo, Descripcion, Fecha, CursoID) VALUES (@titulo, @descripcion, @fecha, @cursoID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadEvaluaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la evaluación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowEvaluacion != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Evaluaciones SET Titulo = @titulo, Descripcion = @descripcion, Fecha = @fecha, CursoID = @cursoID WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@fecha", DateTime.Now);
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                        command.Parameters.AddWithValue("@id", (int)selectedRowEvaluacion["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadEvaluaciones();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna evaluación.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowEvaluacion != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta evaluación?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Evaluaciones WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowEvaluacion["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadEvaluaciones();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna evaluación.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la evaluación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Materiales (Titulo, Descripcion, Tipo, CursoID) VALUES (@titulo, @descripcion, @tipo, @cursoID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@tipo", "NuevoTipo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadMateriales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el material: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowMaterial != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Materiales SET Titulo = @titulo, Descripcion = @descripcion, Tipo = @tipo, CursoID = @cursoID WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@tipo", "NuevoTipo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                        command.Parameters.AddWithValue("@id", (int)selectedRowMaterial["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadMateriales();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún material.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowMaterial != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este material?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Materiales WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowMaterial["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadMateriales();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún material.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el material: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarForo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Foros (Titulo, Descripcion, Fecha, CursoID) VALUES (@titulo, @descripcion, @fecha, @cursoID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadForos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el foro: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarForo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowForo != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Foros SET Titulo = @titulo, Descripcion = @descripcion, Fecha = @fecha, CursoID = @cursoID WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@fecha", DateTime.Now);
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                        command.Parameters.AddWithValue("@id", (int)selectedRowForo["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadForos();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún foro.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarForo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowForo != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este foro?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Foros WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowForo["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadForos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún foro.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el foro: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarCalificacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Calificaciones (UsuarioID, CursoID, Calificacion, Comentarios) VALUES (@usuarioID, @cursoID, @calificacion, @comentarios)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@usuarioID", 1); // Reemplaza con el ID del usuario correspondiente
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente
                    command.Parameters.AddWithValue("@calificacion", 0); // Reemplaza con el valor de la calificación
                    command.Parameters.AddWithValue("@comentarios", "NuevosComentarios"); // Reemplaza con el valor del campo de texto

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadCalificaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la calificación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarCalificacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowCalificacion != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Calificaciones SET UsuarioID = @usuarioID, CursoID = @cursoID, Calificacion = @calificacion, Comentarios = @comentarios WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@usuarioID", 1); // Reemplaza con el ID del usuario correspondiente
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente
                        command.Parameters.AddWithValue("@calificacion", 0); // Reemplaza con el valor de la calificación
                        command.Parameters.AddWithValue("@comentarios", "NuevosComentarios"); // Reemplaza con el valor del campo de texto

                        command.Parameters.AddWithValue("@id", (int)selectedRowCalificacion["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadCalificaciones();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna calificación.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarCalificacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowCalificacion != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta calificación?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Calificaciones WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowCalificacion["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadCalificaciones();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna calificación.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la calificación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarGrupo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Grupos (Nombre, Descripcion, CursoID) VALUES (@nombre, @descripcion, @cursoID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", "NuevoNombre"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadGrupos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el grupo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarGrupo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowGrupo != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Grupos SET Nombre = @nombre, Descripcion = @descripcion, CursoID = @cursoID WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@nombre", "NuevoNombre"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                        command.Parameters.AddWithValue("@id", (int)selectedRowGrupo["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadGrupos();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún grupo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarGrupo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowGrupo != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este grupo?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Grupos WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowGrupo["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadGrupos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún grupo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el grupo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Reportes (Titulo, Descripcion, Fecha, CursoID) VALUES (@titulo, @descripcion, @fecha, @cursoID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);
                    command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadReportes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el reporte: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizarReporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowReporte != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Reportes SET Titulo = @titulo, Descripcion = @descripcion, Fecha = @fecha, CursoID = @cursoID WHERE ID = @id";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@titulo", "NuevoTitulo"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@descripcion", "NuevaDescripcion"); // Reemplaza con el valor del campo de texto
                        command.Parameters.AddWithValue("@fecha", DateTime.Now);
                        command.Parameters.AddWithValue("@cursoID", 1); // Reemplaza con el ID del curso correspondiente

                        command.Parameters.AddWithValue("@id", (int)selectedRowReporte["ID"]);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadReportes();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún reporte.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminarReporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRowReporte != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este reporte?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Reportes WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", (int)selectedRowReporte["ID"]);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadReportes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún reporte.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el reporte: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
