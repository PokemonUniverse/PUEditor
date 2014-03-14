using System;

namespace PokeEditorV3.Logic.Managers
{
    public class Manager
    {
        public string Name { get; protected set; }

        public Manager(String name)
        {
            this.Name = name;
        }

        public void Initialize() { }

        public void Deinitialize() { }

        public void Destroy() { }
    }
}
