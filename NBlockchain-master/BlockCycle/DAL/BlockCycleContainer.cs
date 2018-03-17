using Unity;

namespace BlockCycle.UI.DAL
{
    public static class BlockCycleContainer
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container==null)
                    _container = new UnityContainer();

                return _container;
            }
        }
    }
}