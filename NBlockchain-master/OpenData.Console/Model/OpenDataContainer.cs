using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace OpenData.Console.Model
{
    public static class OpenDataContainer
    {
        private static IUnityContainer _unityContainer;

        public static IUnityContainer Container
        {
            get
            {
                if (_unityContainer==null)
                    _unityContainer = new UnityContainer();

                return _unityContainer;
            }
        }
    }
}
