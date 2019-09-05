namespace TemplateMethod
{
    public static class EpamUsersStorage
    {
        public static bool HasUser(string userName)
        {
            return true;
        }

        public static bool HasUserWithEmail(string email)
        {
            return true;
        }
    }
}
