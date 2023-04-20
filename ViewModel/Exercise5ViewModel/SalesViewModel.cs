
using Chapter9.Model.Exercise5Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter9.ViewModel.Exercise5ViewModel.ViewModelSales
{
    public class SalesViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<SalesModel> SalesDetails { get; set; }
       
        public SalesViewModel()
        {
            Details();
        }

        public void Details()
        {
            SalesDetails = new ObservableCollection<SalesModel>
            {
                new SalesModel()
                {
                    Title= " The complete sales app for your company",
                    ImageSource="burger"
                },
                new SalesModel()
                {
                    Title= " The complete sales app for your company",
                    ImageSource="cooking"
                },
                new SalesModel()
                {
                    Title= " The complete sales app for your company",
                    ImageSource="order"
                },
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
