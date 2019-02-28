using System;

namespace appAlcanciaLab.CapaDominio
{
   public class clsMONEDA
    {
        #region Atributos
        #region Descriptores
        /// <summary>
        /// Describe una caracteriztica unica de la moneda.
        /// </summary>
        private uint atrOID = 0;
        /// <summary>
        /// Describe la denominacion que caracteriza la moneda
        /// </summary>
        private uint atrDenominacion = 0;
        /// <summary>
        /// Describe el año de emision que caracteriza la moneda
        /// </summary>
        private int atrAnhoEmision = 0;
        #endregion
        #region Asociativos
        /// <summary>
        /// Atributo para asociar una moneda a clsALCANCIA
        /// </summary>
        private clsALCANCIA atrObjAlcancia = null;
        #endregion
        #endregion
        #region Metodos
        #region Constructor-Destructor
        /// <summary>
        /// Construye una moneda como parametros los atributos descriptores 
        /// </summary>
        /// <param name="parOID">Parametro de tipo uint que instrucciona el metodo</param>
        /// <param name="parDenominacion">Parametro de tipo short que instrucciona el metodo</param>
        /// <param name="parAnhoEmision">Parametro de tipo int que instrucciona el metodo</param>
        public clsMONEDA(uint parOID, ushort parDenominacion, int parAnhoEmision)
        {
            this.atrOID = parOID;
            this.atrAnhoEmision = parAnhoEmision;
            this.atrDenominacion = parDenominacion;
        }
        /// <summary>
        /// Finaliza el objeto moneda si ésta no está contenida en ninguna alcancía
        /// </summary>
        /// <param name="parMensajeResultado">Parámetro de tipo string por referencia que indicará el éxtio o fracaso</param>
        /// <returns></returns>
        public bool Finalizar(ref string parMensajeResultado)
        {
            parMensajeResultado = "El objeto se puede finalizar";
            if(this.atrObjAlcancia==null)
            {
                parMensajeResultado = "El objeto se puede finalizar";
                return true;
            }
            parMensajeResultado += "La moneda está almacenada en una alcancía";
            return false;

        }
        /// <summary>
        /// Construye una moneda con valores por defecto.
        /// </summary>
        public clsMONEDA()
        {

        }
        #endregion
        #region Accesores
        /// <summary>
        /// El metodo funciona para mostrar el valor unico de la moneda
        /// </summary>
        /// <returns>Devuelve el atributo uint que describe el valor unico de la moneda</returns>
        public uint ObtenerOID()
        {
            return atrOID;
        }
        /// <summary>
        /// El metodo funciona para mostrar la denominacion de la moneda
        /// </summary>
        /// <returns>devuelve el atributo short que describe la denominacion</returns>
        public uint ObtenerDenominacion()
        {
            return atrDenominacion;
        }
        /// <summary>
        /// El metodo funciona para mostrar el año de emision de la moneda
        /// </summary>
        /// <returns>devuelve el atributo int que describe el año de la moneda</returns>
        private int ObtenerAnhoEmision()
        {
            return atrAnhoEmision;
        }
        /// <summary>
        /// El metodo funciona para mostrar donde esta la moneda
        /// </summary>
        /// <returns>Devuelve el atributo clsALCANCIA que describe la asociacion de la moneda </returns>
        private clsALCANCIA ObtenerObjAlcancia()
        {
            return atrObjAlcancia;
        }
        #endregion
        #region Mutadores
        /// <summary>
        /// El metodo funciona para cambiar el valor unico de la moneda
        /// </summary>
        /// <param name="parValor">Parametro de tipo uint que instrucciona el metodo</param>
        private void MutarOID(uint parValor)
        {
            this.atrOID = parValor;
        }
        /// <summary>
        /// el metodo funciona para cambiar la denominacion de la moneda
        /// </summary>
        /// <param name="parValor">parametro de tipo short que instrucciona el metodo</param>
        private void MutarDenominacion(ushort parValor)
        {
            this.atrDenominacion = parValor;
        }
        /// <summary>
        /// El metodo funciona para campiar el año de emision de la moneda
        /// </summary>
        /// <param name="parValor">parametro de tipo int que instrucciona el metodo</param>
        private void MutarAnhoEmision(int parValor)
        {
            this.atrAnhoEmision = parValor;
        }
        /// <summary>
        /// Modifica los atributos Denominación y año emisión
        /// </summary>
        /// <param name="parDenominacion">Parámetro de tipo ushort para modificar el atributo denominación</param>
        /// <param name="parAnio">Parámetro de tipo int para modificar el atributo año</param>
        public void ModificarCon(ushort parDenominacion, int parAnio)
        {
            this.atrDenominacion = parDenominacion;
            this.atrAnhoEmision = parAnio;
        }
        /// <summary>
        /// Modifica el objeto alcancía contenedor de la moneda 
        /// </summary>
        /// <param name="parObjeto">Parametro de tipo clsALCANCIA que instrucciona el metodo</param>
        /// 
        private void MutarObjAlcancia(clsALCANCIA parObjeto)
        {
            this.atrObjAlcancia = parObjeto;
        }
        #endregion
        #region Asociadores
        /// <summary>
        /// El metodo asocia la moneda a la alcancia
        /// </summary>
        /// <param name="parObjeto">Parametro de tipo clsALCANCIA que instrucciona el metodo</param>
        public void AsociadorObjAlcancia(clsALCANCIA parObjeto)
        {
            this.atrObjAlcancia = parObjeto;
        }
        #endregion
        #region Disociadores
        /// <summary>
        /// El metodo funciona para borrar la asociacion de la moneda con la alcancia
        /// </summary>
       public void DisociarObjAlcancia(clsALCANCIA parObjeto)
        {
            this.atrObjAlcancia = null;
        }
        #endregion
        #endregion
    }
}
