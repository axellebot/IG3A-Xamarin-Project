using System;
using System.ComponentModel;

namespace XamarinApp.Models
{
    public class TodoItem : IEquatable<TodoItem>, INotifyPropertyChanged , IComparable<TodoItem>
    {
        string text;
        bool done;

        public string Id { get; set; }
        public string Text {
            set
            {
                if (text != value)
                {
                    text = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                    }
                }
            }
            get {
                return text;
            }
        }
        public bool Done {
            set
            {
                if (done != value)
                {
                    done = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Done"));
                    }
                }
            }
            get
            {
                return done;
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