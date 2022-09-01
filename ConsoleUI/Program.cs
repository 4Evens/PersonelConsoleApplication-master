// See https://aka.ms/new-console-template for more information
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public  class Program
    {

        public static IDepartmantService _departmantManager = new DepartmantManager(new MemoryDepartmantDal());

        public static IPersonalService _personalManager = new PersonalManager(new MemoryPersonalDal());
        public static IAuthService _authManager = new AuthManager(new MemoryAdminDal());
        static void Main(string[] args)
        {
            //Giriş için 2 adet admin var, 1-> username:admin1 , password:1234 ; 2-> username: admin2 , password:1234
            //Toplamda 5 Adet Departman ve personel bilgilerinin yer aldığı fake datalar oluşturuldu.
            MainPage();
        }

        //Login Sayfası, İlk Açılacak Olan Sayfa
        public static void MainPage()
        {
            string username = "", password = "";

            Console.WriteLine("ENTER YOUR USERNAME AND PASSWORD");
            Console.Write("Username:");
            username = Console.ReadLine();
            Console.Write("password:");
            password = Console.ReadLine();
            if (Login(username, password))
            {
                Console.Clear();
                Console.WriteLine("Welcome");
                Thread.Sleep(1000);
                SecondPage();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Try Again");
                Thread.Sleep(2000);
                Console.Clear();
                MainPage();
            }
        }

        //Mevcut Login İşlemini Sorgulayan metot
        public static bool Login(string userName, string password)
        {

            return _authManager.IsAdmin(userName, password);
        }


        //Ana Seçim Ekranı , Kullanıcı burada personeller ile mi yoksa departmanlar ile ilgili mi işlem yapacağını seçecek
        public static void SecondPage()
        {
            int choice = 0;

            Console.Clear();
            Console.WriteLine("Choose the number of operation that you want to do " +
                "\n 1-> Personal Operations " +
                "\n 2-> Departmant Operations " +
                "\n 3-> Login Page");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    PersonalOperations();
                    break;
                case 2:
                    DepartmantOperations();
                    break;
                case 3:
                    Console.Clear();
                    MainPage();
                    break;
                default:
                    Console.WriteLine("Wrong Choice, Try Again");
                    Thread.Sleep(1000);
                    Console.Clear();
                    SecondPage();
                    break;

            }

        }


        //3. Açılacak Olan Ekran, departmanlar ile ilgili yapılacak ana işlemleri içerir.
        private static void DepartmantOperations()
        {
            int choice = 0;
            Console.Clear();
            Console.WriteLine("Choose the number of operation that you want to do" +
                "\n 1-> Add Departmant" +
                "\n 2-> Delete Departmant " +
                "\n 3-> Get Departmant List" +
                "\n 4-> Main Menu");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddDepartmant();
                    break;
                case 2:
                    DeleteDepartmant();
                    break;
                case 3:
                    AvailableDepartmans();
                    ConsoleExitMethodToDepartmantOperationPage();
                    break;
                case 4:
                    Console.Clear();
                    SecondPage();
                    break;
                default:
                    Console.WriteLine("Wrong Choice, Try Again");
                    Thread.Sleep(1000);
                    PersonalOperations();
                    break;
            }


        }

        //3. Açılacak Olan Ekran, Personeller ile ilgili yapılacak ana işlemleri içerir.
        private static void PersonalOperations()
        {

            //User 1 => username:engin1 , password:1234 ; User 2 => username:engin2 , password:1234 ,... sayıları 1 arttırarak 5 e kadar giriş
            //yapılabilir. DataAcces Katmanın 5 adet fake data oluşturuldu başlangıç için.
            int choice = 0;
            Console.Clear();
            Console.WriteLine("Choose the number of operation that you want to do" +
                "\n 1-> Add Personal" +
                "\n 2-> Delete Personal " +
                "\n 3-> Get Personal List" +
                "\n 4-> Check Personals that are close to Holiday Beginnig(10 Days)" +
                "\n 5-> Check Personals By Departmants" +
                "\n 6-> Main Menu");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddPersonal();
                    break;
                case 2:
                    DeletePersonal();
                    break;
                case 3:
                    GetPersonalList();
                    break;
                case 4:
                    CheckPersonalByHolidayDate();
                    break;
                case 5:
                    CheckPersonalByDepartmant();
                    break;
                case 6:
                    Console.Clear();
                    SecondPage();
                    break;
                default:
                    Console.WriteLine("Wrong Choice, Try Again");
                    Thread.Sleep(1000);
                    PersonalOperations();
                    break;
            }
        }

        //Departman Silmek istendiğinde çalışacak metot
        private static void DeleteDepartmant()
        {
            string departmantName = "";
            int choiceNumber = 0;
            Console.Clear();
            Console.Write("Write Departmant Name That You Want To Delete \n Departmant Name:");
            departmantName = Console.ReadLine();
            var searchedDepartmant = _departmantManager.GetDepartmant(departmantName);
            if (searchedDepartmant != null)
            {
                Console.Clear();
                Console.WriteLine("Departmant Found \n Departmant Name:{0} \n Are You Sure About Delete? \n 1-> Yes  2->No",
                     searchedDepartmant.DepartmantName);
                choiceNumber = Convert.ToInt32(Console.ReadLine());
                switch (choiceNumber)
                {
                    case 1:
                        Console.Clear();
                        _departmantManager.Remove(searchedDepartmant);
                        Console.WriteLine("Operation Is Success. You Are Directing To Operation Page");
                        Thread.Sleep(1000);
                        DepartmantOperations();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You are Directing to Departmant Operations Page");
                        Thread.Sleep(1000);
                        DepartmantOperations();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice, Try Again");
                        Thread.Sleep(1000);
                        DeleteDepartmant();
                        break;
                }



            }
        }
        //Departman Eklendiğinde çalışacak metot.
        private static void AddDepartmant()
        {
            Console.Clear();
            var departmant = new Departmant();
            Console.Write("Departmant Id:");
            departmant.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Departmant Name:");
            departmant.DepartmantName = Console.ReadLine().ToUpper();

            _departmantManager.Add(departmant);

            Console.WriteLine("Operation is success. You are directing to Departmant Operations Page ");
            Thread.Sleep(1000);
            DepartmantOperations();
        }

        //Departmant Page sayfasına geri döndüren metot
        private static void ConsoleExitMethodToDepartmantOperationPage()
        {
            Console.WriteLine("Write exit to go to Departmant Operations page");
            string returnToPersonalPage = Console.ReadLine();
            if (returnToPersonalPage.Equals("exit"))
            {
                DepartmantOperations();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You Wrote Wrong.Try Again!");
                Thread.Sleep(1000);
                AvailableDepartmans();
                ConsoleExitMethodToDepartmantOperationPage();
            }
        }

        //Personelleri İzin Tarihine 10 günden kısa kalanları listeler.
        private static void CheckPersonalByHolidayDate()
        {
            Console.Clear();
            var listOfPersonal = _personalManager.GetPersonalsByHolidayDate();
            ConsoleWritePersonalList(listOfPersonal);
            ConsoleExitMethodToPersonalOperationPage();

        }

        //Personelleri Departmanlarına Göre Listeler
        private static void CheckPersonalByDepartmant()
        {

            AvailableDepartmans();
            Console.Write("Write Departmant Name:");
            var personalListByDepartman = _personalManager.GetPersonalByDepartman(Console.ReadLine().ToUpper());
            ConsoleWritePersonalList(personalListByDepartman);
            ConsoleExitMethodToPersonalOperationPage();

        }

        //Personel listlerini ekrana yazdıran metot
        private static void ConsoleWritePersonalList(List<Personal> personalListByDepartman)
        {
            foreach (var personal in personalListByDepartman)
            {
                Console.WriteLine(" Id:{0} |Departmant Name:{1} |First Name:{2} |Last Name:{3} |Holiday Beginnig Time:{4} |Holiday Finishing Time:{5}", personal.Id
                    , personal.DepartmantName, personal.FirstName, personal.LastName, personal.HolidayBeginnigTime, personal.HolidayFinishingTime);
            }
        }
        //Personel Silme İşleminde çağırılan metot
        private static void DeletePersonal()
        {
            int numberOfPersonalId = 0, choiceNumber = 0;
            Console.Clear();
            Console.Write("Write Personal Id That You Want To Delete \n Personal Id:");
            numberOfPersonalId = Convert.ToInt32(Console.ReadLine());
            var searchedPersonel = _personalManager.Get(numberOfPersonalId);
            if (searchedPersonel != null)
            {
                Console.Clear();
                Console.WriteLine("Personal Found \n First Name:{0} Second Name:{1} Departmant Name:{2} \n Are You Sure About Delete? \n 1-> Yes  2->No"
                    ,searchedPersonel.FirstName,searchedPersonel.LastName,searchedPersonel.DepartmantName);
                choiceNumber = Convert.ToInt32(Console.ReadLine());
                switch (choiceNumber)
                {
                    case 1:
                        Console.Clear();
                        _personalManager.Remove(searchedPersonel);
                        Console.WriteLine("Operation Is Success. You Are Directing To Operation Page");
                        Thread.Sleep(1000);
                        PersonalOperations();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You are Directing to Personal Operations Page");
                        Thread.Sleep(1000);
                        PersonalOperations();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice, Try Again");
                        Thread.Sleep(1000);
                        DeletePersonal();
                        break;
                }



            }
        }
        //Personel listelemede çağırılan metot
        private static void GetPersonalList()
        {
            Console.Clear();
            var personalList = _personalManager.GetAll();
            foreach (var personal in personalList)
            {
                Console.WriteLine(" Id:{0} |Departmant Name:{1} |First Name:{2} |Last Name:{3} |Holiday Beginnig Time:{4} |Holiday Finishing Time:{5}", personal.Id
                    , personal.DepartmantName, personal.FirstName, personal.LastName, personal.HolidayBeginnigTime, personal.HolidayFinishingTime);
            }

            ConsoleExitMethodToPersonalOperationPage();
        }
        //Operation Page sayfasına geri döndüren metot
        private static void ConsoleExitMethodToPersonalOperationPage()
        {
            Console.WriteLine("Write exit to go to Personal Operations page");
            string returnToPersonalPage = Console.ReadLine();
            if (returnToPersonalPage.Equals("exit"))
            {
                PersonalOperations();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You Wrote Wrong.Try Again!");
                Thread.Sleep(1000);
                GetPersonalList();
            }
        }
        //Personel eklemesi yapan method.
        private static void  AddPersonal()
        {
            Console.Clear();
            AvailableDepartmans();
            var personal = new Personal();
            Console.Write("Personal Id:");
            personal.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Departmant Name:");
            personal.DepartmantName = Console.ReadLine();
            Console.Write("First Name:");
            personal.FirstName = Console.ReadLine();
            Console.Write("Last Name:");
            personal.LastName = Console.ReadLine();
            Console.Write("Holiday Beginnig Time(dd.mm.yyyy):");
            personal.HolidayBeginnigTime = DateOnly.Parse(Console.ReadLine());
            Console.Write("Holiday Finishing Time(dd.mm.yyyy):");
            personal.HolidayFinishingTime = DateOnly.Parse(Console.ReadLine());

            _personalManager.Add(personal);

            Console.WriteLine("Operation is success. You are directing to Personal Operations Page ");
            Thread.Sleep(1000);
            PersonalOperations();


        }
        //Mevcut Departmanları listeleyen metot
        private static void AvailableDepartmans()
        {
            Console.Clear();
            Console.Write("Available Departmants Are: ");
            var departmanList = _departmantManager.GetAll();
            foreach (var departman in departmanList)
            {
                Console.Write(departman.DepartmantName + " | ");
            }
            Console.WriteLine();
        }




        
    }   
}


