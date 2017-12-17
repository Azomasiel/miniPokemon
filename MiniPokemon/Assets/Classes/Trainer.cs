using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace miniPokemon
{
    public class Trainer : Animal
    {

        public List<Pokemon> listPokemon;
        

        public Trainer()
        {
            listPokemon = new List<Pokemon>();
        }


        public int NumberOfPokemon()
        {
            return listPokemon.Count;
        }



        public void AddPokemon (int index)
        {
            listPokemon.Add(Pokemon.allPokemonList[index]);
        }
        
    }
}
