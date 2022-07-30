using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SSM;

public class Test : MonoBehaviour
{
    private SSMController sSMController;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        var holdState1 = new SSMState(
            onEnter: () =>
            {
                text.text = "State 1";
            },
            onRun: () =>
            {

            },
            onExit: () =>
            {

            });
        var holdState2 = new SSMState(
            onEnter: () =>
            {
                text.text = "State 2";
            },
            onRun: () =>
            {

            },
            onExit: () =>
            {

            });
        var holdState3 = new SSMState(
            onEnter: () =>
            {
                text.text = "State 3";
            },
            onRun: () =>
            {
                
            },
            onExit: () =>
            {

            });

        sSMController = new SSMController();
        
        sSMController.AddState("state1", holdState1);
        sSMController.AddState("state2", holdState2);
        sSMController.AddState("state3", holdState3);

        sSMController.Initialized("state1");
    }

    private void Update()
    {
        sSMController.Run();
    }

    public void StateChange1()
    {
        sSMController.ChangeState("state1");
    }

    public void StateChange2()
    {
        sSMController.ChangeState("state2");
    }

    public void StateChange3()
    {
        sSMController.ChangeState("state3");
    }
}