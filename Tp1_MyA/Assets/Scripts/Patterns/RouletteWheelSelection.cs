using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RouletteWheelSelection
{

    public static T GetRandom<T>(List<T> posibles)
    {
        //Probabilidad de cada uno
        var probEach = 1f / posibles.Count;//El uno tiene que ser float(por eso la f) sino nos da 0 siempre.

        //Accumulador de probabilidades anteriores
        var acc = 0f;

        //Numero random entre 0 y 1
        var x = UnityEngine.Random.value;

        for (int i = 0; i < posibles.Count; i++)
        {
            acc += probEach;

            if (x <= acc) return posibles[i];
        }

        //Nunca deberia llegar aca, pero el compilador nunca lo sabe, por eso
        //nos pide que devolvamos un valor si llega aca
        return default(T);//Devuelve "null" si T es una clase o "0" si es un numero
    }

    public static T GetRandomByWeight<T>(List<T> posibles, List<float> weights)
    {
        //Pesos sumados
        var totalWeights = 0f;

        foreach (var weight in weights)
        {
            totalWeights += weight;
        }

        //Accumulador de probabilidades anteriores
        var acc = 0f;

        //Numero random entre 0 y 1
        var x = UnityEngine.Random.value;

        for (int i = 0; i < posibles.Count; i++)
        {
            //La probabilidad es el peso sobre el peso total
            var probThis = weights[i] / totalWeights;

            acc += probThis;

            if (x <= acc) return posibles[i];
        }

        //Nunca deberia llegar aca, pero el compilador nunca lo sabe, por eso
        //nos pide que devolvamos un valor si llega aca
        return default(T);//Devuelve "null" si T es una clase o "0" si es un numero
    }

    //RECOMIENDO hacer este solo
    //Key es el dato, Value es el peso
    public static T GetRandomByWeight<T>(Dictionary<T, float> posibles)
    {
        #region NO TE SPOILEES

        //Pesos sumados
        var totalWeights = 0f;

        foreach (var weight in posibles.Values)
        {
            totalWeights += weight;
        }

        //Accumulador de probabilidades anteriores
        var acc = 0f;

        //Numero random entre 0 y 1
        var x = UnityEngine.Random.value;

        foreach (var pair in posibles)
        {
            //La probabilidad es el peso sobre el peso total
            var probThis = pair.Value / totalWeights;

            acc += probThis;

            if (x <= acc) return pair.Key;
        }        

        //Nunca deberia llegar aca, pero el compilador nunca lo sabe, por eso
        //nos pide que devolvamos un valor si llega aca
        return default(T);//Devuelve "null" si T es una clase o "0" si es un numero

        #endregion
    }

}
