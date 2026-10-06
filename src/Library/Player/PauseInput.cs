//------------------------------------------------------------------------------
// <copyright file="PauseInput.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa la entrada que recibe el reproductor de música cuando se
    /// presiona el botón <c>Pause</c>.
    /// </summary>
    public class PauseInput : Input
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PauseInput"/>.
        /// </summary>
        public PauseInput()
            : base("Pause")
        {
        }
    }
}
