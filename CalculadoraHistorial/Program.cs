using EspacioCalculadora;

Calculadora calc = new Calculadora(25);

Console.WriteLine($"Se creo una nueva instancia de la clase Calculadora con el valor {calc.Resultado}");

bool bandera = true;
int opcion;
double termino;
bool estado;

do
{
    Console.WriteLine("\n¿Que operacion desea realizar?\n1. Sumar\n2. Restar\n3. Multiplicar\n4. Dividir\n0. Ninguna/Salir");
    estado = int.TryParse(Console.ReadLine(), out opcion);
    if(estado && opcion != 0)
    {
        Console.WriteLine("Ingrese un termino para realizar el calculo");
        estado = double.TryParse(Console.ReadLine(), out termino);
        if (estado)
        {
            switch (opcion)
            {
                case 1:
                    calc.Sumar(termino);
                    break;
                case 2:
                    calc.Restar(termino);
                    break;
                case 3:
                    calc.Multiplicar(termino);
                    break;
                case 4:
                    calc.Dividir(termino);
                    break;
                default:
                    Console.WriteLine("Hubo un error realizando la operacion, no se realizaron cambios");
                    break;
            }
            Console.WriteLine($"El resultado de la operacion hecha fue {calc.Resultado}");
        } 
        else
        {
            Console.WriteLine("El numero ingresado no es valido, no se realizaron cambios");
        }
    }
    else
    {
        if (!estado)
        {
            Console.WriteLine("La opcion elegida no es correcta, no se realizaron cambios");
        }
        else
        {
            calc.Limpiar();
            bandera = false;
        }
    }
}while(bandera);

foreach (var operacion in calc.Historial)
{
    Console.WriteLine($"Operacion: {operacion.TipoDeOperacion}");
}