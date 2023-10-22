namespace Define.Common.Exceptions
{
    [Serializable]
    public class ControllerExceptionMessage : Exception
    {
        public ControllerExceptionMessage(string message) : base(String.Format(message))
        {

        }
        public ControllerExceptionMessage(string athletesExceptionMesseges, string message) : base(String.Format(athletesExceptionMesseges, message))
        {

        }
    }
}
