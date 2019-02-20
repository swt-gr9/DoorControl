using Castle.Core.Smtp;
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
        private IDoorControlFactory _mockFactory;
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;

        [SetUp]
        public void Setup()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _entryNotification = Substitute.For<IEntryNotification>();
            _userValidation = Substitute.For<IUserValidation>();
            _mockFactory = Substitute.For<IDoorControlFactory>();
            _uut = new DoorControl(_mockFactory);
           // _mockFactory.UserValidation.Validate = false;    // Ensure that validation will fail
        }


        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_DoorNotOpened()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            Assert.AreEqual(_mockFactory.Door.WasOpenCalled, false);
        }
        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_BeeperMakeUnhappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.AreEqual(_mockFactory.EntryNotification.WasNotifyEntryDeniedCalled, true);
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_BeeperMakeHappyNoiseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.AreEqual(_mockFactory.EntryNotification.WasNotifyEntryGrantedCalled, false);
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_AlarmNotSounded()
        {
            _uut.RequestEntry("TFJ");
            Assert.AreEqual(_mockFactory.Alarm.WasAlarmCalled, false);
        }

    }
}