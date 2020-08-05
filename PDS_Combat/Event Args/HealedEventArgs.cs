﻿﻿using System;

  namespace PhantomDragonStudio.Combat.Event_Args
  {
      public class HealedEventArgs : EventArgs
      {
          public float Amount { get; }
          public HealedEventArgs(float amount)
          {
              Amount = amount;
          }
      }
  }