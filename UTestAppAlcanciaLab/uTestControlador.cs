using System;
using System.Collections.Generic;
using appAlcanciaLab.CapaDominio;
using appAlcanciaLab.CapaCoordinacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTestAppAlcanciaLab
{
    [TestClass]
    public class uTestControlador
    {
        /// <summary>
        /// Método unidad de prueba, verifica el correcto registro de un objeto de tipo moneda.
        /// </summary>
        [TestMethod]
        public void uTestRegistrarMoneda()
        {
            string varMensaje="";
            clsMONEDA varObjMoneda = new clsMONEDA(1, 200, 1999);
            clsCONTROLADOR.AsociarObjMoneda(varObjMoneda, ref varMensaje);
            Assert.AreEqual(varObjMoneda, clsCONTROLADOR.ObtenerObjMonedaCon(200, ref varMensaje)); //verifica que la moneda creada con denominación 200 se encuentre en la colección
        }
        /// <summary>
        /// Método unidad de prueba, verifica la correcta actualización de un objeto de tipo moneda.
        /// </summary>
        [TestMethod]
        public void uTestActualizarMoneda()
        {
            string varMensaje = "";
            clsMONEDA varObjMoneda = new clsMONEDA(1, 200, 1999);
            clsCONTROLADOR.AsociarObjMoneda(varObjMoneda, ref varMensaje);
            clsCONTROLADOR.crudActualizarMoneda(1, 500, 2008);
            clsMONEDA varObj = clsCONTROLADOR.ObtenerObjMonedaCon((uint)1, ref varMensaje);
            Assert.AreEqual(500, (int)varObj.ObtenerDenominacion());

        }
        /// <summary>
        /// Método unidad de prueba, verifica la correcta eliminación de un objeto de tipo moneda.
        /// </summary>

        [TestMethod]
        public void uTestEliminarMoneda()
        {
            string varMensaje = "";
            clsMONEDA varObjMoneda = new clsMONEDA(5, 200, 1999);
            clsCONTROLADOR.AsociarObjMoneda(varObjMoneda, ref varMensaje);
            clsCONTROLADOR.CrudEliminarObjMonedaCon(5, ref varMensaje);
            clsMONEDA varObj = clsCONTROLADOR.ObtenerObjMonedaCon((uint)5, ref varMensaje);
            Assert.AreEqual(null,varObj);

        }
        /// <summary>
        /// Método unidad de prueba, verifica la correcta transacción de deposito de un objeto moneda en un objeto alcancía.
        /// </summary>

        [TestMethod]
        public void uTestDepositarMonedaCasoExitoso()
        {

            #region Inicializar
            string varMensajeResultado = "";
            uint[] varVectorDenominacionesAceptables = new uint[2] { 100, 200 };

            clsALCANCIA varObjAlcancia = new clsALCANCIA(100, varVectorDenominacionesAceptables);
            clsCONTROLADOR.AsociarObjAlcancia(varObjAlcancia);

            clsCONTROLADOR.crudRegistrarMonedaCon(1, 200, 1999,ref  varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(2, 100, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(3, 100, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(4, 200, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(5, 200, 1999, ref varMensajeResultado);
            #endregion
            #region Probar
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);

            clsCONTROLADOR.Depositar(100, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(100, ref varMensajeResultado);

            #endregion
            #region Comprobar
            Assert.AreEqual((uint)800, varObjAlcancia.ObtenerSaldoTotalMonedas()); //Saldo total de la alcancía
            Assert.AreEqual((uint)2, varObjAlcancia.ObtenerVectorConteoTotalMonedasPorDenominacion()[0]);// Cantidad de monedas de 100
            Assert.AreEqual((uint)3, varObjAlcancia.ObtenerVectorConteoTotalMonedasPorDenominacion()[1]);//Cantidad de monedas de 200
            Assert.AreEqual((uint)200, varObjAlcancia.ObtenerVectorSaldoTotalMonedasPorDenominacion()[0]);//Saldo total de monedas de 100
            Assert.AreEqual((uint)600, varObjAlcancia.ObtenerVectorSaldoTotalMonedasPorDenominacion()[1]);//Saldo total monedas de 200
            #endregion
        }
        /// <summary>
        /// Método unidad de prueba, verifica la correcta procedencia de intentar depositar una moneda no válida.
        /// </summary>
        [TestMethod]
        public void uTestDepositarMonedaNoValida()
        {
            #region Inicializar
            string varMensajeResultado = "";
            uint[] varVectorDenominacionesAceptables = new uint[2] { 100, 200 };

            clsALCANCIA varObjAlcancia = new clsALCANCIA(100, varVectorDenominacionesAceptables);
            clsCONTROLADOR.AsociarObjAlcancia(varObjAlcancia);
            clsCONTROLADOR.crudRegistrarMonedaCon(1, 500, 1999, ref varMensajeResultado);
            #endregion
            #region Probar
            clsCONTROLADOR.Depositar(500, ref varMensajeResultado);

            #endregion
            #region Comprobar
            Assert.AreEqual((uint)0, varObjAlcancia.ObtenerSaldoTotalMonedas());
            #endregion
        }
        /// <summary>
        /// Método unidad de prueba, verifica la correcta transacción de retirar un objeto moneda de un objeto alcancía.
        /// </summary>

        [TestMethod]
        public void uTestRetirarMonedaCasoExitoso()
        {


            #region Inicializar
            string varMensajeResultado = "";
            uint[] varVectorDenominacionesAceptables = new uint[2] { 100, 200 };

            clsALCANCIA varObjAlcancia = new clsALCANCIA(100, varVectorDenominacionesAceptables);
            clsCONTROLADOR.AsociarObjAlcancia(varObjAlcancia);

            clsCONTROLADOR.crudRegistrarMonedaCon(1, 200, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(2, 100, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(3, 100, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(4, 200, 1999, ref varMensajeResultado);
            clsCONTROLADOR.crudRegistrarMonedaCon(5, 200, 1999, ref varMensajeResultado);
            #endregion
            #region Probar
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(200, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(100, ref varMensajeResultado);
            clsCONTROLADOR.Depositar(100, ref varMensajeResultado);

            clsCONTROLADOR.Retirar(100, ref varMensajeResultado);
            clsCONTROLADOR.Retirar(100, ref varMensajeResultado);
            clsCONTROLADOR.Retirar(100, ref varMensajeResultado);
            clsCONTROLADOR.Retirar(200, ref varMensajeResultado);

            #endregion
            #region Comprobar
            Assert.AreEqual((uint)400, varObjAlcancia.ObtenerSaldoTotalMonedas()); //Saldo total de la alcancía
            Assert.AreEqual((uint)0, varObjAlcancia.ObtenerVectorSaldoTotalMonedasPorDenominacion()[0]);
            Assert.AreEqual((uint)400, varObjAlcancia.ObtenerVectorSaldoTotalMonedasPorDenominacion()[1]);
            Assert.AreEqual((uint)0, varObjAlcancia.ObtenerVectorConteoTotalMonedasPorDenominacion()[0]);// Cantidad de monedas de 100
            Assert.AreEqual((uint)2, varObjAlcancia.ObtenerVectorConteoTotalMonedasPorDenominacion()[1]);//Cantidad de monedas de 200
            #endregion
        }






    }
}
