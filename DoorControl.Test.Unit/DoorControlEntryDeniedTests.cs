using DoorControl.Test.Unit.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for exception 1: Entry denied
    [TestFixture]
    public class DoorControlEntryDeniedTests
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
            UserValidation.ValidateEntryRequest("TFJ").Returns(false);    // Ensure that validation will fail
            
        }


        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_DoorNotOpened()
        {
            _uut.RequestEntry("TFJ");
            Door.DidNotReceive().Open();
        }
        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_BeeperMakeUnhappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            EntryNotification.Received().NotifyEntryDenied();
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_BeeperMakeHappyNoiseNotCalled()
        {
            
            _uut.RequestEntry("TFJ");
            EntryNotification.DidNotReceive().NotifyEntryGranted();
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_AlarmNotSounded()
        {
            _uut.RequestEntry("TFJ");
            Alarm.DidNotReceive().SoundAlarm();
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_AlarmNotSoundedd()
        {
            _uut.RequestEntry("TFJ");
            Alarm.DidNotReceive().SoundAlarm();
        }

    }
}