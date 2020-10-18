using UnityEngine;

namespace FlippyPong.Gameplay
{
    public class BallServe : MonoBehaviour
    {
        public void Serve(Rigidbody2D ballRigidbody)
        {
            const float minAngle = Mathf.PI / 6;
            const float maxAngle = 5 * Mathf.PI / 6;

            var angle = Random.Range(minAngle, maxAngle);

            var x = Mathf.Cos(angle) * Mathf.Rad2Deg;
            var y = Mathf.Sin(angle) * Mathf.Rad2Deg;

            var speed = ballRigidbody.velocity.magnitude;
            var side = -Mathf.Sign(ballRigidbody.velocity.y);

            ballRigidbody.velocity = new Vector2(x, y).normalized * (speed * side);
        }
    }
}
