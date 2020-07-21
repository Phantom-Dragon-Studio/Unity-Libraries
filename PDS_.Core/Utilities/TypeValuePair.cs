﻿﻿namespace PhantomDragonStudio.Core.Utilities
{
    [System.Serializable]
    public class TypeValuePair<TKey, TValue>
    {
        public TKey type;
        public TValue value;

        public TypeValuePair(TKey _key, TValue _value)
        {
            type = _key;
            value = _value;
        }

        public override string ToString()
        {

            return type.ToString() + " " + value.ToString();
        }
    }
}
