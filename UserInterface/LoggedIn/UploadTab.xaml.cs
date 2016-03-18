﻿using System;
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

namespace UserInterface
{
    using Interfaces;

    using Microsoft.Win32;

    using ViewModel;
    /// <summary>
    /// Interaction logic for UploadTab.xaml
    /// </summary>
    public partial class UploadTab : Window
    {
        private View parent;

        private IUploadViewModel uploadViewModel;

        private int authorId;

        private string filePath = string.Empty;

        public UploadTab(ref View parent, int authorId)
        {

            this.parent = parent;
            this.authorId = authorId;
            this.uploadViewModel = new UploadViewModel();
            this.InitializeComponent();
        }

        private void BtnUploadBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            FileDialog filePath = new OpenFileDialog();
            if ((bool)filePath.ShowDialog())
            {
                this.filePath = filePath.FileName;
            }
        }

        private void BtnUploadSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.uploadViewModel.Upload(this.authorId,this.filePath, TxtUploadTitle.Text, TxtUploadDescription.Text))
            {
                MessageBox.Show("Starting upload");
            }
            else
            {
                MessageBox.Show("Something fucked up");
            }
        }
    }
}
