using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace sistema_escolar
{
    public partial class menu : Form
    {

        private MySqlConnection conexion;
        private string cadenaConexion = "server=localhost;port=3307;database=sistema_escolar;uid=root;password=;";

        public menu()
        {
            InitializeComponent();
        }



        private void menu_Load(object sender, EventArgs e)
        {

            string connectionString = "server=localhost;port=3307;database=sistema_escolar;uid=root;password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    dataGridView1.Rows.Clear();
                    connection.Open();
                    MessageBox.Show("Conexión exitosa");

                    // Aquí puedes ejecutar consultas, por ejemplo:
                    string query = "SELECT * FROM alumnos";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Aquí puedes procesar los datos obtenidos
                            int columna1 = reader.GetInt32("id_alumno");
                            String columna2 = reader.GetString("apellido_1");
                            String columna3 = reader.GetString("apellido_2");
                            String columna4 = reader.GetString("nombre_alumno");
                            String columna5 = reader.GetString("correo_alumno");
                            dataGridView1.Rows.Add(columna1, columna2, columna3, columna4, columna5);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "server=localhost;port=3307;database=sistema_escolar;uid=root;password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa");

                    // Ejemplo de INSERT
                    string insertQuery = "INSERT INTO alumnos (id_alumno, apellido_1, apellido_2, nombre_alumno, correo_alumno) VALUES (@valor1, @valor2, @valor3, @valor4, @valor5)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);

                    // Parámetros para el INSERT
                    insertCommand.Parameters.AddWithValue("@valor1", textBox1.Text);
                    insertCommand.Parameters.AddWithValue("@valor2", textBox2.Text);
                    insertCommand.Parameters.AddWithValue("@valor3", textBox3.Text);
                    insertCommand.Parameters.AddWithValue("@valor4", textBox4.Text);
                    insertCommand.Parameters.AddWithValue("@valor5", textBox5.Text);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    // MessageBox.Show("Filas afectadas por el INSERT: " + rowsAffected);
                    menu_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                try
                {
                    string connectionString = "server=localhost;port=3307;database=sistema_escolar;uid=root;password=;";
                    string query = "UPDATE alumnos SET apellido_1 = @apellido1, apellido_2 = @apellido2, nombre_alumno = @nombre, correo_alumno = @correo WHERE id_alumno = @idAlumno";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parámetros para los datos actualizados del alumno
                        command.Parameters.AddWithValue("@apellido1", textBox2.Text);
                        command.Parameters.AddWithValue("@apellido2", textBox3.Text);
                        command.Parameters.AddWithValue("@nombre", textBox4.Text);
                        command.Parameters.AddWithValue("@correo", textBox5.Text);
                        command.Parameters.AddWithValue("@idAlumno", textBox1.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Se actualizaron correctamente los datos del alumno con ID " + textBox1.Text);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún alumno con el ID " + textBox1.Text);
                        }

                        // Actualizar la vista después de modificar el alumno
                        menu_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del alumno: " + ex.Message);
                }
            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;port=3307;database=sistema_escolar;uid=root;password=;";
                string query = "DELETE FROM alumnos WHERE id_alumno = @idAlumno";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Parámetro para el ID del alumno
                    command.Parameters.AddWithValue("@idAlumno", textBox1.Text);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Se eliminó correctamente el alumno con ID " + textBox1.Text);

                    // Actualizar la vista después de eliminar el alumno
                    menu_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el alumno: " + ex.Message);
            }
        }
    }

}