namespace SecretSanta.Web.State
{
    public partial class CascadingAppState
    {
        public string ActiveYear { get; set; } = "2022";
        
        private string _santaPicker;
        public string SantaPicker => _santaPicker;

        private int _loggedin;
        public int LoggedInUser => _loggedin;

        public void SetLoggedInUser(int loggedin)
        {
            _loggedin = loggedin;
        }
    }
}