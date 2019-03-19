using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class ProductInfo : ValidationAttribute, IComparable<ProductInfo>
    {
        [Required(ErrorMessage = "Empty field")]
        [StringLength(10,MinimumLength =3,ErrorMessage = "small count of letters")]
        public string Name { get; set; }
        public int Number;
        public int Size;
        public int Weight;
        public int Price;

        public bool IsValid(ProductInfo value)
        {
            if (value.Name == "Max")
                MessageBox.Show("Wrong name");
            return true;
        }

        public int CompareTo(ProductInfo obj)
        {
            //return Name.CompareTo(obj.Name);
            if (this.Price > obj.Price)
                return 1;
            if (this.Price < obj.Price)
                return - 1;
            return 0;
        }

    }

    //
    public class CheckValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string userName = value.ToString();
                if (!userName.StartsWith("T"))
                    return true;
                else
                    this.ErrorMessage = "Имя не должно начинаться с буквы T";
            }
            return false;
        }
    }
}
