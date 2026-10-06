//------------------------------------------------------------------------------
// <copyright file="StoppedState.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa el estado <c>Stopped</c> del reproductor de música: no hay
    /// ninguna canción reproduciéndose.
    /// </summary>
    public class StoppedState : State
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StoppedState"/>.
        /// </summary>
        public StoppedState()
            : base("Stopped")
        {
        }

        /// <summary>
        /// Informa en la consola que el reproductor entró en el estado
        /// <c>Stopped</c>.
        /// </summary>
        public override void OnEnter()
        {
            Console.WriteLine("Reproducción detenida.");
        }
    }
}
