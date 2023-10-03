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
                    string createAccountQuery = "INSERT INTO accounts (uid, username, password, money) VALUES (0, @username, @password, 100)";
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

                string fetchUIDAndMoneyQuery = "SELECT uid, money FROM accounts WHERE username = @username AND password = @password";
                MySqlCommand fetchUIDAndMoneyCmd = new MySqlCommand(fetchUIDAndMoneyQuery, connection);
                fetchUIDAndMoneyCmd.Parameters.AddWithValue("@username", username);
                fetchUIDAndMoneyCmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = fetchUIDAndMoneyCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        persistantData.persistantUID = reader.GetInt32("uid");
                        persistantData.money = reader.GetInt32("money");
                    }
                }

                if (persistantData.persistantUID > 0)
                {
                    MessageBox.Show("Logged in with UID: " + persistantData.persistantUID + " and money: " + persistantData.money);
                    persistantData.hubScreen.Visible = true;
                    persistantData.hubScreen.populateCharacters();
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

            persistantData.firstLoad();
        }
    }
}

