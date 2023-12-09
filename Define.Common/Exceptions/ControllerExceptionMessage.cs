namespace Define.Common.Exceptions
{
    [Serializable]
    public class ControllerExceptionMessage : Exception
    {
        public ControllerExceptionMessage(string message) : base(String.Format(message))
        {

        }
        public ControllerExceptionMessage(string athletesExceptionMessages, string message) : base(String.Format(athletesExceptionMessages, message))
        {

        }
    }
}
