using System;
using libConsolas;
using appAlcanciaLab.CapaCoordinacion;
using appAlcanciaLab.CapaDominio;
namespace appAlcanciaLab.CapaPresentacion
{
    class clsMENUCRUDMONEDA : clsMENU
    {
        #region Atributos
        #region Entrada
        /// <summary>
        /// campo que describe el OID de un objeto moneda
        /// </summary>
        private uint cmpOID;
        /// <summary>
        /// Campo que describe la Denominación de un objeto moneda
        /// </summary>
        private ushort cmpDenominacion;
        /// <summary>
        /// campo que que describe el año de un objeto moneda
        /// </summary>
        private int cmpAnhoDenominacion;
        /// <summary>
        /// Campo que describe el resultado de realizar una operación CRUD de un objeto moneda
        /// </summary>
        #endregion
        #region Salida
        private string cmpMensajeResultado;
        #endregion
        #endregion
        #region Métodos
        #region Constructor
        /// <summary>
        /// Constructor por defecto de un objeto de tipo clsMENUCRUDMONEDA.
        /// </summary>
        public clsMENUCRUDMONEDA()
        {

            this.atrVectorOpcionesDelMenu = new string[3] { "Registrar moneda", "Actualizar Moneda", "Eliminar Moneda" };
        }

        #endregion
        #region obtenerCampos
        // Mensaje 1: Como entrante
        /// <summary>
        /// Método que lee un OID para un objeto moneda
        /// </summary>
        private void LeerOID()
        {
            //Mensaje 1.1: Como saliente
            cmpOID = clsCONSOLA.LeerVariableCon<uint>("OID: ");
        }
        /// <summary>
        /// Método que lee la denominación y año de un objeto moneda
        /// </summary>
        private void LeerCampos()
        {

            //Mensaje 1.2 Como saliente
            cmpDenominacion = clsCONSOLA.LeerVariableCon<ushort>("Denominación: ");
            //Mensaje 1.3: Como saliente
            cmpAnhoDenominacion = clsCONSOLA.LeerVariableCon<int>("Año: ");
        }
        #endregion
        #region Cruds
        /// <summary>
        /// Registra un nuevo objeto de tipo moneda
        /// </summary>
        private void Registrar()
        {
            //Mensaje 1: Como saliente
            this.LeerOID();
            this.LeerCampos();
            //Mensaje 2: Como saliente
            clsCONTROLADOR.crudRegistrarMonedaCon(this.cmpOID, this.cmpDenominacion, this.cmpAnhoDenominacion, ref this.cmpMensajeResultado);
            //Mensaje 3: Como saliente
            clsCONSOLA.EscribirMensajeEmergenteCon("", cmpMensajeResultado);

        }
        /// <summary>
        /// Método crud que busca un OID dado para actualizar un objeto de tipo moneda
        /// </summary>
        private void Actualizar()
        {
            this.LeerOID();
            if (clsCONTROLADOR.ObtenerObjMonedaCon(this.cmpOID, ref this.cmpMensajeResultado) != null)
            {
                this.LeerCampos();
              this.cmpMensajeResultado= clsCONTROLADOR.crudActualizarMoneda(this.cmpOID, this.cmpDenominacion, this.cmpAnhoDenominacion);
            }
            clsCONSOLA.EscribirMensajeEmergenteCon("Resultado de la operacion actualizar", this.cmpMensajeResultado);

        }
        /// <summary>
        /// Método crud que busca un OID dado para eliminar un objeto de tipo moneda
        /// </summary>

        public void Eliminar()
        {
            this.LeerOID();
            if (clsCONTROLADOR.ObtenerObjMonedaCon(this.cmpOID, ref this.cmpMensajeResultado) != null)
            {
                clsCONTROLADOR.CrudEliminarObjMonedaCon(this.cmpOID, ref this.cmpMensajeResultado);
            }
            clsCONSOLA.EscribirMensajeEmergenteCon("Resultado de la operacion fallida", this.cmpMensajeResultado);
        }
        #endregion
        #endregion
        #region Procesar opción menú
        /// <summary>
        /// Método override (desplaza la lógica de su antecesor) procesa la opción escogida. 
        /// </summary>
        /// <param name="parOpcion">parámetro de tipo byte, recibe como argumento una opción escogida</param>
        protected override void ProcesarOpcion(byte parOpcion)
        {
            switch (parOpcion)
            {
                case 1: Registrar(); break;
                case 2: Actualizar(); break;
                case 3: Eliminar(); break;

            }
        }
        #endregion
    }
}
