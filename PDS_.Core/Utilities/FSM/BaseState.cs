using System;

namespace PhantomDragonStudio.Core.Utilities.FSM
{
    public abstract class BaseState
    {
        protected GameObject _gameObject;
        protected Transform _transform;
        
        public abstract void Enter();
        public abstract Type Tick();
        public abstract void Exit();

        protected BaseState(GameObject gameObject, Transform transform)
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}