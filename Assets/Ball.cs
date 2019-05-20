using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
  public float speed = 30;
  void Start() {
    // Initial velocity
    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
  }

  /*
    col.gameObject = racket
    col.transform.position = racket's position
    col.collider = racket's collider
  */
  void OnCollisionEnter2D(Collision2D col) {
    if(col.gameObject.name == "RacketLeft") {
      float y = hitFactor(transform.position,
                          col.transform.position,
                          col.collider.bounds.size.y);

      // Calculate direction, make length = 1 via .normalized
      Vector2 dir = new Vector2(1,y).normalized;

      // Set Velocity with direction * speed
      GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    if(col.gameObject.name == "RacketRight") {
      float y = hitFactor(transform.position,
                          col.transform.position,
                          col.collider.bounds.size.y);

      // Calculate direction, make length = 1 via .normalized
      Vector2 dir = new Vector2(-1,y).normalized;

      // Set Velocity with direction * speed
      GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
  }

  /*
    1 = top of racket
    0 = middle of racket
    -1 = bottom of racket
   */
  float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
    return (ballPos.y - racketPos.y) / racketHeight;
  }
}
