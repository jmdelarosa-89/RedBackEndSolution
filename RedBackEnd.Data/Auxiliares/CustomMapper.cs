using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Data.Auxiliares
{
    public static class CustomMapper
    {
        /// <summary>
        /// Clona la informacion de un objeto a otro
        /// </summary>
        /// <typeparam name="T">Modelo origen</typeparam>
        /// <typeparam name="TU">Modelo destino</typeparam>
        /// <param name="source">Objeto origen con informacion</param>
        /// <param name="dest">Objeto destino con informacion</param>
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest, string Ignore = "")
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();

            if (sourceProps.Count == 0)
            {
                sourceProps = source.GetType().GetProperties().Where(x => x.CanRead).ToList();
            }

            var destProps = typeof(TU).GetProperties()
                                      .Where(x => x.CanWrite)
                                      .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name) && (Ignore.Length > 0 ? sourceProp.Name != Ignore : true))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    {   // Revisa si la propiedad puede delegar un valor o no
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
