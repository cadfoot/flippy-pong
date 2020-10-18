using System.Collections.Generic;
using FlippyPong.Core;
using Mirror;
using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class GameplayContext : InjectableMonoBehaviour<GameplayContext>
    {
        [SerializeField] private List<NetworkIdentity> paddles = default;
        [SerializeField] private Ball _ball = default;

        public IReadOnlyList<NetworkIdentity> Paddles => paddles;

        public IBall Ball => _ball;

    }
}