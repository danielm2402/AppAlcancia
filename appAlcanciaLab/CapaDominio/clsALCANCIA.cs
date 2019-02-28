using System;
using System.Collections.Generic;

namespace appAlcanciaLab.CapaDominio
{
    public class clsALCANCIA
    {
        #region Atributos
        #region Descriptores
        /// <summary>
        /// Descirbe la capacidad limite de la alcancia.
        /// </summary>
        private byte atrCapacidadLimiteMonedas = 0;
        /// <summary>
        /// Describe las denominaciones que aceptara la alcancia.
        /// </summary>
        private uint[] atrVectorDenominacionesAceptables = null;
        #endregion
        #region Derivables
        /// <summary>
        /// Cuenta el total de monedas que lleva la alcancia en general.
        /// </summary>
        private byte atrConteoTotalMonedas = 0;
        /// <summary>
        /// Lleva el conteo de la cantidad de monedas, pero especificadas por denominacion.
        /// </summary>
        private byte[] atrVectorConteoMonedasPorDenominacion = null;
        /// <summary>
        /// Lleva la suma del saldo total de la alcancia.
        /// </summary>
        private uint atrSaldoTotalMonedas = 0;
        /// <summary>
        /// Lleva la suma del saldo total, pero escpicificamente por denominacion.
        /// </summary>
        private uint[] atrVectorSaldoTotalMonedasPorDenominacion = null;
        #endregion
        #region Asociativos
        /// <summary>
        /// Crea una lista de coleccion de monedas en la alcancia.
        /// </summary>
        List<clsMONEDA> atrColeccionObjsMoneda = new List<clsMONEDA>();
        #endregion
        #endregion
        #region Metodos
        #region constructor-destructor
        /// <summary>
        /// Construye una Alcancia con valores por defecto.
        /// </summary>
        public clsALCANCIA()
        {

        }
        /// <summary>
        /// Construye una Alcancia como Parametros los atributos Descriptores. 
        /// </summary>
        /// <param name="parCapacidadLimiteMonedas">Parametro de Tipo Byte que instrucciona el metodo</param>
        /// <param name="parVectorDenominacionesAceptables">Parametro de Tipo short vector que instruccion el metodo</param>
        public clsALCANCIA(byte parCapacidadLimiteMonedas, uint[] parVectorDenominacionesAceptables)
        {
            this.atrCapacidadLimiteMonedas = parCapacidadLimiteMonedas;
            this.atrVectorDenominacionesAceptables = parVectorDenominacionesAceptables;
            this.atrVectorSaldoTotalMonedasPorDenominacion =new uint [parVectorDenominacionesAceptables.Length];
            this.atrVectorConteoMonedasPorDenominacion = new byte[parCapacidadLimiteMonedas];


        }
        #endregion
        #region Accesores
        /// <summary>
        /// El metodo funciona para mostrar  la capacidad de la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo byte que describe la capacidad de la alcancia</returns>
        public byte ObtenerCapacidadLimiteMonedas()
        {
            return atrCapacidadLimiteMonedas;
        }
        /// <summary>
        /// El metodo funciona para mostrar las denominaciones que permite la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo vector short que describe las denomincaiones aceptables</returns>
        public uint[] ObtenerVectorDenominacionesAceptables()
        {
            return atrVectorDenominacionesAceptables;
        }
        /// <summary>
        /// El metodo funciona para mostrar cuantas monedas en general hay en la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo byte que describe la cantidad de monedas</returns>
        public byte ObtenerConteoTotalMonedas()
        {
            return atrConteoTotalMonedas;
        }
        /// <summary>
        /// El metodo funciona para mostrar cuantas monedas por denominacion hay en la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo vector byte que describe la cantidad de monedas por denominacion</returns>
        public byte[] ObtenerVectorConteoTotalMonedasPorDenominacion()
        {
            return atrVectorConteoMonedasPorDenominacion;
        }
        /// <summary>
        /// El metodo funciona para mostrar el saldo total que hay en la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo unit que describe el saldo total</returns>
        public uint ObtenerSaldoTotalMonedas()
        {
            return atrSaldoTotalMonedas;
        }
        /// <summary>
        /// El metodo funciona para mostrar el saldo por denominacion que hay en la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo vector uint que describe el saldo por denominacion</returns>
        public uint[] ObtenerVectorSaldoTotalMonedasPorDenominacion()
        {
            return atrVectorSaldoTotalMonedasPorDenominacion;
        }
        /// <summary>
        /// El metodo funciona para mostrar la coleccion de monedas que hay en la alcancia
        /// </summary>
        /// <returns>Devuelve el atributo Lista clsMONEDA que describe la coleccion de objetos monedas</returns>
        private List<clsMONEDA> ObtenerColeccionObjsMoneda()
        {
            return atrColeccionObjsMoneda;
        }
        #endregion
        #region Mutadores
        /// <summary>
        /// El metodo funciona para cambiar la capacidad de la alcancia.
        /// </summary>
        /// <param name="parValor">Parametro de tipo byte que instrucciona la mutacion del metodo</param>
        private void MutarCapcidadLimiteMonedas(byte parValor)
        {
            this.atrCapacidadLimiteMonedas = parValor;
        }
        /// <summary>
        /// El metodo funciona para cambiar las denominaciones que acepta la alcancia.
        /// </summary>
        /// <param name="parValor">Parametro de tipo short vector que instrucciona la mutacion del metodo</param>
        private void MutarVectorDenominacionesAceptables(uint[] parValor)
        {
            this.atrVectorDenominacionesAceptables = parValor;
        }
        /// <summary>
        /// El metodo funciona para cambiar el conteo total de la alcancia.
        /// </summary>
        /// <param name="parValor">Parametro de tipo byte que instrucciona la mutacion del metodo</param>
        private void MutarConteoTotalMonedas(byte parValor)
        {
            this.atrConteoTotalMonedas = parValor;
        }
        /// <summary>
        /// El metodo funciona para cambiar el conteo por denominacion de la alcancia.
        /// </summary>
        /// <param name="parVector">Parametro de tipo byte vector que instrucciona la mutacion del metodo</param>
        private void MutarVectorConteoTotalMonedasPorDenominacion(byte[] parVector)
        {
            this.atrVectorConteoMonedasPorDenominacion = parVector;
        }
        /// <summary>
        /// El metodo funciona para cambiar el saldo total de la alcancia.
        /// </summary>
        /// <param name="parValor">Parametro de tipo uint que instrucciona la mutacion del metodo</param>
        private void MutarSaldoTotalMonedas(uint parValor)
        {
            this.atrSaldoTotalMonedas = parValor;
        }
        /// <summary>
        /// El metodo funciona para cambiar el saldo por denominacion de la alcancia.
        /// </summary>
        /// <param name="parVector">Parametro de tipo uint vector que instrucciona la mutacion del metodo</param>
        private void MutarVectorSaldoTotalMonedasPorDenominacion(uint[] parVector)
        {
            this.atrVectorSaldoTotalMonedasPorDenominacion = parVector;
        }
        /// <summary>
        /// El metodo funciona para cambiar el objeto moneda de la alcancia.
        /// </summary>
        /// <param name="parColeccion">Parametro de tipo lista clsMONEDA que instrucciona la mutacion del metodo</param>
        private void MutarColeccionObjsMoneda(List<clsMONEDA> parColeccion)
        {
            this.atrColeccionObjsMoneda = parColeccion;
        }
        #endregion
        #region Asociador
        /// <summary>
        /// El metodo adiciona un objeto moneda a la alcancia
        /// </summary>
        /// <param name="parObjeto">Parametro de tipo clsMONEDA que instrucciona el metodo</param>
        private void AsociarObjMoneda(clsMONEDA parObjeto)
        {
            this.atrColeccionObjsMoneda.Add(parObjeto);
        }
        #endregion
        #region Disociador
        /// <summary>
        /// Método que disocia un objeto de tipo moneda de la alcancía
        /// </summary>
        /// <param name="parObjeto">Parametro de tipo clsMONEDA que instrucciona el metodo</param>
        private void DisociarObjMoneda(clsMONEDA parObjeto)
        {
            this.atrColeccionObjsMoneda.Remove(parObjeto);
        }
        #endregion
        #region Transacciones
        /// <summary>
        /// Verifica si la denominación de un objeto moneda es admitida en el objeto alcancía
        /// </summary>
        /// <param name="parObjMoneda">Parámetro de tipo clsMONEDA</param>
        /// <returns>Returna el éxito o fracaso de la operación por medio de un bool</returns>
        bool EsValidaDenominacion(clsMONEDA parObjMoneda)
        {
            for (int varIndice = 0; varIndice < this.atrVectorDenominacionesAceptables.Length; varIndice++)
            {
                if(parObjMoneda.ObtenerDenominacion()==this.atrVectorDenominacionesAceptables[varIndice])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Encuentra un objeto de tipo moneda en la colección de la alcancía, verifica por medio de la denominación.
        /// </summary>
        /// <param name="parObjMoneda">parámetro de tipo clsMONEDA</param>
        /// <returns></returns>

        bool EncontrarMonedaEnAlcancia(clsMONEDA parObjMoneda)
        {
            for (int varIndice = 0; varIndice < this.atrVectorDenominacionesAceptables.Length; varIndice++)
            {
                if (parObjMoneda.ObtenerDenominacion() == this.atrVectorDenominacionesAceptables[varIndice])
                {
                    for (int varIndice2 = 0; varIndice2 < this.atrColeccionObjsMoneda.Count; varIndice2++)
                    {
                        if (parObjMoneda.ObtenerDenominacion() == this.atrColeccionObjsMoneda[varIndice2].ObtenerDenominacion())
                        {
                            return true;
                        }

                    }
            }
          
            }
            return false;
        }
        /// <summary>
        /// Recibe un parámetro de tipo clsMONEDA y un factor que indicará el aumento o decremento de los atributos derivables. Actualiza el saldo total de la alcancía, el saldo total por denominaciones, la cantidad de monedas de la alcancía y la cantidad de monedas por denominación
        /// </summary>
        /// <param name="parObjeto">Parámetro de tipo clsMONEDA</param>
        /// <param name="parFactor">Parámetro de tipo entero. 1 para incrementar, -1 para decrementar</param>
        public void ActualizarSaldoConteoMonedas(clsMONEDA parObjeto, int parFactor)
        {
            this.atrSaldoTotalMonedas += (uint)((parObjeto.ObtenerDenominacion() * parFactor));
            this.atrConteoTotalMonedas= (byte)(atrConteoTotalMonedas+parFactor);

            for(int varPosicion=0;varPosicion<this.atrVectorDenominacionesAceptables.Length;  varPosicion++)
            {
                if(parObjeto.ObtenerDenominacion()==this.atrVectorDenominacionesAceptables[varPosicion])
                {
                    this.atrVectorSaldoTotalMonedasPorDenominacion[varPosicion] += (uint)(parObjeto.ObtenerDenominacion() * parFactor);
                    this.atrVectorConteoMonedasPorDenominacion[varPosicion]= (byte)(this.atrVectorConteoMonedasPorDenominacion[varPosicion]+parFactor);
                }
            }
        }
        /// <summary>
        /// Deposita un objeto moneda en la alcancía, modifica los atributos asociativos de ambos
        /// </summary>
        /// <param name="parObjMoneda">Parámetro de tipo clsMONEDA</param>
        /// <param name="parMensajeResultadoDepositarMoneda">Parámetro de tipo string por referencia para indicar el éxtio o fracaso</param>
        public void transDepositarObjMoneda(clsMONEDA parObjMoneda, ref string parMensajeResultadoDepositarMoneda)
        {
            
                if (EsValidaDenominacion(parObjMoneda))
                {
                    parObjMoneda.AsociadorObjAlcancia(this);
                    this.AsociarObjMoneda(parObjMoneda);
                    this.ActualizarSaldoConteoMonedas(parObjMoneda, 1);
                parMensajeResultadoDepositarMoneda = "Se depositó la moneda exitosamente";

            }
        }
        /// <summary>
        ///  Retira un objeto moneda de la alcancía, modifica los atributos asociativos de ambos
        /// </summary>
        /// <param name="parObjMoneda">Parámetro de tipo clsMONEDA</param>
        /// <param name="parMensajeResultadoDepositarMoneda">Parámetro de tipo string por referencia para indicar el éxtio o fracaso</param>
        public void transRetirarObjMoneda(clsMONEDA parObjMoneda, ref string parMensajeResultadoDepositarMoneda)
        {

            if (EncontrarMonedaEnAlcancia(parObjMoneda))
            {
                    parObjMoneda.DisociarObjAlcancia(this);
                    this.DisociarObjMoneda(parObjMoneda);
                    this.ActualizarSaldoConteoMonedas(parObjMoneda, (-1));
                    parMensajeResultadoDepositarMoneda = "Se retiró la moneda exitosamente";
                
            }
        }






        #endregion
        #endregion
    }
}
