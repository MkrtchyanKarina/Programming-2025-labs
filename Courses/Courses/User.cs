using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal abstract class User
    {
        protected string _name;
        protected string _lastname;
        protected string _phone;
        protected string _email;
        protected User(string name, string lastname, string phone, string email) 
        {
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Email = email;
        }

        internal string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"имя\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_name))
                        _name = "Undefinded";
                }
                else
                    _name = value;
            }
        }

        internal string Lastname
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"фамилия\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_lastname))
                        _lastname = "Undefinded";
                }
                else
                    _lastname = value;
            }
        }

        internal string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"телефон\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_phone))
                        _phone = "Undefinded";
                }
                else
                    _phone = value;
            }
        }

        internal string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"жлектронная почта\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_email))
                        _email = "Undefinded";
                }
                else
                    _email = value;
            }
        }



    }
}
