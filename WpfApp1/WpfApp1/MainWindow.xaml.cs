using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;
using ColorPickerWPF;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            //this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary2.xaml") };
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void rtbEditor_SelectionChanged(object sender,RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);

            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);

            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            btnUnderLine.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);

            cmbFontFamily.SelectedItem = temp;
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(filestream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(filestream, DataFormats.Rtf);
            }
        }

        private void cmbFontFamily_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            if(cmbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }

        /*private void ClrPcker_Background_SelectedColorChanged(object sender, TextChangedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontStyleProperty, ClrPcker_Background.SelectedColorText);
            //TextBox.Text = "#" + ClrPcker_Background.SelectedColor.R.ToString() + ClrPcker_Background.SelectedColor.G.ToString() + ClrPcker_Background.SelectedColor.B.ToString();
        }*/

        private void ClrPcker_Background_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //rtbEditor.Selection.ApplyPropertyValue(Inline.FontStyleProperty, ClrPcker_Background.SelectedColor );
            //Background = new SolidColorBrush((Color)ClrPcker_Background.SelectedColor);
            if(rtbEditor != null)
            {
                //Background = new SolidColorBrush((Color)ClrPcker_Background.SelectedColor);
                rtbEditor.Foreground = new SolidColorBrush((Color)ClrPcker_Background.SelectedColor);
            }

        }

        int i = 1;
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox rc = new RichTextBox();
            rtbEditor = rc;
            Texts.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = $"new {i++}" },
                Content = rtbEditor
            });
            rc = rtbEditor;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary2.xaml") };
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary2.xaml") };
            this.Resources["btnBrush2"] = new SolidColorBrush(Colors.LimeGreen);//LinearGradientBrush(Colors.Green,VisualOffset);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary2.xaml") };
            this.Resources["btnBrush2"] = new SolidColorBrush(Colors.Coral);//LinearGradientBrush(Colors.Green,VisualOffset);
        }
    }

}
