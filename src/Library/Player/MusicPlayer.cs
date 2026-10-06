//------------------------------------------------------------------------------
// <copyright file="MusicPlayer.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// Representa un reproductor de música modelado como una máquina de estados
    /// finitos. Puede estar en los estados <c>Stopped</c>, <c>Playing</c> o
    /// <c>Paused</c>, y cambia de estado al recibir las entradas <c>Play</c>,
    /// <c>Pause</c> o <c>Stop</c>. El estado inicial es <c>Stopped</c>.
    /// </summary>
    public class MusicPlayer : StateMachine
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MusicPlayer"/>
        /// con sus estados y las transiciones entre ellos.
        /// </summary>
        public MusicPlayer()
        {
            State stopped = new StoppedState();
            State playing = new PlayingState();
            State paused = new PausedState();

            stopped.AddTransition(new PlayInput(), playing);
            playing.AddTransition(new PauseInput(), paused);
            playing.AddTransition(new StopInput(), stopped);
            paused.AddTransition(new PlayInput(), playing);
            paused.AddTransition(new StopInput(), stopped);

            // El primer estado que se agrega es el estado inicial.
            this.AddState(stopped);
            this.AddState(playing);
            this.AddState(paused);
        }

        /// <summary>
        /// Presiona el botón <c>Play</c> del reproductor.
        /// </summary>
        /// <returns><c>true</c> si el reproductor cambió de estado;
        /// <c>false</c> si el botón fue ignorado.</returns>
        public bool Play()
        {
            return this.ProcessInput(new PlayInput());
        }

        /// <summary>
        /// Presiona el botón <c>Pause</c> del reproductor.
        /// </summary>
        /// <returns><c>true</c> si el reproductor cambió de estado;
        /// <c>false</c> si el botón fue ignorado.</returns>
        public bool Pause()
        {
            return this.ProcessInput(new PauseInput());
        }

        /// <summary>
        /// Presiona el botón <c>Stop</c> del reproductor.
        /// </summary>
        /// <returns><c>true</c> si el reproductor cambió de estado;
        /// <c>false</c> si el botón fue ignorado.</returns>
        public bool Stop()
        {
            return this.ProcessInput(new StopInput());
        }
    }
}
