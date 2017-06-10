using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{

    public class EmailInfo
    {
        public const string MailAdress_outlook = "@outlook.com";
        public string Firstname { get; set; }
        public string SecondName { get; set; }
        public string Email { get; private set; }

        public int MailAdressCountValue { set; get; }
        public int CurentMailAdressCountValue { set; get; }

        public EmailInfo()
        {
            MailAdressCountValue = Randomizer.MixStringList.random.Next(5, 12);
            CurentMailAdressCountValue = 0;
        }
        public void CreateFullEmail(string fpart) => Email = fpart + MailAdress_outlook;

        public override string ToString() => $"{Firstname} {SecondName} {Email}";


    }
}
