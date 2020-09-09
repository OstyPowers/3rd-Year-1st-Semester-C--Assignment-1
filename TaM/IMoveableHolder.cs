﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaM
{
	interface IMoveableHolder
    {
        int TheseusRow { get; }
        int TheseusColumn { get; }
        int MinotuarRow { get; }
        int MinitaurColumn { get; }
        int MoveCount { get; }
        void MoveTheseus(Directions direction);
        bool IsTheseusDead();
        bool HasTheseusEscaped();


    }

}
