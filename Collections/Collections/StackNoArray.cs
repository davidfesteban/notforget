using System;
using System.Collections.Generic;

namespace Collections
{
    public class StackNoArray<Object>
    {
        private Object _cabeza;
        private StackNoArray<Object> _cola;

        public StackNoArray(Object cabeza) : this(cabeza, null)
        {

        }

        private StackNoArray(Object cabeza, StackNoArray<Object> cola)
        {
            this._cabeza = cabeza;
            this._cola = cola;
        }

        public bool Push(Object objeto)
        {
            bool resultado = true;

            try
            {
                _cola = new StackNoArray<Object>(_cabeza,_cola);
                _cabeza = objeto;

            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Couldnt push. -> " + e.Message.ToString());
                resultado = false;
            }

            return resultado;

        }

        public Object Pop()
        {
            Object resultado = default(Object);

            try
            {   

                resultado = _cabeza;
                _cabeza = _cola._cabeza;
                _cola = _cola._cola;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Couldnt pop. -> " + e.Message.ToString());
            }

            return resultado;

        }

        /// <summary>
        /// Outputs an array with all the elements.
        /// </summary>
        /// <returns>An array.</returns>
        public Object[] OutputToArray()
        {
            var output = new List<Object>();

            do
            {
                output.Add(Pop());

            } while (_cabeza != null );

            return output.ToArray();

        }

    }
}
