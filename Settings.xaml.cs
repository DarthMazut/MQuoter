using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MQuoter
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public Brush ChoosenBrush { get; private set; }

        public Settings(Brush colorName)
        {
            InitializeComponent();
            xe_Rectangle.Fill = colorName;
            SetDDListProperSelection(colorName);
        }

        private void SetDDListProperSelection(Brush colorName)
        {
            for (int i = 0; i < xe_DDList.Items.Count; i++)
            {
                string s = xe_DDList.Items.GetItemAt(i).ToString();
                s = s.Substring(s.IndexOf(" "));
                Brush currentColor = (SolidColorBrush)new BrushConverter().ConvertFromString(s);
                if (currentColor.ToString() == colorName.ToString())
                {
                    xe_DDList.SelectedIndex = i;
                    break;
                }
            }
        }

        private void em_OnSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                xe_Rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(xe_DDList.SelectedValue.ToString());
                ChoosenBrush = xe_Rectangle.Fill;
            }
            catch (Exception){}
        }

        private void em_Default_OnClick(object sender, RoutedEventArgs e)
        {
            xe_DDList.SelectedValue = "SkyBlue";
            xe_Rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(xe_DDList.SelectedValue.ToString());
            ChoosenBrush = xe_Rectangle.Fill;
        }

        private void em_Apply_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Properties.Settings.Default.BorderColor = (SolidColorBrush)ChoosenBrush;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
