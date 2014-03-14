using System;
using System.Collections.Generic;
using PokeEditorV3.Logic.Exceptions;

namespace PokeEditorV3.Logic.Managers
{
    public static class GlobalManager
    {
        private enum GlobalManagerException
        {
            ManagerNonExistent
        }

        private readonly static Dictionary<Type, Manager> managers = new Dictionary<Type, Manager>();

        public static void Initialize()
        {
            managers.Add(typeof(StartupManager), new StartupManager());
            managers.Add(typeof(ApplicationManager), new ApplicationManager());
            managers.Add(typeof(ConnectionManager), new ConnectionManager());
            managers.Add(typeof(TileManager), new TileManager());
            managers.Add(typeof(KeyInputManager), new KeyInputManager());
            managers.Add(typeof(ViewManager), new ViewManager());
        }

        public static T GetManager<T>() where T : Manager
        {
            Manager m;
            if (managers.TryGetValue(typeof(T), out m))
            {
                return (T)m;
            }

            throw new ManagerException(GlobalManagerException.ManagerNonExistent, "The manager '{0}' does not exists. Are you sure the manager gets initialized in GlobalManager.Initialize?", typeof(T));
        }
    }
}
