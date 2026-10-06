//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Ucu.Poo.Fsm;
using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// El programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            // Crea un reproductor de música, una secuencia de entradas y
            // procesa esas entradas con el reproductor de música.
            MusicPlayer player = new MusicPlayer();
            Console.WriteLine("Estado inicial: " + player.CurrentState.Name);

            Input[] inputs = new Input[]
            {
                new PlayInput(),
                new PauseInput(),
                new PlayInput(),
                new StopInput(),
            };

            foreach (Input input in inputs)
            {
                Console.WriteLine("Entrada: " + input.Name);
                player.ProcessInput(input);
            }

            Console.WriteLine("Estado final: " + player.CurrentState.Name);

            // Una entrada que no provoca un cambio de estado se ignora.
            Input[] inputsWithIgnored = new Input[]
            {
                new PauseInput(),
                new PlayInput(),
            };

            bool allProcessed = player.ProcessInputs(inputsWithIgnored);
            Console.WriteLine("¿Todas las entradas cambiaron el estado? " + allProcessed);
            Console.WriteLine("Estado final: " + player.CurrentState.Name);
        }
    }
}
