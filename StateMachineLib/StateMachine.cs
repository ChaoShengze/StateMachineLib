using System;

namespace StateMachineLib
{
    /// <summary>
    /// 状态机脚手架，用于方便的控制逻辑状态
    /// State machine scaffolding for convenient control logic states.
    /// </summary>
    public class StateMachine
    {
        #region 变量声明 / Variable Definition 
        /// <summary>
        /// 当前状态
        /// Current Status
        /// </summary>
        public State NowState = null;
        /// <summary>
        /// 状态机名称，用以区分不同状态机
        /// Name of statemachine
        /// </summary>
        public string MachineName;
        #endregion

        /// <summary>
        /// 状态机构造函数
        /// Constructor function
        /// </summary>
        /// <param name="machineName">Name of statemachine</param>
        public StateMachine(string machineName = "UNNAMED")
        {
            MachineName = machineName;
        }
        /// <summary>
        /// 进入状态
        /// Enter a state obj.
        /// </summary>
        /// <param name="state">状态对象 state obj</param>
        public void EnterState(State state)
        {
            try
            {
                // 如果当前已处于一个状态，调用After回调进行资源释放和规整
                // If it is currently in a state, call the After callback to release and organize resources
                if (NowState != null)
                {
                    NowState.StateStage = StateStage.AFTER;
                    NowState.AfterStateChange();
#if DEBUG
                    PrintLog($"Change state from [{NowState.StateName}] to [{state.StateName}], enter after phase.");
#endif
                }

                // 重置状态缓存
                // Reset status cache
                NowState = state;

                // 进入新状态的准备阶段
                // Preparation for entering a new state 
                state.StateStage = StateStage.BEFORE;
                state.BeforeStateChange();
#if DEBUG
                PrintLog($"Enter [{NowState.StateName}] state before phase.");
#endif

                // 进入新状态的当前阶段
                // Enter the current phase of the new state 
                state.StateStage = StateStage.NOW;
                state.NowStateChange();
#if DEBUG
                PrintLog($"Enter [{NowState.StateName}] state curr phase.");
#endif
            }
            catch (Exception ex)
            {
                PrintLog(ex.Message);
            }
        }
        /// <summary>
        /// 打印日志，默认只在DEBUG模式下触发
        /// Print log, triggered only in DEBUG mode by default
        /// </summary>
        /// <param name="info">日志内容 Log</param>
        private void PrintLog(string info)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | StateMachine-{MachineName}-{info}");
        }
    }
}
