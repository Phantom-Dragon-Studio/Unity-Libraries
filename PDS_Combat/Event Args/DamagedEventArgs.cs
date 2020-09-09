﻿﻿using System;

  namespace PhantomDragonStudio.Combat
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