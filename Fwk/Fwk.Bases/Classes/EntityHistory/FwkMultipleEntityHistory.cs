using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace Fwk.Bases
{
    /// <summary>
    /// Administra las pilas Undo y Redo
    /// Cada entrada en la pila UNDO es un cambio de propiedad
    /// </summary>
    [Serializable]
    public class FwkMultipleEntityHistory : Fwk.Bases.IFwkHistory
    {
        private Stack<List<PropertyValue>> _RedoStack;
        private Stack<List<PropertyValue>> _UndoStack;


        private Type _ParentObjectType;
        private object _ParentObject;

       
        /// <summary>
        /// El constructor nececita la referencia al objeto padre que se subscriba al manejador Undo.-
        /// </summary>
        /// <param name="parent">Clase que implementara el patron Undo Redo</param>
        public FwkMultipleEntityHistory(object parent)
        {
            _RedoStack = new Stack<List<PropertyValue>>();
            _UndoStack = new Stack<List<PropertyValue>>();
       
            _ParentObject = parent;
            _ParentObjectType = _ParentObject.GetType();
        }


        /// <summary>
        /// Obtiene el valor existente de la propiedad y lo inserta en Redo.-
        /// Retira la ultima propiedad de del objeto en la pila Undo (esto es para establecerlo como el valor vigente de la propiedad)
        /// Establece al objeto padre el valor de la propiedad que esta en la pila undo
        /// </summary>
        public void Undo()
        {
            if (_UndoStack.Count > 0)
            {
                //Retira las ultimas propiedades  del objeto en la pila Undo
                List<PropertyValue> wPropertyValueUndoList = (List<PropertyValue>)_UndoStack.Pop();
                List<PropertyValue> wPropertyValueRedoList = new List<PropertyValue>();
                PropertyInfo wPropertyInfo;
                object wOldValue;
                PropertyValue wPropertyValueRedo;

                foreach (PropertyValue wPropertyValue in wPropertyValueUndoList)
                {
                    //Obtengo la propiedad del objeto 
                    wPropertyInfo = _ParentObjectType.GetProperty(wPropertyValue.PropertyName);

                    #region Primero Obtiene el valor existente y lo inserta en Redo.-
                    //Obtengo el valor de la propiedad wPropertyInfo
                    wOldValue = wPropertyInfo.GetValue(_ParentObject, null);

                    //Creo una PropertyValue con el valor de la propiedad y lo invcerto en la pila Redo 
                    wPropertyValueRedo = new PropertyValue(wPropertyValue.PropertyName, wOldValue);
                    wPropertyValueRedoList.Add(wPropertyValueRedo);
                    #endregion

     
                    wPropertyInfo.SetValue(_ParentObject, wPropertyValue.Value, null);
                }

                //Saco de la pila redo el ultimo PropertyValue list de propiedad ingresado
                _RedoStack.Push(wPropertyValueRedoList);

            }
        }

        /// <summary>
        /// Retira la ultima propiedad de Redo y las pasa a Undo
        /// </summary>
        public void Redo()
        {
            if (_RedoStack.Count > 0)
            {
                //Retira la ultima propiedad de Redo
                List<PropertyValue> wPropertyValueRedoList = (List<PropertyValue>)_RedoStack.Pop();
                List<PropertyValue> wPropertyValueUndoList = new List<PropertyValue>();
                PropertyInfo wPropertyInfo;
                object wOldValue;
                PropertyValue wPropertyValueUndo;

                foreach (PropertyValue wPropertyValue in wPropertyValueRedoList)
                {

                    wPropertyInfo = _ParentObjectType.GetProperty(wPropertyValue.PropertyName);

                    #region Primero obtiene el valor existente y lo mete en la pila UNDO

                    wOldValue = wPropertyInfo.GetValue(_ParentObject, null);
                    wPropertyValueUndo = new PropertyValue(wPropertyValue.PropertyName, wOldValue);
                    wPropertyValueUndoList.Add(wPropertyValueUndo);
                    #endregion

                    wPropertyInfo.SetValue(_ParentObject, wPropertyValue.Value, null);
                }


                _UndoStack.Push(wPropertyValueUndoList);
            }
        }

        /// <summary>
        /// Establece una marca de historia para todas las propiedades a las que se le decea guardar su trazabilidad
        /// </summary>
        /// <param name="pHistoryProperties"></param>
        internal void AddHistoryToAllProperties(String[] pHistoryProperties)
        {
           


            if (pHistoryProperties.Length != 0)
            {
                List<PropertyValue> wPropertyValueList = new List<PropertyValue>();

                foreach (string propName in pHistoryProperties)
                {
                    PropertyInfo wPropertyInfo = _ParentObjectType.GetProperty(propName);
                    wPropertyValueList.Add(new PropertyValue(propName, wPropertyInfo.GetValue(_ParentObject, null)));
                }
                //if (DetermineMarck(wPropertyValueList))
                    _UndoStack.Push(wPropertyValueList);
        
            }
        }

        bool DetermineMarck(List<PropertyValue> pPropertyValueList)
        {

            if (_UndoStack.Count == 0) return true;
            List<PropertyValue> _PropertyValueList_OnTopStack = _UndoStack.Peek();
     
            foreach (PropertyValue prop_OnTopStack in _PropertyValueList_OnTopStack)
            {
                PropertyValue evenNum = pPropertyValueList.Find(p => 
                    (p.PropertyName == prop_OnTopStack.PropertyName));// && (p.Value == prop_OnTopStack.Value));

                if (evenNum.Value.GetType().Name == typeof(DateTime).Name)
                {
                    if (Convert.ToDateTime(evenNum.Value).CompareTo(prop_OnTopStack.Value) != 0)
                        return true;
                    //break;
                }
                else
                {
                    if (evenNum.Value != prop_OnTopStack.Value)//si hay almenos una distinta es por que existio cambio
                        return true;
                }
               
           
            }
            return false;
        }

       

      

        /// <summary>
        /// Si la pila Undo tiene alcgun elemento retorna TRUE.
        /// </summary>
        public bool CanUndo
        {
            get
            {
                return (_UndoStack.Count > 0 ? true : false);
            }
        }

        /// <summary>
        ///  Si la pila REDO tiene alcgun elemento retorna TRUE.
        /// </summary>
        public bool CanRedo
        {
            get
            {
                return (_RedoStack.Count > 0 ? true : false);
            }
        }
       
    }
}
