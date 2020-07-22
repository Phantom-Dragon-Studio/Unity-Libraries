﻿﻿namespace PhantomDragonStudio.Core.Utilities
{
    [System.Serializable]
    public struct Label
    {
        private string name;
        private string description;

        public Label(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get => name; }
        public string Description { get => description; }
    }
}
