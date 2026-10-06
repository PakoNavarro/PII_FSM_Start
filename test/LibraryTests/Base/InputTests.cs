using System;
using NUnit.Framework;

namespace Ucu.Poo.Fsm.Tests
{
    [TestFixture]
    public class InputTests
    {
        [Test]
        public void Constructor_ValidName_SetsName()
        {
            Input input = new Input("Play");

            Assert.That(input.Name, Is.EqualTo("Play"));
        }

        [Test]
        public void Constructor_NullName_ThrowsArgumentException()
        {
            TestDelegate action = () => { Input created = new Input(null); };

            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            TestDelegate action = () => { Input created = new Input(string.Empty); };

            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Equals_InputWithSameName_ReturnsTrue()
        {
            Input first = new Input("Play");
            Input second = new Input("Play");

            Assert.That(first.Equals(second), Is.True);
        }

        [Test]
        public void Equals_InputWithDifferentName_ReturnsFalse()
        {
            Input first = new Input("Play");
            Input second = new Input("Stop");

            Assert.That(first.Equals(second), Is.False);
        }

        [Test]
        public void Equals_ObjectThatIsNotInput_ReturnsFalse()
        {
            Input input = new Input("Play");

            Assert.That(input.Equals("Play"), Is.False);
        }

        [Test]
        public void GetHashCode_InputsWithSameName_ReturnsSameValue()
        {
            Input first = new Input("Play");
            Input second = new Input("Play");

            Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
        }

        [Test]
        public void ToString_ValidName_ReturnsName()
        {
            Input input = new Input("Play");

            Assert.That(input.ToString(), Is.EqualTo("Play"));
        }
    }
}
