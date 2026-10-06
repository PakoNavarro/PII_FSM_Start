namespace Ucu.Poo.Fsm.Tests
{
    /// <summary>
    /// Un estado que cuenta cuántas veces se entró y se salió de él, para
    /// verificar que la máquina de estados ejecuta esas acciones.
    /// </summary>
    public class TrackingState : State
    {
        public TrackingState(string name)
            : base(name)
        {
        }

        public int EnterCount { get; private set; }

        public int ExitCount { get; private set; }

        public override void OnEnter()
        {
            this.EnterCount = this.EnterCount + 1;
        }

        public override void OnExit()
        {
            this.ExitCount = this.ExitCount + 1;
        }
    }
}
