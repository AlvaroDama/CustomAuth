using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuth.Utility
{
    public class SeguridadUtility
    {
        public static string GetSha1(string txt)
        {
            var hasher = SHA1.Create();
            UTF8Encoding encoding = new UTF8Encoding(); //UNICODE encoding (gracias por las eñes).
            
            StringBuilder builder = new StringBuilder();
            var datos = hasher.ComputeHash(encoding.GetBytes(txt));

            foreach (var ite in datos)
            {
                builder.AppendFormat("{0:x2}", ite); //el {0:x2} indica que voy a devolver dos caracteres aunque solo tenga uno (fabriquemos un HEXA)
            }

            return builder.ToString();
        }

        public static byte[] GetKey(string txt)
        {
            return new PasswordDeriveBytes(txt, null).GetBytes(32); //genera password aleatoria desde un origen. El null es el salt 
                                                                    //(salto de aleatoriedad), que lo queremos en nulo para que no 
                                                                    //sea aleatorio y cree la misma Pass para la misma cadena de texto.
        }

        public static string Encrypt(string txt, string crypt)
        {
            var cripto = new RijndaelManaged(); //
            var encoding = new UTF8Encoding();
            byte[] aEncriptar, cifrado, retorno, clave;

            clave = GetKey(crypt);

            cripto.Key = clave;
            cripto.GenerateIV();

            aEncriptar = encoding.GetBytes(txt);
            cifrado = cripto.CreateEncryptor().TransformFinalBlock(aEncriptar, 0, aEncriptar.Length);

            retorno = new byte[cripto.IV.Length + cifrado.Length];

            cripto.IV.CopyTo(retorno, 0);
            cifrado.CopyTo(retorno, cripto.IV.Length);

            return Convert.ToBase64String(retorno); //la mejor opción para almacenar strings con un UTF8-encode.
        }

        public static string Decrypt(byte[] txt, string crypt)
        {
            var cripto = new RijndaelManaged();
            var encoding = new UTF8Encoding();
            var ivTemp = new byte[cripto.IV.Length]; //Rijndael siempre crea los IV del mismo tamaño

            var clave = GetKey(crypt);
            var cifrado = new byte[txt.Length-ivTemp.Length];

            cripto.Key = clave;

            Array.Copy(txt, ivTemp, ivTemp.Length); //coge de data, guarda en ivTemp tantos bytes como Rijndael.IV.length (guarda todo el IV)
            Array.Copy(txt, ivTemp.Length, cifrado, 0, cifrado.Length);    //coge data, se salta tantos bytes como IV.length y guarda en cifrado 
                                                                            //desde la posición 0 a la posición (máxima) los datos
            cripto.IV = ivTemp;
            var descifrado = cripto.CreateDecryptor().TransformFinalBlock(cifrado, 0, cifrado.Length);

            return encoding.GetString(descifrado);
        }
    }
}
