//------------------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa una máquina de estados finitos. Conoce sus estados y cuál de
    /// ellos es el estado actual, permite agregar estados, y procesa una o más
    /// entradas.
    /// </summary>
    public class StateMachine
    {
        private List<State> states;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StateMachine"/>.
        /// </summary>
        public StateMachine()
        {
            this.states = new List<State>();
        }

        /// <summary>
        /// Obtiene el estado actual de la máquina. Es <c>null</c> mientras no
        /// se haya agregado ningún estado.
        /// </summary>
        public State CurrentState { get; private set; }

        /// <summary>
        /// Agrega un estado a la máquina. El primer estado que se agrega es el
        /// estado inicial.
        /// </summary>
        /// <param name="state">El estado a agregar.</param>
        public void AddState(State state)
        {
            ArgumentNullException.ThrowIfNull(state, nameof(state));

            if (!this.states.Contains(state))
            {
                this.states.Add(state);
            }

            if (this.CurrentState == null)
            {
                this.CurrentState = state;
            }
        }

        /// <summary>
        /// Procesa una entrada. Si la entrada dispara una transición desde el
        /// estado actual, la máquina sale del estado actual y entra en el
        /// próximo estado; si no, la entrada se ignora y el estado actual no
        /// cambia.
        /// </summary>
        /// <param name="input">La entrada a procesar.</param>
        /// <returns><c>true</c> si la entrada disparó una transición;
        /// <c>false</c> si la entrada fue ignorada.</returns>
        public bool ProcessInput(Input input)
        {
            ArgumentNullException.ThrowIfNull(input, nameof(input));

            if (this.CurrentState == null)
            {
                return false;
            }

            State nextState = this.CurrentState.GetNextState(input);

            if (nextState == null)
            {
                return false;
            }

            this.CurrentState.OnExit();
            this.CurrentState = nextState;
            this.CurrentState.OnEnter();

            return true;
        }

        /// <summary>
        /// Procesa una secuencia de entradas en orden. Las entradas que no
        /// disparan una transición se ignoran y se continúa con la siguiente.
        /// </summary>
        /// <param name="inputs">La secuencia de entradas a procesar.</param>
        /// <returns><c>true</c> si todas las entradas dispararon una
        /// transición; <c>false</c> si alguna fue ignorada.</returns>
        public bool ProcessInputs(Input[] inputs)
        {
            ArgumentNullException.ThrowIfNull(inputs, nameof(inputs));

            bool allProcessed = true;

            foreach (Input input in inputs)
            {
                if (!this.ProcessInput(input))
                {
                    allProcessed = false;
                }
            }

            return allProcessed;
        }
    }
}
