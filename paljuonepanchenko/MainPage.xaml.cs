using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace paljuonepanchenko
{
    public partial class MainPage : ContentPage
    {
        List<string> opilane, mail, number, terve;
        public MainPage()
        {
            InitializeComponent();
            terve = new List<string> { "Head uut aastat!", "Ilusaid Joule", "Roomsaid Joulupuhi ja head uut aastat!", "Teie terviseks!" };
            opilane = new List<string>() { "Aleksandr Shevchenko", "Dima Dovzenok", "Yarik Panchenko" };
            number = new List<string>() { "5520754", "56143908", "+37251923759" };
            mail = new List<string> { "sanjkashevcjenko@gmail.com", "dima.dovzenok2003@gmail.com", "akkauntclasha6@gmail.com" };
            opiPicker.ItemsSource = opilane;
            opiPicker.SelectedIndexChanged += FriendPicker_SelectedIndexChanged;
            btn.Clicked += Btn_Clicked;
        }
        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomi = rnd.Next(5);
            if (type.IsToggled == true)
            {
                await Sms.ComposeAsync(new SmsMessage { Body = terve[randomi], Recipients = new List<string> { number[opiPicker.SelectedIndex] } });
            }
            else
            {
                await Email.ComposeAsync("Soovin onne!", terve[randomi], mail[opiPicker.SelectedIndex]);
            }
        }
        private void FriendPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[opiPicker.SelectedIndex];
            num.Text = number[opiPicker.SelectedIndex];
        }
    }
}
