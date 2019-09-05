namespace Singleton
{
    public class ClassicSingleton
    {
        private static ClassicSingleton _instance;
        public static ClassicSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClassicSingleton();

                return _instance;
            }
        }

        private ClassicSingleton()
        {
            //TODO: initialize instance fields
        }
    }
}
