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
        public Trainer opponent;
        public static Pokemon dracaufeu = new Pokemon(100, 80, Poketype.FIRE);
        public static Pokemon pikachu = new Pokemon(100, 70, Poketype.ELECTRICK);

        public static Pokemon[] allPokemonList = new Pokemon[] { dracaufeu, pikachu};

        private Poketype poketype;
        public float damage;
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
                Attack(0, 0);
            }

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


        public void Attack(int attack, int defender)
        {
            opponent.listPokemon[defender].GetHurt(damage * attackList[attack].ratio);
            attackList[attack].Animation(0, defender);
        }

        public void GetHurt(float damage)
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
