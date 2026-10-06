using NUnit.Framework;

namespace Ucu.Poo.Fsm.Tests
{
    [TestFixture]
    public class MusicPlayerTests
    {
        private MusicPlayer player;

        [SetUp]
        public void SetUp()
        {
            this.player = new MusicPlayer();
        }

        [Test]
        public void Constructor_NewPlayer_IsStopped()
        {
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
            Assert.That(this.player.CurrentState.Name, Is.EqualTo("Stopped"));
        }

        [Test]
        public void ProcessInput_PlayWhenStopped_ChangesToPlaying()
        {
            bool result = this.player.ProcessInput(new PlayInput());

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PlayingState>());
        }

        [Test]
        public void ProcessInput_PauseWhenPlaying_ChangesToPaused()
        {
            this.player.ProcessInput(new PlayInput());

            bool result = this.player.ProcessInput(new PauseInput());

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PausedState>());
        }

        [Test]
        public void ProcessInput_StopWhenPlaying_ChangesToStopped()
        {
            this.player.ProcessInput(new PlayInput());

            bool result = this.player.ProcessInput(new StopInput());

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void ProcessInput_PlayWhenPaused_ChangesToPlaying()
        {
            this.player.ProcessInput(new PlayInput());
            this.player.ProcessInput(new PauseInput());

            bool result = this.player.ProcessInput(new PlayInput());

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PlayingState>());
        }

        [Test]
        public void ProcessInput_StopWhenPaused_ChangesToStopped()
        {
            this.player.ProcessInput(new PlayInput());
            this.player.ProcessInput(new PauseInput());

            bool result = this.player.ProcessInput(new StopInput());

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void ProcessInput_PauseWhenStopped_IsIgnored()
        {
            bool result = this.player.ProcessInput(new PauseInput());

            Assert.That(result, Is.False);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void ProcessInput_StopWhenStopped_IsIgnored()
        {
            bool result = this.player.ProcessInput(new StopInput());

            Assert.That(result, Is.False);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void ProcessInput_PlayWhenPlaying_IsIgnored()
        {
            this.player.ProcessInput(new PlayInput());

            bool result = this.player.ProcessInput(new PlayInput());

            Assert.That(result, Is.False);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PlayingState>());
        }

        [Test]
        public void ProcessInput_PauseWhenPaused_IsIgnored()
        {
            this.player.ProcessInput(new PlayInput());
            this.player.ProcessInput(new PauseInput());

            bool result = this.player.ProcessInput(new PauseInput());

            Assert.That(result, Is.False);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PausedState>());
        }

        [Test]
        public void ProcessInputs_PlayThenStop_EndsStopped()
        {
            Input[] inputs = new Input[] { new PlayInput(), new StopInput() };

            bool result = this.player.ProcessInputs(inputs);

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void ProcessInputs_PlayThenPause_EndsPaused()
        {
            Input[] inputs = new Input[] { new PlayInput(), new PauseInput() };

            bool result = this.player.ProcessInputs(inputs);

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PausedState>());
        }

        [Test]
        public void Play_WhenStopped_ChangesToPlaying()
        {
            bool result = this.player.Play();

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PlayingState>());
        }

        [Test]
        public void Pause_WhenPlaying_ChangesToPaused()
        {
            this.player.Play();

            bool result = this.player.Pause();

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<PausedState>());
        }

        [Test]
        public void Stop_WhenPaused_ChangesToStopped()
        {
            this.player.Play();
            this.player.Pause();

            bool result = this.player.Stop();

            Assert.That(result, Is.True);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }

        [Test]
        public void Stop_WhenStopped_IsIgnored()
        {
            bool result = this.player.Stop();

            Assert.That(result, Is.False);
            Assert.That(this.player.CurrentState, Is.InstanceOf<StoppedState>());
        }
    }
}
