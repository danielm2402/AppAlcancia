using System;

namespace libConsolas
{
    public static class clsCONSOLA
    {
        public static void EscribirSaltarLinea(string parMensaje)
        {
            Console.WriteLine(parMensaje);
        }
        public static void LeerTecla()
        {
            Console.ReadKey();
        }
    }
}
