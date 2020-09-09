﻿﻿using System;

  namespace PhantomDragonStudio.Combat
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