using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody2D rb2D;
        public Animator animator;
        public PlayerMoveController moveController;

        private void Awake()
        {
            moveController = new(this);
        }
    }
}