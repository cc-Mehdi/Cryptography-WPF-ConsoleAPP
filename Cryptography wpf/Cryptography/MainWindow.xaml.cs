using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cryptography
{
    /// <summary>
    // Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] key = new int[3, 3];
        private bool isEncode = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHillCheaper_Click(object sender, RoutedEventArgs e)
        {
            if (checkInputs())
            {
                HillCheaper.Program _hillCheaper = new HillCheaper.Program();
                _hillCheaper.getKey(key);
                _hillCheaper.getPlainText(txtInput.Text);
                _hillCheaper.initialize();
                if (isEncode)
                    txtOutput.Text = _hillCheaper.resultEncription;
                else
                    txtOutput.Text = _hillCheaper.resultDecription;
                _hillCheaper = new();
            }
            else
                MessageBox.Show("Please enter all key items and plain text between a, z!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool checkInputs()
        {
            //check plain text
            if (isEncode)
            {
                txtInput.Text = txtInput.Text.ToLower().Replace(" ", "");
                char[] ch = txtInput.Text.ToCharArray();
                for (int i = 0; i < ch.Length; i++)
                    if (ch[i] < 97 || ch[i] > 123)
                        return false;
            }

            //check key
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (key[i, j] == 0)
                        return false;

            return true;
        }

        private void txtK1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[0, 0] = Convert.ToInt32(txtK1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK1.Text = "";
            }
        }

        private void txtK2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[0, 1] = Convert.ToInt32(txtK2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK2.Text = "";
            }
        }

        private void txtK3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[0, 2] = Convert.ToInt32(txtK3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK3.Text = "";
            }
        }

        private void txtK4_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[1, 0] = Convert.ToInt32(txtK4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK4.Text = "";
            }
        }

        private void txtK5_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[1, 1] = Convert.ToInt32(txtK5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK5.Text = "";
            }
        }

        private void txtK6_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[1, 2] = Convert.ToInt32(txtK6.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK6.Text = "";
            }
        }

        private void txtK7_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[2, 0] = Convert.ToInt32(txtK7.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK7.Text = "";
            }
        }

        private void txtK8_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[2,1] = Convert.ToInt32(txtK8.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK8.Text = "";
            }
        }

        private void txtK9_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                key[2, 2] = Convert.ToInt32(txtK9.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct numbers not text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtK9.Text = "";
            }
        }

        private void btnEncode_Click(object sender, RoutedEventArgs e)
        {
            isEncode = true;
            btnEncode.Background = new SolidColorBrush(Color.FromArgb(250, 53, 180, 180));
            btnDecode.Background = new SolidColorBrush(Color.FromArgb(250, 221, 221, 221));
        }

        private void btnDecode_Click(object sender, RoutedEventArgs e)
        {
            isEncode = false;
            btnDecode.Background = new SolidColorBrush(Color.FromArgb(250, 53, 180, 180));
            btnEncode.Background = new SolidColorBrush(Color.FromArgb(250, 221, 221, 221));
        }
    }
}
