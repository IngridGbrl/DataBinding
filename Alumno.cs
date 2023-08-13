using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{

    // se usa la interfaz INotifyPropertyChanged para implementar el patrón de enlace de datos, que permite la sincronización de datos entre
    // el modelo y la vista

    // INotifyPropertyChanged se usa para notificar cuando se cambie el valor de una propiedad en la interfaz gráfica
    public class Alumno : INotifyPropertyChanged
    {
        //se manda a llamar el evento PropertyChanged de tipo PropertyChangedEventHandler y se asigna dentro de una propiedad en este caso
        //seria a PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //se declara un campo de tipo string nombre con sus metodos get y set
        //en get devolvera el campo nombre 
        //en set se verifica si el valor introducido como argumento al set es igual al valor actual del campo nombre, Si son iguales
        //significa que no hay cambios en el valor, y sale del set con  return

        //esto se hace para evitar notificaciones y actualizaciones innecesarias
        string nombre = string.Empty;
        public string Nombre { get => nombre;
            set
            {
                if (nombre == value)
                    return;
                //se asigna el valor pasado como argumento al setter al campo nombre esto actualiza el valor interno de
                //la propiedad nombre
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
                OnPropertyChanged(nameof(MostrarNombre));
            }
        }
        //se declara la propiedad MostrarNombre que tiene solo un get y es un método que se define para obtener el valor
        //de la propiedad
        //el get usa una expresión lambda para devolver el valor de la propieda se refiere a la propiedad Nombre de la
        //clase Alumno. El valor devuelto por la propiedad MostrarNombre
        //será una cadena que contiene el texto “Nombre Ingresado:” seguido del valor de la propiedad Nombre.
        public string MostrarNombre => $"Nombre Ingresado:{Nombre}";

        void OnPropertyChanged(string nombre)
        {
            //a este metodo se le declara un parametro nombre y este metodo se usa para para lanzar el evento PropertyChanged
            //cuando cambia el valor de una propiedad.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

            //se usa el operador ?, para indicar que se llama al método Invoke solo si el objeto PropertyChanged
            //no es nulo, este metodo invoca al evento PropertyChanged, pasando dos argumentos: el primero es this, que se
            //refiere al objeto actual de la clase Alumno, y el segundo es un objeto de tipo PropertyChangedEventArgs, que se crea
            //usando el constructor con un argumento, que es el nombre de la propiedad cuyo valor ha cambiado, que se pasa como parámetro al método
            //y se notifica en la interfas gráfica que ha habido un cambio en el valor de la propiedad, y les pasa el 
            //nombre de la propiedad
        }
    }
}
