
using Chapter9.Model.Exercise2Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter9.ViewModel.Exercise2ViewModel.ViewModelLibrary
{
    public class LibraryViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<LibraryModel> LibraryDetails { get; set; }
       
        public int _current;
        public int Current
        {
            get => _current;
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }

        private string _buttonLabel;
        public string ButtonLabel
        {
            get => _buttonLabel;
            set
            {
                _buttonLabel= value;
                OnPropertyChanged();
            }
        }

        public event EventHandler FinishEvent;
        public ICommand ItemChangeCommand { get; private set; }
        public ICommand NextButtonCommand { get; private set; }
        
     
        
        public LibraryViewModel()
        {
            Details();
            ItemChangeCommand = new Command(ChangeValue);
            NextButtonCommand = new Command(FinishChange);
        }

        public void Details()
        {
            LibraryDetails = new ObservableCollection<LibraryModel>
            {
                new LibraryModel()
                {
                    Title="Read & Learn Anywhere",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImageSource="read"
                },
                 new LibraryModel()
                {
                    Title="Your favorite Books",
                    Description="Lorem ipsum dolor sit amet. Qui magnam ducimus et odio laudantium in aspernatur nemo et natus amet aut voluptas odit qui suscipit consequatur?",
                    ImageSource="book"
                },
                new LibraryModel()
                {
                    Title="Your Victory",
                    Description="Non veniam nostrum aut molestiae quaerat sed similique consequatur eum enim nulla sed facilis rerum aut quas ducimus et possimus officia.",
                    ImageSource="victory"
                }
            };
        }
     
        
        public void FinishChange()
        {
            if (Current >= LibraryDetails.Count - 1)
            {
                FinishEvent?.Invoke(this, new EventArgs());
                Current= 0;
            }
            else
            {
                Current += 1;
            }
        }

        public void ChangeValue()
        {                  
            if (Current == LibraryDetails.Count-1)
            {
                ButtonLabel = "Finish";     
            }
            else
            {
                ButtonLabel = "Next";
            }             
        }
     

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
