using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        /*Магазин. Основной объект «Товар». Поля: название+, инвентарный номер+,
         * размер+, вес+, тип+, дата поступления+, количество+, цена, производитель.
         * Агрегируемый объект «Производитель». Поля: организация, страна, адрес,
         * телефон.  Дополнительно: Агрегируемый объект «Кладовщик». Поля: ФИО, стаж, адрес и т.д. */
    }

    
    public class Product
    {
        public string ProductName;
        public int ProductNumber;
        public int ProductSize;
        public int ProductWeight;
        public string ProductType;
        public DateTime date;
        public int Count;
        public int Price;
        public string Developer;
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public string WorkerName;
        [DataMember]
        public string WorkerSurname;
        [DataMember]
        public string Patronymic;
        [DataMember]
        public int WorkExperience;
        [DataMember]
        public string Adress;
    }

}
