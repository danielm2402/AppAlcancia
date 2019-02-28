//Patrón fachada
using System;
using System.Collections.Generic;
using appAlcanciaLab.CapaDominio;
using libConsolas;

namespace appAlcanciaLab.CapaCoordinacion
{
public static class clsCONTROLADOR
    {

        #region atributos
        #region Asociativos
        /// <summary>
        /// Atributo que describe la asociación de un objeto alcancía
        /// </summary>
        private static clsALCANCIA atrObjAlcancia = null;
        /// <summary>
        /// Atributo que describe la asociación de un objeto moneda 
        /// </summary>
        private static List<clsMONEDA> atrColeccionObjsMoneda = new List<clsMONEDA>();
        #endregion
        #endregion
        #region Metodos
        #region Accesores
        /// <summary>
        /// Obtiene una objeto moneda dado un OID 
        /// </summary>
        /// <param name="parOID">parámetro de tipo UINT</param>
        /// <returns></returns>
         public static clsMONEDA ObtenerObjMonedaCon(uint parOID, ref string parMensajeResultado)
        {
            try
            {
                if(clsCONTROLADOR.atrColeccionObjsMoneda.Count>0)
                {
                    foreach (clsMONEDA varObj in clsCONTROLADOR.atrColeccionObjsMoneda )
                    {
                        if(varObj.ObtenerOID()==parOID)
                        {
                            parMensajeResultado = "Ya existe una moneda con el OID proporcionado";
                            return varObj;
                        }
                    }
                    parMensajeResultado = "No se encontró un objeto con el OID proporcionado";
                    return null;
                }
                parMensajeResultado = "La coleccion está vacía";
                return null;
                    
            }
            catch (Exception e)
            {
                parMensajeResultado = e.Message;
                return null;
           
            }
        }
        /// <summary>
        /// Sobrecarga del método ObtenerObjMonedaCon, obtiente un objeto moneda dada una denominación.
        /// </summary>
        /// <param name="parDenominacion">Parámetro de tipo ushort dado para obtener un objeto moneda</param>
        /// <param name="parMensajeResultado">Parámetro de tipo string por referencia, indica el éxito o fracaso de la operación</param>
        /// <returns></returns>
         public static clsMONEDA ObtenerObjMonedaCon(ushort parDenominacion, ref string parMensajeResultado)
        {
            try
            {
                if (clsCONTROLADOR.atrColeccionObjsMoneda.Count > 0)
                {
                    foreach (clsMONEDA varObj in clsCONTROLADOR.atrColeccionObjsMoneda)
                    {
                        if (varObj.ObtenerDenominacion() == parDenominacion)
                        {
                            parMensajeResultado = "Se ha encontrado un objeto con la denominacion";
                            return varObj;
                        }
                    }
                    parMensajeResultado = "No se encontró un objeto con la denominacion proporcionada";
                    return null;
                }
               
                return null;

            }
            catch (Exception e)
            {
                parMensajeResultado += e.Message;
                return null;

            }
        }
        #endregion
        #region Asociadores
        /// <summary>
        /// Asocia un objeto de tipo alcancía
        /// </summary>
        /// <param name="parObjeto">parámetro de tipo clsALCANCÍA</param>
        public static void AsociarObjAlcancia(clsALCANCIA parObjeto)
        {
            atrObjAlcancia = parObjeto;
        }
        /// <summary>
        /// Asocia a la colección un objeto de tipo Moneda
        /// </summary>
        /// <param name="parObjeto">parámetro de tipo clsMONEDA</param>
        public static bool AsociarObjMoneda(clsMONEDA parObjeto, ref string parMensajeResultado)
        {
            try
            {
                clsCONTROLADOR.atrColeccionObjsMoneda.Add(parObjeto);
                parMensajeResultado = "Se ha asociado el objeto moneda con éxito";
                return true;
            }
            catch (Exception e)
            {
                parMensajeResultado = e.Message;
                return false;
                throw;
            }

        }
        #endregion
        #region Disociadores
        /// <summary>
        /// Remueve un objeto de tipo moneda de la colección de monedas
        /// </summary>
        /// <param name="parObjeto">parámetro de tipo clsMONEDA</param>
        private static void DisociarObjMoneda(clsMONEDA parObjeto)
        {
            clsCONTROLADOR.atrColeccionObjsMoneda.Remove(parObjeto);
        }
        /// <summary>
        /// Disocia el objeto alcancía
        /// </summary>
        private static void DisociarObjAlcancia()
        {
            atrObjAlcancia = null;
        }
        #endregion
        #region CRUD'S
        #region Registradores
        /// <summary>
        /// CRUD: Registra un objeto de tipo Moneda, por medio del OID verifica si ya existe una moneda registrada con el mismo identificador, devuelve un mensaje de error en caso de ya existir una moneda con ese OID
        /// </summary>
        /// <param name="parOID">Parámetro de tipo Uint, recibe como argumento un OID, recibe como argumento un OID para el objeto moneda </param>
        /// <param name="parDenominacion">Parámetro de tipo Ushort, recibe como argumento una Denominación para el objeto moneda</param>
        /// <param name="parAnhoEmision">Parámetro de tipo Int, recibe como argumento un año para el objeto moneda</param>
        /// <returns>Mensaje de éxito o fracaso al registrar un objeto moneda</returns>
        public static bool crudRegistrarMonedaCon(uint parOID, ushort parDenominacion, int parAnhoEmision, ref string parMensajeResultado)
        {
            parMensajeResultado = "La operación ha falado debido a: ";
            string varMensajeResultadoObtenerMoneda = "";
            string varMensajeResultadoAsociarObjMoneda="";

            if (clsCONTROLADOR.ObtenerObjMonedaCon(parOID, ref varMensajeResultadoObtenerMoneda) == null)
            {
                clsMONEDA varObjMoneda = new clsMONEDA(parOID, parDenominacion, parAnhoEmision);
                if(clsCONTROLADOR.AsociarObjMoneda(varObjMoneda, ref varMensajeResultadoAsociarObjMoneda))
                {
                    parMensajeResultado = "Se ha registrado correctamente el objeto moneda";
                    return true;
                }
                parMensajeResultado += varMensajeResultadoAsociarObjMoneda;
                return false;
            }
            parMensajeResultado += varMensajeResultadoObtenerMoneda;
            return false;
        }
        #endregion
        #region Actualizadores
        /// <summary>
        /// Método CRUD que actualiza un objeto de tipo moneda, por medio del OID verifica la existencia de una moneda y procede a modificarla (No permite modificar el OID) 
        /// </summary>
        /// <param name="parOID"> Parámetro de tipo uint, recibe como argumento un OID de cualquier moneda</param>
        /// <param name="parDenominacion">Parámetro de tipo Ushort, recibe como argumento una denominación para el objeto moneda</param>
        /// <param name="parAnhoEmision">Parámetro de tipo entero, recibe como argumento un año para el objeto moneda</param>
        /// <returns>Mensaje de éxito o fracaso al actualizar el objeto moneda</returns>
       public static string crudActualizarMoneda(uint parOID, ushort parDenominacion, int parAnhoEmision)
        {
            string varMensajeResultadoObtenerObjMoneda = "";
            clsMONEDA varObjMoneda = clsCONTROLADOR.ObtenerObjMonedaCon(parOID, ref varMensajeResultadoObtenerObjMoneda);
            if(varObjMoneda!=null)
            {

                varObjMoneda.ModificarCon(parDenominacion, parAnhoEmision);

                return "El objeto moneda fue modificado correctamente";
            }

          else
            {
                return "ERROR: La operación ha fallado debido a que el objeto no fue encontrado";
            }

            return "El objeto moneda fue modificado correctamente";
        }
        #endregion
        #region Eliminadores
        /// <summary>
        /// Método crud que elimina un objeto moneda, por medio de su identificador verifica la existencia de un objeto moneda, de ser así procede a su eliminación. 
        /// </summary>
        /// <param name="parOID">Parámetro de tipo uint, recibe como argumento un identificador de objeto para una moneda</param>
        /// <param name="parMensajeResultado">Parámetro de tipo string, se envía como referencia para sobreescribir el porqué del éxito o fracaso de una operación</param>
        /// <returns>Devuelve valores booleanos que confirman el éxito o fracaso de la operación</returns>
       public static bool CrudEliminarObjMonedaCon(uint parOID, ref string parMensajeResultado)
        {
            parMensajeResultado = "FRACASO: La operación fracasó debido a: ";
            string varMensajeResultadoObtenerObjMoneda = "";
            clsMONEDA varObjMoneda = clsCONTROLADOR.ObtenerObjMonedaCon(parOID, ref varMensajeResultadoObtenerObjMoneda);
            if (varObjMoneda != null)
            {

                string varMensajeResultadoFinalizar = "";
                if (varObjMoneda.Finalizar(ref varMensajeResultadoFinalizar))
                {
                    clsCONTROLADOR.DisociarObjMoneda(varObjMoneda);
                    varObjMoneda = null;
                    parMensajeResultado = "EXITO: El objeto moneda ha sido eliminado correctamente";
                    return true;
                }
            }
                parMensajeResultado += varMensajeResultadoObtenerObjMoneda;
                return false;
            }
        #endregion
        /// <summary>
        /// Construye un objeto alcancía inicializándola con una capacidad límite y un vector de denominaciones aceptables. 
        /// </summary>
        /// <param name="parCapacidadLimiteMonedas">Parámetro de tipo byte para el límite de la alcancía</param>
        /// <param name="parVectorDenominacionesAceptables">Parámetro de tipo uint[] para indicar las denominaciones aceptables</param>
        /// <param name="parMensajeResultado">Parámetro de tipo string por referencia para indicar el éxito o fracaso</param>
       public  static void IniciarAlcancia(byte parCapacidadLimiteMonedas, uint[]parVectorDenominacionesAceptables, ref string parMensajeResultado )
        {
            if(atrObjAlcancia== null)
            { 
           clsALCANCIA varObjAlcancia = new clsALCANCIA(parCapacidadLimiteMonedas, parVectorDenominacionesAceptables);
                parMensajeResultado = "Alcancia inicializada";
                clsCONTROLADOR.AsociarObjAlcancia(varObjAlcancia);
            }
            else
            {
                parMensajeResultado = "No se pudo iniciar la alcancía ya existe una alcancía inicializada";
            }

        }

        
        #endregion
        #region Transacciones
        /// <summary>
        /// Método que busca un objeto moneda con una denominación dada, si es aceptada en la alcancía la deposita modificando los atributos asociativos
        /// </summary>
        /// <param name="parDenominacion">Parámetro de tipo ushort dado para la busqueda de un objeto moneda</param>
        /// <param name="parMensaje">Parámetro de tipo string por referencia, indica el éxito o fracaso de la operación</param>
        public static void Depositar(ushort parDenominacion, ref string parMensaje)
        {
            clsMONEDA varObjMoneda;
            varObjMoneda= ObtenerObjMonedaCon(parDenominacion, ref parMensaje);
            if(varObjMoneda!=null)
            atrObjAlcancia.transDepositarObjMoneda(varObjMoneda, ref parMensaje);

        }
        /// <summary>
        /// Método que busca un objeto moneda con una denominación dada, si ésta denominación es aceptada en la alcancía procede a buscarla y la retira modificando los atributos asociativos.
        /// </summary>
        /// <param name="parDenominacion">Parámetro de tipo ushort dado para la busqueda de un objeto moneda</param>
        /// <param name="parMensaje">Parámetro de tipo string por referencia, indica el éxito o fracaso de la operación</param>
      public  static void Retirar(ushort parDenominacion, ref string parMensaje)
        {
            clsMONEDA varObjMoneda;
            varObjMoneda = ObtenerObjMonedaCon(parDenominacion, ref parMensaje);
            if (varObjMoneda != null)
               atrObjAlcancia.transRetirarObjMoneda(varObjMoneda, ref parMensaje);
           
        }

        #endregion
        #endregion

    }
}
