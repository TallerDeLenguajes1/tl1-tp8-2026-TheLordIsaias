using System.Security.Cryptography;

namespace EspacioCalculadora{
    public class Calculadora
    {
        private double dato;
        private List<Operacion> historial;
        public Calculadora(double dato)
        {
            this.dato = dato;
            this.historial = new List<Operacion>();
        }
        public double Resultado
        {
            get => dato; 
        }
        public void Sumar(double termino)
        {
            Operacion operacion = new Operacion(dato);
            operacion.NuevoValor = termino;
            operacion.TipoDeOperacion = TipoOperacion.Suma;
            historial.Add(operacion);
            dato += termino;
        }
        public void Restar(double termino)
        {
            Operacion operacion = new Operacion(dato);
            operacion.NuevoValor = termino;
            operacion.TipoDeOperacion = TipoOperacion.Resto;
            historial.Add(operacion);
            dato -= termino;
        }
        public void Multiplicar(double termino)
        {
            Operacion operacion = new Operacion(dato);
            operacion.NuevoValor = termino;
            operacion.TipoDeOperacion = TipoOperacion.Multiplicacion;
            historial.Add(operacion);
            dato *= termino;
        }
        public void Dividir(double termino)
        {
            Operacion operacion = new Operacion(dato);
            operacion.NuevoValor = termino;
            operacion.TipoDeOperacion = TipoOperacion.Division;
            historial.Add(operacion);
            dato /= termino;
        }
        public void Limpiar()
        {
            Operacion operacion = new Operacion(dato);
            operacion.NuevoValor = 0;
            operacion.TipoDeOperacion = TipoOperacion.Limpiar;
            historial.Add(operacion);
            dato = 0;
        }
        public List<Operacion> Historial
        {
            get
            {
                return historial;
            }
        }
    }
    public enum TipoOperacion
    {
        Suma,
        Resto,
        Multiplicacion,
        Division,
        Limpiar
    }
    public class Operacion
    {
        private double resultadoAnterior;
        public double ResultadoAnterior
        {
            get
            {
                return resultadoAnterior;
            }
            set
            {
                resultadoAnterior = value;
            }
        }
        private double nuevoValor;
        public double NuevoValor
        {
            get
            {
                return nuevoValor;
            }
            set
            {
                nuevoValor = value;
            }
        }
        public TipoOperacion TipoDeOperacion{get; set;}
        public double Resultado()
        {
            double resultado = 0;
            switch (TipoDeOperacion)
            {
                case TipoOperacion.Suma:
                    resultado = resultadoAnterior + nuevoValor;
                    break;
                case TipoOperacion.Resto:
                    resultado = resultadoAnterior - nuevoValor;
                    break;
                case TipoOperacion.Multiplicacion:
                    resultado = resultadoAnterior * nuevoValor;
                    break;
                case TipoOperacion.Division:
                    resultado = resultadoAnterior / nuevoValor;
                    break;
                case TipoOperacion.Limpiar:
                    resultadoAnterior = 0;
                    nuevoValor = 0;
                    break;
            }

            return resultado;
            
        }
        public Operacion(double resultadoAnterior)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = 0;
            this.TipoDeOperacion = TipoOperacion.Limpiar;
        }
    }
}