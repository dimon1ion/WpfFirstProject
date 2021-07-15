using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfFirstProject
{
    class DataSource : INotifyPropertyChanged
    {
        Command blueCommand;
        Command redCommand;
        Command greenCommand;
        Command purpleCommand;
        string selectedColor = "Black";
        public DataSource()
        {
            blueCommand = new DelegateCommand(
                () => SelectedColor = "Blue", //Execute
                () => SelectedColor != "Blue"); //Can Execute check
            redCommand = new DelegateCommand(
                () => SelectedColor = "Red", //Execute
                () => SelectedColor != "Red"); //Can Execute check
            greenCommand = new DelegateCommand(
                () => SelectedColor = "Green", //Execute
                () => SelectedColor != "Green"); //Can Execute check
            purpleCommand = new DelegateCommand(
                () => SelectedColor = "Purple", //Execute
                () => SelectedColor != "Purple"); //Can Execute check
            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(nameof(SelectedColor)))
                {
                    blueCommand.RiseOnCanExecuteChanged();
                    redCommand.RiseOnCanExecuteChanged();
                    greenCommand.RiseOnCanExecuteChanged();
                    purpleCommand.RiseOnCanExecuteChanged();
                }
            };
        }

        public ICommand BlueCommand => blueCommand;
        public ICommand RedCommand => redCommand;
        public ICommand GreenCommand => greenCommand;
        public ICommand PurpleCommand => purpleCommand;

        public string SelectedColor
        {
            get => selectedColor;
            set
            {
                if (!selectedColor.Equals(value))
                {
                    selectedColor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
