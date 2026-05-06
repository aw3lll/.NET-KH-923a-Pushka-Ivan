using System.Windows;
using Core;

namespace WpfApp___Lab7
{
    public partial class MovieEditWindow : Window
    {
        public Movie? ResultMovie { get; private set; }
        public MovieEditWindow() => InitializeComponent();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtDuration.Text, out int dur) && double.TryParse(txtRating.Text, out double rat))
            {
                ResultMovie = new Movie(txtTitle.Text, dur, rat, txtGenre.Text, chk3D.IsChecked ?? false);
                DialogResult = true;
            }
            else MessageBox.Show("Введіть коректні числа!");
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}