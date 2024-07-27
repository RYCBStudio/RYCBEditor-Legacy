using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IDE.Utils.PackageManager
{
    class FrmWPFDownloadProgressViewModel : ObservableObject
    {
        private bool _isi;
        public bool IsIntermediate
        {
            get => _isi;
            set
            {
                _isi = value;
                OnPropertyChanged();
            }
        }

        private bool _issi;
        public bool IsSingleIntermediate
        {
            get => _issi;
            set
            {
                _issi = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _sv;
        public int SingleValue
        {
            get => _sv;
            set
            {
                _sv = value;
                OnPropertyChanged();
            }
        }

        private int _sm;
        public int SingleMaximum
        {
            get => _sm;
            set
            {
                _sm = value;
                OnPropertyChanged();
            }
        }

        private int _val;
        public int Value
        {
            get => _val;
            set
            {
                _val = value;
                OnPropertyChanged();
            }
        }

        private int _max;
        public int Maximum
        {
            get => _max;
            set
            {
                _max = value;
                OnPropertyChanged();
            }
        }
    }
}
