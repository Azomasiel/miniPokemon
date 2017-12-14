using System;
using System.Collections.Generic;
using System.Reflection;

namespace miniPokemon
{
    public class Pokemon : Animal
    {
        private Poketype poketype;
        private int damage;
        private int level;
        private bool isKO;
        private int life;


        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public bool IsKO
        {
            get { return isKO; }
            set { isKO = value; }
        }


        public enum Poketype
        {
            POISON,
            FIRE,
            WATER,
            GRASS,
            ELECTRICK
        };


        
        public Pokemon(string name, int life, int damage, Poketype poketype)
        : base(name)
        {
            this.damage = damage;
            this.life = life;
            this.poketype = poketype;
            level = 1;
            isKO = false;
        }
        

        
        public override void WhoAmI()
        {
            Console.WriteLine("I'm a Pokemon");
        }

        public override void Describe()
        {
            Console.WriteLine("My name is " + Name + " I'm a Pokemon of type " + poketype + " and I'm level " + level);
        }
        
        public void LevelUp()
        {
            level++;
        }

        public int Attack()
        {
            return damage;
        }

        public void GetHurt(int damage)
        {
            life -= damage;
            IsKO = life <= 0;
        }

        public void Heal(int life)
        {
            this.life += life;
            IsKO = life <= 0;
        }
    }
}
