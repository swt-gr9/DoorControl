namespace DoorControl.Test.Unit.Mocks
{
    public class MockAlarm : IAlarm
    {
        public bool WasAlarmCalled { get; private set; }
        public MockAlarm() { WasAlarmCalled = false; }

        // From IAlarm
        public void SoundAlarm() { WasAlarmCalled = true; }
    }
}