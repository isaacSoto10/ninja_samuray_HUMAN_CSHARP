using System;
using System.Collections.Generic;

namespace FirstCSharp
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        
        public virtual int Health
        {
            get { return health; } 
    
            set { this.health = value;}
        }
        
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
        
        // Build Attack method
        public int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }


        
    }
    class Wizard: Human
    {
        public Wizard(string n) : base(n)
        {
            Health = 50;
            Intelligence = 175;
        }
        public void attack(object target)
        {
            int dmg = (5 * intelligence);
            target.health -= dmg;
            Wizard.health += dmg;
        }
        public void heal()
        {
            health += 10 * intelligence;
        }

    }
    class Samurai : Human
    {
        public static int count = 0;
        public Samurai(string n) : base(n) {
            count++;
            health = 200;
        }

        public void death_blow(object target) {
            Human enemy = target as Human;
            if(enemy != null) {
                if(enemy.health < 50) {
                    enemy.health = 0;
                }
            }
        }

        public void meditate() {
            health = 200;
        }

        public static void how_many() {
            Console.WriteLine(count);
        }
    }
    class Ninja : Human 
    {
        public Ninja(string n) : base(n)
        {
            Dexterity = 175;

        }
        public void Steal(object target)
        {
            Human enemy = target as Human;
            if(enemy != null)
            {
                Attack(enemy);
                Health += 10;

            }

        }
        public void get_away()
        {
            health -= 15;

        }
        

    }
    public static void Main(string[] args)
    {
        Wizard wiz = new Wizard("Caster");
        Ninja nin = new Ninja("Sneaker");
        Samurai sam = new Samurai("Slasher");
    }
}



