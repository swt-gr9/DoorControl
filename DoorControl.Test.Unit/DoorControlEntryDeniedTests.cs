using DoorControl.Test.Unit.Mocks;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for exception 1: Entry denied
    [TestFixture]
    public class DoorControlEntryDeniedTests
    {
        private DoorControl _uut;
        private MockDoorControlFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockFactory = new MockDoorControlFactory();
            _mockFactory.UserValidation.Validate = false;    // Ensure that validation will fail
            _uut = new DoorControl(_mockFactory);
        }


        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_DoorNotOpened()
        {
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