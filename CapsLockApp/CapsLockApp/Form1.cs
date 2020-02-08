using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CapsLockApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NotifyIcon capsLockApp = new NotifyIcon();//sistem tepsisindeki uygulama
        Bitmap icon = new Bitmap(Properties.Resources.capslock);//uygulamanin icon yolu

        //Capslock tusuna uygulama disinda erismek icin gerekli kodlar 
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern short GetAsyncKeyState(int Tus);

        public static bool TusKontrol(byte Kod)
        {
            if (GetAsyncKeyState((int) Kod) == System.Int16.MinValue + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void form_Activated(object sender, EventArgs e)
        {
            this.Hide();//formu acilista gizler   
        }

        private void form_Load(object sender, EventArgs e)
        {
            capsLockApp.Icon = Icon.FromHandle(icon.GetHicon());//uygulama iconunun belirlenmesi                
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Eger capslock aktifse icon belirir degilse gizlenir 
            if (TusKontrol((byte)Keys.CapsLock))
            {
                if (Control.IsKeyLocked(Keys.CapsLock))
                {
                    capsLockApp.Visible = true;
                    capsLockApp.Text = "Caps lock Açık.";
                }
                else
                {
                    capsLockApp.Visible = false;
                    capsLockApp.Text = "Caps lock Kapalı.";
                }
            }
        }
    }
}
