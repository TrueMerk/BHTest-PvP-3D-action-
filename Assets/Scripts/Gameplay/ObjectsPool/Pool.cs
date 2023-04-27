using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay.ObjectsPool
{
    public class Pool : IEnumerable 
    {
        private readonly DiContainer _diContainer;
        private GameObject _objectPrefab;
        private Transform _container;
        private List<MonoBehaviour> _pool;
        
        public bool AutoExpand { get; set; } = true;

        public Pool(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void CreatePool<T>(GameObject objectPrefab, int count, Transform container) where T : MonoBehaviour
        {
            _pool = new List<MonoBehaviour>();
            _objectPrefab = objectPrefab;
            _container = container;
            
            for (var i = 0; i < count; i++)
            {
                CreateObject<T>();
            }
        }
        
        private T CreateObject<T>(bool isActiveByDefault = false) where T : MonoBehaviour
        {
            var createdObject = _diContainer.InstantiatePrefab(
                _objectPrefab,
                _container.position,
                _container.rotation,
                _container
            ).GetComponent<T>();
                
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement<T>(out T element) where T : MonoBehaviour
        {
            foreach (var mono in _pool.Where(mono => !mono.gameObject.activeInHierarchy))
            {
                element = mono.GetComponent<T>();
                mono.gameObject.SetActive(true);
                return true;
            }
            element = null;
            return false;
        }

        public T GetFreeElement<T>() where T : MonoBehaviour
        {
            if (HasFreeElement<T>(out var element))
                return element;
            if (AutoExpand)
                return CreateObject<T>(true);

            throw new Exception("No free GameObjects in pool");
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
}
}