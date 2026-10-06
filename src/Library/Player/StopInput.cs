//------------------------------------------------------------------------------
// <copyright file="StopInput.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa la entrada que recibe el reproductor de música cuando se
    /// presiona el botón <c>Stop</c>.
    /// </summary>
    public class StopInput : Input
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StopInput"/>.
        /// </summary>
        public StopInput()
            : base("Stop")
        {
        }
    }
}
