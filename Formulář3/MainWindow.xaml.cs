using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Formulář3
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public MainWindow()
        {
            InitializeComponent();
			DataContext = this;
			ErrorLabelName.DataContext = this;
			ErrorLabelSurname.DataContext = this;
		}
		private bool CheckNameOK()
		{
			if (Name.Text.Length > 0)
			{
				NameErrorVisible = Visibility.Hidden;
				return true;
			}
			else
			{
				NameErrorVisible = Visibility.Visible;
				return false;
			}
		}

		private Visibility _NameErrorVisible;
		public Visibility NameErrorVisible
		{
			get
			{
				return _NameErrorVisible;
			}

			set
			{
				_NameErrorVisible = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
			}
		}

		private string _NameError = "Jméno je povinná položka.";
		public string NameError
		{
			get
			{
				return _NameError;
			}
		}

		private bool CheckSurnameOK()
		{
			if (Surname.Text.Length > 1 && Surname.Text.Length < 20)
			{
				SurnameErrorVisible = Visibility.Hidden;
				return true;
			}
			else
			{
				SurnameErrorVisible = Visibility.Visible;
				SurnameError = "Cokoliv";
				return false;
			}
		}

		private Visibility _SurnameErrorVisible;
		public Visibility SurnameErrorVisible
		{
			get
			{
				return _SurnameErrorVisible;
			}

			set
			{
				_NameErrorVisible = value;
				PropertyChanged(this, new PropertyChangedEventArgs("SurnameErrorVisible"));
			}
		}

		private string _SurnameError;
		public string SurnameError
		{
			get
			{
				return _SurnameError;
			}

			set
			{
				if (Surname.Text.Length < 2)
					_SurnameError = "Jméno nemůže být kratší než 2 znaky.";
				else if (Surname.Text.Length > 20)
					_SurnameError = "Jméno nemůže být delší než 20 znaků.";
				else
					_SurnameError = "";
				PropertyChanged(this, new PropertyChangedEventArgs("SurnameError"));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Name_TextChanged(object sender, TextChangedEventArgs e)
		{
			CheckNameOK();
		}

		private void Surname_TextChanged(object sender, TextChangedEventArgs e)
		{
			CheckSurnameOK();
		}

    }

    class Person
    {
        public string name;
        public string surname;
        public int yearBirth;
        
        public Person() { }
        public Person(string Name, string Surname, int year)
        {
            name = Name;
            surname = Surname;
            yearBirth = year;
        }
    }
    class Employee : Person
    {
        public static List<Employee> Employees = new List<Employee>();
        
		public string jobPosition;
        public int grossIncome;
        public string education;
        
        public Employee() : base()
        { }
        public Employee(string Name, string Surname, int year, string job, int income) : base(Name, Surname, year)
        {
            jobPosition = job;
            grossIncome = income;
        }
    }

}
