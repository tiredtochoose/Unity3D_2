using UnityEngine;

namespace My3DProject
{
    class GameObjectsSpawner : MonoBehaviour
    {

        public GameObject _medKit;
        public Transform _medKitPos;
        public Transform _medKitPos1;

        public GameObject _bot;
        public Transform _botPos1;
        public Transform _botPos2;
        public Transform _botPos3;

        public void Start()
        {
            _medKit = Resources.Load("MedKit") as GameObject;
            Instantiate(_medKit, _medKitPos.position, Quaternion.identity);
            Instantiate(_medKit, _medKitPos1.position, Quaternion.identity);

            _bot = Resources.Load("Bot") as GameObject;
            
            Instantiate(_bot, _botPos1.position, Quaternion.identity);
            Instantiate(_bot, _botPos2.position, Quaternion.identity);
            Instantiate(_bot, _botPos3.position, Quaternion.identity);
        }

    }
}
