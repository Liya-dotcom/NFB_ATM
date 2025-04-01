using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NFB_ATM
{
    internal class Usernames
    {
        private int _id;
        private string _name, _surname;

        public Usernames()
        {
        }

        public Usernames(int id, string first, string last)
        {
            this._id = id;
            string _name = first;
            string _surname = last;
        }
        public int ID 
        { 
            get{return _id;}
            set{_id = ID;}
        }

        public string Firstname
        {
            get{return _name;}
            set{_name = Firstname;}
        }

        public string Lastname
        {
            get{return _surname;}
            set{_surname = Lastname;}
        }


    }
}
