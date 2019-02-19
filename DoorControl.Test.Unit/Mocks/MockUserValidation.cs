namespace DoorControl.Test.Unit.Mocks
{
    public class MockUserValidation : IUserValidation
    {
        public bool Validate { get; set; }
        public string LastId { get; private set; }

        public MockUserValidation()
        {
            Validate = true;
        }

        
        // From IUserValidation
        public bool ValidateEntryRequest(string id)
        {
            LastId = id;
            return Validate;
        }

    }
}