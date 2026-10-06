//------------------------------------------------------------------------------
// <copyright file="PlayInput.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa la entrada que recibe el reproductor de música cuando se
    /// presiona el botón <c>Play</c>.
    /// </summary>
    public class PlayInput : Input
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayInput"/>.
        /// </summary>
        public PlayInput()
            : base("Play")
        {
        }
    }
}
