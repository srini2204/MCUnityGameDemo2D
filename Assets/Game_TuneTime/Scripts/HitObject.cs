using UnityEngine;
using System.Collections;

namespace ToyBox.TuneTime
{
    public enum PieceType
    {
        NORMAL,
        ENEMY,
    };

    [System.Serializable]
    public struct PieceAttributes
    {
        public PieceType type;
        public int score;
    };

    public class HitObject : MonoBehaviour
    {
        public PieceAttributes pieceAttributes;
        public ScoreManager scoreManager;

        public bool isDead = false;

        private Vector3 targetPosition;
        public int speed;

        // Use this for initialization
        void Update()
        {

            foreach (var touch in Input.touches)
            {
                if (GetComponent<BoxCollider2D>().OverlapPoint(touch.position))
                {
                    NoteHit();
                    Debug.Log("Touch hit");

                }
            }

            if (Input.GetMouseButtonDown(0) && GetComponent<BoxCollider2D>().OverlapPoint(Input.mousePosition))
            {
                NoteHit();
                Debug.Log("Mouse hit");
            }
        }

        public void Release(Vector3 startPosition, int speed)
        {

            isDead = false;
            this.transform.localPosition = startPosition;
            this.speed = speed;

            targetPosition = new Vector3(startPosition.x, startPosition.y + 1300, startPosition.z);

            GetComponent<Animator>().SetTrigger("Moving");
            StartCoroutine("MoveCoroutine");
        }

        IEnumerator MoveCoroutine()
        {

            while (Vector3.Distance(transform.localPosition, targetPosition) > 5)
            {

                float step = speed * Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);

                yield return null;
            }

            //Reached the target
            ResetNote();

        }

        public void ResetNote()
        {

            isDead = true;

        }

        public void NoteHit()
        {
            StopCoroutine("MoveCoroutine");
            GetComponent<Animator>().SetTrigger("Hit");
            scoreManager.incrementScore(pieceAttributes.score);
            Debug.Log("NoteHit");
        }

    }

}