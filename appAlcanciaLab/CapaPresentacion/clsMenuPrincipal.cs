using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appAlcanciaLab.CapaPresentacion
{
    class clsMenuPrincipal: clsMENU
    {
        /// <summary>
        /// Constructor por defecto de un objeto de tipo clsMenuPrincipal.
        /// </summary>
        public clsMenuPrincipal()
        {

            this.atrVectorOpcionesDelMenu = new string[2] { "Ingresar como administrador", "Ingresar como ahorrador" };
        }
        /// <summary>
        /// Método override (desplaza la lógica de su antecesor) procesa la opción escogida.
        /// </summary>
        /// <param name="parOpcion">parámetro de tipo byte, recibe como argumento una opción escogida</param>
        protected override void ProcesarOpcion(byte parOpcion)
        {
            switch(parOpcion)
            {
                case 1: new clsMENUCRUDMONEDA().IterarMenu(); break; 
                case 2: new clsMENUCRUDALCANCIA().IterarMenu(); break;

            }
        }
    }
}
