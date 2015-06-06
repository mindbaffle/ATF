﻿//Copyright © 2014 Sony Computer Entertainment America LLC. See License.txt.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalizableStringExtractor
{
    /// <summary>
    /// Interaction logic</summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            var progressBar = (ProgressBar)this.FindName("ExtractionProgressBar");
            progressBar.Minimum = 0;
            progressBar.Maximum = 1;
            progressBar.Value = 0;
            m_extractor.ProgressChanged += (sender, args) =>
            {
                progressBar.Value = m_extractor.Progress;
            };
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            m_extractor.ExtractAll();
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DirectoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            m_extractor.OpenSettingsFile();
        }

        private readonly Extractor m_extractor = new Extractor();
    }
}
