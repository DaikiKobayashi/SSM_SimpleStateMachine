using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleStateMachine
{
    public class SSMController
    {
        private Dictionary<string, SSMState> _states;
        private (string, SSMState) _activeState;
        private bool _stateMachineActive = false;



        public SSMController()
        {
            _states = new Dictionary<string, SSMState>();
        }

        /// <summary>
        /// ステートマシンの初期化を行う。
        /// ステートを追加して発行してください。
        /// </summary>
        public void Initialized(string activeStateName)
        {
            if (_states.TryGetValue(activeStateName, out var state))
            {
                _activeState = (activeStateName, state);
                _activeState.Item2.Enter("default");
            }
            else
            {
                throw new System.ArgumentNullException($"Not select name state. name : {activeStateName}");
            }
        }

        /// <summary>
        /// ステート追加。
        /// キーがすでに存在した場合は引数で渡されたstateを有効化する。
        /// </summary>
        public void AddState(string stateName, SSMState state)
        {
            state.Init(this);

            _states.Add(stateName, state);
        }

        /// <summary>
        /// アクティブステートを変更する
        /// </summary>
        /// <param name="stateName"></param>
        public void ChangeState(string stateName)
        {
            if (_states.TryGetValue(stateName, out var state))
            {
                var backStateName = _activeState.Item1;
                _activeState.Item2.Exit(stateName);

                _activeState = (stateName, state);
                _activeState.Item2.Enter(backStateName);
            }
            else
            {
                throw new System.ArgumentNullException($"Not select name state. name : {stateName}");
            }
        }

        public void Run()
        {
            if (_stateMachineActive == false)
                return;

            _activeState.Item2?.Run();
        }

        public string ActiveStateName() => _activeState.Item1;
    }
}