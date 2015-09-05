using System;
using System.Collections;
using System.Reflection;

namespace Fwk.Bases
{
	/// <summary>
	/// Administra las pilas Undo y Redo
    /// Cada entrada en la pila UNDO es un cambio de propiedad
	/// </summary>
	[Serializable]
	public class ModificationHistory
	{
		private Stack _RedoStack;
		private Stack _UndoStack;
        private Type _ParentObjectType;
		private object _ParentObject;

		/// <summary>
		/// El constructor nececita la referencia al objeto padre que se subscriba al manejador Undo.-
		/// </summary>
		/// <param name="parent"></param>
		public ModificationHistory(object parent)
		{
			_RedoStack = new Stack();
			_UndoStack = new Stack();
			_ParentObject = parent;
            _ParentObjectType = _ParentObject.GetType();
		}

		/// <summary>
        /// El objeto padre llamara este metodo par aalmacenar el valor de la propiedad 
        /// antes de que esta sufra algun cambio.-
		/// </summary>
		/// <param name="propName">nombre de la propiedad</param>
		/// <param name="propVal">El valor anterior al cambio</param>
		public void Store (string propName, object propVal)
		{
			PropertyValue pVal = new PropertyValue(propName, propVal);
            //Inserto en la pila undo el par (name - value).-
			_UndoStack.Push(pVal);
		}

		/// <summary>
        /// Obtiene el valor existente de la propiedad y lo inserta en Redo.-
        /// Retira la ultima propiedad de del objeto en la pila Undo (esto es para establecerlo como el valor vigente de la propiedad)
        /// Establece al objeto padre el valor de la propiedad que esta en la pila undo
		/// </summary>
		public void Undo()
		{
			if (_UndoStack.Count>0)
			{
                //Retira la ultima propiedad de del objeto en la pila Undo
                PropertyValue pPropertyValueUndo = (PropertyValue)_UndoStack.Pop();
                PropertyInfo wPropertyInfo = _ParentObjectType.GetProperty(pPropertyValueUndo.PropertyName);

                #region Primero Obtiene el valor existente y lo inserta en Redo.-

                object wOldValue = wPropertyInfo.GetValue(_ParentObject, null);
                PropertyValue _PropertyValueRedo = new PropertyValue(pPropertyValueUndo.PropertyName, wOldValue);
                _RedoStack.Push(_PropertyValueRedo);
                #endregion

                // apply the value that was popped off the undo stack
                wPropertyInfo.SetValue(_ParentObject, pPropertyValueUndo.Value, null);
			}
		}
        /// <summary>
        /// Redo
        /// </summary>
		public void Redo()
		{
			if (_RedoStack.Count>0)
			{
                //Retira la ultima propiedad de Redo
                PropertyValue wPropertyValue = (PropertyValue)_RedoStack.Pop();
            
                PropertyInfo wPropertyInfo = _ParentObjectType.GetProperty(wPropertyValue.PropertyName);

                #region Primero obtiene el valor existente y lo mete en la pila UNDO

                object wOldValue = wPropertyInfo.GetValue(_ParentObject,null);
                PropertyValue _PropertyValueUndo = new PropertyValue(wPropertyValue.PropertyName, wOldValue);
                _UndoStack.Push(_PropertyValueUndo);
                #endregion

                // apply the value that was popped off the redo stack
                wPropertyInfo.SetValue(_ParentObject, wPropertyValue.Value, null);
			}
		}

        /// <summary>
        /// Establece una marca de historia para todas las propiedades a las que se le decea guarrdar su trazabilidad
        /// </summary>
        /// <param name="pHistoryProperties"></param>
        internal void AddHistoryToAllProperties(String[] pHistoryProperties)
        {
            foreach (string propName in pHistoryProperties)
            {
                PropertyInfo wPropertyInfo = _ParentObjectType.GetProperty(propName);

                this.Store(propName, wPropertyInfo.GetValue(_ParentObject, null));
            }
        }

        /// <summary>
        /// Si la pila Undo tiene alcgun elemento retorna TRUE.
        /// </summary>
		public bool CanUndo
		{
			get
			{
				return (_UndoStack.Count>0?true:false);
			}
		}

        /// <summary>
        ///  Si la pila REDO tiene alcgun elemento retorna TRUE.
        /// </summary>
		public bool CanRedo
		{
			get
			{
				return (_RedoStack.Count>0?true:false);
			}
		}
	}
}
