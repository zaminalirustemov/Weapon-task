using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task
{
    internal class Weapon
    {
        public Weapon(int bulletCapacity, int bulletCount, double dechargeTime, bool ısAuto)
        {
            this.BulletCapacity = bulletCapacity;
            this.BulletCount = bulletCount;
            this.DechargeTime = dechargeTime;
            this.IsAuto = ısAuto;
        }

        public int BulletCapacity { get; set; }
        public int BulletCount { get; set; }
        public double DechargeTime { get; set; }
        public bool IsAuto { get; set; }

        public void ShowAllInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"---BulletCapacity:  {BulletCapacity} \n---BulletCount:     {BulletCount} \n---DechargeTime:    {DechargeTime} \n---Mode:            {IsAuto} ");
        }
        public void Shoot()
        {
            if (BulletCount > 0)
            {
                BulletCount--;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($">>>DISH<<< \nBullet count: {BulletCount} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough bullets, reload");
            }

        }
        public void Fire()
        {
            if (IsAuto == true)
            {
                if (BulletCount > 0)
                {
                    double NowDechargeTime = (DechargeTime * BulletCount) / BulletCapacity;
                    BulletCount = 0;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($">>>DIDIDIDIDIDISHHHHH<<< \nCurrently, the period of discharge of the bullets: {NowDechargeTime} second \nBullet count: {BulletCount} pieces (Not enough bullets, reload)");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Not enough bullets, reload (Bullet count: {BulletCount} )");
                }
            }
            else
            {
                Shoot();
            }


        }
        public int GetRemainBulletCount()
        {
            int remainBullet = BulletCapacity - BulletCount;
            return remainBullet;


        }
        public void Reload()
        {
            if (BulletCount < BulletCapacity)
            {
                BulletCount = BulletCount + GetRemainBulletCount();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"weapon is reloaded. Bullet:{BulletCount}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Full of bullets.");
            }

        }
        public void ChangeFireMode()
        {
            IsAuto = !IsAuto;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Weapon mode changed.");

        }
    }
}
