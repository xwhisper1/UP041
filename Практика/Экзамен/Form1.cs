using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Экзамен
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("@Software\\KEYUS");// открываем ключ(созданный ранее)
            if (reg != null) //проверем пустой ли путь // проверка на уже ранее созданного  этого ключа 
            {
                RegistryKey myKey = Registry.LocalMachine;//Открываем реестр и путь HKLM
                RegistryKey wKey = myKey.OpenSubKey(@"HARDWARE\DESCRIPTION\System"); //открываем ключ по путь
                string Str2 = wKey.GetValue("SystemBiosDate") as string; //считываем данные ключа

                string SystemBiosDate = Str2; //присваение дааных из ключа в переменную 
                label2.Text = Str2;

                RegistryKey currentUserKey = Registry.CurrentUser; //Открываем реестр и путь HKCU
                RegistryKey Key = currentUserKey.CreateSubKey(@"Software\KEYUS"); //Создаем ключь по пути
                Key.SetValue("SystemBiosDate", Str2); //присваиваем имя и значение ключа
                Key.Close(); // закрываем ключ
                MessageBox.Show("Ключ записан!", "ВНИМАНИЕ!"); // сообщение об успешной записи ключа в реестр 
            }
            else
            {
                MessageBox.Show("Ключ уже записан!","ВНИМАНИЕ!"); // сообщение о том, что ключ был создан ранее
            }
        }
    }
}
