//============================================================
// AUTHOR:  TFJ
//============================================================

namespace DoorControl.Test.Unit.Mocks
{
    public class MockDoorControlFactory : IDoorControlFactory
    {
        public MockUserValidation UserValidation { get; set; }
        public MockDoor Door { get; set; }
        public MockEntryNotification EntryNotification { get; set; }
        public MockAlarm Alarm { get; set; }
        
        public MockDoorControlFactory()
        { 
            UserValidation = new MockUserValidation();
            Door = new MockDoor();
            EntryNotification = new MockEntryNotification();
            Alarm = new MockAlarm();
        }

        // From IDoorControlFactory
        public IUserValidation CreateUserValidation()       {   return UserValidation;  }
        public IDoor CreateDoor()                           {   return Door;    }
        public IEntryNotification CreateEntryNotification() {   return EntryNotification;  }
        public IAlarm CreateAlarm()                         {   return Alarm; }
    }
}