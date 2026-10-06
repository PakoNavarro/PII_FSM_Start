using System;
using NUnit.Framework;

namespace Ucu.Poo.Fsm.Tests
{
    [TestFixture]
    public class StateTests
    {
        private Input play;
        private Input stop;
        private State stopped;
        private State playing;

        [SetUp]
        public void SetUp()
        {
            this.play = new Input("Play");
            this.stop = new Input("Stop");
            this.stopped = new State("Stopped");
            this.playing = new State("Playing");
        }

        [Test]
        public void Constructor_ValidName_SetsName()
        {
            Assert.That(this.stopped.Name, Is.EqualTo("Stopped"));
        }

        [Test]
        public void Constructor_NullName_ThrowsArgumentException()
        {
            TestDelegate action = () => { State created = new State(null); };

            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetNextState_InputWithTransition_ReturnsNextState()
        {
            this.stopped.AddTransition(this.play, this.playing);

            Assert.That(this.stopped.GetNextState(this.play), Is.SameAs(this.playing));
        }

        [Test]
        public void GetNextState_InputWithoutTransition_ReturnsNull()
        {
            this.stopped.AddTransition(this.play, this.playing);

            Assert.That(this.stopped.GetNextState(this.stop), Is.Null);
        }

        [Test]
        public void GetNextState_StateWithoutTransitions_ReturnsNull()
        {
            Assert.That(this.stopped.GetNextState(this.play), Is.Null);
        }

        [Test]
        public void GetNextState_SeveralTransitions_ReturnsStateOfMatchingTransition()
        {
            State paused = new State("Paused");
            Input pause = new Input("Pause");
            this.playing.AddTransition(pause, paused);
            this.playing.AddTransition(this.stop, this.stopped);

            Assert.That(this.playing.GetNextState(pause), Is.SameAs(paused));
            Assert.That(this.playing.GetNextState(this.stop), Is.SameAs(this.stopped));
        }

        [Test]
        public void AddTransition_TransitionToSameState_ReturnsSameState()
        {
            this.playing.AddTransition(this.play, this.playing);

            Assert.That(this.playing.GetNextState(this.play), Is.SameAs(this.playing));
        }

        [Test]
        public void AddTransition_NullInput_ThrowsArgumentNullException()
        {
            TestDelegate action = () => this.stopped.AddTransition(null, this.playing);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void AddTransition_NullNextState_ThrowsArgumentNullException()
        {
            TestDelegate action = () => this.stopped.AddTransition(this.play, null);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void AddTransition_InputAlreadyHasTransition_ThrowsInvalidOperationException()
        {
            this.stopped.AddTransition(this.play, this.playing);

            TestDelegate action = () => this.stopped.AddTransition(new Input("Play"), this.stopped);


            Assert.That(action, Throws.TypeOf<InvalidOperationException>());
        }
    }
}
