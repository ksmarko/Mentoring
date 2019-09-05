namespace Singleton
{
    public class SingletonWithLock
    {
        private static SingletonWithLock _instance;
        private static readonly object Lock = new object();

        public static SingletonWithLock Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                            _instance = new SingletonWithLock();
                    }
                }

                return _instance;
            }
        }

        private SingletonWithLock()
        {
            //TODO: initialize instance fields
        }
    }
}
