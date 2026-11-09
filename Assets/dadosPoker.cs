using UnityEngine;

public class dadosPoker : MonoBehaviour
{

    char[] dadosValor = {'7' , '8' , 'J' , 'Q' , 'K' , 'A'}; // Array con los posibles valores de los dados de poker
    
    char[] dados = new char [6];  // Array donde se guarda el resultado actual de cada dado
    
    public int tiradas = 0; // Contador del número de tiradas realizadas
    
    public bool[] dadosSeleccion = new bool [6]; // Array para controlar qué dados se van a volver a tirar
    
    string tiradaDados = null; // String donde se guarda el resultado final de la tirada
    
    public bool tiraDados = false; // Booleano que activa la tirada
    
    public bool reset; // Booleano para reiniciar la partida

    void Start()
    {
        tiradas = 0; // Reinicia el contador de tiradas
        
        dadosSeleccion = new bool[]{true, true, true, true, true, true}; // Todos los dados estarán seleccionados al comenzar
    }

    void Update()
    {
        if (reset) // Comprueba si se ha pulsado reset

        {
            tiradas = 0; // Reinicia el número de tiradas
            
            dadosSeleccion = new bool[]{true, true, true, true, true, true}; // Vuelve a seleccionar todos los dados
            
            reset = false; // Desactiva reset para evitar reinicios infinitos
            
            print("Realice su tirada"); // Mensaje en consola
        }


        if (tiraDados) // Comprueba si se debe lanzar los dados
        {
            tiradas++; // Suma una tirada
            
            tiradaDados = null; // Vacía el string anterior

            for (int i = 0; i < dadosSeleccion.Length; i++) // Recorre todos los dados
            {
                if (dadosSeleccion[i]==true) // Comprueba si el dado está seleccionado
                {
                    dados[i] = dadosValor[Random.Range(0,5)]; // Genera un valor aleatorio del array dadosValor
                }
                if (i < dadosSeleccion.Length - 1) // Añade una coma excepto en el último dado
                {
                    tiradaDados += dados[i] + ",";
                }
                else
                {
                    tiradaDados += dados[i]; // Añade el valor del dado al string
                }
                
                
            }

   
            // -----------------------------
            // COMPROBAR JUGADAS DE POKER
            // -----------------------------

            //Creamos las variables para cada jugada
            
            int parejas = 0; // Guarda cuantas parejas existen
            
            int trio = 0; // Guarda cuantos trios existen
            
            bool poker = false; // Detecta si hay poker
            
            bool repoker = false; // Detecta si hay repoker
            
            char dadoAlto = '7'; // Guarda el dado más alto


            // Recorre cada posible valor
            for (int i = 0; i < dadosValor.Length; i++)
            {
                int contador = 0;

                // Cuenta cuantas veces aparece ese valor
                for (int j = 0; j < dados.Length; j++)
                {
                    if (dados[j] == dadosValor[i])
                    {
                        contador++;
                    }
                }
                
                // Guarda el dado mas alto encontrado
                if (contador > 0)
                {
                    dadoAlto = dadosValor[i];
                }


                // Detecta las jugadas
                if (contador == 2)
                {
                    parejas++;
                }
                if (contador == 3)
                {
                    trio++;
                }
                if (contador == 4)
                {
                    poker = true;
                }
                if (contador >= 5)
                {
                    repoker = true;
                }

            }

            string jugada = dadoAlto + " ALTO"; // Variable donde guardaremos la jugada, por defecto mostrará el dado más alto

            // Comprueba las combinaciones
            if (parejas == 1)
            {
                jugada = "PAREJA";
            }

            if (parejas >= 2)
            {
                jugada = "DOBLE PAREJA";
            }

            if (trio == 1)
            {
                jugada = "TRIO";
            }

            if (trio >= 2 || (trio == 1 && parejas >= 1))
            {
                jugada = "FULL";
            }

            if (poker)
            {
                jugada = "POKER";
            }

            if (repoker)
            {
                jugada = "REPOKER";
            }

            // Muestra resultado final
            print("El valor de la tirada es: " + tiradas + ") " + tiradaDados);

            print("Jugada obtenida: " + jugada);

            tiraDados = false;
        }
    }
}
