using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IDE.Utils.PackageManager
{
    public class FrmWPFPackageViewModel : ObservableObject
    {
        private TabItem _cp;
        public TabItem CurrentPage
        {
            get => _cp;
            set
            {
                _cp = value;
                OnPropertyChanged();
            }
        }

        private int _slctdpkgs;
        public int SelectedPackages
        {

            get => _slctdpkgs;
            set
            {
                _slctdpkgs = value;
                OnPropertyChanged();
            }
        }
    }
}