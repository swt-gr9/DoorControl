using DoorControl.Test.Unit.Mocks;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for exception 2: Door breached (i.e. opened without prior validation)
    [TestFixture]
    public class DoorControlDoorBreachedTests
    {
        private DoorControl _uut;
        private MockDoorControlFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockFactory = new MockDoorControlFactory();
            _uut = new DoorControl(_mockFactory);
        }

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {
            _uut.DoorOpened();  // Breach door
            Assert.That(_mockFactory.Alarm.WasAlarmCalled, Is.True);
        }
    }
}