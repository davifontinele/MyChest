using MyChest.Data.DAO;
using MyChest.Extensions;
using MyChest.Forms;
using MyChest.Interfaces;
using MyChest.Models;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyChest
{
    public partial class HomeForm : Form
    {
        protected User? _userLoged;
        protected LoginForm? _loginForm;
        public HomeForm(User userLoged, LoginForm loginForm)
        {
            InitializeComponent();
            _userLoged = userLoged;
            _loginForm = loginForm;
            btnUserInfo.Text = _userLoged.Name;
        }

        public HomeForm()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Apenas para teste, remover depois
            if (_userLoged != null)
            {
                HideAndDisableButtons();
                ConfigureUIByUserPermissions();
            }
            DataGridProductLoad();
            comboBoxSearch.SelectedIndex = 0;
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm!.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            DataGridProductLoad();
        }

        private void btnUserLoged_Click(object sender, EventArgs e)
        {
            UserLogedForm userForm = new UserLogedForm(_userLoged!, this, _loginForm);
            userForm.ShowDialog();
        }

        // OBS: Precisamos fazer um sistema de verifica��o dos dados no DB para implementarem com essa funcionalidade de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Voc� tem certeza que deseja excluir os itens selecionados?", "Confirma��o de Exclus�o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        for (int a = listBoxWarning.SelectedIndices.Count - 1; a >= 0; a--)
                        {
                            listBoxWarning.Items.RemoveAt(listBoxWarning.SelectedIndices[a]);
                        }
                    }
                }
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            DataGridUserLoad();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            DataGridAddressLoad();
        }

        private void btnMoveProduct_Click(object sender, EventArgs e)
        {
            MoveProdForm moveProdForm = new MoveProdForm();
            moveProdForm.ShowDialog();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 1 && dataGrid.Columns.Count == 6)
            {
                Product selectedProduct = new Product(
                    // Code
                    Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value),

                    // Nome
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[1].Value)!,

                    // Marca
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[2].Value)!,

                    // Quantidade
                    Convert.ToInt32(dataGrid.SelectedRows[0].Cells[3].Value),

                    // Tags
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[4].Value)!,

                    // Medida
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[5].Value)!
                    );

                ProductInfoForm newForm = new ProductInfoForm(selectedProduct);
                newForm.Show();

                newForm.Owner = this;
            }
            else if (dataGrid.SelectedRows.Count == 1 && dataGrid.Columns.Count == 3)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                User selectedUser = new User(selectedRow.Cells[0].Value.ToString()!, selectedRow.Cells[1].Value.ToString()!);
                UserInfoForm newUserInfoForm = new UserInfoForm(selectedUser);
                newUserInfoForm.Show();

                newUserInfoForm.Owner = this;
            }
        }

        private void btnReceiptProduct_Click(object sender, EventArgs e)
        {
            ReceiptProductForm newForm = new ReceiptProductForm();
            newForm.ShowDialog();

            newForm.Owner = this;
        }

        private void maskTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGrid.Columns.Count == 5)
            {
                string[] addressNumbers = maskTextSearch.Text.Split('-');
                Address searchAddress = new Address
                {
                    Corridor = addressNumbers[0].ConvertToInt32(),
                    Column = addressNumbers[1].ConvertToInt32(),
                    Level = addressNumbers[2].ConvertToInt32(),
                    Hall = addressNumbers[3].ConvertToInt32(),
                };

                AddressDAO addressDAO = new AddressDAO();

                dataGrid.Rows.Clear();
                dataGrid.Rows.Add(
                    addressDAO.GetAddressByNumbers(searchAddress.Corridor, searchAddress.Column, searchAddress.Level, searchAddress.Hall).Corridor,
                    addressDAO.GetAddressByNumbers(searchAddress.Corridor, searchAddress.Column, searchAddress.Level, searchAddress.Hall).Column,
                    addressDAO.GetAddressByNumbers(searchAddress.Corridor, searchAddress.Column, searchAddress.Level, searchAddress.Hall).Level,
                    addressDAO.GetAddressByNumbers(searchAddress.Corridor, searchAddress.Column, searchAddress.Level, searchAddress.Hall).Hall,
                    addressDAO.GetAddressByNumbers(searchAddress.Corridor, searchAddress.Column, searchAddress.Level, searchAddress.Hall).ProductCode);
            }

            if (e.KeyCode == Keys.Enter)
            {
                // C�digo
                if (dataGrid.ColumnCount == 6 && comboBoxSearch.SelectedIndex == 0)
                {
                    ProductDAO productDAO = new ProductDAO();
                    if (maskTextSearch.Text.TestConvertToInt32())
                    {
                        Product product = ((IData<Product>)productDAO).GetById(maskTextSearch.Text.ConvertToInt32());
                        foreach (var item in productDAO.GetProductTags(product.Code))
                        {
                            product.Tags += item + " ";
                        }

                        dataGrid.Rows.Clear();
                        dataGrid.Rows.Add(product.Code, product.Name, product.Brand, product.Amount, product.Tags, product.Measure);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira um n�mero v�lido para a busca por c�digo.");
                    }
                }
                // Nome
                else if (comboBoxSearch.SelectedIndex == 1)
                {
                    ProductDAO productDAO = new ProductDAO();
                    if (Regex.IsMatch(maskTextSearch.Text, "^[a-zA-Z ]+$"))
                    {
                        Product product = productDAO.GetByName(maskTextSearch.Text.ToUpper());
                        foreach (var item in productDAO.GetProductTags(product.Code))
                        {
                            product.Tags += item + " ";
                        }

                        dataGrid.Rows.Clear();
                        dataGrid.Rows.Add(product.Code, product.Name, product.Brand, product.Amount, product.Tags, product.Measure);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira apenas letras para a busca por nome.");
                    }
                }
                // Marca
                else if (comboBoxSearch.SelectedIndex == 2)
                {
                    ProductDAO productDAO = new ProductDAO();
                    if (Regex.IsMatch(maskTextSearch.Text, "^[a-zA-Z ]+$"))
                    {
                        Product product = productDAO.GetByBrand(maskTextSearch.Text);
                        foreach (var item in productDAO.GetProductTags(product.Code))
                        {
                            product.Tags += item + " ";
                        }

                        dataGrid.Rows.Clear();
                        dataGrid.Rows.Add(product.Code, product.Name, product.Brand, product.Amount, product.Tags, product.Measure);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira apenas letras para a busca por marca.");
                    }
                }
                // Tags
                else if (comboBoxSearch.SelectedIndex == 3)
                {
                    ProductDAO productDAO = new ProductDAO();
                    if (Regex.IsMatch(maskTextSearch.Text, "^[a-zA-Z]+$"))
                    {
                        dataGrid.Rows.Clear();
                        foreach (var item in productDAO.GetProductByTag(maskTextSearch.Text.ToUpper().Trim()))
                        {
                            dataGrid.Rows.Add(item.Code, item.Name, item.Brand, item.Amount, item.Tags, item.Measure);
                        }
                    }
                }
                // Medida
                else if (comboBoxSearch.SelectedIndex == 4)
                {
                    ProductDAO productDAO = new ProductDAO();
                    if (Regex.IsMatch(maskTextSearch.Text, "^[a-zA-Z]+$"))
                    {
                        dataGrid.Rows.Clear();
                        foreach (var item in productDAO.GetProductByMeasureType(maskTextSearch.Text.ToUpper().Trim()))
                        {
                            dataGrid.Rows.Add(item.Code, item.Name, item.Brand, item.Amount, item.Tags, item.Measure);
                        }
                    }
                }
            }
        }

        private void picBoxSearcIcon_Click(object sender, EventArgs e)
        {
            if (comboBoxSearch.Visible || comboBoxSearch.Enabled)
            {
                comboBoxSearch.Visible = false;
                comboBoxSearch.Enabled = false;
            }
            else if (dataGrid.ColumnCount == 6)
            {
                comboBoxSearch.Visible = true;
                comboBoxSearch.Enabled = true;
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSearch.Visible = false;
            comboBoxSearch.Enabled = false;
        }

        private void picBoxAdd_Click(object sender, EventArgs e)
        {
            if (dataGrid.Columns.Count == 3)
            {
                AddUserForm AddUserForm = new AddUserForm();
                AddUserForm.ShowDialog();
            }
            else if (dataGrid.Columns.Count == 5)
            {
                AddAddressForm addAddressForm = new AddAddressForm();
                addAddressForm.ShowDialog();
            }
        }

        private void dataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && dataGrid.ColumnCount == 3)
            {
                var hit = dataGrid.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGrid.ClearSelection();
                    dataGrid.Rows[hit.RowIndex].Selected = true;
                }
            }
        }
    }
}
