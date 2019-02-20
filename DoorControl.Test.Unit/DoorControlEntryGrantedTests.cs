using System;
using DoorControl.Test.Unit.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    // Test Fixture for the main (sunny-day) scenario
    [TestFixture]
    public class DoorControlEntryGrantedTests
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
            UserValidation.ValidateEntryRequest("TFJ").Returns(true);
            
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorOpenCalled()
        {
            _uut.RequestEntry("TFJ");
            Door.Received().Open();
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorCloseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            Door.DidNotReceive().Close();
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_BeeperMakeHappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            EntryNotification.Received().NotifyEntryGranted();
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_BeeperMakeUnhappyNoiseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            EntryNotification.DidNotReceive().NotifyEntryDenied();
        }


        [Test]
        public void RequestEntry_DoorOpenedAndClosed_AlarmNotSounded()
        {
            _uut.RequestEntry("TFJ");
            _uut.DoorOpened();
            _uut.DoorClosed();
            Alarm.DidNotReceive().SoundAlarm();
       }
    }
}
