using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WMSCrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string[] array = new string[]
        {
            "5N93e3d03291A9c5072fbcX5285PO316",
            "c9dGP9da1aXf7a9F79b3a0d50c5aM7c"
        };
        private ZF2006Class myClass = new ZF2006Class();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AESZF2006 aeszf = new AESZF2006();
            aeszf.AESKeySet(array[0]);
            aeszf.AESKeySet(array[1]);
            string[] array2 = new string[]
            {
                tb_ckx1.Text.Trim(),
                tb_ckx2.Text.Trim(),
                tb_ckx3.Text.Trim(),
                tb_ckx4.Text.Trim()
            };
            array2[0] = aeszf.AESDecrypto(array2[0]);
            array2[1] = aeszf.AESDecrypto(array2[1]);
            array2[2] = aeszf.AESDecrypto(array2[2]);
            array2[3] = aeszf.AESDecrypto(array2[3]);
            tb_rs1.Text = array2[0];
            tb_rs2.Text = array2[1];
            tb_rs3.Text = array2[2];
            tb_rs4.Text = array2[3];
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AESZF2006 aeszf = new AESZF2006();
            aeszf.AESKeySet(array[0]);
            aeszf.AESKeySet(array[1]);
            string[] array2 = new string[]
            {
                tb1_ckx1.Text.Trim(),
                tb1_ckx2.Text.Trim(),
                tb1_ckx3.Text.Trim(),
                tb1_ckx4.Text.Trim()
            };
            array2[0] = aeszf.AESEncrypto(array2[0]);
            array2[1] = aeszf.AESEncrypto(array2[1]);
            array2[2] = aeszf.AESEncrypto(array2[2]);
            array2[3] = aeszf.AESEncrypto(array2[3]);
            tb1_rs1.Text = array2[0];
            tb1_rs2.Text = array2[1];
            tb1_rs3.Text = array2[2];
            tb1_rs4.Text = array2[3];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb_rspass.Text = myClass.md5Target(tb_pass.Text, "pw");
        }
    }
}
