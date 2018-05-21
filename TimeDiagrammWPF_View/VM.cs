using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TimeDiagrammGeneratorLibrary;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammWPF_View
{
    internal class VM:INotifyPropertyChanged
    {
        private Stream diagramm1;
        private Stream diagramm2;
        private Stream diagramm3;
        public VM()
        {
            ClearLocalBDCommand = new ClearLocalBDCommand();
            GenerateDiagrammCommand = new GenerateDiagrammCommand(this);
            LoadMDT6DataCommand = new LoadMDT6DataCommand();
            LoadDataScanerCommand = new LoadDataScanerCommand();

        }

        public ICommand GenerateDiagrammCommand { get; private set; }
        public ICommand ClearLocalBDCommand { get; private set; }

        public ICommand LoadMDT6DataCommand { get; private set; }

        public ICommand LoadDataScanerCommand { get; set; }

        public Stream Diagramm
        {
            get
            {
                return diagramm1;
            }
            set
            {
                if (diagramm1 != value)
                {
                    diagramm1 = value;
                    RaisePropertyChanged(nameof(Diagramm));
                }
            }
        }

        public Stream Diagramm2
        {
            get
            {
                return diagramm2;
            }
            set
            {
                if (diagramm2 != value)
                {
                    diagramm2 = value;
                    RaisePropertyChanged(nameof(Diagramm2));
                }
            }
        }

        public Stream Diagramm3
        {
            get
            {
                return diagramm3;
            }
            set
            {
                if (diagramm3 != value)
                {
                    diagramm3 = value;
                    RaisePropertyChanged(nameof(Diagramm3));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}