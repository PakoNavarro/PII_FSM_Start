//------------------------------------------------------------------------------
// <copyright file="Input.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa una entrada de una máquina de estados finitos, es decir, uno
    /// de los símbolos del alfabeto de la máquina. Dos entradas con el mismo
    /// nombre se consideran la misma entrada.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Input"/>.
        /// </summary>
        /// <param name="name">El nombre de la entrada.</param>
        public Input(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre de la entrada no puede ser nulo ni vacío.", nameof(name));
            }

            this.Name = name;
        }

        /// <summary>
        /// Obtiene el nombre de la entrada.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Determina si el objeto recibido es una entrada con el mismo nombre
        /// que esta.
        /// </summary>
        /// <param name="obj">El objeto a comparar con esta entrada.</param>
        /// <returns><c>true</c> si el objeto es una entrada con el mismo
        /// nombre; <c>false</c> en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            Input other = obj as Input;

            if (other == null)
            {
                return false;
            }

            return string.Equals(this.Name, other.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Obtiene el código hash de la entrada, calculado a partir de su
        /// nombre.
        /// </summary>
        /// <returns>El código hash de la entrada.</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode(StringComparison.Ordinal);
        }

        /// <summary>
        /// Obtiene el nombre de la entrada.
        /// </summary>
        /// <returns>El nombre de la entrada.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
