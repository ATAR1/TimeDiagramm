using JournalDbModel;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class VM:INotifyPropertyChanged,IDateTimeInterval
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
            LoadJournalCommand = new LoadDataCommand("Загрузить данные из журнала дежурных", new TestAndTunesUptimesRepository(), this);
        }

        public ICommand GenerateDiagrammCommand { get; private set; }
        public ICommand ClearLocalBDCommand { get; private set; }

        public ICommand LoadMDT6DataCommand { get; private set; }

        public ICommand LoadDataScanerCommand { get; private set; }

        public ICommand LoadJournalCommand { get; private set; }

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

        public DateTime BeginTime{get; set;}

        public DateTime EndTime{get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}