using Injection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FlippyPong.UI
{
    public interface IMainMenuView : IInjectable
    {
        event UnityAction OnHostButtonPressed;
        event UnityAction OnFindButtonPressed;
        event UnityAction OnJoinButtonPressed;
        
        bool JoinAvailable { set; }
    }
}
