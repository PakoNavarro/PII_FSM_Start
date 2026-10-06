//------------------------------------------------------------------------------
// <copyright file="PausedState.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa el estado <c>Paused</c> del reproductor de música: la
    /// reproducción de la canción está detenida temporalmente.
    /// </summary>
    public class PausedState : State
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PausedState"/>.
        /// </summary>
        public PausedState()
            : base("Paused")
        {
        }

        /// <summary>
        /// Informa en la consola que el reproductor entró en el estado
        /// <c>Paused</c>.
        /// </summary>
        public override void OnEnter()
        {
            Console.WriteLine("Reproducción en pausa.");
        }
    }
}
