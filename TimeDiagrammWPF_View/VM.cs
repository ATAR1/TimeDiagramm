using IntervalDatasources;
using JournalDbModel;
using MDT6DbModel;
using ScanerTubeInfoDbModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class VM : INotifyPropertyChanged, IDateTimeInterval
    {
        private Stream diagramm1;
        private Stream diagramm2;
        private Stream diagramm3;

        private IEnumerable<ICommand> _menuItems;
        public VM()
        {
            GenerateDiagrammCommand = new GenerateDiagrammCommand(this);
            SaveToFileCommand = new SaveToFileCommand(this);
            //todo CopyToClipBoardCommand = new CopyToClipBoardCommand(this);
            _menuItems = new List<ICommand>
            {
                new ClearLocalBDCommand(),
                new LoadDataCommand("Загрузить данные МДТ 6", new MDT6IntervalsSource("МДТ 6"), this),
                new LoadDataCommand("Загрузить данные МДТ 6.1", new MDT6IntervalsSource("МДТ 6.1"), this),
                //new LoadDataCommand("Загрузить данные сканера ТО1", new ScanerIntervalsSource(new FileSeeker(), "Сканер ТО1"), this),
                new LoadDataCommand("Загрузить данные сканера ТО1 из папки", new ScanerDirrectorySource(new DirectorySeeker(),"Сканер ТО1"), this),
                new LoadDataCommand("Загрузить данные из журнала дежурных", new TestAndTunesUptimesRepository(), this),
                new LoadDataCommand("Загрузить данные МДТ 6.2", new MDT6IntervalsSource("МДТ 6.2"), this),
                //new LoadDataCommand("Загрузить данные сканера ТО2 из файла", new ScanerIntervalsSource(new FileSeeker(), "Сканер ТО2"), this),
                //new LoadDataCommand("Загрузить данные сканера ТО2 из службы", new ScanerWcfClientDatasource("Сканер ТО2"), this),
                new LoadDataCommand("Загрузить данные сканера ТО2 из папки", new ScanerDirrectorySource(new DirectorySeeker(),"Сканер ТО2"), this),
            };
        }

        public IEnumerable<ICommand> MenuItems => _menuItems;

        public ICommand GenerateDiagrammCommand { get; private set; }

        //todo public ICommand CopyToClipBoardCommand { get; private set; }

        public ICommand SaveToFileCommand { get; }

        public Bitmap Bitmap1 { get; set; }
        public Bitmap Bitmap2 { get; set; }
        public Bitmap Bitmap3 { get; set; }

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

        DateTime _beginTime = DateTime.Today;
        public DateTime BeginTime
        {
            get { return _beginTime; }
            set
            {
                _beginTime = value;
                RaisePropertyChanged(nameof(BeginTime));
            }
        }

        DateTime _endTime = DateTime.Today;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                RaisePropertyChanged(nameof(EndTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}