using Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer;

namespace MailGenerator
{
    class Generator
    {
        public void CreateRandomMail(EmailInfo em)
        {
            string tempadress = "";
            int curentindex;
            em.CurentMailAdressCountValue = 0;

            if (!em.Firstname.Equals("") && !em.SecondName.Equals(""))
            {
                int i = em.MailAdressCountValue / 3;
                curentindex = MixStringList.random.Next(i, em.MailAdressCountValue + 1);
                curentindex = em.Firstname.Length < curentindex ? em.Firstname.Length : curentindex;
                tempadress += em.Firstname.Substring(0, curentindex);

                em.CurentMailAdressCountValue += curentindex;

                if (em.CurentMailAdressCountValue < em.MailAdressCountValue)
                {
                    int j = (em.MailAdressCountValue - em.CurentMailAdressCountValue) / 2;


                    curentindex = MixStringList.random.Next(j, em.MailAdressCountValue - em.CurentMailAdressCountValue + 1);
                    curentindex = em.SecondName.Length < curentindex ? em.SecondName.Length : curentindex;

                    em.CurentMailAdressCountValue += curentindex;
                    tempadress += em.SecondName.Substring(0, curentindex);

                }
                AddNumber(ref tempadress, em);
                em.CreateFullEmail(tempadress);
            }
        }


        private void AddNumber(ref string tempaddr, EmailInfo em)
        {
            while (em.MailAdressCountValue - em.CurentMailAdressCountValue > 0)
            {
                tempaddr += MixStringList.random.Next(0, 10).ToString();
                em.CurentMailAdressCountValue++;
            }



        }
    }
}
