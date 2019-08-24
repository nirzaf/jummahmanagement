using System;
using System.Windows.Forms;
using System.IO;

namespace BabatyeInventory
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }


    }
    public static class MyExtensions
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
    }

}
