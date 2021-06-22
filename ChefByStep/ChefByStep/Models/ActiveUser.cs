namespace ChefByStep.Models
{
    public class ActiveUser
    {
        private ActiveUser()
        {
        }

        public User ApplicationUser { get; set; }

        private static ActiveUser Instance { get; set; }

        public static ActiveUser GetInstance()
        {
            return Instance ?? (Instance = new ActiveUser());
        }
    }
}