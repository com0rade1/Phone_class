using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Проверка работоспособности класса
            Phone phone1 = new Phone(8888888556123457);
            Phone phone2 = new Phone(8953132072513250, "Galaxy A50", "Samsung");
            Phone phone3 = new Phone(8953138650954692, "Redmi GO 3", "Xiaomi", "Qualcom Snapdragon 645");
            Phone phone4 = new Phone(8922931700865099, "10", "IPhone", "SmartPhone", "EliteSmartPhone", 2018, 36, 1000, 72, 24, 4, 24, 12, "1880x960",6.1, true,2, 256, true, "IDragon best");
            Phone phone5 = new Phone(2201000232027429, "J6", "Samsung");
            Phone phone6 = new Phone(2201000232027429, "J Prime", "Samsung");
            Phone phone7 = new Phone(2201000232027485, "J Prime", "Samsung");
            Console.WriteLine(phone1);
            Console.WriteLine(phone2);
            Console.WriteLine(phone3);
            Console.WriteLine(phone4);
            Console.WriteLine(phone1.Equals(phone2));
            Console.WriteLine(phone1.Equals(phone1));
            Console.WriteLine(phone2.IMEICode);
            Console.WriteLine(phone1.Processor);
            Phone_Shop Eldorado = new Phone_Shop();
            Eldorado.Add(phone1);
            Eldorado.Add(phone2);
            Eldorado.Add(phone3);
            Eldorado.Add(phone4);
            Eldorado.Remove(phone2);
            Console.WriteLine(Eldorado.ToString());
            Eldorado.RemoveAt(1);
            Console.WriteLine(Eldorado.ToString());
            Console.WriteLine(Eldorado.SearchByAmountOperativeMemory(1, 3));
            Console.WriteLine(Eldorado.SearchByDeveloperCompany("Samsung"));
            Console.WriteLine(Eldorado.SearchByPriceRange(180, 1100));
            Console.WriteLine(Eldorado.SearchByType("SmartPhone"));
            Eldorado.Add(phone3);
            Eldorado.Add(phone4);
            Eldorado.SortByName();
            Console.WriteLine(Eldorado.ToString());
            Eldorado.SortByName(false);
            Console.WriteLine(Eldorado.ToString());
            Eldorado.Add(phone5);
            Eldorado.Add(phone6);
            Eldorado.Add(phone7);
            Eldorado.SortByPrice();
            Console.WriteLine(Eldorado.ToString());
            Eldorado.DeveloperSale("Samsung", 10);
            Console.WriteLine(Eldorado.ToString());
            Console.WriteLine(Eldorado.GetInfoFromNameAndDeveloper("J Prime", "Samsung"));
            Console.WriteLine(Eldorado.GetInfoFromIMEICode(8922931700865099));
            Console.ReadKey();

            #endregion

        }
    }

  

    public sealed class Phone
    {
        #region Поля класса Phone
        long IMEIcode; // Серийный номер телефона (состоит из 16 цифр)
        string name; // Модель телефона
        string developerCompany; // Марка телефона
        string type; // Тип телефона
        string description; // Описание модели
        int yearOfIssue; // Год выпуска
        int warrantyPeriod; // Гарантийный срок в месяцах
        decimal price; // Цена в долларах
        int timeOfWorkFlightMode; // Время работы в автономном режиме
        int timeOfWorkActiveMode; // Время работы в активном режиме (при постоянном пользовании телефоном)
        int amountOfOperativeMemory; // Объем оперативной памяти (в МБ)
        int photoQuality; // Качество съемки основной камеры (в МП)
        int frontalPhotoQuality; // Качество съемки фронтальной камеры (в МП)
        string screenResolution; // Разрешение экрана
        double screenDiagonal; // Диагональ экрана (Дюймы)
        bool memoryExpansion; // Возможность расширения памяти телефона
        int simCount; // Количество сим-карт.
        int physicalMemory; // Физическая память телефона (в ГБ)
        bool technology5G; // Доступность технологии 5G
        string processor; // Марка процессора
        #endregion

        /*  public Phone()
          {
              Random rnd = new Random();
              IMEIcode = 999999999999999 + rnd.Next(1, 10000) * rnd.Next(1, 10000) * rnd.Next(1, 10000) * rnd.Next(1, 10000);
              yearOfIssue = Convert.ToInt32(DateTime.Now.Year) - 2;
              warrantyPeriod = 4;
              price = 180;
              name = "Unknown";
              developerCompany = "Unknown";
              type = "With TouchScreen";
              description = "Classic Phone with TouchScreen";
              timeOfWorkFlightMode = 12;
              timeOfWorkActiveMode = 6;
              amountOfOperativeMemory = 2;
              photoQuality = 8;
              screenResolution = "1280x720";
              memoryExpansion = true;
              physicalMemory = 4;
              technology5G = false;
              processor = "Qualcom Snapdragon 616";
          } */

        #region Конструкторы класса Phone
        public Phone(long IMEIcode)
        {
            if ((IMEIcode > 999999999999999) && (IMEIcode <= 9999999999999999))
            {
                this.IMEIcode = IMEIcode;
                yearOfIssue = Convert.ToInt32(DateTime.Now.Year) - 2;
                warrantyPeriod = 48;
                price = 180;
                name = "Unknown";
                developerCompany = "Unknown";
                type = "With TouchScreen";
                description = "Classic Phone with TouchScreen";
                timeOfWorkFlightMode = 12;
                timeOfWorkActiveMode = 6;
                amountOfOperativeMemory = 2048;
                photoQuality = 8;
                frontalPhotoQuality = 6;
                screenResolution = "1280x720";
                memoryExpansion = true;
                simCount = 1;
                physicalMemory = 4;
                technology5G = false;
                processor = "Qualcom Snapdragon 616";
            }
        } // Конструктор
        public Phone(long IMEIcode, string name, string developerCompany) : this(IMEIcode)
        {
            if (name != "") this.name = name;
            if (developerCompany != "") this.developerCompany = developerCompany;
        } // Конструктор
        public Phone(long IMEIcode, string name, string developerCompany, decimal price) : this(IMEIcode)
        {
            if (name != "") this.name = name;
            if (developerCompany != "") this.developerCompany = developerCompany;
            if (price != 0) this.price = price;
        } // Конструктор
        public Phone(long IMEIcode, string name, string developerCompany, string description, decimal price) : this(IMEIcode, name, developerCompany, price)
        {
            if (description != "")
                this.description = description;
        } // Конструктор
        public Phone(long IMEIcode, string name, string developerCompany, string processor) : this(IMEIcode, name, developerCompany)
        {
            if (processor != "") this.processor = processor;
        } // Конструктор
        public Phone(long IMEIcode, string name, string developerCompany, string type, string description, int yearOfIssue, int warrantyPeriod, decimal price, int timeOfWorkFlightMode, int timeOfWorkActiveMode, int amountOfOperativeMemory, int photoQuality, int frontalPhotoQuality, string screenResolution, double screenDiagonal, bool memoryExpansion, int simCount,int physicalMemory, bool technology5G, string processor) : this(IMEIcode, name, developerCompany, description, price)
        {
            if (type != "") this.type = type;
            if (yearOfIssue != 0) this.yearOfIssue = yearOfIssue;
            if (warrantyPeriod != 0) this.warrantyPeriod = warrantyPeriod;
            if (timeOfWorkFlightMode != 0) this.timeOfWorkFlightMode = timeOfWorkFlightMode;
            if (timeOfWorkActiveMode != 0) this.timeOfWorkActiveMode = timeOfWorkActiveMode;
            if (amountOfOperativeMemory != 0) this.amountOfOperativeMemory = amountOfOperativeMemory;
            if (photoQuality != 0) this.photoQuality = photoQuality;
            if (frontalPhotoQuality != 0) this.frontalPhotoQuality = frontalPhotoQuality;
            if (screenResolution != "") this.screenResolution = screenResolution;
            if (screenDiagonal != 0) this.screenDiagonal = screenDiagonal;
            if (memoryExpansion != false) this.memoryExpansion = memoryExpansion;
            if (simCount != 0) this.simCount = simCount;
            if (physicalMemory != 0) this.physicalMemory = physicalMemory;
            if (technology5G != false) this.technology5G = technology5G;
            if (processor != "") this.processor = processor;
        } // Конструктор
        #endregion

        #region Свойства класса Phone
        public string Name
        {
            get { return name; }
        } // Свойство "модель телефона" только для чтения. Продавец не может изменить модель телефона 
        public long IMEICode
        {
            get { return IMEIcode; }
        } // Свойство "IMEI-код телефона" только для чтения. Продавец не может изменить IMEI-код телефона
        public string DeveloperCompany
        {
            get { return developerCompany; }
        } // Свойство "Производитель телефона" только для чтения. Продавец не может изменить производителя телефона.
        public string Type
        {
            get { return type; }
        } // Свойство "Тип телефона" только для чтения. Продавец не может изменить тип телефона
        public string Description
        {
            get { return description; }
            set { if (value != "") description = value; }
        } // Свойство "Прочее" для чтения и для записи. Продавец может изменять информацию о телефоне.
        public int YearOfIssue
        {
            get { return yearOfIssue; }
        } // Свойство "Год выпуска" для чтения. Продавец не может изменить год выпуска телефона
        public int WarrantyPeriod
        {
            get { return warrantyPeriod; }
        } // Свойство "Гарантийный срок" для чтения. Продавец не может изменить гарантийный срок.
        public decimal Price
        {
            get { return price; }
            set { if (value != 0) price = value; }
        } // Свойство "Цена" для чтения и для записи. Цена на телефон может изменяться продавцом.
        public int TimeOfWorkInFlightMode
        {
            get { return timeOfWorkFlightMode; }
        } // Свойство "Время работы в автономном режиме" только для чтения.
        public int TimeOfWorkInActiveMode
        {
            get { return timeOfWorkActiveMode; }
        } // Свойство "Время работы при активном использовании" только для чтения.
        public int AmountOfOperativeMemory
        {
            get
            {
                return amountOfOperativeMemory;
            }
        } // Свойство "Объем оперативной памяти" только для чтения.
        public int PhotoQuality
        {
            get
            {
                return photoQuality;
            }
        } // Свойство "Качество съемки основной камеры" только для чтения.
        public int FrontalPhotoQuality
        {
            get
            {
                return frontalPhotoQuality;
            }
        } // Свойство "Качество съемки фронтальной камеры" только для чтения.
        public string ScreenResolution
        {
            get
            {
                return screenResolution;
            }
        } // Свойство "Разрешение экрана" только для чтения.
        public double ScreenDiagonal // Свойство "Диагональ экрана" только для чтения.
        {
            get
            {
                return screenDiagonal;
            }
        }
        public bool MemoryExpansion
        {
            get
            {
                return memoryExpansion;
            }
        } // Свойство "Расширение памяти" только для чтения.
        public int SimCount // Свойство "Количество сим-карт" только для чтения.
        {
            get
            {
                return simCount;
            }
        }
        public int PhysicalMemory
        {
            get
            {
                return physicalMemory;
            }
        } // Свойство "Физическая память" только для чтения.
        public bool Technology5G
        {
            get
            {
                return technology5G;
            }
        } // Свойство "Технология 5G" только для чтения.
        public string Processor
        {
            get
            {
                return processor;
            }
        } // Свойство "Процессор" только для чтения.
        public override string ToString()
        {
            return string.Format("Изготовитель телефона: {0}\n Модель телефона: {1}\n Уникальный IMEI-код телефона: {2}\n Тип телефона: {3}\n Время работы в автономном режиме(часы): {4}\n Время работы в активном режиме(часы): {5}\n Объем оперативной памяти(МБ): {6}\n Качество съемки основной камеры (МП): {7}\n Качество съемки фронтальной камеры (МП): {17}\n Разрешение экрана: {8}\n Диагональ экрана: {18}\n Возможность расширения памяти (True - есть, False - нет): {9}\n Количество сим-карт: {19}\n Физическая память телефона {10}\n Наличие технологии 5G (True - есть, False - нет): {11}\n Модель процессора: {12}\n Прочее: {13}\n год выпуска: {14}\n Гарантийный срок: {15}\n Цена: {16}. \n\n", developerCompany, name, IMEIcode, type, timeOfWorkFlightMode, timeOfWorkActiveMode, amountOfOperativeMemory, photoQuality, screenResolution, memoryExpansion, physicalMemory, technology5G, processor, description, yearOfIssue, warrantyPeriod, price, frontalPhotoQuality, screenDiagonal, simCount);
        } // Переопределение метода "ToString"
        public override bool Equals(object obj)
        {
            if ((obj == null) && (GetType() != obj.GetType())) return false;
            Phone temp = (Phone)obj;
            return (temp.Name == this.name) && (temp.IMEICode == IMEIcode) && (temp.DeveloperCompany == developerCompany) && (temp.Type == type) && (temp.Description == description) && (temp.YearOfIssue == yearOfIssue) && (temp.WarrantyPeriod == warrantyPeriod) && (temp.Price == Price) && (temp.TimeOfWorkInFlightMode == timeOfWorkFlightMode) && (temp.TimeOfWorkInActiveMode == timeOfWorkActiveMode) && (temp.AmountOfOperativeMemory == amountOfOperativeMemory) && (temp.PhotoQuality == photoQuality) && (temp.ScreenResolution == screenResolution) && (temp.MemoryExpansion == memoryExpansion) && (temp.PhysicalMemory == physicalMemory) && (temp.Technology5G == technology5G) && (temp.Processor == processor);
        } // Переопределение метода "Equals"
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    public class Phone_Shop
    {
        List<Phone> myList = new List<Phone>();

        #region Методы класса Phone_Shop
        public void Add(Phone newPhone) // Метод добавления телефона в базу данных магазина телефонов.
        {
            bool flag = true;
            for (int i = 1; i < myList.Count; i++)
            {
                if (myList[i].IMEICode == newPhone.IMEICode)
                {
                    flag = false;
                }
            }
            if ((!myList.Contains(newPhone)) && flag)
            {
                myList.Add(newPhone);
            }
        }
        public void RemoveAt(int k) // Метод удаления элементов списка с позиции k-1
        {
            if ((k >= 0) && (k < myList.Count)) myList.RemoveAt(k);
        }
        public void RemoveAt(int k, int m) // Метод удаления элементов списка с позиции k-1 до позиции m-1
        {
            if ((k < m) && (k > 0) && (k < myList.Count) && (m > 0) && (m < myList.Count))
                for (int i = k; i <= m; i++)
                {
                    myList.RemoveAt(i);
                }
        }
        public void Remove(Phone phone)
        {
            myList.Remove(phone);
        } // Метод удаления конкретной записи.
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("Количество телефонов на продаже: {0}. \nCписок телефонов:\n", myList.Count);
            for (int i = 0; i < myList.Count; i++)
                s.Append("\t" + (i + 1) + ") " + myList[i] + "\n");
            return s.ToString();
        } // переопределение метода ToString
        public Phone GetInfoFromIMEICode (long IMEICode)
        {
            for(int i=1;i<myList.Count;i++)
            {
                if (myList[i].IMEICode == IMEICode) return myList[i];
            }
            return myList[myList.Count];
        } // Получение информации о телефоне по его IMEICode (ВОПРОС ВОЗВРАТ ОШИБКИ)
        public Phone GetInfoFromNameAndDeveloper(string name,string developer)
        {
            for (int i = 1; i<myList.Count;i++)
            {
                if ((myList[i].Name == name) && (myList[i].DeveloperCompany == developer)) return myList[i];
            }
            return myList[myList.Count];
            
        } // Получение информации о телефоне по его модели и производителю. (ВОПРОС ВОЗВРАТА ОШИБКИ)
        public string SearchByDeveloperCompany(string DeveloperCompany)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].DeveloperCompany == DeveloperCompany) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Телефона данной марки в наличии нет";
        } // Поиск по производителю. (вывод списка)
        public void DeveloperSale(string DeveloperCompany, decimal Percent) // Акция от производителя
        {
            if ((Percent<100) && (Percent>-100) && (Percent != 0))
                for (int i=1;i<myList.Count;i++)
                {
                    if (myList[i].DeveloperCompany == DeveloperCompany)
                    {
                        myList[i].Price = myList[i].Price * (1 + Percent/100);
                    }
                }
        }
        public void ChangePrice(Phone phone,decimal Price)
        {
            if (myList.Contains(phone)) myList[myList.IndexOf(phone)].Price = Price;
        } // Изменение цены телефона по элементу типа Phone
        public void ChangePrice(long IMEICode, decimal Price)
        {
            myList[myList.IndexOf(GetInfoFromIMEICode(IMEICode))].Price = Price;
        } // Изменение цены телефона по IMEICode
        public string SearchByName(string name)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].Name == name) s.Append("\n/t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Данной модели телефона в наличии нет";

        } // Поиск по модели телефона.
        public string SearchByType(string type)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].Type == type) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "В продаже не имеется телефонов данного типа";

        } // Поиск по типу телефона. (вывод списка)
        public string SearchByPriceRange(int min, int max)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].Price >= min) && (myList[i].Price <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "В данной ценовой категории телефонов нет, либо данные были введены неверно";
        } // Поиск по ценовой категории (в долларах, указывается ценовой промежуток, вывод списка)
        public string SearchByWarrantyPeriod(int min, int max)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].WarrantyPeriod >= min) && (myList[i].WarrantyPeriod <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным гарантийным сроком, либо данные неверны";
        } // Поиск по гарантийному сроку (указывается промежуток в месяцах "от" и "до", вывод списка)
        public string SearchByPhotoQuality(int min, int max)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].PhotoQuality >= min) && (myList[i].PhotoQuality <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным количеством мегапикселей основной камеры, либо данные неверны";
        } // Поиск по количеству мегапикселей основной камеры (указывается промежуток в мегапикселях "от" и "до", вывод списка)
        public string SearchByTimeOfWorkFlightMode(int min, int max) // Поиск по времени работы в автономном режиме (вывод списка)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].TimeOfWorkInFlightMode >= min) && (myList[i].TimeOfWorkInFlightMode <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным временем работы в автономном режиме, либо данные неверны";
        }
        public string SearchByTimeOfWorkActiveMode(int min, int max) // Поиск по времени работы при активном использовании (вывод списка)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].TimeOfWorkInActiveMode >= min) && (myList[i].TimeOfWorkInActiveMode <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным временем работы при активном использовании, либо данные неверны";
        }
        public string SearchByPhysicalMemory(int min, int max) // Поиск по объему встроенной памяти (вывод списка)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].PhysicalMemory >= min) && (myList[i].PhysicalMemory <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным объемом встроенной памяти, либо данные неверны";
        }
        public string SearchByAmountOperativeMemory(int min, int max) // Поиск по объему оперативной памяти (вывод списка)
        {
            StringBuilder s = new StringBuilder();
            if ((min <= max) && (min > 0))
            {
                for (int i = 0; i < myList.Count; i++)
                    if ((myList[i].AmountOfOperativeMemory >= min) && (myList[i].AmountOfOperativeMemory <= max)) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            }
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанным объемом оперативной памяти, либо данные неверны";
        }
        public string SearchByMemoryExpansion(bool memoryExpansion) // Поиск по наличию слота для карты памяти (вывод списка)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].MemoryExpansion == memoryExpansion) s.Append("\n/t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "Нет телефонов с указанными параметрами";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void SortByName()
        {
            myList.Sort(new CompareByName());
        } // Сортировка по марке телефона в алфавитном порядке.
        public void SortByName(bool p)
        {
            myList.Sort(new CompareByName(p));
        }  // Сортировка по марке телефона в алфавитном или обратном алфавитном порядке.
        public void SortByPrice()
        {
            myList.Sort(new CompareByPrice());
        } // Сортировка по цене телефона в алфавитном порядке.
        public void SortByPrice(bool p)
        {
            myList.Sort(new CompareByPrice(p));
        } // Сортировка по цене телефона в алфавитном или обратном алфавитном порядке.
        public void SortByDeveloper()
        {
            myList.Sort(new CompareByDeveloper());
        }  // Сортировка по производителю телефона в алфавитном порядке.
        public void SortByDeveloper(bool p)
        {
            myList.Sort(new CompareByDeveloper(p));
        } // Сортировка по производителю телефона в алфавитном или обратном алфавитном порядке.
        public void SortByIMEICode()
        {
            myList.Sort(new CompareByIMEICode());
        } // Сортировка по IMEI телефона в порядке возрастания.
        public void SortByIMEICode(bool p)
        {
            myList.Sort(new CompareByIMEICode(p));
        } // Сортировка по IMEI телефона в порядке возрастания или убывания.
        public void SortByPhoneType()
        {
            myList.Sort(new CompareByPhoneType());
        } // Сортировка по типу телефона в алфавитном порядке.
        public void SortByPhoneType(bool p)
        {
            myList.Sort(new CompareByPhoneType(p));
        } // Сортировка по типу телефона в алфавитном или обратном алфавитном порядке.
        public void SortByYearOfIssue()
        {
            myList.Sort(new CompareByYearOfIssue());
        } // Сортировка по году выпуска в порядке возрастания.
        public void SortByYearOfIssue(bool p)
        {
            myList.Sort(new CompareByYearOfIssue(p));
        } // Сортировка по году выпуска в порядке возрастания или убывания.
        public void SortByWarrantyPeriod()
        {
            myList.Sort(new CompareByWarrantyPeriod());
        } // Сортировка по гарантийному сроку в порядке возрастания.
        public void SortByWarrantyPeriod(bool p)
        {
            myList.Sort(new CompareByWarrantyPeriod(p));
        } // Сортировка по гарантийному сроку в порядке возрастания или убывания.
        public void SortByAmountOfOperativeMemory()
        {
            myList.Sort(new CompareByAmountOfOperativeMemory());
        } // Сортировка по объему оперативной памяти в порядке возрастания.
        public void SortByAmountOfOperativeMemory(bool p)
        {
            myList.Sort(new CompareByAmountOfOperativeMemory(p));
        } // Сортировка по объему оперативной памяти в порядке возрастания или убывания.
        public void SortByPhotoQuality()
        {
            myList.Sort(new CompareByPhotoQuality());
        } // Сортировка по качеству съемки основной камеры в порядке возрастания.
        public void SortByPhotoQuality(bool p)
        {
            myList.Sort(new CompareByPhotoQuality(p));
        } // Сортировка п окачеству съемки основной камеры в порядке возрастания или убывания.
        public void SortByPhysicalMemory()
        {
            myList.Sort(new CompareByPhysicalMemory());
        } // Сортировка по объему встроенной памяти в порядке возрастания.
        public void SortByPhysicalMemory(bool p)
        {
            myList.Sort(new CompareByPhysicalMemory(p));
        } // Сортировка по объему встроенной памяти в порядке возрастания или убывания.
        #endregion
    }
    #region Классы_группировщики
    class CompareByName : IComparer<Phone> // класс для задания условия сравнения при сортировке по имени
    {
        #region IComparer<Phone> Members
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByName()
        {
            ascending = true;
        }

        public CompareByName(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.Name.CompareTo(y.Name);
            return y.Name.CompareTo(x.Name);
        }

        #endregion
    }
    class CompareByPrice : IComparer<Phone> // класс для задания условия сравнения при сортировке по размеру
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByPrice()
        {
            ascending = true;
        }

        public CompareByPrice(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.Price.CompareTo(y.Price);
            return y.Price.CompareTo(x.Price);
        }
    }
    class CompareByDeveloper : IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByDeveloper()
        {
            ascending = true;
        }

        public CompareByDeveloper(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.DeveloperCompany.CompareTo(y.DeveloperCompany);
            return y.DeveloperCompany.CompareTo(x.DeveloperCompany);
        }

    }
    class CompareByIMEICode : IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByIMEICode()
        {
            ascending = true;
        }

        public CompareByIMEICode(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.IMEICode.CompareTo(y.IMEICode);
            return y.IMEICode.CompareTo(x.IMEICode);
        }
    }
    class CompareByPhoneType: IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByPhoneType()
        {
            ascending = true;
        }

        public CompareByPhoneType(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.Type.CompareTo(y.Type);
            return y.Type.CompareTo(x.Type);
        }
    }
    class CompareByYearOfIssue:IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByYearOfIssue()
        {
            ascending = true;
        }

        public CompareByYearOfIssue(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.YearOfIssue.CompareTo(y.YearOfIssue);
            return y.YearOfIssue.CompareTo(x.YearOfIssue);
        }
    }
    class CompareByWarrantyPeriod:IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByWarrantyPeriod()
        {
            ascending = true;
        }

        public CompareByWarrantyPeriod(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.WarrantyPeriod.CompareTo(y.WarrantyPeriod);
            return y.WarrantyPeriod.CompareTo(x.WarrantyPeriod);
        }
    }
    class CompareByAmountOfOperativeMemory:IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByAmountOfOperativeMemory()
        {
            ascending = true;
        }

        public CompareByAmountOfOperativeMemory(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.AmountOfOperativeMemory.CompareTo(y.AmountOfOperativeMemory);
            return y.AmountOfOperativeMemory.CompareTo(x.AmountOfOperativeMemory);
        }
    }
    class CompareByPhotoQuality:IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByPhotoQuality()
        {
            ascending = true;
        }

        public CompareByPhotoQuality(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.PhotoQuality.CompareTo(y.PhotoQuality);
            return y.PhotoQuality.CompareTo(x.PhotoQuality);
        }
    }
    class CompareByPhysicalMemory:IComparer<Phone>
    {
        bool ascending; // определяет порядок сравнения по возрастанию/убыванию

        public CompareByPhysicalMemory()
        {
            ascending = true;
        }

        public CompareByPhysicalMemory(bool a)
        {
            ascending = a;
        }

        public int Compare(Phone x, Phone y)
        {
            if (ascending)
                return x.PhysicalMemory.CompareTo(y.PhysicalMemory);
            return y.PhysicalMemory.CompareTo(x.PhysicalMemory);
        }
    }
    #endregion


}