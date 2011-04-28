
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Core.Service;

namespace Service
{
    public class UtilService : IUtilService
    {

        #region IUtilService Members

        public string ConvertChsToPinYin(string chs)
        {
            byte[] decodeds = Encoding.BigEndianUnicode.GetBytes(chs);
            var singleChsChar = new StringBuilder();
            var retValue = new StringBuilder();
            var dict = UnicodeToPinYinMapping.GetInstance().BuildMappingDictionary();
            for (int i = 0; i < decodeds.Length; i++ )
            {
                singleChsChar.AppendFormat(decodeds[i].ToString("x2"));                    

                if ((i + 1) % 2 == 0)
                {
                    // Translate Unicode to PinYin
                    var pinYin = from entry in dict
                                 where entry.Key.Equals(singleChsChar.ToString().ToUpper())
                                 select entry.Value;
                    if (pinYin.Count() > 0)
                        retValue.AppendFormat("{0} ", pinYin.Single());

                    singleChsChar.Clear();
                }
            }

            return retValue.ToString().Trim();
        }

        #endregion

    }

    public class UnicodeToPinYinMapping
    {

        private static readonly UnicodeToPinYinMapping Instance = new UnicodeToPinYinMapping();

        public static UnicodeToPinYinMapping GetInstance()
        {
            return Instance;
        }

        public IDictionary<string, string> BuildMappingDictionary()
        {
            var dict = new Dictionary<string, string>();
            var resources = GetEmbeddedResourceStream(string.Format("{0}.Resources.UnicodeToPinYinMappingTable.txt", Assembly.GetExecutingAssembly().GetName().Name));
            using (var sr = new StreamReader(resources))
            {
                while (sr.Peek() >= 0)
                {
                    var lineStr = sr.ReadLine();
                    if (lineStr != null && !lineStr.StartsWith("#"))
                    {
                        var unicodePinYin = lineStr.Split(new string[] { " " }, System.StringSplitOptions.None);
                        if (unicodePinYin.Length > 0)
                        {
                            dict.Add(unicodePinYin[0], unicodePinYin[1]);
                        }
                    }
                }
            }

            return dict;
        }

        /// <summary>
        /// Takes the full name of a resource and loads it in to a stream.
        /// </summary>
        /// <param name="resourceName">Assuming an embedded resource is a file
        /// called info.png and is located in a folder called Resources, it
        /// will be compiled in to the assembly with this fully qualified
        /// name: Full.Assembly.Name.Resources.info.png. That is the string
        /// that you should pass to this method.</param>
        /// <returns></returns>
        public static Stream GetEmbeddedResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        /// <summary>
        /// Get the list of all emdedded resources in the assembly.
        /// </summary>
        /// <returns>An array of fully qualified resource names</returns>
        public static string[] GetEmbeddedResourceNames()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }

}
