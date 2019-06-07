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
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;

namespace HCI_zadatak_2.popups
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        MainWindow _parent;
        public MainWindow parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged("parent"); }
        }

        public Event e { get; set; }

        public AddEvent(MainWindow parent, Event e)
        {
            InitializeComponent();
            DataContext = this;
            this.parent = parent;
            this.e = e;
        }

        private void CreateEventBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(parent.appContext.Tags.Count+"");
        }
    }
}
