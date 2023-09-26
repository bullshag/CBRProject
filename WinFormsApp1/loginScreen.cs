namespace WinFormsApp1
{
    using MySqlConnector;
    using System.Diagnostics;

    public partial class loginScreen : Form
    {
        public string username;

        public string password;
        public loginScreen()
        {
            InitializeComponent();
            persistantData.firstLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            Debug.WriteLine("Trying to connect..");
            username = textBox1.Text;
            password = textBox2.Text;
            try
            {
                connection.Open();

                Console.WriteLine("Connected!");

                // Check if the account already exists
                string checkAccountQuery = "SELECT COUNT(*) FROM accounts WHERE username = @username";
                MySqlCommand checkAccountCmd = new MySqlCommand(checkAccountQuery, connection);
                checkAccountCmd.Parameters.AddWithValue("@username", username);

                long count = (long)checkAccountCmd.ExecuteScalar();

                if (count == 0)
                {
                    // Create a new account
                    string createAccountQuery = "INSERT INTO accounts (uid, username, password) VALUES (0, @username, @password)";
                    MySqlCommand createAccountCmd = new MySqlCommand(createAccountQuery, connection);
                    createAccountCmd.Parameters.AddWithValue("@username", username);
                    createAccountCmd.Parameters.AddWithValue("@password", password);  // Consider hashing the password

                    createAccountCmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully!");
                }
                else
                {
                    MessageBox.Show("Account already exists.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem boss!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=accounts;User ID=root;Password=123321;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            Debug.WriteLine("Trying to connect..");
                 username = textBox1.Text;

                 password = textBox2.Text;
            try
            {
                connection.Open();

                Console.WriteLine("Connected!");

                // Check if the account already exists
                string checkAccountQuery = "SELECT COUNT(*) FROM accounts WHERE username =@username AND password = @password";
                MySqlCommand checkAccountCmd = new MySqlCommand(checkAccountQuery, connection);
                checkAccountCmd.Parameters.AddWithValue("@username", username);
                checkAccountCmd.Parameters.AddWithValue("@password", password);

                long count = (long)checkAccountCmd.ExecuteScalar();

                string fetchUIDQuery = "SELECT uid FROM accounts WHERE username = @username AND password = @password";
                MySqlCommand fetchUIDCmd = new MySqlCommand(fetchUIDQuery, connection);
                fetchUIDCmd.Parameters.AddWithValue("@username", username);
                fetchUIDCmd.Parameters.AddWithValue("@password", password);  // In a real application, consider hashing the password

                object result = fetchUIDCmd.ExecuteScalar();

                if (result != null)
                {
                    persistantData.persistantUID = Convert.ToInt32(result);
                }
                if (count == 1)
                {
                    MessageBox.Show("Logged in with UID: " + persistantData.persistantUID);
                    persistantData.hubScreen.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine("Problem boss!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
    }
}
