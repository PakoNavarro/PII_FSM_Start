using System;
using NUnit.Framework;

namespace Ucu.Poo.Fsm.Tests
{
    [TestFixture]
    public class TransitionTests
    {
        private Input play;
        private State playing;

        [SetUp]
        public void SetUp()
        {
            this.play = new Input("Play");
            this.playing = new State("Playing");
        }

        [Test]
        public void Constructor_ValidArguments_SetsTriggerInputAndNextState()
        {
            Transition transition = new Transition(this.play, this.playing);

            Assert.That(transition.TriggerInput, Is.SameAs(this.play));
            Assert.That(transition.NextState, Is.SameAs(this.playing));
        }

        [Test]
        public void Constructor_NullTriggerInput_ThrowsArgumentNullException()
        {
            TestDelegate action = () => { Transition created = new Transition(null, this.playing); };

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_NullNextState_ThrowsArgumentNullException()
        {
            TestDelegate action = () => { Transition created = new Transition(this.play, null); };

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void IsTriggeredBy_TriggerInput_ReturnsTrue()
        {
            Transition transition = new Transition(this.play, this.playing);

            Assert.That(transition.IsTriggeredBy(new Input("Play")), Is.True);
        }

        [Test]
        public void IsTriggeredBy_OtherInput_ReturnsFalse()
        {
            Transition transition = new Transition(this.play, this.playing);

            Assert.That(transition.IsTriggeredBy(new Input("Stop")), Is.False);
        }

        [Test]
        public void IsTriggeredBy_Null_ReturnsFalse()
        {
            Transition transition = new Transition(this.play, this.playing);

            Assert.That(transition.IsTriggeredBy(null), Is.False);
        }
    }
}
