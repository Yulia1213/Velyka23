using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Velyka23.Commands;
using Velyka23.Exeptions;
using Velyka23.Models;

namespace Velyka23.ViewModels
{

    class MainViewModels
    {
       
        private string _name;
        private string _surname;
        private string _mail;
        private DateTime? _birthday;


        private ICommand _proceed;


        

        private bool _isAdult;
        


        private string _sunSign;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChanged();
            }
        }
 
       
        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {

                
                _birthday = value;
                OnPropertyChanged();
            }
        }
        public string SunSign
        {
            get { return _sunSign; }
            set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }
        public ICommand ProceedCommand =>
            _proceed ?? (_proceed = new RelayCommand(async o => {await Procced(); }));
        

        public async Task Procced()
        {
            await Task.Run(() => ProccedMethod());
            

        }


        public void ProccedMethod()
        {
            try
            {
                string wishes = "";
                DateTime BirthdayTime = Birthday ?? DateTime.Now;

                Person myPerson = new Person(Name, Surname, Mail, BirthdayTime);


                if (myPerson.IsBirthday) wishes = "Birthday wishes";

                SunSign = myPerson.SunSign;
                MessageBox.Show(wishes + "\n" + myPerson.Name + "\n" + myPerson.Surname + "\n" + myPerson.Mail + "\n" +
                                myPerson.Birthday.ToShortDateString() + "\nIsAdult = " + myPerson.IsAdult +
                                "\nIsBirthday = " + myPerson.IsBirthday + "\n" + myPerson.ChineseSign +


                                "\n" + myPerson.SunSign);



            }
            catch (AgeExeption ex)
            {
                MessageBox.Show("EXEPTION:+\n message: " + ex.Message + "\nvalue: " + ex.Value);

            }
            catch (MailExeption ex)
            {
                MessageBox.Show("EXEPTION:+\n message: " + ex.Message);

            }
            catch (BirthdayExeption ex)
            {
                MessageBox.Show("EXEPTION:+\n message: " + ex.Message + "\nvalue: " + ex.Value);

            }
        }
          

        















        #region OnProperetyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
