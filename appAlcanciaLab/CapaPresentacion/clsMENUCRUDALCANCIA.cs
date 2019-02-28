using System;
using libConsolas;
using appAlcanciaLab.CapaCoordinacion;
using appAlcanciaLab.CapaDominio;

namespace appAlcanciaLab.CapaPresentacion

{
    class clsMENUCRUDALCANCIA : clsMENU
    {
        #region Atributos
        #region Entrada
        /// <summary>
        /// campo que asigna la capacidad límite de monedas del objeto alcancía
        /// </summary>
        private byte cmpCapacidadLimite;
        /// <summary>
        /// Campo que asigna la cantidad de denominaciones aceptables del objeto alcancía.
        /// </summary>
        private byte cmpCantidadDenominaciones;
        /// <summary>
        /// Campo que asigna las denominaciones aceptables del objeto alcancía.
        /// </summary>
        private uint[] cmpVectorDenominacionesAceptables = null;



        #endregion
        #region Salida
        /// <summary>
        /// Campo que recibe el éxito o fracaso de cada método.
        /// </summary>
        private string cmpMensajeResultado;
        #endregion
        #endregion
        #region Métodos
        #region Constructor
        /// <summary>
        /// Constructor por defecto de la clase heredada clsMENUCRUDALCANCIA
        /// </summary>
        public clsMENUCRUDALCANCIA()
        {

            this.atrVectorOpcionesDelMenu = new string[4] { "Iniciar alcancía", "Depositar Moneda", "Retirar Moneda", "Finalizar alcancía" };

        }

        #endregion
        #region obtenerCampos
        /// <summary>
        /// Obtiene por consola el campo capacidad límite de monedas del objeto alcancía.
        /// </summary>
        private void LeerCapacidadLimite()
        {

            cmpCapacidadLimite = clsCONSOLA.LeerVariableCon<Byte>("Capacidad límite de monedas: ");
        }
        /// <summary>
        /// Obtiene por consola el campo cantidad de denominaciones aceptables del objeto alcancía.
        /// </summary>

        private void CantidadDenominaciones()
        {

            cmpCantidadDenominaciones = clsCONSOLA.LeerVariableCon<Byte>("Cantidad de denominaciones aceptables: ");
        }
        /// <summary>
        /// Obtiene por consola el vector de denominaciones aceptables del objeto alcancía.
        /// </summary>
        private void LeerVectorDenominacionesAceptables()
        {
            CantidadDenominaciones();
            cmpVectorDenominacionesAceptables = new uint[cmpCantidadDenominaciones];
            clsCONSOLA.LeerVector<uint>("Escriba denominación: ", ref cmpVectorDenominacionesAceptables, cmpCantidadDenominaciones);
        }

        #endregion
        #region Cruds
        /// <summary>
        /// Método que inicia un objeto alcancía con una capacidad límite y unas denominaciones aceptables.
        /// </summary>
        private void Iniciar()
        {
            LeerCapacidadLimite();
            LeerVectorDenominacionesAceptables();
            clsCONTROLADOR.IniciarAlcancia(cmpCapacidadLimite, cmpVectorDenominacionesAceptables, ref cmpMensajeResultado);
        }
        /// <summary>
        /// Método que permite depositar un objeto de tipo moneda en la alcancía.
        /// </summary>
        public void Depositar()
        {
            ushort varDenominacion = clsCONSOLA.LeerVariableCon<ushort>("Denominacion de la moneda que desea depositar: ");
            clsCONTROLADOR.Depositar(varDenominacion, ref cmpMensajeResultado);
            clsCONSOLA.EscribirMensajeEmergenteCon("", cmpMensajeResultado);
        }
        /// <summary>
        /// Método que permite el retiro de un objeto moneda de la alcancía.
        /// </summary>
        public void Retirar()
        {
            ushort varDenominacion = clsCONSOLA.LeerVariableCon<ushort>("Denominacion de la moneda que desea retirar: ");
            clsCONTROLADOR.Retirar(varDenominacion, ref cmpMensajeResultado);
            clsCONSOLA.EscribirMensajeEmergenteCon("", cmpMensajeResultado);

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
                case 1: Iniciar(); break;
                case 2: Depositar(); break;
                case 3: Retirar(); break;

            }
        }
        #endregion
    }
}
