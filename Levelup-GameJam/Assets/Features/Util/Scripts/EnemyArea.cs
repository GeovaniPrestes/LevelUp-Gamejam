using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Features.Util.Scripts
{
    public class EnemyArea : MonoBehaviour{

        Player _player;

        void Start(){
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();   
        }

        void OnTriggerEnter2D(Collider2D other){
            if(other.tag == "Player"){
                StartCoroutine(EnemySpawn());
            }
        }

        IEnumerator EnemySpawn(){
            while(true){
                yield return new WaitForSeconds(2);

                if(_player.GetMovementDirection() != Vector2.zero){
                    float chance = Random.Range(0f, 1f);
                    if(chance <= 0.30f){
                        SceneManager.LoadScene("Battle");
                        yield break;
                    }
                }
            }
        }

        void OnTriggerExit2D(Collider2D other){
            if(other.tag == "Player"){
                StopAllCoroutines();
            }
        }
    }
}
