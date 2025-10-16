using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project_Lamb.Entities
{
    public class Entity : MonoBehaviour
    {
        protected Dictionary<Type, IEntityComponent> _components;
        protected virtual void Awake()
        {
            FindComponents();
            InitComponents();
            AfterInitComponents();
        }

        protected virtual void FindComponents()
        {
            _components = new Dictionary<Type, IEntityComponent>();
            GetComponentsInChildren<IEntityComponent>(true).ToList()
                .ForEach(component => _components.Add(component.GetType(), component));
        }

        protected virtual void InitComponents()
        {
            _components.Values.ToList().ForEach(component => component.Initialize(this));
        }

        protected virtual void AfterInitComponents()
        {
            _components.Values.ToList().ForEach(component =>
            {
                if (component is IAfterInitable
                
                afterInitable)
                {
                    afterInitable.AfterInitialize();
                }
            });
        }

        protected virtual void DisposeComponents()
        {
            _components.Values.ToList().ForEach(component =>
            {
                if (component is IAfterInitable disposeable)
                {
                    disposeable.Dispose();
                }
            });
        }
    }
}
