using NHibernate;
using System.Windows;
using System.Windows.Input;

namespace AddressBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleRepository repository = new PeopleRepository();

        // инициализировать и вывести данные из бд
        public MainWindow()
        {             
            InitializeComponent();
            
            ReadDB();
        }

        //При нажати сделать:
        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            //Проверка что бы строки небыли пустыми
            if (txtlastName.Text != "" && txtfirstName.Text != "")
            {
               //вызываеться класс и присваиваются данные
                var person = new People
                {
                    FirstName = txtfirstName.Text,
                    LastName = txtlastName.Text,
                    NickName = txtnickName.Text,
                    Address = txtaddress.Text,
                    Email = txtemail.Text,
                    Phone = txtphone.Text,
                    ICQ = txticq.Text,
                    Skype = txtskype.Text
                };

                //сылаеться в репозирорий и задает действие
                repository.Add(person);

                //обновляет ListView
                ReadDB();

                //отчищает Textbox
                ClearTextBox();
            }
            
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (People)LvPeople.SelectedItem;

            //проверяет на выделение обьекта
            if (LvPeople.SelectedItem != null)
            {
                if (txtlastName.Text != "" && txtfirstName.Text != "")
                {
                    selected.FirstName = txtfirstName.Text;
                    selected.LastName = txtlastName.Text;
                    selected.NickName = txtnickName.Text;
                    selected.Address = txtaddress.Text;
                    selected.Email = txtemail.Text;
                    selected.Phone = txtphone.Text;
                    selected.ICQ = txticq.Text;
                    selected.Skype = txtskype.Text;

                    repository.Update(selected);

                    ReadDB();

                    ClearTextBox();
                }
            }
            
            
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (People)LvPeople.SelectedItem;

            if (LvPeople.SelectedItem != null)
            {
                repository.Delete(selected);

                ReadDB();

                ClearTextBox();
            }
        }

        private void ClearTextBox()
        {
            txtlastName.Clear();
            txtfirstName.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            txticq.Clear();
            txtphone.Clear();
            txtskype.Clear();
            txtnickName.Clear();
        }

        public void ReadDB()
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {   
                   var read = session.Query<People>();

                    LvPeople.ItemsSource = read;
                }
            }
        }

        private void LvPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //переносить информацию в TextBox из класса если она имееться у него
            if (LvPeople.SelectedItem != null)
            {
                txtfirstName.Text = (LvPeople.SelectedItem as People).FirstName;
                txtlastName.Text = (LvPeople.SelectedItem as People).LastName;
                txtemail.Text = (LvPeople.SelectedItem as People).Email;
                txtphone.Text = (LvPeople.SelectedItem as People).Phone;
                txtnickName.Text = (LvPeople.SelectedItem as People).NickName;
                txtaddress.Text = (LvPeople.SelectedItem as People).Address;
                txticq.Text = (LvPeople.SelectedItem as People).ICQ;
                txtskype.Text = (LvPeople.SelectedItem as People).Skype;
            }
        }
    }
}
