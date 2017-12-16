using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace miniPokemon
{
    class Trainer : Animal
    {

        private int age;

        

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public List<Pokemon> listPokemon;
        

        public Trainer(string name, int age)
        : base(name)
        {
            this.age = age;
            listPokemon = new List<Pokemon>();
        }


        public override void WhoAmI()
        {
            Console.WriteLine("I'm a pokemon Trainer !");
        }

        public int NumberOfPokemon()
        {
            return listPokemon.Count;
        }

        public override void Describe()
        {
            Console.WriteLine("My name is " + Name + ", I'm " + age + " and I have " + NumberOfPokemon() + " Pokemon !");
        }

        public void Birthday()
        {
            age++;
        }

        public void MyPokemon()
        {
            Console.WriteLine("My Pokemon are :");
            foreach (Pokemon pokemon in listPokemon)
            {
                Console.WriteLine("- " + pokemon.Name);
            }
        }

        public void CatchAPokemon(Pokemon pokemon)
        {
            listPokemon.Add(pokemon);
        }


        public void AddPokemon (int index)
        {
            listPokemon.Add(Pokemon.allPokemonList[index]);
        }
        
    }
}
