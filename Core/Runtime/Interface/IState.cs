using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleStateMachine
{
    interface IState
    {
        public void Init(SSMController controller);

        public void Exit(string backStateName);
        
        public void Run();

        public void Enter(string nextStateName);
    }
}