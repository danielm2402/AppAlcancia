using System;
using libConsolas;

namespace appAlcanciaLab.CapaPresentacion
{
    class clsMENU
    {
        /// <summary>
        /// Atributo al cual se asigna una opción para iterar el menú
        /// </summary>
       private byte varOpcion;
        /// <summary>
        /// atributo protegido, vector de tipo string
        /// </summary>
        protected String[] atrVectorOpcionesDelMenu;
        /// <summary>
        /// Método protegido que imprime un menú
        /// </summary>
        private void ImprimirMenu()
        {
            byte varPosicion;
            clsCONSOLA.Limpiar();
            clsCONSOLA.EscribirSaltarLineaCon("--------------- MENU PRINCIPAL--------------------");
            clsCONSOLA.EscribirSaltarLineaCon("---------------------------------------------------");
            for (varPosicion = 0; varPosicion < atrVectorOpcionesDelMenu.Length; varPosicion++)
            {
                clsCONSOLA.EscribirSaltarLineaCon((varPosicion + 1) + "." + atrVectorOpcionesDelMenu[varPosicion]);
            }
            clsCONSOLA.EscribirSaltarLineaCon((varPosicion + 1) + ".Salir");
            clsCONSOLA.EscribirSaltarLineaCon("--------------------------------------------------------");
        }
        /// <summary>
        /// método virtual, espera procesar una opción en algún descendiente
        /// </summary>
        /// <param name="parOpcion"></param>
        protected virtual void ProcesarOpcion(byte parOpcion)
        {

        }
        /// <summary>
        /// Método iterativo, escribe un menú bajo el ciclo do-while
        /// </summary>
        public void IterarMenu()
        {
                do
                {
               
                try
                {
                    this.ImprimirMenu();
                    varOpcion = clsCONSOLA.LeerVariableCon<byte>("Seleccione una opción: ");
                    this.ProcesarOpcion(varOpcion);
                }
                catch (Exception e)
                {

                    clsCONSOLA.EscribirCon(e.Message);
                    clsCONSOLA.LeerTecla();
                }

                    
                } while (varOpcion != (this.atrVectorOpcionesDelMenu.Length + 1));


            }

        }
    }


