using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab03
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

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=Tecsup2023DB;User Id = user01;Password=123456";

            List<Student> students = new List<Student>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM STUDENTS", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId = reader.GetInt32("StudentId");
                    string FirstName = reader.GetString("FirstName");
                    string LastName = reader.GetString("LastName");
                    students.Add(new Student { StudentId = StudentId, FirstName = FirstName, LastName=LastName });
                }

                dataGrid1.ItemsSource = students;

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            var parametro = Textbox1.Text;

            string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=Tecsup2023DB;User Id = user01;Password=123456";

            List<Student> students = new List<Student>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM STUDENTS WHERE FirstName='"+parametro+"'", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId = reader.GetInt32("StudentId");
                    string FirstName = reader.GetString("FirstName");
                    string LastName = reader.GetString("LastName");
                    students.Add(new Student { StudentId = StudentId, FirstName = FirstName, LastName = LastName });
                }

                dataGrid1.ItemsSource = students;

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}