using SQLite;
using System;
using System.ComponentModel;

namespace XamarinApp.Models
{
    public class TodoItem : IEquatable<TodoItem>, INotifyPropertyChanged, IComparable<TodoItem>
    {
        private string _id;
        private string _text;
        private bool _done;

        [PrimaryKey]
        public string Id {
            set
            {
                if (_id != value)
                {
                    _id = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                    }
                }
            }
            get
            {
                return _id;
            }
        }
        public string Text {
            set
            {
                if (_text != value)
                {
                    _text = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                    }
                }
            }
            get {
                return _text;
            }
        }
        public bool Done {
            set
            {
                if (_done != value)
                {
                    _done = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Done"));
                    }
                }
            }
            get
            {
                return _done;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int CompareTo(TodoItem other)
        {
            return this.Text.CompareTo(other.Text);
        }

        public bool Equals(TodoItem other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}