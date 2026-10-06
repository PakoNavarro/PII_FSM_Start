//------------------------------------------------------------------------------
// <copyright file="State.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa un estado de una máquina de estados finitos. Conoce las
    /// transiciones a otros estados, determina el próximo estado cuando la
    /// máquina recibe una entrada, y ejecuta acciones cuando se entra y cuando
    /// se sale del estado.
    /// </summary>
    public class State
    {
        private List<Transition> transitions;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="State"/>.
        /// </summary>
        /// <param name="name">El nombre del estado.</param>
        public State(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del estado no puede ser nulo ni vacío.", nameof(name));
            }

            this.Name = name;
            this.transitions = new List<Transition>();
        }

        /// <summary>
        /// Obtiene el nombre del estado.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Agrega una transición desde este estado hacia otro estado, que se
        /// dispara con la entrada recibida. Un estado puede tener una sola
        /// transición por cada entrada.
        /// </summary>
        /// <param name="input">La entrada que dispara la transición.</param>
        /// <param name="nextState">El estado al que lleva la transición.</param>
        public void AddTransition(Input input, State nextState)
        {
            ArgumentNullException.ThrowIfNull(input, nameof(input));
            ArgumentNullException.ThrowIfNull(nextState, nameof(nextState));

            if (this.GetNextState(input) != null)
            {
                throw new InvalidOperationException(
                    "El estado " + this.Name + " ya tiene una transición para la entrada " + input.Name + ".");
            }

            this.transitions.Add(new Transition(input, nextState));
        }

        /// <summary>
        /// Determina el próximo estado cuando la máquina recibe una entrada
        /// estando en este estado.
        /// </summary>
        /// <param name="input">La entrada recibida.</param>
        /// <returns>El próximo estado, o <c>null</c> si la entrada no dispara
        /// ninguna transición desde este estado.</returns>
        public State GetNextState(Input input)
        {
            foreach (Transition transition in this.transitions)
            {
                if (transition.IsTriggeredBy(input))
                {
                    return transition.NextState;
                }
            }

            return null;
        }

        /// <summary>
        /// Ejecuta las acciones que corresponden cuando la máquina entra en
        /// este estado. Por defecto no hace nada; las clases sucesoras pueden
        /// sobrescribir este método para agregar comportamiento.
        /// </summary>
        public virtual void OnEnter()
        {
        }

        /// <summary>
        /// Ejecuta las acciones que corresponden cuando la máquina sale de
        /// este estado. Por defecto no hace nada; las clases sucesoras pueden
        /// sobrescribir este método para agregar comportamiento.
        /// </summary>
        public virtual void OnExit()
        {
        }
    }
}
