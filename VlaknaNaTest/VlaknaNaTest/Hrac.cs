using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlaknaNaTest
{
    public class Hrac
    {

        private string name;
        private int health;
        private bool isAlive;
        private int max;
        private Object playerLock;

        public Hrac(string name, int max)
        {
            Name = name;
            Health = max;
            IsAlive = true;
            Max = max;
            PlayerLock = new object();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public Object PlayerLock
        {
            get { return playerLock; }
            set { playerLock = value; }
        }

        public void Heal(int value)
        {
            lock (playerLock)
            {
                if (isAlive)
                {
                    health += value;
                    if(health > max)
                    {
                        health = max;
                    }
                    Console.WriteLine($"Player: {name} heal {value}hp, hp = {health}");
                }
                else
                {
                    Console.WriteLine($"Player: {name} heal {value}hp is dead! hp = {health}");
                }
            }
        }

        public void Damage(int value)
        {
            lock (playerLock)
            {
                if (isAlive)
                {
                    health -= value;
                    if (health <= 0)
                    {
                        isAlive = false;
                        health = 0;
                        Console.WriteLine($"Player: {name} damage {value}hp is dead! hp = {health}");
                    }
                    else
                    {
                        Console.WriteLine($"Player: {name} damage {value}hp, hp = {health}");
                    }
                }
                else
                {
                    Console.WriteLine($"Player: {name} is already dead! hp = {health}");
                }
            }
        }

        public override string ToString()
        {
            return $"{name}, HP {health} player is alive: {isAlive}";
        }

    }
}
