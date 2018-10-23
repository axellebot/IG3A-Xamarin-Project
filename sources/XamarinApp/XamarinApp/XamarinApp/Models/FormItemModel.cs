using SQLite;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinApp.Models
{

    public class FormItemModel : IEquatable<FormItemModel>, IComparable<FormItemModel>
    {
        public FormItemModel()
        {
            Id = Guid.NewGuid().ToString();
            Name_Drug = string.Empty;
            Name_Body = string.Empty;
            Name_Doctor = string.Empty;
            Dosage = string.Empty;
            Dose = string.Empty;
            Notif = false;
            TimeCheck_1 = false;
            TimeCheck_2 = false;
            TimeCheck_3 = false;
            Date_Deb = DateTime.Now.ToLocalTime();
            Time_1 = DateTime.Now.TimeOfDay;
            Time_2 = DateTime.Now.TimeOfDay;
            Time_3 = DateTime.Now.TimeOfDay;
            MyTime = string.Empty;

        }

        [PrimaryKey]
        public string Id { set; get; }
        public string Name_Drug { set; get; }
        public string Name_Body { set; get; }
        public string Name_Doctor { set; get; }
        public string Dosage { set; get; }   
        public bool Notif { set; get; }
        public bool TimeCheck_1 { set; get; }
        public bool TimeCheck_2 { set; get; }
        public bool TimeCheck_3 { set; get; }
        public DateTime Date_Deb { set; get; }
        public DateTime Date_Fin { set; get; }
        public TimeSpan Time_1 { set; get; }
        public TimeSpan Time_2 { set; get; }
        public TimeSpan Time_3 { set; get; }
        public string Dose { set; get; }
        public string MyTime { set; get; }



        public int CompareTo(FormItemModel other)
        {
            return this.Name_Drug.CompareTo(other.Name_Drug);
        }

        public bool Equals(FormItemModel other)
        {
            return (this.Id.Equals(other.Id) && this.Name_Drug.Equals(other.Name_Drug) && this.Notif.Equals(other.Notif));
        }
    }
}

