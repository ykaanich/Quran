using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Quran
{
    static class Program
    {
        public static string NomClasseur = "";
        public static string IdClasseur = "";
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_main());
        }
        public static void ExeciteOrigine(string NomDifference)
        {
            string nomSegment = ExisteDifferenceDansEnsemble(NomDifference );
            if (nomSegment != "")
                throw new Exception("تم استعمال الخلاف في المقطع  :" + nomSegment);
            string nomExclusion = ExisteDifferenceDansExclusion(NomDifference );
            if (nomExclusion != "")
                throw new Exception("تم استعمال الخلاف في امتناع  :" + nomExclusion);
        }

        public static string ExisteDifferenceDansEnsemble(string NomDifference)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Ensemble.xml"); // Load xml file data to xmlDocument
            XmlNode cas = doc.SelectSingleNode("/Ensembles/Ensemble/nomDifference[string='" + NomDifference + "']");
            if (cas == null)
                return "";
            else
                return cas.ParentNode.ChildNodes[2].InnerText;
        }


        public static string ExisteDifferenceDansExclusion(string NomDifference)
        {

            DataSet ds = new DataSet();
            ds.ReadXml("Exclusions.xml", XmlReadMode.InferSchema);
            ds.Tables["DifferenceCas"].DefaultView.RowFilter = "NomDifference = '" + NomDifference + "'";

            if (ds.Tables["DifferenceCas"].DefaultView.ToTable().Rows.Count == 0)
                return "";
            else
                return ds.Tables["DifferenceCas"].DefaultView.ToTable().Rows[1]["nomcas"].ToString();
        }

        public static string ExisteNomCasDansExclusion(string NomCas)
        {

            DataSet ds = new DataSet();
            ds.ReadXml("Exclusions.xml", XmlReadMode.InferSchema);
            ds.Tables["DifferenceCas"].DefaultView.RowFilter = "NomCas = '" + NomCas + "'";

            if (ds.Tables["DifferenceCas"].DefaultView.ToTable().Rows.Count == 0)
                return "";
            else
                return ds.Tables["DifferenceCas"].DefaultView.ToTable().Rows[1]["nomcas"].ToString();
        }
    }
}