using Randomizer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Email
{
    class Adder
    {
        public void AddFirstName(IList<string> list,ObservableCollection<EmailInfo> items)
        {
            items.Clear();

            MixStringList.GetMix(list);

            foreach (var t in list)
            {
                items.Add(new EmailInfo() { Firstname = t });
            }
        }

        public void AddSecondName(IList<string> list,ObservableCollection<EmailInfo> items)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Мудак, сначала загрузи имена! Я же тебе говорил" + Environment.NewLine +
                    "Ты стал совершенно другим. Ты меня совсем не слушаешь" + Environment.NewLine +
                    "Когда мы познакомились, ты был другим...");
                return;
            }
            MixStringList.GetMix(list);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].SecondName = list[i];
            }
        }
    }
}
