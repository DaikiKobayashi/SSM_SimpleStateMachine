using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action = System.Action;

namespace SimpleStateMachine
{
    public class SSMState : IState
    {
        private Action onEnter;
        private Action onRun;
        private Action onExit;

        public SSMState(Action onEnter, Action onRun, Action onExit)
        {
            this.onExit = onExit;
            this.onRun = onRun;
            this.onEnter = onEnter;
        }

        public void Init(SSMController controller)
        {

        }

        public void Enter(string backStateName)
        {
            onEnter?.Invoke();
        }

        public void Exit(string nextStateName)
        {
            onExit?.Invoke();
        }

        public void Run()
        {
            onRun?.Invoke();
        }
    }
}