using DoorControl.Test.Unit.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for exception 2: Door breached (i.e. opened without prior validation)
    [TestFixture]
    public class DoorControlDoorBreachedTests
    {
        private DoorControl _uut;
        private IAlarm Alarm;
        private IDoor Door;
        private IEntryNotification EntryNotification;
        private IUserValidation UserValidation;


        [SetUp]
        public void Setup()
        {
            Alarm = Substitute.For<IAlarm>();
            Door = Substitute.For<IDoor>();
            EntryNotification = Substitute.For<IEntryNotification>();
            UserValidation = Substitute.For<IUserValidation>();


            _uut = new DoorControl(Alarm, Door, EntryNotification, UserValidation);
        }

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {
            _uut.DoorOpened();  // Breach door
            Alarm.Received(1).SoundAlarm();
        }
    }
}