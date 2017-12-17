using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace miniPokemon
{
    public class Pokemon : Animal
    {
        public static Pokemon dracaufeu = new Pokemon(100, 40, Poketype.FIRE);
        public static Pokemon pikachu = new Pokemon(100, 30, Poketype.ELECTRICK);

        public static Pokemon[] allPokemonList = new Pokemon[] { pikachu, dracaufeu};
        
        private Poketype poketype;
        public float damage;
        private bool isKO;
        public float life;
        


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
            if (isKO)
            {
                Destroy(gameObject);
            }
        }

        public Pokemon(int life, int damage, Poketype poketype)
        {
            this.damage = damage;
            this.life = life;
            this.poketype = poketype;
            isKO = false;
        }

        public void GetHurt(float damage)
        {
            life -= damage;
            IsKO = life <= 0;
        }
    }
}
