using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Xml.Serialization;//for xml serialization

namespace DronaApp
{
    public class AppGlobalVariablesAccess : ContentPage
    {
        public AppGlobalVariablesAccess()
        {
            var assembly = typeof(AppGlobalVariablesAccess).GetTypeInfo().Assembly;

            /*
            //first set the files Build Action to embeded resources
            */

            #region How to load an Json file embedded resource
            //Stream stream = assembly.GetManifestResourceStream("DronaApp.AppGlobalVariablesJson.json");//DronaApp.Views.WorkingWithFiles.Files.AppGlobalVariablesJson.json
            Stream streamJSON = assembly.GetManifestResourceStream("DronaApp.Views.WorkingWithFiles.Files.AppGlobalVariablesJson.json");

            //Colors[] colors;
            List<Colors> colorsJSON;

            if(streamJSON!=null)
            {
                using (var reader = new System.IO.StreamReader(streamJSON))
                {

                    var json = reader.ReadToEnd();
                    var FromJSON = JsonConvert.DeserializeObject<ColorsPCL>(json);

                    colorsJSON = FromJSON.colors;
                }
                Dictionary<string, string> colorsJSONDictionary = new Dictionary<string, string>();
                foreach (var item in colorsJSON)
                {
                    colorsJSONDictionary.Add(item.ColorName, item.ColorValue);
                }
            }
            else
            {
                /*
                //this below line gives all the resource files naems and their path values 
                use this if you get stream = null in assembly.GetmanifestResourceStream 
                path value is very mandatory anf should be exact for assembly.GetManifestResourceStream
                */
                var data = assembly.GetManifestResourceNames();
            }
            #endregion

            #region How to load an XML file embedded resource
            Stream streamXML = assembly.GetManifestResourceStream("DronaApp.Views.WorkingWithFiles.Files.AppGlobalVariablesXML.xml");

            List<Colors> colorsXML;
            if(streamXML != null)
            {
                using (var reader = new System.IO.StreamReader(streamXML)) 
                {
                    var serializer = new XmlSerializer(typeof(List<Colors>));
                    colorsXML = (List<Colors>)serializer.Deserialize(reader);
                }
                Dictionary<string, string> colorsXMLDictionary = new Dictionary<string, string>();
                foreach (var item in colorsXML)
                {
                    colorsXMLDictionary.Add(item.ColorName, item.ColorValue);
                }
            }
            #endregion

            #region How to load a text file embedded resource
            Stream streamText = assembly.GetManifestResourceStream("DronaApp.Views.WorkingWithFiles.Files.PCLTextResource.txt");

            string text = "";
            using (var reader = new System.IO.StreamReader(streamText)) {
                text = reader.ReadToEnd ();
            }
            #endregion

            /*
            #region How to load an Json file embedded resource
            var assembly = typeof(AppGlobalVariablesAccess).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLJsonResource.json");

            //Colors[] colors;
            List<Colors> colors;

            using (var reader = new System.IO.StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                var ColorsJSON = JsonConvert.DeserializeObject<ColorsPCLJSON>(json);

                colors = ColorsJSON.colors;
            }
            Dictionary<string, string> colorDictionary = new Dictionary<string, string>();
            foreach (var item in colors)
            {
                colorDictionary.Add(item.ColorName, item.ColorValue);
            }
            #endregion
            */
        }
    }

    public class ColorsPCL
    {
        //public Colors[] colors { get; set; }
        public List<Colors> colors { get; set; }
    }

    public class Colors
    {
        public string ColorName { get; set; }

        public string ColorValue { get; set; }
    }

}


/*
namespace WorkingWithFiles
{
	/// <summary>
	/// This Monkey class is used to deserialize an XML file and display the resulting data in a list.
	/// </summary>
	/// <remarks>
	/// The code used to load the XML into this class is shown here:
	/// <code><![CDATA[
	/// List<Monkey> monkeys;
	///     using (var reader = new System.IO.StreamReader (stream)) {
	///     var serializer = new XmlSerializer(typeof(List<Monkey>));
	///     monkeys = (List<Monkey>)serializer.Deserialize(reader);
	/// }
	/// ]]></code>
	/// </remarks>
	public class Monkey
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
*/

/*
namespace WorkingWithFiles
{
	public class Earthquake
	{
		public string eqid { get; set; }
		public float magnitude { get; set; }
		public float lng { get; set; }
		public string src { get; set; }
		public string datetime { get; set; }
		public float depth { get; set; }
		public float lat { get; set; }

		public string Summary
		{
			get { return String.Format("Date: {0}, Magnitude: {1}", datetime.Substring(0, 10), magnitude); }
		}

		public override string ToString()
		{
			return String.Format("{0}, {1}, {2}, {3}", lat, lng, magnitude, depth);
		}
	}

	public class Rootobject
	{
		public Earthquake[] earthquakes { get; set; }
	}
}
*/