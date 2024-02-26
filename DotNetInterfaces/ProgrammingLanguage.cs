using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterfaces
{
    public class ProgrammingLanguage : IComparable<ProgrammingLanguage>, INotifyPropertyChanged
    {

        string _name = "Java";
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_name)));
            }
        }
        public int CompareTo(ProgrammingLanguage? other)
        {
            return other.Name.CompareTo(Name);
        }
    }
}
