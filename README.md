# StateMachine

状态机脚手架，用于方便的控制逻辑状态。

State machine scaffolding for convenient control logic states.    



## Quick Start

一个状态分为 准备、进入、离开三个阶段。进行状态切换时，如果存在上一个状态，则会执行上一个状态对象的 `AfterStateChange` 函数，然后执行新状态对象的 `BeforeStateChange` 函数，然后再执行新状态的 `NowStateChange` 函数。

使用此动态库可以快速的使用状态机模式来实现对逻辑状态的控制。



A state is divided into three stages: preparation, entry and exit. When a state switch occurs, if a previous state exists, the `AfterStateChange` function of the previous state object is executed, followed by the `BeforeStateChange` function of the new state object, followed by the `NowStateChange` function of the new state. 

Using this dynamic library can quickly use the state machine model to achieve the control of logic states. 



```c#

var stateMachine = new StateMachine("MainWindow");
var state = new StateOne();
stateMachine.EnterState(state);

```

```c#

public class StateOne : StateMachineLib.State
{    
    public override void BeforeStateChange()
    {
        base.BeforeStateChange();
        // Prepare data objects, etc.
    }

    public override void NowStateChange()
    {
        base.NowStateChange();
        // Fill data into ui, etc.
    }
    
    public override void AfterStateChange()
    {
        base.AfterStateChange();
        // Release resources, etc.
    }
}

```

