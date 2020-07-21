﻿﻿using System;

  namespace PhantomDragonStudio.Combat.Event_Args
  {
      public class DamagedEventArgs : EventArgs
      {
          public float Amount { get; private set; }
          public DamagedEventArgs(float amount)
          {
              Amount = amount;
          }
      }
  }