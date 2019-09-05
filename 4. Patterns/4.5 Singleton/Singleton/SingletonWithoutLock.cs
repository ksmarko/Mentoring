using System;

namespace Singleton
{
    public class SingletonWithoutLock
    {
        private static readonly Lazy<SingletonWithoutLock> LazyInstance =
            new Lazy<SingletonWithoutLock>(() => new SingletonWithoutLock());

        public static SingletonWithoutLock Instance => LazyInstance.Value;

        private SingletonWithoutLock()
        {
            //TODO: initialize instance fields
        }
    }
}
