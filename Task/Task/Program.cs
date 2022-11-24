using System.Diagnostics.SymbolStore;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletCapacity;
            int bulletCount;
            double dechargeTime;
            bool isAuto;
            bool check;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">>>>>>>WELCOME TO ARMORY<<<<<<<");
            do
            {

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("---Enter the bulletcapacity:");
                check = int.TryParse(Console.ReadLine(), out bulletCapacity);
                if (bulletCapacity<=0)
                {
                    check = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Bullet capacity is a number and must be greater than 0");
                }

            } while (!check);

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("---Enter the bulletcount:");
                check = int.TryParse(Console.ReadLine(), out bulletCount);
                if (bulletCount > bulletCapacity || bulletCount<0)
                {
                    check = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Bullet count is a number and cannot be less than 0");
                }


            }while (!check) ;
            

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("---Enter the dechargetime:");
                check = double.TryParse(Console.ReadLine(), out dechargeTime);
                if (dechargeTime <= 0)
                {
                    check = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Xeta: Dechargetime is a number and must be greater than 0.");
                }

            } while (!check);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("---Enter the mode(true=Auto mode | false=Single mode):");
                check = bool.TryParse(Console.ReadLine(), out isAuto);

            } while (!check);

            Weapon weapon = new Weapon(bulletCapacity, bulletCount, dechargeTime, isAuto);

            string choise;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("====================================");
                Console.WriteLine("        Menu:");
                Console.WriteLine("0 - For get information\r\n1 - For Shoot method\r\n2 - For Fire method\r\n3 - For GetRemainBulletCount method\r\n4 - For Reload method\r\n5 - For ChangeFireMode method\r\n6 - Console clear\r\n7 - Shortcut to quit the program.\"");
                Console.WriteLine("====================================");
                Console.Write("Please select:"); choise = Console.ReadLine();
                Console.WriteLine("------------------------------------");
                switch (choise)
                {
                    case "0":
                        weapon.ShowAllInfo();
                        break;
                    case "1":
                        weapon.Shoot();
                        break;
                    case "2":
                        weapon.Fire();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"The number of bullets needed to fully fill the capacity: {weapon.GetRemainBulletCount()}");
                        break;
                    case "4":
                        weapon.Reload();
                        break;
                    case "5":
                        weapon.ChangeFireMode();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (choise != "7");

        }
    }
}