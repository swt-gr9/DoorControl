namespace DoorControl.Test.Unit.Mocks
{
    public class MockDoor : IDoor
    {
        public MockDoor()
        {
            WasCloseCalled = WasOpenCalled = false;
        }

        public bool WasOpenCalled { get; private set; }
        public bool WasCloseCalled { get; private set; }

        // From IDoor
        public void Open() { WasOpenCalled = true; }
        public void Close() { WasCloseCalled = true; }
    }
}