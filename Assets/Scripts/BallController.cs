using UnityEngine;

public class BallController : MonoBehaviour
{
    private const float BAG_MARGIN = 0.1f;
    private LivesManager _livesManager;

    private void Start()
    {
        _livesManager = FindObjectOfType<LivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bag"))
        {
            if (isInBag(other))
            {
                if (CompareTag("YellowBall"))
                {
                    _livesManager.IncreasePoints();
                }
            }


            //if the violet ball touches any part of the bag we remove points
            if (CompareTag("VioletBall"))
            {
                _livesManager.UpdateLives();
            }
        }

        //either if touches the bag or the floor
        Destroy(gameObject);
    }

    //if the yellow ball is touching the sides of the bag and not really falling in the centre
    //we wont count it as a point
    private bool isInBag(Collider2D bag)
    {
        var leftEdge = bag.bounds.min.x + BAG_MARGIN;
        var rightEdge = bag.bounds.max.x - BAG_MARGIN;
        var ballX = transform.position.x;

        return ballX > leftEdge && ballX < rightEdge;
    }
}