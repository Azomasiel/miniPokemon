using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace miniPokemon
{
    public class Pokemon : Animal
    {
        public GameObject pokemon;
        public GameObject opponent;
        public static Pokemon dracaufeu = new Pokemon("Dracaufeu", 100, 80, Poketype.FIRE);
        public static Pokemon pikachu = new Pokemon("Pikachu", 100, 70, Poketype.ELECTRICK);

        public static Pokemon[] allPokemonList = new Pokemon[] { dracaufeu, pikachu};

        private Poketype poketype;
        public float damage;
        private int level;
        private bool isKO;
        public float life;

        public Attack[] attackList;


        public float Life
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

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                attackList[0].Animation(0, 0);
            }
        }

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

        public float Attack()
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
