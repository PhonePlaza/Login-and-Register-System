using System.Data.OleDb;

namespace Login_and_Register_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\WINDOWS10\\Desktop\\C#\\Login and Register System\\Login and Register System\\bin\\Debug\\db_users.mdb\"");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "") 
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtusername.Text + "','" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register,con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtusername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Password does not match,Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtusername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}