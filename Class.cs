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
            #region �������� ����������������� ������
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
        #region ���� ������ Phone
        long IMEIcode; // �������� ����� �������� (������� �� 16 ����)
        string name; // ������ ��������
        string developerCompany; // ����� ��������
        string type; // ��� ��������
        string description; // �������� ������
        int yearOfIssue; // ��� �������
        int warrantyPeriod; // ����������� ���� � �������
        decimal price; // ���� � ��������
        int timeOfWorkFlightMode; // ����� ������ � ���������� ������
        int timeOfWorkActiveMode; // ����� ������ � �������� ������ (��� ���������� ����������� ���������)
        int amountOfOperativeMemory; // ����� ����������� ������ (� ��)
        int photoQuality; // �������� ������ �������� ������ (� ��)
        int frontalPhotoQuality; // �������� ������ ����������� ������ (� ��)
        string screenResolution; // ���������� ������
        double screenDiagonal; // ��������� ������ (�����)
        bool memoryExpansion; // ����������� ���������� ������ ��������
        int simCount; // ���������� ���-����.
        int physicalMemory; // ���������� ������ �������� (� ��)
        bool technology5G; // ����������� ���������� 5G
        string processor; // ����� ����������
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

        #region ������������ ������ Phone
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
        } // �����������
        public Phone(long IMEIcode, string name, string developerCompany) : this(IMEIcode)
        {
            if (name != "") this.name = name;
            if (developerCompany != "") this.developerCompany = developerCompany;
        } // �����������
        public Phone(long IMEIcode, string name, string developerCompany, decimal price) : this(IMEIcode)
        {
            if (name != "") this.name = name;
            if (developerCompany != "") this.developerCompany = developerCompany;
            if (price != 0) this.price = price;
        } // �����������
        public Phone(long IMEIcode, string name, string developerCompany, string description, decimal price) : this(IMEIcode, name, developerCompany, price)
        {
            if (description != "")
                this.description = description;
        } // �����������
        public Phone(long IMEIcode, string name, string developerCompany, string processor) : this(IMEIcode, name, developerCompany)
        {
            if (processor != "") this.processor = processor;
        } // �����������
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
        } // �����������
        #endregion

        #region �������� ������ Phone
        public string Name
        {
            get { return name; }
        } // �������� "������ ��������" ������ ��� ������. �������� �� ����� �������� ������ �������� 
        public long IMEICode
        {
            get { return IMEIcode; }
        } // �������� "IMEI-��� ��������" ������ ��� ������. �������� �� ����� �������� IMEI-��� ��������
        public string DeveloperCompany
        {
            get { return developerCompany; }
        } // �������� "������������� ��������" ������ ��� ������. �������� �� ����� �������� ������������� ��������.
        public string Type
        {
            get { return type; }
        } // �������� "��� ��������" ������ ��� ������. �������� �� ����� �������� ��� ��������
        public string Description
        {
            get { return description; }
            set { if (value != "") description = value; }
        } // �������� "������" ��� ������ � ��� ������. �������� ����� �������� ���������� � ��������.
        public int YearOfIssue
        {
            get { return yearOfIssue; }
        } // �������� "��� �������" ��� ������. �������� �� ����� �������� ��� ������� ��������
        public int WarrantyPeriod
        {
            get { return warrantyPeriod; }
        } // �������� "����������� ����" ��� ������. �������� �� ����� �������� ����������� ����.
        public decimal Price
        {
            get { return price; }
            set { if (value != 0) price = value; }
        } // �������� "����" ��� ������ � ��� ������. ���� �� ������� ����� ���������� ���������.
        public int TimeOfWorkInFlightMode
        {
            get { return timeOfWorkFlightMode; }
        } // �������� "����� ������ � ���������� ������" ������ ��� ������.
        public int TimeOfWorkInActiveMode
        {
            get { return timeOfWorkActiveMode; }
        } // �������� "����� ������ ��� �������� �������������" ������ ��� ������.
        public int AmountOfOperativeMemory
        {
            get
            {
                return amountOfOperativeMemory;
            }
        } // �������� "����� ����������� ������" ������ ��� ������.
        public int PhotoQuality
        {
            get
            {
                return photoQuality;
            }
        } // �������� "�������� ������ �������� ������" ������ ��� ������.
        public int FrontalPhotoQuality
        {
            get
            {
                return frontalPhotoQuality;
            }
        } // �������� "�������� ������ ����������� ������" ������ ��� ������.
        public string ScreenResolution
        {
            get
            {
                return screenResolution;
            }
        } // �������� "���������� ������" ������ ��� ������.
        public double ScreenDiagonal // �������� "��������� ������" ������ ��� ������.
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
        } // �������� "���������� ������" ������ ��� ������.
        public int SimCount // �������� "���������� ���-����" ������ ��� ������.
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
        } // �������� "���������� ������" ������ ��� ������.
        public bool Technology5G
        {
            get
            {
                return technology5G;
            }
        } // �������� "���������� 5G" ������ ��� ������.
        public string Processor
        {
            get
            {
                return processor;
            }
        } // �������� "���������" ������ ��� ������.
        public override string ToString()
        {
            return string.Format("������������ ��������: {0}\n ������ ��������: {1}\n ���������� IMEI-��� ��������: {2}\n ��� ��������: {3}\n ����� ������ � ���������� ������(����): {4}\n ����� ������ � �������� ������(����): {5}\n ����� ����������� ������(��): {6}\n �������� ������ �������� ������ (��): {7}\n �������� ������ ����������� ������ (��): {17}\n ���������� ������: {8}\n ��������� ������: {18}\n ����������� ���������� ������ (True - ����, False - ���): {9}\n ���������� ���-����: {19}\n ���������� ������ �������� {10}\n ������� ���������� 5G (True - ����, False - ���): {11}\n ������ ����������: {12}\n ������: {13}\n ��� �������: {14}\n ����������� ����: {15}\n ����: {16}. \n\n", developerCompany, name, IMEIcode, type, timeOfWorkFlightMode, timeOfWorkActiveMode, amountOfOperativeMemory, photoQuality, screenResolution, memoryExpansion, physicalMemory, technology5G, processor, description, yearOfIssue, warrantyPeriod, price, frontalPhotoQuality, screenDiagonal, simCount);
        } // ��������������� ������ "ToString"
        public override bool Equals(object obj)
        {
            if ((obj == null) && (GetType() != obj.GetType())) return false;
            Phone temp = (Phone)obj;
            return (temp.Name == this.name) && (temp.IMEICode == IMEIcode) && (temp.DeveloperCompany == developerCompany) && (temp.Type == type) && (temp.Description == description) && (temp.YearOfIssue == yearOfIssue) && (temp.WarrantyPeriod == warrantyPeriod) && (temp.Price == Price) && (temp.TimeOfWorkInFlightMode == timeOfWorkFlightMode) && (temp.TimeOfWorkInActiveMode == timeOfWorkActiveMode) && (temp.AmountOfOperativeMemory == amountOfOperativeMemory) && (temp.PhotoQuality == photoQuality) && (temp.ScreenResolution == screenResolution) && (temp.MemoryExpansion == memoryExpansion) && (temp.PhysicalMemory == physicalMemory) && (temp.Technology5G == technology5G) && (temp.Processor == processor);
        } // ��������������� ������ "Equals"
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
    public class Phone_Shop
    {
        List<Phone> myList = new List<Phone>();

        #region ������ ������ Phone_Shop
        public void Add(Phone newPhone) // ����� ���������� �������� � ���� ������ �������� ���������.
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
        public void RemoveAt(int k) // ����� �������� ��������� ������ � ������� k-1
        {
            if ((k >= 0) && (k < myList.Count)) myList.RemoveAt(k);
        }
        public void RemoveAt(int k, int m) // ����� �������� ��������� ������ � ������� k-1 �� ������� m-1
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
        } // ����� �������� ���������� ������.
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("���������� ��������� �� �������: {0}. \nC����� ���������:\n", myList.Count);
            for (int i = 0; i < myList.Count; i++)
                s.Append("\t" + (i + 1) + ") " + myList[i] + "\n");
            return s.ToString();
        } // ��������������� ������ ToString
        public Phone GetInfoFromIMEICode (long IMEICode)
        {
            for(int i=1;i<myList.Count;i++)
            {
                if (myList[i].IMEICode == IMEICode) return myList[i];
            }
            return myList[myList.Count];
        } // ��������� ���������� � �������� �� ��� IMEICode (������ ������� ������)
        public Phone GetInfoFromNameAndDeveloper(string name,string developer)
        {
            for (int i = 1; i<myList.Count;i++)
            {
                if ((myList[i].Name == name) && (myList[i].DeveloperCompany == developer)) return myList[i];
            }
            return myList[myList.Count];
            
        } // ��������� ���������� � �������� �� ��� ������ � �������������. (������ �������� ������)
        public string SearchByDeveloperCompany(string DeveloperCompany)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].DeveloperCompany == DeveloperCompany) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "�������� ������ ����� � ������� ���";
        } // ����� �� �������������. (����� ������)
        public void DeveloperSale(string DeveloperCompany, decimal Percent) // ����� �� �������������
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
        } // ��������� ���� �������� �� �������� ���� Phone
        public void ChangePrice(long IMEICode, decimal Price)
        {
            myList[myList.IndexOf(GetInfoFromIMEICode(IMEICode))].Price = Price;
        } // ��������� ���� �������� �� IMEICode
        public string SearchByName(string name)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].Name == name) s.Append("\n/t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "������ ������ �������� � ������� ���";

        } // ����� �� ������ ��������.
        public string SearchByType(string type)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].Type == type) s.Append("\n \t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "� ������� �� ������� ��������� ������� ����";

        } // ����� �� ���� ��������. (����� ������)
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
            else return "� ������ ������� ��������� ��������� ���, ���� ������ ���� ������� �������";
        } // ����� �� ������� ��������� (� ��������, ����������� ������� ����������, ����� ������)
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
            else return "��� ��������� � ��������� ����������� ������, ���� ������ �������";
        } // ����� �� ������������ ����� (����������� ���������� � ������� "��" � "��", ����� ������)
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
            else return "��� ��������� � ��������� ����������� ������������ �������� ������, ���� ������ �������";
        } // ����� �� ���������� ������������ �������� ������ (����������� ���������� � ������������ "��" � "��", ����� ������)
        public string SearchByTimeOfWorkFlightMode(int min, int max) // ����� �� ������� ������ � ���������� ������ (����� ������)
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
            else return "��� ��������� � ��������� �������� ������ � ���������� ������, ���� ������ �������";
        }
        public string SearchByTimeOfWorkActiveMode(int min, int max) // ����� �� ������� ������ ��� �������� ������������� (����� ������)
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
            else return "��� ��������� � ��������� �������� ������ ��� �������� �������������, ���� ������ �������";
        }
        public string SearchByPhysicalMemory(int min, int max) // ����� �� ������ ���������� ������ (����� ������)
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
            else return "��� ��������� � ��������� ������� ���������� ������, ���� ������ �������";
        }
        public string SearchByAmountOperativeMemory(int min, int max) // ����� �� ������ ����������� ������ (����� ������)
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
            else return "��� ��������� � ��������� ������� ����������� ������, ���� ������ �������";
        }
        public string SearchByMemoryExpansion(bool memoryExpansion) // ����� �� ������� ����� ��� ����� ������ (����� ������)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].MemoryExpansion == memoryExpansion) s.Append("\n/t" + (i + 1) + ")" + "\t" + myList[i].ToString());
            if (s.ToString() != "")
            {
                return s.ToString();
            }
            else return "��� ��������� � ���������� �����������";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void SortByName()
        {
            myList.Sort(new CompareByName());
        } // ���������� �� ����� �������� � ���������� �������.
        public void SortByName(bool p)
        {
            myList.Sort(new CompareByName(p));
        }  // ���������� �� ����� �������� � ���������� ��� �������� ���������� �������.
        public void SortByPrice()
        {
            myList.Sort(new CompareByPrice());
        } // ���������� �� ���� �������� � ���������� �������.
        public void SortByPrice(bool p)
        {
            myList.Sort(new CompareByPrice(p));
        } // ���������� �� ���� �������� � ���������� ��� �������� ���������� �������.
        public void SortByDeveloper()
        {
            myList.Sort(new CompareByDeveloper());
        }  // ���������� �� ������������� �������� � ���������� �������.
        public void SortByDeveloper(bool p)
        {
            myList.Sort(new CompareByDeveloper(p));
        } // ���������� �� ������������� �������� � ���������� ��� �������� ���������� �������.
        public void SortByIMEICode()
        {
            myList.Sort(new CompareByIMEICode());
        } // ���������� �� IMEI �������� � ������� �����������.
        public void SortByIMEICode(bool p)
        {
            myList.Sort(new CompareByIMEICode(p));
        } // ���������� �� IMEI �������� � ������� ����������� ��� ��������.
        public void SortByPhoneType()
        {
            myList.Sort(new CompareByPhoneType());
        } // ���������� �� ���� �������� � ���������� �������.
        public void SortByPhoneType(bool p)
        {
            myList.Sort(new CompareByPhoneType(p));
        } // ���������� �� ���� �������� � ���������� ��� �������� ���������� �������.
        public void SortByYearOfIssue()
        {
            myList.Sort(new CompareByYearOfIssue());
        } // ���������� �� ���� ������� � ������� �����������.
        public void SortByYearOfIssue(bool p)
        {
            myList.Sort(new CompareByYearOfIssue(p));
        } // ���������� �� ���� ������� � ������� ����������� ��� ��������.
        public void SortByWarrantyPeriod()
        {
            myList.Sort(new CompareByWarrantyPeriod());
        } // ���������� �� ������������ ����� � ������� �����������.
        public void SortByWarrantyPeriod(bool p)
        {
            myList.Sort(new CompareByWarrantyPeriod(p));
        } // ���������� �� ������������ ����� � ������� ����������� ��� ��������.
        public void SortByAmountOfOperativeMemory()
        {
            myList.Sort(new CompareByAmountOfOperativeMemory());
        } // ���������� �� ������ ����������� ������ � ������� �����������.
        public void SortByAmountOfOperativeMemory(bool p)
        {
            myList.Sort(new CompareByAmountOfOperativeMemory(p));
        } // ���������� �� ������ ����������� ������ � ������� ����������� ��� ��������.
        public void SortByPhotoQuality()
        {
            myList.Sort(new CompareByPhotoQuality());
        } // ���������� �� �������� ������ �������� ������ � ������� �����������.
        public void SortByPhotoQuality(bool p)
        {
            myList.Sort(new CompareByPhotoQuality(p));
        } // ���������� � ��������� ������ �������� ������ � ������� ����������� ��� ��������.
        public void SortByPhysicalMemory()
        {
            myList.Sort(new CompareByPhysicalMemory());
        } // ���������� �� ������ ���������� ������ � ������� �����������.
        public void SortByPhysicalMemory(bool p)
        {
            myList.Sort(new CompareByPhysicalMemory(p));
        } // ���������� �� ������ ���������� ������ � ������� ����������� ��� ��������.
        #endregion
    }
    #region ������_�������������
    class CompareByName : IComparer<Phone> // ����� ��� ������� ������� ��������� ��� ���������� �� �����
    {
        #region IComparer<Phone> Members
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
    class CompareByPrice : IComparer<Phone> // ����� ��� ������� ������� ��������� ��� ���������� �� �������
    {
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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
        bool ascending; // ���������� ������� ��������� �� �����������/��������

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