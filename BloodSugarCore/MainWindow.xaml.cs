using BloodSugarCore.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace BloodSugarCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BuildReadingsList();
            bloodReadings = new ObservableCollection<BloodReading>();
            ReadingsList.ItemsSource = bloodReadings;
        }

        private ObservableCollection<BloodReading> bloodReadings;
        public ObservableCollection<BloodReading> BloodReadingList
        {
            get => bloodReadings;
            set
            {
                if (bloodReadings == value) return;
                bloodReadings = value;
                OnPropertyChanged("BloodReadingList");
            }
        }

        private BloodReading selectedBloodReading;
        public BloodReading SelectedBloodReading
        {
            get => selectedBloodReading;
            set
            {
                if (selectedBloodReading == value) return;
                selectedBloodReading = value;
                OnPropertyChanged("SelectedBloodReading");
            }
        }

        private void BuildReadingsList()
        {
            using (var db = new SqliteDbContext())
            {
                bloodReadings = new ObservableCollection<BloodReading>(db.BloodReadings.OrderBy(x => x.ReadingDate).ToList());
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedBloodReading != null) return;

                using (var db = new SqliteDbContext())
                {
                    BloodReading bloodReading = new BloodReading();
                    if (!string.IsNullOrEmpty(txtReadingDate.Text))
                        bloodReading.ReadingDate = txtReadingDate.Text;
                    if (!string.IsNullOrEmpty(txtReadingTime.Text))
                        bloodReading.ReadingTime = txtReadingTime.Text;
                    if (!string.IsNullOrEmpty(txtReading.Text))
                        bloodReading.ReadingValue = decimal.Parse(txtReading.Text);

                    db.BloodReadings.Add(bloodReading);
                    db.SaveChanges();
                    CollectionViewSource.GetDefaultView(BloodReadingList).Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        public virtual string DisplayName { get; protected set; }
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = $"Invalid property name: {propertyName}";
                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);

                Debug.Fail(msg);
            }
        }
    }
}
