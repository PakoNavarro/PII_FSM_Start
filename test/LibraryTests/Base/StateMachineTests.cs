using System;
using NUnit.Framework;

namespace Ucu.Poo.Fsm.Tests
{
    [TestFixture]
    public class StateMachineTests
    {
        private Input play;
        private Input stop;
        private TrackingState stopped;
        private TrackingState playing;
        private StateMachine machine;

        [SetUp]
        public void SetUp()
        {
            this.play = new Input("Play");
            this.stop = new Input("Stop");
            this.stopped = new TrackingState("Stopped");
            this.playing = new TrackingState("Playing");
            this.stopped.AddTransition(this.play, this.playing);
            this.playing.AddTransition(this.stop, this.stopped);

            this.machine = new StateMachine();
            this.machine.AddState(this.stopped);
            this.machine.AddState(this.playing);
        }

        [Test]
        public void CurrentState_MachineWithoutStates_IsNull()
        {
            StateMachine emptyMachine = new StateMachine();

            Assert.That(emptyMachine.CurrentState, Is.Null);
        }

        [Test]
        public void AddState_FirstState_BecomesCurrentState()
        {
            Assert.That(this.machine.CurrentState, Is.SameAs(this.stopped));
        }

        [Test]
        public void AddState_SecondState_DoesNotChangeCurrentState()
        {
            this.machine.AddState(new State("Paused"));

            Assert.That(this.machine.CurrentState, Is.SameAs(this.stopped));
        }

        [Test]
        public void AddState_Null_ThrowsArgumentNullException()
        {
            TestDelegate action = () => this.machine.AddState(null);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ProcessInput_InputWithTransition_ChangesCurrentStateAndReturnsTrue()
        {
            bool result = this.machine.ProcessInput(this.play);

            Assert.That(result, Is.True);
            Assert.That(this.machine.CurrentState, Is.SameAs(this.playing));
        }

        [Test]
        public void ProcessInput_InputWithoutTransition_KeepsCurrentStateAndReturnsFalse()
        {
            bool result = this.machine.ProcessInput(this.stop);

            Assert.That(result, Is.False);
            Assert.That(this.machine.CurrentState, Is.SameAs(this.stopped));
        }

        [Test]
        public void ProcessInput_MachineWithoutStates_ReturnsFalse()
        {
            StateMachine emptyMachine = new StateMachine();

            Assert.That(emptyMachine.ProcessInput(this.play), Is.False);
        }

        [Test]
        public void ProcessInput_Null_ThrowsArgumentNullException()
        {
            TestDelegate action = () => this.machine.ProcessInput(null);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ProcessInput_InputWithTransition_ExitsCurrentStateAndEntersNextState()
        {
            this.machine.ProcessInput(this.play);

            Assert.That(this.stopped.ExitCount, Is.EqualTo(1));
            Assert.That(this.playing.EnterCount, Is.EqualTo(1));
            Assert.That(this.stopped.EnterCount, Is.EqualTo(0));
            Assert.That(this.playing.ExitCount, Is.EqualTo(0));
        }

        [Test]
        public void ProcessInput_InputWithoutTransition_DoesNotExitCurrentState()
        {
            this.machine.ProcessInput(this.stop);

            Assert.That(this.stopped.ExitCount, Is.EqualTo(0));
            Assert.That(this.stopped.EnterCount, Is.EqualTo(0));
        }

        [Test]
        public void ProcessInputs_AllInputsWithTransition_ChangesCurrentStateAndReturnsTrue()
        {
            Input[] inputs = new Input[] { this.play, this.stop, this.play };

            bool result = this.machine.ProcessInputs(inputs);

            Assert.That(result, Is.True);
            Assert.That(this.machine.CurrentState, Is.SameAs(this.playing));
        }

        [Test]
        public void ProcessInputs_SomeInputWithoutTransition_IgnoresItAndReturnsFalse()
        {
            Input[] inputs = new Input[] { this.play, this.play, this.stop };

            bool result = this.machine.ProcessInputs(inputs);

            Assert.That(result, Is.False);
            Assert.That(this.machine.CurrentState, Is.SameAs(this.stopped));
        }

        [Test]
        public void ProcessInputs_NoInputs_KeepsCurrentStateAndReturnsTrue()
        {
            bool result = this.machine.ProcessInputs(Array.Empty<Input>());

            Assert.That(result, Is.True);
            Assert.That(this.machine.CurrentState, Is.SameAs(this.stopped));
        }

        [Test]
        public void ProcessInputs_Null_ThrowsArgumentNullException()
        {
            TestDelegate action = () => this.machine.ProcessInputs(null);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }
    }
}
