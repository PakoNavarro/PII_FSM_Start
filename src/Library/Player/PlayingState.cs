//------------------------------------------------------------------------------
// <copyright file="PlayingState.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa el estado <c>Playing</c> del reproductor de música: se está
    /// reproduciendo una canción.
    /// </summary>
    public class PlayingState : State
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayingState"/>.
        /// </summary>
        public PlayingState()
            : base("Playing")
        {
        }

        /// <summary>
        /// Informa en la consola que el reproductor entró en el estado
        /// <c>Playing</c>.
        /// </summary>
        public override void OnEnter()
        {
            Console.WriteLine("Reproduciendo la canción.");
        }
    }
}
