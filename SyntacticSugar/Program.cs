using System;
using System.Collections.Generic;
using System.Numerics;

namespace SyntacticSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            var predators = new List<string>();
            predators.Add("Anteater");
            predators.Add("Termites");

            var prey = new List<string>();
            prey.Add("Carrion");
            prey.Add("Sugar");

            var bug = new Bug("Andy", "Ant", predators, prey);

            Console.WriteLine($"{bug.FormalName} likes to prey on {bug.PreyList()}");
            Console.WriteLine($"{bug.FormalName} hates {bug.PredatorList()}");

            Console.WriteLine(bug.Eat("Sugar"));
            Console.WriteLine(bug.Eat("plastic"));
        }
        public class Bug
        {
            /*
                You can declare a typed public property, make it read-only,
                and initialize it with a default value all on the same
                line of code in C#. Readonly properties can be set in the
                class' constructors, but not by external code.
            */
            public string Name { get; } = "";
            public string Species { get; } = "";
            public List<string> Predators { get; } = new List<string>();
            public List<string> Prey { get; } = new List<string>();

            // Convert this readonly property to an expression member
            public string FormalName => $"{this.Name} the {this.Species}";

            // Class constructor
            public Bug(string name, string species, List<string> predators, List<string> prey)
            {
                this.Name = name;
                this.Species = species;
                this.Predators = predators;
                this.Prey = prey;
            }

            // Convert this method to an expression member
            public string PreyList() => string.Join(", ", this.Prey);

            // Convert this method to an expression member
            public string PredatorList() => string.Join(", ", this.Predators);

            // Convert this to expression method
            public string Eat(string food) => Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
        }
    }
}
