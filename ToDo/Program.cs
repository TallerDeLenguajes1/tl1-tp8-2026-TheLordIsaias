using System.Linq;
using System.Security.Cryptography;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

int N = 10;

Random random = new Random();

for (int i = 0; i < N; i++)
{
    tareasPendientes.Add(new Tarea(){TareaID = i+1, Descripcion = $"Tarea #{i+1}", Duracion = random.Next(10, 101)});
}

bool bandera = true;
while (bandera)
{
    switch (menu())
    {
        case 1:
            Console.WriteLine("------------ Lista de Tareas Pendientes ------------");
            mostrarLista(tareasPendientes);
            break;
        case 2:
            Console.WriteLine("------------ Lista de Tareas Realizadas ------------");
            mostrarLista(tareasRealizadas);
            break;
        case 3:
            Tarea mover = buscarTareaEnListaPorID(tareasPendientes);
            completarTarea(tareasPendientes, tareasRealizadas, mover);
            break;
        case 4:
            Tarea tareaBuscada = buscarTareaEnListaPorDescripcion(tareasPendientes);
            mostrarTarea(tareaBuscada);
            break;
        case 5:
            bandera = false;
            break;
        default:
            Console.WriteLine("Ha ocurrido un error inesperado");
            bandera = false;
            break;
    }
}

void mostrarLista(List<Tarea> tareas)
{
    if(tareas.Count != 0)
    {
        foreach (var tarea in tareas)
        {
            Console.WriteLine($"------------------------------\n- ID Tarea: #{tarea.TareaID}\n- Descripcion de la Tarea: {tarea.Descripcion}\n- Duracion tarea: {tarea.Duracion}");
        } 
    } else
    {
        Console.WriteLine("La lista esta vacia");
    }
    
}

int menu()
{
    int opcion;    
    do
    {
        Console.WriteLine("¿Que desea hacer?\n1. Ver lista de Tareas Pendientes\n2. Ver lista de Tareas Realizadas\n3. Mover una Tarea Pendiente a Realizada\n4. Buscar una tarea por Descripcion\n5. Salir");
        if(!int.TryParse(Console.ReadLine(), out opcion)){
            Console.WriteLine("Error al ingresar un numero");
            opcion = 0;
        }
    } while(opcion<1 || opcion >5);
    return opcion;
}

Tarea buscarTareaEnListaPorID(List<Tarea> tareas)
{
    bool encontrado = false;
    Tarea mover = null;
    int idTarea;
    Console.WriteLine("Ingrese una ID para marcar como completada una tarea: ");
    if(!int.TryParse(Console.ReadLine(), out idTarea))
    {
        Console.WriteLine("ID de tarea invalido");
    } else
    {
        
        foreach (var tarea in tareasPendientes)
        {
            if(tarea.TareaID == idTarea)
            {
                mover = tarea;
                encontrado = true;
            }
        }
    }
    if (!encontrado)
    {
        Console.WriteLine("No existe una tarea con ese ID en la lista buscada");
    }
    return mover;
}

void completarTarea(List<Tarea> listaOrigen, List<Tarea> listaDestino, Tarea tarea)
{
    listaDestino.Add(tarea);
    listaOrigen.Remove(tarea);
}

Tarea buscarTareaEnListaPorDescripcion(List<Tarea> tareas)
{
    Tarea tareaEncontrada = null;
    string descripcionTarea;
    Console.WriteLine("Ingrese una descripcion para buscar una tarea: ");
    descripcionTarea = Console.ReadLine();
    foreach (var tarea in tareas)
    {
        if (tarea.Descripcion.Contains(descripcionTarea))
        {
            tareaEncontrada = tarea;
        }
    }
    return tareaEncontrada;
}

void mostrarTarea(Tarea tarea)
{
    Console.WriteLine($"------------------------------\n- ID Tarea: #{tarea.TareaID}\n- Descripcion de la Tarea: {tarea.Descripcion}\n- Duracion tarea: {tarea.Duracion}");
}