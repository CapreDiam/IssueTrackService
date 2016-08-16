using System;
using StructureMap;

namespace ITS.Model.SMC
{
    public class StructureMapContainer
    {
        private static readonly Container Container = new Container();

        public void Inject(Type pluginType, object instance)
        {
            Container.Inject(pluginType, instance);
        }

        public void Inject<T>(object instance)
        {
            Container.Inject(typeof(T), instance);
        }

        public object GetObject(Type pluginType)
        {
            return Container.TryGetInstance(pluginType);
        }

        public T GetObject<T>()
        {
            return Container.TryGetInstance<T>();
        }
    }
}