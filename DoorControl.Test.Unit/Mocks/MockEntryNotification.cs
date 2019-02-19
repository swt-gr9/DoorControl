namespace DoorControl.Test.Unit.Mocks
{
    public class MockEntryNotification : IEntryNotification
    {
        public bool WasNotifyEntryGrantedCalled { get; private set; }
        public bool WasNotifyEntryDeniedCalled { get; private set; }

        public MockEntryNotification()
        {
            WasNotifyEntryDeniedCalled = WasNotifyEntryGrantedCalled = false;
        }

        // From IEntryNotification
        public void NotifyEntryGranted() { WasNotifyEntryGrantedCalled = true; }
        public void NotifyEntryDenied() { WasNotifyEntryDeniedCalled = true; }
    }
}