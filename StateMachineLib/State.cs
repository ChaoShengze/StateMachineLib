
namespace StateMachineLib
{
    /// <summary>
    /// 状态，包含Before、Now、After三个阶段
    /// </summary>
    public class State
    {
        /// <summary>
        /// 状态名称
        /// State Name
        /// </summary>
        public string StateName = "UNNAMED";
        /// <summary>
        /// 状态对象的所处状态
        /// The state of the state object
        /// </summary>
        public StateStage StateStage = StateStage.INACTIVE;
        /// <summary>
        /// 正式进入某个状态前的准备工作
        /// Preparation for a formal entry into a state
        /// </summary>
        public virtual void BeforeStateChange() 
        {
            StateStage = StateStage.BEFORE;
        }
        /// <summary>
        /// 处于某个状态
        /// Enter into a state
        /// </summary>
        public virtual void NowStateChange()
        {
            StateStage = StateStage.NOW;
        }
        /// <summary>
        /// 离开或者准备进入一个新状态前的资源释放和收尾工作
        /// Resource release and closeout before leaving or preparing to enter a new state
        /// </summary>
        public virtual void AfterStateChange()
        {
            StateStage = StateStage.AFTER;
        }
    }

    /// <summary>
    /// 状态阶段
    /// </summary>
    public enum StateStage
    {
        /// <summary>
        /// 未激活
        /// INACTIVE
        /// </summary>
        INACTIVE,
        /// <summary>
        /// 正式进入某个状态前，此阶段主要进行准备工作
        /// BEFORE
        /// </summary>
        BEFORE,
        /// <summary>
        /// 处于某个状态
        /// NOW
        /// </summary>
        NOW,
        /// <summary>
        /// 离开或者准备进入一个新状态前，主要进行资源释放和收尾工作
        /// AFTER
        /// </summary>
        AFTER
    }
}
