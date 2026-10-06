//------------------------------------------------------------------------------
// <copyright file="Transition.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa una transición de una máquina de estados finitos. Conoce qué
    /// entrada la dispara y cuál es el próximo estado.
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Transition"/>.
        /// </summary>
        /// <param name="triggerInput">La entrada que dispara la transición.</param>
        /// <param name="nextState">El estado al que lleva la transición.</param>
        public Transition(Input triggerInput, State nextState)
        {
            ArgumentNullException.ThrowIfNull(triggerInput, nameof(triggerInput));
            ArgumentNullException.ThrowIfNull(nextState, nameof(nextState));

            this.TriggerInput = triggerInput;
            this.NextState = nextState;
        }

        /// <summary>
        /// Obtiene la entrada que dispara la transición.
        /// </summary>
        public Input TriggerInput { get; }

        /// <summary>
        /// Obtiene el estado al que lleva la transición.
        /// </summary>
        public State NextState { get; }

        /// <summary>
        /// Determina si la transición es disparada por la entrada recibida.
        /// </summary>
        /// <param name="input">La entrada a evaluar.</param>
        /// <returns><c>true</c> si la entrada dispara la transición;
        /// <c>false</c> en caso contrario.</returns>
        public bool IsTriggeredBy(Input input)
        {
            return this.TriggerInput.Equals(input);
        }
    }
}
