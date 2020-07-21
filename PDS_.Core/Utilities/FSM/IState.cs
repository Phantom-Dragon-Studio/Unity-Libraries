﻿﻿namespace PhantomDragonStudio.Core.Utilities.FSM
  {
      public interface IState
      {
          void Enter();
          void Execute();
          void Exit();
      }
  }