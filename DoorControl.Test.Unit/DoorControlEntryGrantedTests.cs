using System;
using DoorControl.Test.Unit.Mocks;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for the main (sunny-day) scenario
    [TestFixture]
    public class DoorControlEntryGrantedTests
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
        public void RequestEntry_CorrectIdUsedForDbQuery()
        {
            _uut.RequestEntry("TFJ");
            Assert.That(_mockFactory.UserValidation.LastId, Is.EqualTo("TFJ"));
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorOpenCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.That(_mockFactory.Door.WasOpenCalled, Is.EqualTo(true));
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorCloseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.That(_mockFactory.Door.WasCloseCalled, Is.EqualTo(false));
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_BeeperMakeHappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.That(_mockFactory.EntryNotification.WasNotifyEntryGrantedCalled, Is.EqualTo(true));
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_BeeperMakeUnhappyNoiseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            Assert.That(_mockFactory.EntryNotification.WasNotifyEntryDeniedCalled, Is.EqualTo(false));
        }


        [Test]
        public void RequestEntry_DoorOpened_DoorIsClosed()
        {
            _uut.RequestEntry("TFJ");
            _uut.DoorOpened();
            Assert.That(_mockFactory.Door.WasCloseCalled, Is.True);
        }



        [Test]
        public void RequestEntry_DoorOpenedAndClosed_AlarmNotSounded()
        {
            _uut.RequestEntry("TFJ");
            _uut.DoorOpened();
            _uut.DoorClosed();
            Assert.That(_mockFactory.Alarm.WasAlarmCalled, Is.EqualTo(false));
       }
    }
}
